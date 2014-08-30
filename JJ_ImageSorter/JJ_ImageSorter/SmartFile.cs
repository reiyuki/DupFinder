using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


    public class SmartFile
    {
        //Private Properties
        private byte[] _hash;
        private ulong _hash64;
        private bool _isValidFile;
        private FileInfo _fileInfo;

        public Dictionary<string,Tag> tags;  //Tags are used to upvote/downvote a file

        public string value
        {
            get
            {
                return _fileInfo.Name;
            }
        }

        public int TagRank
        {
            get
            {
                int returnVal = 0;
                foreach (Tag curTag in tags.Values)
                {
                    returnVal = returnVal + curTag.TagValue;
                }
                return returnVal;
            }
        }

        public long FileSize
        {
            get
            {
                return _fileInfo.Length;
            }
        }

        //Public Properties
        public string fileName
        {
            get
            {
                return _fileInfo.Name;
            }
        }
        public string fullFileName
        {
            get
            {
                return _fileInfo.FullName;
            }

        }
        public byte[] hash
        {
            get
            {
                //Compute hash if it hasn't yet
                if (_hash == null) { ComputeHash(); }

                return _hash;
            }
        }
        public UInt64 hash64
        {
            get
            {
                if (_hash64 == 0) { ComputeHash64(); }
                return _hash64;
            }
        }
        public bool isValidFile
        {
            get
            {
                return _isValidFile;
            }
        }
        public FileInfo fileInfo
        {
            get
            {
                return _fileInfo;
            }
        }
        public string hashString
        {
            get
            {
                string returnString = String.Join(string.Empty,Array.ConvertAll(hash,b => b.ToString("X2")));
                // Encoding.UTF8.GetString(this.hash);
                return returnString;
            }
        }
        public string ShortFilename
        {
            get
            {
                if (fileName.Contains("."))  //ignore extensionless filenames
                {
                    string shortFilename = fileName;
                    shortFilename = shortFilename.Substring(0, shortFilename.LastIndexOf('.'));
                    return shortFilename;
                }
                else
                {
                    return fileName;
                }
            }
        }

        //Get the final folder item in the hierarchy
        public string LastFolderName
        {
            get
            {
            string returnName = "";

            string[] elements = fullFileName.Split(Convert.ToChar("\\"));

            returnName = elements[elements.Length - 2];  //return last foldername
            return returnName;
            }
        }

        public string[] GetFolderTree //Add later
        {
            get
            {
                return null;
            }
        }


        //Constructors
        public SmartFile(string fullFilename)
        {
            FileInfo myFileInfo;
            try
            {
                myFileInfo = new FileInfo(fullFilename);
            }
            catch
            {
                return;
            }
            _isValidFile = myFileInfo.Exists;
            if (!_isValidFile) { return; }

            _isValidFile = true;
            _fileInfo = myFileInfo;
            //tags = new List<Tag>();
            tags = new Dictionary<string, Tag>();
        }
        public SmartFile(FileInfo myFileInfo)
        {
            //Basic startup checks
            if (myFileInfo == null) { return; }
            _isValidFile = myFileInfo.Exists;
            if (!_isValidFile) { return; }

            _isValidFile = true;
            _fileInfo = myFileInfo;
            //tags = new List<Tag>();
            tags = new Dictionary<string, Tag>();
        }


        //Fun methods
        public void ComputeHash()
        {
            if (_hash == null)
            {
                //Basic Sha1 hashing of file
                System.Security.Cryptography.SHA1 sha = System.Security.Cryptography.SHA1.Create();

                FileStream fs = _fileInfo.Open(FileMode.Open, FileAccess.Read);
                fs.Position = 0;
                //System.Diagnostics.Debug.WriteLine("Hashing file: " + _fileInfo.Name);
                _hash = sha.ComputeHash(fs);
                fs.Close();

            }
        }
        public void ComputeHash64()
        {
                _hash64 = BitConverter.ToUInt64(this.hash,1);
        }




        public bool IsIdenticalTo(SmartFile otherFile)
        {
            if (Array.Equals(this.hash, otherFile.hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }




