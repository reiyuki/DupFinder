//
//      AutoRank - Adds 'Tag' objects to SmartFile's dictionary.  Total tagged value determines how 'useful' each duplicate is
//


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

public class AutoRank
{
    private List<AutoRankRule> rules;


    //Constructor
    public AutoRank()
    {
        rules = new List<AutoRankRule>();

        //Add all our rulesets
        rules.Add(new AutoRankRule_FilenameReadability());
        rules.Add(new AutoRankRule_IsACopy());
    }

    
    public void UpdateTags(SmartFile sf)
    {

        foreach (AutoRankRule rule in rules)
        {
            rule.UpdateTag(sf);
        }

    }
    


    
}







