using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace pruf
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            int[] arr = { 1, 1, 3, 3, 5, 3, 7 };

            int[][] arr2 = new int[arr.Length][];

            List<int> list = new List<int>(arr);
            PrufCode a = new PrufCode(arr2);
            Assert.AreEqual(a, list);
        }
    }
}
