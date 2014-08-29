using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Text.RegularExpressions;

namespace UnitTests
{
    [TestClass]
    public class AutoRankTests
    {
        [TestMethod]
        public void Autorank_Legibility()
        {
            AutoRankRule_FilenameReadability autoRankRuler = new AutoRankRule_FilenameReadability();
            
            SmartFile newFile = new SmartFile("C:\\inc\\Riftchan_Notes032714.txt");

            autoRankRuler.UpdateTag(newFile);


        }


        [TestMethod]
        public void Autorank_VowelTest()
        {
            AutoRankRule_FilenameReadability autoRankRuler = new AutoRankRule_FilenameReadability();


            string[] filenames = Directory.GetFiles("C:\\inc", "*", SearchOption.AllDirectories);
            foreach (string curFile in filenames)
            {
                SmartFile newSmartFile = new SmartFile(curFile);
                autoRankRuler.UpdateTag(newSmartFile);
            }








            




        }



    }
}
