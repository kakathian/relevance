using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relevance.Model
{
    public class TextOccurrence : IComparable<TextOccurrence>
    {
        public string Value { get; set; }
        public int Frequency { get; set; }

        public virtual int CompareTo(TextOccurrence other)
        {
            return this.Frequency.CompareTo(other.Frequency);
        }
    }
}
