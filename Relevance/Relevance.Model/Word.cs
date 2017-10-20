using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relevance.Model
{
    public class Word : TextOccurrence
    {
        public override int CompareTo(TextOccurrence other)
        {
            return -1 * this.Frequency.CompareTo(other.Frequency);
        }

        public override int GetHashCode()
        {
            return string.IsNullOrWhiteSpace(this.Value) ? base.GetHashCode() : this.Value.GetHashCode();
        }
    }
}
