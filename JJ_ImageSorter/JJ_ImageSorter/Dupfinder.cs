using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;
using System.IO;
using System.Diagnostics;

public class DupFinder
{
	//List of all files, keyed by filesize
	private Dictionary<long,List<SmartFile>> fileSizeList;

	//List of all duplicates, hash as key
	private Dictionary<ulong,List<SmartFile>> duplicateFiles;
    public Dictionary<ulong, List<SmartFile>> DuplicateFiles
    {
        get
        {
            return duplicateFiles;
        }
    }

    //pathsToSearch   (no \ at the end)
	private List<string> pathsToSearch;	
	public void AddSearchPath(string newSearchPath)
	{
        //Remove any trailing \'es
        if (newSearchPath.EndsWith("\\")) { newSearchPath = newSearchPath.TrimEnd("\\".ToCharArray()); }

		pathsToSearch.Add(newSearchPath);
	}
	public void DelSearchPath(string oldSearchPath)
	{
        //Remove any trailing \'es
        if (oldSearchPath.EndsWith("\\")) { oldSearchPath = oldSearchPath.TrimEnd("\\".ToCharArray()); }

		pathsToSearch.Remove(oldSearchPath);
	}	
	public List<string> GetSearchPaths()
	{
		return pathsToSearch;
	}
	
    //Status checking
    private SearchState state;
    public SearchState State
    {
        get
        {
            return state;
        }
        private set
        {
            if (state != value)
            {
                //change and throw event
                OnStateChanged(value);
                state = value;
            }
        }
    }


    //Thread Stuff
    Thread workerThread;


    //Same as below, but through a worker thread
    public void StartSearch_Async()
    {
        if (workerThread == null)
        {
            workerThread = new Thread(new ThreadStart(this.StartSearch));

            workerThread.Start();
            OnStatusChanged("Started Search");
        }
        else
        {
            Reset();
            StartSearch_Async();
        }

    }

	// Iterate through 
	public void StartSearch()
	{
        OnStatusChanged("Hi there");
        State = SearchState.Discovering_Files;

		//Initialize master list of files (organized by filesize)
		fileSizeList = new Dictionary<long,List<SmartFile>>();
		
		//Discover files in each path (adds to master list fileSizeList)
		foreach (string curSearchPath in pathsToSearch)
		{
			DiscoverFiles(curSearchPath);
		}

		
        //Run through list to find actual duplicates
        State = SearchState.Comparing_Files;

        for ( int i = 0; i < fileSizeList.Count; i++)
        {
            double progressPercent = (double) i / (double) fileSizeList.Count;
            OnProgressChanged(100f * progressPercent, fileSizeList.ElementAt(i).Value[0].fileName, state); //Report Progress

            CompareHashesAndAddDuplicates(fileSizeList.ElementAt(i).Value);
        }

        //Finish
        State = SearchState.Idle;
        OnProgressChanged(100, "FINISHED", state);
        OnScanFinished();
	}
	

	//Discover files and add to fileSizeList dictionary.   THREAD BLOCKING
	private void DiscoverFiles(string pathName)
	{
		// FileInfo and parsing etc
        
        string[] filenames = Directory.GetFiles(pathName, "*", SearchOption.AllDirectories);
        foreach (string curFile in filenames)
        {
            //Ignore all bittorrent sync folder items
            if (curFile.Contains("\\.SyncArchive\\")) { continue;}

            //Generate Smartfile and do fun stuff with it
            SmartFile newSmartFile = new SmartFile(curFile);

            //Add the list if it dosen't exist already
            if (!fileSizeList.ContainsKey(newSmartFile.FileSize))
            {
                fileSizeList.Add(newSmartFile.FileSize,new List<SmartFile>());
            }


            fileSizeList[newSmartFile.FileSize].Add(newSmartFile);

            OnProgressChanged(0, filenames.Length.ToString() + " files acquired", state);
        }

	}

	
	//Check a list of files and auto-add to 'Duplicates' whatever is found to be duplicate 
    private void CompareHashesAndAddDuplicates(List<SmartFile> fileList)
    {
        //Only check hashes on files with duplicate sizes
        if (fileList.Count == 1)
        {
            return;
        }

        //create temp dictionary like before
        Dictionary<ulong, SmartFile> tmpHashLookup = new Dictionary<ulong, SmartFile>();

        //
        foreach (SmartFile curFile in fileList)
        {

            if (tmpHashLookup.ContainsKey(curFile.hash64))
            {
                //
                TryAddDuplicate(tmpHashLookup[curFile.hash64]); //try add hashtable item
                TryAddDuplicate(curFile);
            }
            else
            {
                tmpHashLookup.Add(curFile.hash64, curFile);
            }
        }
    }

	//Attempt to add a file to our master 'duplicates' list.
	private void TryAddDuplicate(SmartFile newFile)
		{
			List<SmartFile> dupeList;
		
			//If hash exists open dictionary, if not create a new entry
			if (duplicateFiles.ContainsKey(newFile.hash64))
			{
				dupeList = duplicateFiles[newFile.hash64];
			}
			else
			{
				dupeList = new List<SmartFile>();  //create new list
				duplicateFiles.Add(newFile.hash64,dupeList); //add list to master dupe dictionary
			}

			//Add the duplicate file if it doesn't already exist
			if (!dupeList.Contains(newFile))
			{
				dupeList.Add(newFile);

                //Autotag/autorank
                AutoRank ar = new AutoRank();
                ar.UpdateTags(newFile);

                OnDuplicateFileFound(newFile);
			}
		}



    //Constructor
    public DupFinder()
    {
        Reset();  //Also used to initialize
    }


    //Initialize/reset
    public void Reset()
    {
        if (workerThread != null) { workerThread = null; }

        fileSizeList = null;
        fileSizeList = new Dictionary<long, List<SmartFile>>();

        duplicateFiles = null;
        duplicateFiles = new Dictionary<ulong, List<SmartFile>>();

        pathsToSearch = null;
        pathsToSearch = new List<string>();


        State = SearchState.Idle;

    }


        //Events and delegates

    //Status Changed (text message)
    public event StringHandler StatusChanged;
    public delegate void StringHandler(string myText);
    private void OnStatusChanged(string newState)
        {
            if (StatusChanged != null)
            {
                StatusChanged(newState);
            }
        }

    //State Changed
    public event StateHandler StateChanged;
    public delegate void StateHandler(SearchState state);
    private void OnStateChanged(SearchState newState)
    {
        if (StateChanged != null)
        {
            StateChanged(newState);
        }
    }

    //DuplicateFileFound
    public event SmartFileEventHandler DuplicateFileFound;
    public delegate void SmartFileEventHandler(SmartFile sf);
    private void OnDuplicateFileFound(SmartFile sf)
    {
        if (DuplicateFileFound != null)
        {
            DuplicateFileFound(sf);
        }
    }

    //Progress Changed
    public event ProgressEventHandler ProgressChanged;
    public delegate void ProgressEventHandler(double progressPercent, string progressDescription, SearchState state);
    private void OnProgressChanged(double progressPercent, string progressDescription, SearchState state)
    {
        if (ProgressChanged != null)
        {
            ProgressChanged(progressPercent, progressDescription, state);
        }
    }

    //Scan Finished
    public event EventHandler ScanFinished;
    private void OnScanFinished()
    {
        if (ScanFinished != null)
        {
            ScanFinished(this,null);
        }
    }

    

    //Local Enum for Search State
    public enum SearchState {Unknown = 0, Idle = 1, Discovering_Files = 2, Comparing_Files= 3, Error = 4};
	
}
