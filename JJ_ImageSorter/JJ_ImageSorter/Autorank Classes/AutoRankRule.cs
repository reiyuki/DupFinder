//
//      AutoRankRule   -- Prototype abstract class used by actual AutoRankRules.
//


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Autorank ruleset prototype
public abstract class AutoRankRule
{
    public abstract string RuleName { get; }   //No spaces in name, please
    public abstract string RuleDescription { get; }

    protected string ruleResult;
    public string RuleResult { get { return ruleResult; } }

    //public abstract int GetRank(SmartFile sf);
    public abstract void UpdateTag(SmartFile sf);
}