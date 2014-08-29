using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

//Add rankings based on readability of the filename
public class AutoRankRule_FilenameReadability : AutoRankRule
{
    public override string RuleName { get { return "FilenameReadability"; } }
    public override string RuleDescription { get { return "Not finished.  Rank items up/down depending on how readable the filename is."; } }

    //tweakables
    private static int legibleFilenameModifier = 2;
    private static int probablyLegibleFilenameModifier = 1;
    private static int unknownFilenameModifier = 0;
    private static int unreadableFilenameModifier = -2;     //No alphabet characters


    //Parse file and add necessary tag(s)
    public override void UpdateTag(SmartFile sf)
    {

        //Any alphabet characters?
        if (UnreadableFilename(sf))
        {
            sf.tags[RuleName] = null;  //Kill old tag first
            sf.tags[RuleName] = new Tag(RuleName, "Unreadable Filename", unreadableFilenameModifier);
            return;
        }

        //Probably human readable?
        if (ProbablyLegible(sf))
        {
            sf.tags[RuleName] = null;
            sf.tags[RuleName] = new Tag(RuleName, "Probably Legible Filename", probablyLegibleFilenameModifier);
            return;
        }

        //Unknown
        sf.tags[RuleName] = null;
        sf.tags[RuleName] = new Tag(RuleName, "Unkown Filename Type", unknownFilenameModifier);


    }



    //Returns true if there are no readable characters.  (\w)
    private bool UnreadableFilename(SmartFile sf)
    {
        Match m = Regex.Match(sf.ShortFilename, "(\\w+)");
        return !m.Success;
    }


    //Check ratio of vowels to letters (confirm a file is *probably* human readable
    private bool ProbablyLegible(SmartFile sf)
    {
        //Require at least 1 character after f (rules out Hexidecimal naming)
        Match m = Regex.Match(sf.ShortFilename, "([g-zG-Z+])");
        if (m.Success == false) { return false; }


        //Vowel range between x and y
        int vowelCount = CountVowels(sf.ShortFilename);
        int letterCount = CountLetters(sf.ShortFilename);

        double vowelRatio = (double)vowelCount / ((double)letterCount + vowelCount);
        if ((vowelRatio >= 0.24f) && (vowelRatio <= 0.62f))
        {
            return true;
        }
        else
        {
            return false;
        }

    }


    private int CountVowels(string value)
    {
        const string vowels = "aeiouy";
        return value.Count(chr => vowels.Contains(char.ToLowerInvariant(chr)));
    }
    private int CountNumbers(string value)
    {
        const string vowels = "0123456789";
        return value.Count(chr => vowels.Contains(char.ToLowerInvariant(chr)));
    }
    private int CountLetters(string value)
    {
        const string vowels = "bcdfghjklmnpqrstvwxz";
        return value.Count(chr => vowels.Contains(char.ToLowerInvariant(chr)));
    }




}
