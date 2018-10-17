using System;
using System.Collections.Generic;

namespace Homework2
{
    public interface IReport: IEquatable<IReport>
    {
        void PrintReport(List<IReportModel> reportData);
    }
}