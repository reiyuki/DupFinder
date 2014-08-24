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
        private string _name;
        private int _value;


        //Pub Properties
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public int Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }

        //Constructors
        public Tag(string name, int value)
        {
            _name = name;
            _value = value;
        }

        //Others
        public override string ToString()
        {
            return _name + "," + _value.ToString();
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
