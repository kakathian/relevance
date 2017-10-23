using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relevance.Model
{
    public class Sentence : TextOccurrence
    {
        public override int CompareTo(TextOccurrence other)
        {
            return -1 * this.Frequency.CompareTo(other.Frequency);
        }
    }
}
