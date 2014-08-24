using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class DupFinderTests
    {
        [TestMethod]
        public void PerformanceTest1()
        {
            Dupfinder dup = new Dupfinder();

            dup.searchPaths.Add("C:\\inc\\0614");
            dup.StartSearch();


        }
    }
}
