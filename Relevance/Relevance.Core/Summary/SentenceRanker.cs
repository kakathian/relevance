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
            foreach (string sentence in fSentences)
            {
                long rank = 0;
                foreach (KeyValuePair<string, string> kvp in wordProcessor.ReadWords(sentence).Distinct().ToDictionary(s => s))
                {
                    if (lookupWords.TryGetValue(kvp.Key, out Word hitWord)) rank += hitWord.Frequency;
                }

                sentenceRanks.Add(sentence, rank);
            }

            return sentenceRanks.Select(kvp => new Sentence() { Value = kvp.Key, Frequency = kvp.Value }).ToArray();
        }
    }
}
