using System.Collections.Generic;

namespace Homework2
{
    public interface IReport
    {
        decimal Average { get; set; }
        int Trimester { get; set; }
        int Year { get; set; }

        void PrintConsoleReport(List<IReport> reportData);
    }
}