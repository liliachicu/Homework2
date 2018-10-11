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
            var tralalala = joinQuery.GroupBy(o => o.Date.Year).OrderBy(g => g.Key)
                                     .Select(g => new { Year = g.Key, Month = g.GroupBy(o => o.Date.Month).OrderBy(o => o.Key) })
                                     .Select(g => new { });
        }
        public static int GetQuarter(DateTime date)
        {
            if (date.Month >= 4 && date.Month <= 6)
                return 1;
            else if (date.Month >= 7 && date.Month <= 9)
                return 2;
            else if (date.Month >= 10 && date.Month <= 12)
                return 3;
            else
                return 4;
        }

        public class DataTransposing
        {
            public List<Employee> employees = new List<Employee>();
            public Dictionary<int, ICollection<Payment>> payments = new Dictionary<int, ICollection<Payment>>();
            public void Transpose(string input)
            {
                var records = input.Split(';');
                foreach (var record in records)
                {
                    var data = record.Split(' ');
                    var employeeId = int.Parse(data[0]);

                    if (!employees.Any(e => e.Id == employeeId))
                    {
                        var employee = new Employee(int.Parse(data[0]), data[1], data[2]);
                        employees.Add(employee);
                    }

                    if (!payments.ContainsKey(employeeId))
                    {
                        payments[employeeId] = new List<Payment>();
                    }

                    payments[employeeId].Add(new Payment(employeeId, Decimal.Parse(data[3]), DateTime.Parse(data[4])));
                }
            }
        }
    }
}