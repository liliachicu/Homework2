using System.Collections.Generic;
using System.IO;

namespace Homework2
{
    public class ReportFile : IReport
    {
        public decimal Average { get; set; }
        public int Trimester { get; set; }
        public int Year { get; set; }

        public bool Equals(IReport other)
        {
            return Year == other.Year && Trimester == other.Trimester && Average == other.Average;
        }

        public void PrintReport(List<IReport> reportData)
        {
            using (StreamWriter writer = new StreamWriter(@"C:\Projects L\Project 1\Homework2\Homework2\report.txt"))
            {
                foreach (var item in reportData)
                {
                    writer.WriteLine($"{item.Year}");
                    writer.WriteLine($"Trimester {item.Trimester}: {item.Average}");
                }
            }
        }
    }
}