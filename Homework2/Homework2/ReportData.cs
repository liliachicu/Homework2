using System.Collections.Generic;
using System.Linq;

namespace Homework2
{
    public class ReportData
    {
        public InputParser Transposing { get; set; }
        public ReportData(InputParser transposing)
        {
            Transposing = transposing;
        }
        public List<IReportModel> GenerateReport(string input)
        {
            Transposing.Parse(input);
            var employeeReport = Transposing.Model.Employees;
            var paymentReport = Transposing.Model.Payments;
            var resultOfPaymens = paymentReport.Values.SelectMany(x => x.Select(y => y));
            var joinQuery =
            from e in employeeReport
            join p in resultOfPaymens on e.Id equals p.IDEmployee
            select new
            {
                e.Id,
                e.FirstName,
                e.LastName,
                p.Amount,
                p.Date
            };
            var reportData = new List<IReportModel>();
            var trimesterGroup = joinQuery.GroupBy(o => o.Date.Year).OrderBy(g => g.Key)
                                 .Select(g => new { Year = g.Key, Trimester = g.GroupBy(o => Trimester.GetQuarter(o.Date)).OrderBy(o => o.Key) });
                                     
            foreach (var item in trimesterGroup)
            {
                foreach (var trimester in item.Trimester)
                {
                    reportData.Add(new ReportGenerator
                    {
                        Year = item.Year,
                        Trimester = trimester.Key,
                        Average = trimester.Average(o => o.Amount)
                    });
                }
            }
            return reportData;
        }

    }
}