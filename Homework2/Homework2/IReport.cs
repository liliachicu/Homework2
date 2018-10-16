using System;
using System.Collections.Generic;

namespace Homework2
{
    public interface IReport: IEquatable<IReport>
    {
        decimal Average { get; set; }
        int Trimester { get; set; }
        int Year { get; set; }

        void PrintReport(List<IReport> reportData);
    }
}