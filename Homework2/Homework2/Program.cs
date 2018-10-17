using System;
using System.Collections.Generic;
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
           
            var parseInput = new InputParser(new DataModel());
            var reportData = new ReportData(parseInput);
            var reportModel = reportData.GenerateReport(input);
            var report = new ReportGenerator();

            report.reportShow += report.PrintConsole;
            report.reportShow += report.PrintFile;
            report.InvokeEvent(reportModel);
            Console.ReadKey();
        }
    }
}