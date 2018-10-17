using System;
using System.Collections.Generic;
using System.IO;

namespace Homework2
{
    public delegate void reportSync(List<IReportModel> reportData);
    public class ReportGenerator : IReport, IReportModel
    {
        public event reportSync reportShow;
        public decimal Average { get; set; }
        public int Trimester { get; set; }
        public int Year { get; set; }

        public bool Equals(IReportModel other)
        {
            return Year == other.Year && Trimester == other.Trimester && Average == other.Average;
        }

 
        public void PrintConsole(List<IReportModel> reportData)
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
        public void PrintFile(List<IReportModel> reportData)
        {
            foreach (var item in reportData)
            {
                Console.WriteLine(item.Year);
                Console.WriteLine($"Trimester {item.Trimester}: {String.Format("{0:0.000}", item.Average)}");
            }
        }
        public void InvokeEvent(List<IReportModel> reportData)
        {
            reportShow(reportData);
        }
    }
}