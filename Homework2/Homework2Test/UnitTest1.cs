using System.Collections.Generic;
using FluentAssertions;
using Homework2;
using NUnit.Framework;

//namespace Homework2Test
//{
//    [TestFixture]
//    public class UnitTest1
//    {
//        [Test]
//        public void GenerateReport_Should_Return_Report()
//        {
//            var report = new ReportGenerator();
//            var actual = report.GenerateReport("1 Lilia Chicu 5000 10/10/2018;2 Dorin Mocan 4500 09/10/2018;3 Eugen Stratulat 5005 09/01/2017;4 Dorina Dumbrava 6000 08/09/2017");

//            actual.Should().NotBeNull();
//        }

//        [Test]
//        public void GenerateReport_Should_Return_Records()
//        {
//            var report = new ReportGenerator();
//            var actual = report.GenerateReport("1 Lilia Chicu 5000 10/10/2018;2 Dorin Mocan 4500 09/10/2018;3 Eugen Stratulat 5005 09/01/2017;4 Dorina Dumbrava 6000 08/09/2017");

//            actual.Should().NotBeEmpty();
//        }

//        [Test]
//        public void GenerateReport_Should_Return_Valid_Records()
//        {
//            var report = new ReportGenerator();
//            var actual = report.GenerateReport("1 Lilia Chicu 5000 10/10/2018;2 Dorin Mocan 4500 09/10/2018;3 Eugen Stratulat 5005 09/01/2017;4 Dorina Dumbrava 6000 08/09/2017");

//            actual.Should().Contain(r => r.Year == 2017 && r.Trimester == 3 && r.Average == 5502.5M);
//        }

//        [Test]
//        public void GenerateReport_Should_Return_Contain_Record()
//        {
//            var report = new ReportGenerator();
//            var actual = report.GenerateReport("1 Lilia Chicu 5000 10/10/2018;2 Dorin Mocan 4500 09/10/2018;3 Eugen Stratulat 5005 09/01/2017;4 Dorina Dumbrava 6000 08/09/2017");
//            var expected = new ReportConsole
//            {
//                Average = 5502.5M,
//                Year = 2017,
//                Trimester = 3
//            };
//            actual.Should().Contain(expected);
//        }
//    }
//}
