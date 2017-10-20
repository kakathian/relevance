using Relevance.Core;
using Relevance.Core.Summary;
using Relevance.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relevance.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string dataStorePath = Sundry.ReadSetting<string>(ConfigurationSettings.AppSettings["DataStore"]);
            string text = new TextFileReader().Read(Path.Combine(dataStorePath, "ClimateChange.txt"));
            List<string> words = GetWords(text);
            Word[] wordCount =  CountWords(words);
            Array.Sort(wordCount);

            List<string> sentences = GetSentences(text);

            System.Console.Read();
        }

        private static List<string> GetWords(string text)
        {
            WordProcessor wordProcessor = new WordProcessor(text);
            return wordProcessor.ReadWords();
        }

        private static Word[] CountWords(List<string> words)
        {
            WordCounter counter = new WordCounter();
            return counter.DoCount(words);
        }

        private static List<string> GetSentences(string text)
        {
            WordProcessor wordProcessor = new WordProcessor(text);
            return wordProcessor.ReadSentences();
        }
    }
}
