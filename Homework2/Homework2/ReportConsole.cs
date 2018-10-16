using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2
{
    public class ReportConsole : IReport
    {
        public int Year { get; set; }
        public int Trimester { get; set; }
        public decimal Average { get; set; }

        public bool Equals(IReport other)
        {
            return Year == other.Year && Trimester == other.Trimester && Average == other.Average;
        }

        public void PrintReport(List<IReport> reportData)
        {
            foreach (var item in reportData)
            {
                Console.WriteLine(item.Year);
                Console.WriteLine($"Trimester {item.Trimester}: {String.Format("{0:0.000}",item.Average)}");
            }
        }
    }
}
