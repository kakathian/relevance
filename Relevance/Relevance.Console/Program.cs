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
            string dataStorePath = Sundry.ReadSetting<string>("DataStore");
            string text = new TextFileReader().Read(Path.Combine(dataStorePath, "ClimateChange.txt"));
            List<string> rawWords = GetWords(text);
            Word[] referenceWords = CountWords(rawWords);
            Array.Sort(referenceWords);

            List<string> sentences = GetSentences(text);
            SentenceRanker sentenceRanker = new SentenceRanker();
            Sentence[] rankedSentences = sentenceRanker.DoRank(sentences, referenceWords);
            float sentenceTolerance = Sundry.ReadSetting<float>("SentenceTolerance");
            sentenceTolerance = sentences.Count() * (sentenceTolerance <= 0 ? 1 : sentenceTolerance);
            if (null != rankedSentences)
            {
                Array.Sort(rankedSentences);
                for (int sentenceIndex = 0; sentenceIndex < sentenceTolerance;)
                    System.Console.WriteLine(rankedSentences[sentenceIndex++].Value + "\r\n");
            }

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
