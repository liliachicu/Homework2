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

        }

       public class DataTransposing
        {
            public void Transpose(string input)
            {
                var records = input.Split(';');
                var employees = new List<Employee>();
                var payments = new Dictionary<int, ICollection<Payment>>();
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
                    payments[employeeId].Add(new Payment(Decimal.Parse(data[3]), DateTime.Parse(data[4])));
                }
            }
        }
    }
}