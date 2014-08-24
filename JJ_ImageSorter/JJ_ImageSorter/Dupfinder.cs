using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using System.Diagnostics;

    public class Dupfinder
    {
        public List<string> searchPaths;

        public Dictionary<UInt64, SmartFile> smartFiles;

        public Dictionary<UInt64, List<SmartFile>> duplicates;

    //    SmartFile s = new SmartFile(
        public void StartSearch()
        {
            //Recursively search and add files to temporary list sfl  (smartfilelist)
            string[] filenames = Directory.GetFiles(searchPaths[0], "*", SearchOption.AllDirectories);
            List<SmartFile> sfl = new List<SmartFile>();
            foreach (string s in filenames)
            {
                SmartFile newSmartFile = new SmartFile(s);
                sfl.Add(newSmartFile);
            }


            //Start filling smartFiles dictionary by 64bit hashcode.  On collision, add to duplicates

            for (int i = 0; i <= sfl.Count - 1; i++)
            {
                if (smartFiles.ContainsKey(sfl[i].hash64))
                {
                    //Dupe found !
                    Debug.WriteLine("DUP FOUND:" + sfl[i].fileName);

                    if (duplicates.ContainsKey(sfl[i].hash64) == false)
                    {
                        //Initialize our list if it dosen't exist yet, and add the other first hash
                        duplicates[sfl[i].hash64] = new List<SmartFile>();
                        duplicates[sfl[i].hash64].Add(smartFiles[sfl[i].hash64]);
                    }
                        //Add this file to duplicate list
                        duplicates[sfl[i].hash64].Add(sfl[i]);


                }
                else
                {
                    //No dup found
                    smartFiles.Add(sfl[i].hash64,sfl[i]);
                }
            }
  //          foreach (SmartFile sf in smartFiles.ToArray())
//            {
                //Debug.WriteLine(sf.hashString + "," + sf.fileName );

                //Reorder list
            Debug.WriteLine("test");

//list.OrderBy(b => BitConverter.ToInt64(b, 0))

        }

        private void DupFound()
        {
        }


        public Dupfinder()
        {
            
            searchPaths = new List<string>();

            smartFiles = new Dictionary<UInt64,SmartFile>();

            duplicates = new Dictionary<ulong,List<SmartFile>>();
            //smartFiles = new List<SmartFile>();
            //smartFiles.OrderBy(b => BitConverter.ToInt64(b.hash,0));
            //smartFiles.
            
        }


    }




    

