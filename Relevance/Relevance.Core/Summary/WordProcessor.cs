using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Relevance.Core.Summary
{
    public class WordProcessor
    {
        private readonly string _rawText = string.Empty;
        public WordProcessor(string text)
        {
            this._rawText = text;
        }

        public List<string> ReadWords()
        {
            return this.ReadWords(this._rawText);
        }

        public List<string> ReadWords(string text)
        {
            List<string> words = new List<string>();
            if (string.IsNullOrWhiteSpace(text)) return words;
            words.AddRange(Regex.Split(text.Replace(Environment.NewLine.ToString(), " "), @"\W+"));
            return words;
        }

        public List<string> ReadSentences()
        {
            List<string> sentences = new List<string>();
            if (string.IsNullOrWhiteSpace(this._rawText)) return sentences;
            sentences.AddRange(Regex.Split(this._rawText.Replace(Environment.NewLine.ToString(), " "), @"(?<=[\.!\?])\s+"));
            return sentences;
        }
    }
}
