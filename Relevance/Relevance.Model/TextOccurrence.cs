using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relevance.Model
{
    public class TextOccurrence : IComparable<TextOccurrence>, IEqualityComparer<TextOccurrence>
    {
        public string Value { get; set; }
        public long Frequency { get; set; }

        public virtual int CompareTo(TextOccurrence other)
        {
            return this.Frequency.CompareTo(other.Frequency);
        }

        public virtual bool Equals(TextOccurrence x, TextOccurrence y)
        {
            return string.Equals(x.Value, y.Value, StringComparison.OrdinalIgnoreCase);
        }

        public virtual int GetHashCode(TextOccurrence obj)
        {
            return string.IsNullOrWhiteSpace(this.Value) ? base.GetHashCode() : this.Value.GetHashCode();
        }
    }
}
