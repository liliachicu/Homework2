﻿using System;
using Homework2;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Homework2Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var report = new ReportGenerator();
            var actual = report.GenerateReport("1 Lilia Chicu 5000 10/10/2018;2 Dorin Mocan 4500 09/10/2018;3 Eugen Stratulat 5005 09/01/2017;4 Dorina Dumbrava 6000 08/09/2017");
            
       
        }
    }
}
