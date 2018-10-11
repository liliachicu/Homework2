using System;

namespace Homework2
{
    class ConsoleReader : AbstractValueReader, IConsoleReader
    {
        public void Read()
        {
            value = Console.ReadLine();
        }
    }

}