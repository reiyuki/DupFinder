using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;



    public class globals
    {
        public static System.Drawing.Point GetCenterPoint(System.Windows.Forms.Form form)
        {
            int centerX = form.DesktopLocation.X + (int)(form.Width * 0.5);
            int centerY = form.DesktopLocation.Y + (int)(form.Height * 0.5);
            return new System.Drawing.Point(centerX,centerY);
        }

        public static void SetCenterPoint(System.Windows.Forms.Form form, System.Drawing.Point centerPoint)
        {
            form.DesktopLocation = new System.Drawing.Point(centerPoint.X - (int)(form.Width * 0.5),centerPoint.Y - (int)(form.Height * 0.5));
            //form.DesktopLocation.x = (centerPoint.X - (int)(form.Width * 0.5));

            //System.Drawing.Point tmpPoint = GetCenterPoint(form);
            
            //form.DesktopLocation = new System.Drawing.Point(
        }


    }


    public class Tag
    {
        private string ruleName;
        public string RuleName { get { return ruleName; } }

        private int tagValue;
        public int TagValue { get { return tagValue; } }

        private string ruleResult;
        public string RuleResult { get { return ruleResult; } }


        //Constructors
        public Tag(string myRuleName, string myRuleResult, int value)
        {
            ruleName = myRuleName;
            ruleResult = myRuleResult;
            tagValue = value;
        }

        //Others
        public override string ToString()
        {
            return ruleName + "," + ruleResult + "," + tagValue.ToString();
            //return base.ToString();
        }
    }








    public class DupFileEvent : EventArgs
    {
        public SmartFile smartFile { get; private set; }

        public DupFileEvent(SmartFile s)
        {
            smartFile = s;
        }
        public DupFileEvent()
        {
        }

    }




    //public enum TagType
//    { 



    public enum troolean { False = 0, True = 1, Unknown = 2 }  //A 3 factor boolean
