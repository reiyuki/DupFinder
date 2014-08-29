using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class AutoRankRule_IsACopy : AutoRankRule
{
    public override string RuleName { get { return "IsACopy"; } }
    public override string RuleDescription { get { return "Determine if file has any copied names in it"; } }

    //tweakables
    private static int modifier_IsACopy = -1;
    private static int modifier_NotACopy = 0;

    //Parse file and add necessary tag(s)
    public override void UpdateTag(SmartFile sf)
    {
        //if (sf.fileName.Contains(" - Copy"))
        if (sf.fileName.ToLower().Contains("copy"))
        {
            sf.tags[RuleName] = new Tag(RuleResult, "'Copy' Filename",modifier_IsACopy);
            return;
        }


        return;


    }

}
// - Copy