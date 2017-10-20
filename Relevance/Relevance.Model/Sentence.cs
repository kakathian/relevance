using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relevance.Model
{
    public class Sentence : TextOccurrence, IEqualityComparer<Sentence>
    {
        public override int CompareTo(TextOccurrence other)
        {
            return -1 * this.Frequency.CompareTo(other.Frequency);
        }

        public bool Equals(Sentence x, Sentence y)
        {
            return string.Equals(x.Value, y.Value, StringComparison.InvariantCultureIgnoreCase);
        }

        public int GetHashCode(Sentence sentence)
        {
            return this.GetHashCode() ^ sentence.GetHashCode();
        }
    }
}
