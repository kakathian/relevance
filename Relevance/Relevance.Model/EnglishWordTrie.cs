using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relevance.Model
{
    public class EnglishWordTrie : WordTrie
    {
        protected override bool AreLettersEqual(char sourceLetter, char destinationLetter)
        {
            return (string.Equals(sourceLetter + "", destinationLetter + "", StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
