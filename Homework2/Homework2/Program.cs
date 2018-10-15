using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2
{
    partial class Program
    {
        public static event Action<List<IReport>> Show;
        static void Main(string[] args)
        {
            var consoleReader = new ConsoleReader();
            var fileReader = new FileValueReader();
            var reportConsole = new ReportConsole();
            var reportFile = new ReportFile();
            var reportGenerator = new ReportGenerator();

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
                        input = args[1].Trim(new char[] {'"'});
                        break;

                    case "F":
                        fileReader.ReadFile(@"C:\Projects L\Project 1\Homework2\Homework2\file.txt");
                        input = fileReader.GetInput();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException(nameof(args), "Unknown source flag");
                }
            }
            var report = reportGenerator.GenerateReport(input);
            Show += reportConsole.PrintReport;
            Show += reportFile.PrintReport;
            Show(report);
            Console.ReadKey();
        }
    }
}