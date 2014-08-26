using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JJ_ImageSorter;

namespace UnitTests
{
    [TestClass]
    public class DupFinderTests
    {
        [TestMethod]
        public void PerformanceTestNew()
        {
            
            DupFinder dup = new DupFinder();

            //dup.AddSearchPath("C:\\inc\\0614");
            dup.AddSearchPath("I:\\LSort\\abubu");
            dup.StartSearch();


            

        }

        [TestMethod]
        public void PerformanceTestOld()
        {
            Dupfinder_old dup = new Dupfinder_old();

            //dup.searchPaths.Add("C:\\inc\\0614");
            dup.searchPaths.Add("I:\\LSort\\abubu");
            dup.StartSearch();

        }
    }
}
