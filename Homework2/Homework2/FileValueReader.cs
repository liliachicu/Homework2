using System.IO;

namespace Homework2
{
    class FileValueReader : AbstractValueReader, IFileValueReader
    {
        public void ReadFile(string path)
        {
            value = File.ReadAllText(path);
        }
    }

}