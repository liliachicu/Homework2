using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Homework2
{
        public class DataModel
        {
            public List<Employee> employees = new List<Employee>();
            public Dictionary<int, ICollection<Payment>> payments = new Dictionary<int, ICollection<Payment>>();
            public void Model(string input)
            {
                var records = input.Split(';');
                foreach (var record in records)
                { 
                    var data = record.Split(' ');
                    int employeeId;
                    decimal parsedAmount;
                    DateTime parsedData;
                    bool resInt = int.TryParse(data[0], out employeeId);
                    if (resInt == false) throw new Exception("Id must be an integer value");
                    bool resDec = decimal.TryParse(data[3], out parsedAmount);
                    if (resDec == false) throw new Exception("Amount must be a decimal value");
                    bool resData = DateTime.TryParse(data[4], out parsedData);
                    if (resData == false) throw new Exception("DateTime must be a Date Time value");
                    if (!employees.Any(e => e.Id == employeeId))
                    {
                        var employee = new Employee(employeeId, data[1], data[2]);
                        employees.Add(employee);
                    }

                    if (!payments.ContainsKey(employeeId))
                    {
                        payments[employeeId] = new List<Payment>();
                    }

                    payments[employeeId].Add(new Payment(employeeId, parsedAmount, parsedData));
                }
            }
        }
    
}