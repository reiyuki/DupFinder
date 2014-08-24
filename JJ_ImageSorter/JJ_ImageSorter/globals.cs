using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;



    class globals
    {
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



    public enum troolean { False = 0, True = 1, Unknown = 2 }  //A 3 factor boolean
