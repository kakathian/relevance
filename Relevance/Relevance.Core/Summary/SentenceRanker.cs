using Relevance.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relevance.Core.Summary
{
    public class SentenceRanker
    {
        public Sentence[] DoRank(IList<string> sentences, Word[] references)
        {
            Dictionary<string, long> sentenceRanks = new Dictionary<string, long>();
            if (sentences == null || sentences.Count() < 1) return new Sentence[0];

            List<string> fSentences = sentences.Distinct().ToList();
            WordProcessor wordProcessor = new WordProcessor(string.Empty);
            int tolerance = Sundry.ReadSetting<int>("RankTolerance");
            tolerance = references.Count() / (tolerance < 1 ? 1 : 5 - tolerance);

            Dictionary<string, Word> lookupWords = references.Take(tolerance).ToDictionary(w => w.Value);
            WordDistinctCriteria wordDistinctCriteria = new WordDistinctCriteria();
            foreach (string sentence in fSentences)
            {
                long rank = 0;
                HashSet<string> distinctWords = new HashSet<string>();
                wordProcessor.ReadWords(sentence).ForEach(w => distinctWords.Add(w.ToLower()));

                foreach (string wordKey in distinctWords )
                {
                    Word hitWord = null;
                    if (lookupWords.TryGetValue(wordKey, out hitWord)) rank += hitWord.Frequency;
                }

                sentenceRanks.Add(sentence, rank);
            }

            return sentenceRanks.Select(kvp => new Sentence() { Value = kvp.Key, Frequency = kvp.Value }).ToArray();
        }
    }
}
