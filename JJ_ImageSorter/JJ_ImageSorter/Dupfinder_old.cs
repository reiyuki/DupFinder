using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using System.Diagnostics;

    public class Dupfinder_old
    {
        //Paths to list in our search
        public List<string> searchPaths;

        private Dictionary<UInt64, SmartFile> smartFiles;

        public Dictionary<UInt64, List<SmartFile>> duplicates;



        public bool isSearching { get; private set; }
        public string Status { get; private set; }

        public event EventHandler StatusChanged;



        public delegate void DupFileHandler(DupFileEvent d);
        public event DupFileHandler DuplicateFileFound = delegate { };


        private List<SmartFile> GetAllFilesInfolders(string[] searchPaths)
        {
            List<SmartFile> sfl = new List<SmartFile>();

            foreach (string curPath in searchPaths)
            {
                string[] filenames = Directory.GetFiles(curPath, "*", SearchOption.AllDirectories);

                foreach (string curFile in filenames)
                {
                    SmartFile newSmartFile = new SmartFile(curFile);
                    sfl.Add(newSmartFile);
                }
            }
            return sfl;
        }



    //    SmartFile s = new SmartFile(
        public void StartSearch()
        {
            isSearching = true;
            //Status = "Searching"; StatusChanged(this,new EventArgs());
            //Recursively search and add files to temporary list sfl  (smartfilelist)
            

            List<SmartFile> sfl = GetAllFilesInfolders(searchPaths.ToArray());



            //Start filling smartFiles dictionary by 64bit hashcode.  On collision, add to duplicates
            //Status = "Hashing";
            for (int i = 0; i <= sfl.Count - 1; i++)
            {
                if (smartFiles.ContainsKey(sfl[i].hash64))
                {
                    //Dupe found !
                    //Debug.WriteLine("DUP FOUND:" + sfl[i].fileName);

                    if (duplicates.ContainsKey(sfl[i].hash64) == false)
                    {
                        //Initialize our list if it dosen't exist yet, and add the other first hash
                        duplicates[sfl[i].hash64] = new List<SmartFile>();
                        duplicates[sfl[i].hash64].Add(smartFiles[sfl[i].hash64]);
                        
                        //Raise an event
                        DuplicateFileFound(new DupFileEvent(smartFiles[sfl[i].hash64]));
                        

                    }
                        //Add this file to duplicate list
                        duplicates[sfl[i].hash64].Add(sfl[i]);

                        //Raise an event
                        DuplicateFileFound(new DupFileEvent(sfl[i]));

                }
                else
                {
                    //No dup found
                    smartFiles.Add(sfl[i].hash64,sfl[i]);
                }
            }

            //Finish events
            //Status = "Done"; isSearching = false; StatusChanged(this, new EventArgs());
            
        }


        //Constructor
        public Dupfinder_old()
        {
            //Init all the dictionaries and lists
            searchPaths = new List<string>();
            smartFiles = new Dictionary<UInt64,SmartFile>();
            duplicates = new Dictionary<ulong,List<SmartFile>>();

            //Status = "Initialized";
        }


    }






    

