using System;
using System.Collections.Generic;
using System.Configuration;
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

        public static T ReadSetting<T>(string key, bool isDefault = true)
        {
            if (isDefault && string.IsNullOrWhiteSpace(ConfigurationSettings.AppSettings[key])) return default(T);
            return (T)Convert.ChangeType(ConfigurationSettings.AppSettings[key], typeof(T));
        }
    }
}
