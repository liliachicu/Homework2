using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2
{
    partial class Program
    {
        static void Main(string[] args)
        {
            var consoleReader = new ConsoleReader();
            var fileReader = new FileValueReader();
            var transposing = new DataTransposing();
            var report = new Report();

            string input = string.Empty;

            if (args.Length == 0)
            {
                Console.WriteLine("Insert your data:");
                consoleReader.Read();
                input = consoleReader.GetInput();
            }
            else
            {
                switch (args.First())
                {
                    case "I":
                        //var length = args.Length - 1;
                        //var values = new string[length];
                        //Array.Copy(args, 1, values, 0, args.Length - 1);
                        input = args[1].Trim(new char[] { '"' });
                        //string.Join(" ", values);
                        break;

                    case "F":
                        fileReader.ReadFile(@"C:\Projects L\Project 1\Homework2\Homework2\file.txt");
                        input = fileReader.GetInput();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException(nameof(args), "Unknown source flag");
                }
            }
            
            transposing.Transpose(input);
            var employeeReport = transposing.employees;
            var paymentReport = transposing.payments;
            var resultOfPaymens= paymentReport.Values.SelectMany(x => x.Select(y => y));
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
            var reportData = new List<Report>();
            var trimesterGroup = joinQuery.GroupBy(o => o.Date.Year).OrderBy(g => g.Key)
                                     .Select(g => new { Year = g.Key, Trimester = g.GroupBy(o => Trimester.GetQuarter(o.Date)).OrderBy(o => o.Key) });
                                     
            foreach (var item in trimesterGroup)
            {
                foreach (var trimester in item.Trimester)
                {
                    reportData.Add(new Report
                    {
                        Year = item.Year,
                        Trimester = trimester.Key,
                        Average = trimester.Average(o => o.Amount)
                    });
                }
            }
            report.PrintConsoleReport(reportData);
            Console.ReadKey();
            
        }
    }
}