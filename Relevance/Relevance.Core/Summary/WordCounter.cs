﻿using Relevance.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relevance.Core.Summary
{
    public class WordCounter
    {
        public Word[] DoCount(IList<string> words)
        {
            Dictionary<string, int> wordRanks = new Dictionary<string, int>();
            if (words == null || words.Count() < 1) return new Word[0];

            foreach (string word in words)
            {
                if (!wordRanks.TryGetValue(word, out int frequency)) wordRanks.Add(word, 0);
                wordRanks[word] += 1;
            }

            return wordRanks.Keys.Select<string, Word>((w) => new Word() { Frequency = wordRanks[w], Value = w }).ToArray();
        }
    }
}
