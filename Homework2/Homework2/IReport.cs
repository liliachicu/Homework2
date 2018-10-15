using System.Collections.Generic;

namespace Homework2
{
    public interface IReport
    {
        decimal Average { get; set; }
        int Trimester { get; set; }
        int Year { get; set; }

        void PrintReport(List<IReport> reportData);
    }
}