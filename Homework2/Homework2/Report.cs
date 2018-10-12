using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2
{
    public class Report
    {
        public int Year { get; set; }
        public int Trimester { get; set; }
        public decimal Average { get; set; }
        public void PrintConsoleReport(List<Report> reportData)
        {
            foreach (var item in reportData)
            {
                Console.WriteLine(item.Year);
                Console.WriteLine($"Trimester {item.Trimester}: {item.Average}");
            }
        }
    }
}
