using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


    class AutoRankRule_Folders : AutoRankRule
    {
        public override string RuleName { get { return "FolderRules"; } }
        public override string RuleDescription { get { return "Check for foldername matches"; } }

        private static int modifier_UnsortedFolder = -3;
        private static int modifier_UnsortedSubFolder = -2;
        private static int modifier_KeepFolder = 2;

        public override void UpdateTag(SmartFile sf)
        {
            if (InAKeepFolder(sf))
            {
                sf.tags[RuleName] = new Tag(RuleName, "In a Keeper folder", modifier_KeepFolder);
            }

            if (InUnsortedFolder(sf))
            {
                sf.tags[RuleName] = new Tag(RuleName, "In Unsorted Folder", modifier_UnsortedFolder);
            }

            if (InUnsortedSubFolder(sf))
            {
                sf.tags[RuleName] = new Tag(RuleName, "In Unsorted Subfolder", modifier_UnsortedSubFolder);
            }

        }


        private bool InUnsortedFolder(SmartFile sf)
        {
            if (sf.LastFolderName.ToLower().Contains("unsort"))
            {
                return true;
            }

            return false;
        }

        private bool InUnsortedSubFolder(SmartFile sf)
        {
            if (sf.fullFileName.ToLower().Contains("unsort"))
            {
                return true;
            }

            return false;
        }

        private bool InAKeepFolder(SmartFile sf)
        {
            if (sf.LastFolderName.StartsWith("1"))
            {
                return true;
            }
            return false;
        }

    }
