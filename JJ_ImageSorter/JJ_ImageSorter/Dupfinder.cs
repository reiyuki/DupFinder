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
	


    //Events and Delegates
    public event StateHandler StatusChanged;
    public delegate void StateHandler(string state);
    event FileInfoHandler DuplicateFileFound;
    public delegate void FileInfoHandler(SmartFile smartFile);


    //Thread Stuff
    Thread workerThread;


    //Same as below, but through a worker thread
    public void StartSearch_Async()
    {
        workerThread = new Thread(new ThreadStart(this.StartSearch));
        workerThread.Start();
        OnStatusChanged("Started Search");
    }

	// Iterate through 
	public void StartSearch()
	{
        OnStatusChanged("Hi there");
		//Initialize master list of files (organized by filesize)
		fileSizeList = new Dictionary<long,List<SmartFile>>();
		
		//Discover files in each path (adds to master list fileSizeList)
		foreach (string curSearchPath in pathsToSearch)
		{
			DiscoverFiles(curSearchPath);
		}

		
        //Run through list to find actual duplicates
        for ( int i = 0; i < fileSizeList.Count; i++)
        {

            CompareHashesAndAddDuplicates(fileSizeList.ElementAt(i).Value);
        }

	}
	
	//Discover files and add to fileSizeList dictionary.   THREAD BLOCKING
	private void DiscoverFiles(string pathName)
	{
		// FileInfo and parsing etc

        string[] filenames = Directory.GetFiles(pathName, "*", SearchOption.AllDirectories);
        foreach (string curFile in filenames)
        {
            SmartFile newSmartFile = new SmartFile(curFile);

            //Add the list if it dosen't exist already
            if (!fileSizeList.ContainsKey(newSmartFile.FileSize))
            {
                fileSizeList.Add(newSmartFile.FileSize,new List<SmartFile>());
            }


            fileSizeList[newSmartFile.FileSize].Add(newSmartFile);

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
			}
		
            //Autotag
            AutoRank ar = new AutoRank();
            ar.UpdateTags(newFile);
		}



        //Constructor
        public DupFinder()
        {
            fileSizeList = new Dictionary<long, List<SmartFile>>();
            duplicateFiles = new Dictionary<ulong, List<SmartFile>>();
            pathsToSearch = new List<string>();
        }



        //Events
        private void OnStatusChanged(string newState)
        {
            if (StatusChanged != null)
            {
                StatusChanged(newState);
            }
        }


	
	}
