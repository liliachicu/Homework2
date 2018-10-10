using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2
{
    class Employee
    {
        public Employee(int id, string firstName, string lastName)
        {
            if (id < 0)
            {
                throw new ArgumentException(nameof(id), "ID can not be a negative number");
            }
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentException(nameof(firstName), "The first name cannot be null or empty.");
            }
            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentException(nameof(lastName), "The last name cannot be null or empty.");
            }
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public int Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
    }

    class Payment
    {
        public int EmployeeId { get; }

        public decimal Amount { get; }

        public DateTime Date { get; }
        public Payment(int employeeId, decimal amount, DateTime date)
        {
            if (employeeId < 0)
            {
                throw new ArgumentException(nameof(employeeId), "ID can not be a negative number");
            }
            EmployeeId = employeeId;
            Amount = amount;
            Date = date;
        }

        public Payment(decimal amount, DateTime date)
        {
            Amount = amount;
            Date = date;
        }
    }

    class ConsoleReader : IInputProvider, IConsoleReader
    {
        private string _input;

        public void Read()
        {
            _input = Console.ReadLine();
        }

        public string GetInput()
        {
            return _input;
        }
    }

    public interface IInputProvider
    {
        string GetInput();
    }
    public interface IConsoleReader
    {
        void Read();
    }

    class Program
    {
        static void Main(string[] args)
        {
            var consoleReader = new ConsoleReader();

            string input = string.Empty;

            if (args.Length == 0)
            {
                consoleReader.Read();
                input = consoleReader.GetInput();
            }
            else
            {
                switch (args.First())
                {
                    case "I":
                        var length = args.Length - 1;
                        var values = new string[length];
                        Array.Copy(args, 1, values, 0, args.Length - 1);
                        input = string.Join(" ", values);
                        break;

                    case "F":
                        input = File.ReadAllText("C:\\file.txt");
                        break;

                    default:
                        throw new ArgumentOutOfRangeException(nameof(args), "Unknown source flag");
                }
            }

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

                if(!payments.ContainsKey(employeeId))
                {
                    payments[employeeId] = new List<Payment>();
                }
                    payments[employeeId].Add(new Payment(Decimal.Parse(data[3]),DateTime.Parse(data[4])));
            }
        }

        /*class FirstArgumentInput
        {
            private string argument = "";
            public void Argument(string[] args)
            {
                if (args == null) ; //User interactive model }
                else
                        if (args.Contains("F")) ; // Read from a file 
                if (args.Contains("I"))
                {
                }; //Read from console arguments               
            }
        }
        class ConsoleInteractiveModel
        {
            public void Reader()
            {
                Console.WriteLine("Insert data");
                Console.WriteLine("Id");
            }

        }

        interface IStringGetValue
        {
            string GetValue();
        }

        interface IConsoleReader
        {
            void Read();
        }

        interface IFileValueReader
        {
            void ReadFile(string path);
        }
        internal class ConsoleValueReader : AbstractValueReader, IConsoleReader, IStringGetValue
        {
            public void ReadLine()
            {
                value = Console.ReadLine();
            }
        }

        class FileValueReader : AbstractValueReader, IFileValueReader, IStringGetValue
        {
            public void ReadFile(string path)
            {
                value = File.ReadAllText(path);
            }
        }

        class AbstractValueReader : IStringGetValue
        {
            protected string value;

            public virtual string GetValue()
            {
                return value;

            }

        }
    }*/
}