using System;

namespace Homework2
{
    class ConsoleReader : AbstractValueReader, IConsoleReader
    {
        private string _input;

        public void Read()
        {
            _input = Console.ReadLine();
        }
    }

}