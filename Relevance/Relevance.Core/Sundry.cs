using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relevance.Core
{
    public class Sundry
    {
        public static void GuardFilePath(string path)
        {
            if (!File.Exists(path)) throw new FileNotFoundException();
        }

        public static T ReadSetting<T>(object value)
        {
            return (T)Convert.ChangeType(value,typeof(T));
        }
    }
}
