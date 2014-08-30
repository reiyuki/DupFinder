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

        public override void UpdateTag(SmartFile sf)
        {
        }

    }
