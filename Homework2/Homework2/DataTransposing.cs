using System;
using System.Collections.Generic;
using System.Linq;

namespace Homework2
{
    partial class Program
    {
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
                        int resultId;
                        bool res = int.TryParse(data[0], out resultId);
                        if (res == false) { Console.WriteLine("Id is not a number"); }
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