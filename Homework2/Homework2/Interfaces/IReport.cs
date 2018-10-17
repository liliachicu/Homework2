using System;
using System.Collections.Generic;

namespace Homework2
{
    public interface IReport: IEquatable<IReportModel>
    {
        void PrintConsole(List<IReportModel> reportData);
        void PrintFile(List<IReportModel> reportData);
    }
}
