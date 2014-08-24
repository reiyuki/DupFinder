using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Diagnostics;

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SmartFileTests()
        {


            //Create a test file
            string tmpFile = System.IO.Path.GetTempFileName();
            StreamWriter sw = File.AppendText(tmpFile);
            sw.WriteLine("Testing, over the river and through the woods");
            sw.Close();

            SmartFile s = new SmartFile(tmpFile);
            Assert.IsTrue(s.isValidFile,"Bad File Condition");


            Debug.WriteLine(s.hashString);


            string tmpFile2 = System.IO.Path.GetTempFileName();
            StreamWriter sw2 = File.AppendText(tmpFile2);
            sw2.WriteLine("Testing, over the river and through the woods");
            sw2.Close();

            SmartFile s2 = new SmartFile(tmpFile2);
            Assert.IsTrue(s2.isValidFile, "Bad File Condition");

            Debug.WriteLine(s2.hashString);




            //File.AppendText("Testing, over the river and through the woods");

            //Assert.IsTrue(
            //
            File.Delete(tmpFile2);
            File.Delete(tmpFile);
            
        }


        

    }

