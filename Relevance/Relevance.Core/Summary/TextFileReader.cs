using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relevance.Core.Summary
{
    public class TextFileReader : IFileReader
    {
        public string Read(string filePath)
        {
            Sundry.GuardFilePath(filePath);
            return File.ReadAllText(filePath,Encoding.Unicode);
        }
    }
}
