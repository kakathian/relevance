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
            Dictionary<string, int> sentenceRanks = new Dictionary<string, int>();
            if (sentences == null || sentences.Count() < 1) return new Sentence[0];

            List<string> fSentences = sentences.Distinct().ToList();
            WordProcessor wordProcessor = new WordProcessor(string.Empty);
            int tolerance = Sundry.ReadSetting<int>("RankTolerance");

            tolerance = tolerance % references.Count();
            IEnumerable <Word> toleranceReferences = references.Take(Sundry.ReadSetting<int>("RankTolerance"));
            fSentences.ForEach(fSentence => toleranceReferences.inte Intersect(wordProcessor.ReadWords(fSentence)



        }
    }
}
