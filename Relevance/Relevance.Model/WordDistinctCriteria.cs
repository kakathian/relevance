using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relevance.Model
{
    public class WordDistinctCriteria : StringComparer
    {
        public override int Compare(string x, string y)
        {
            return string.Compare(x, y, true);
        }

        public override bool Equals(string x, string y)
        {
            return string.Equals(x, y, StringComparison.OrdinalIgnoreCase);
        }

        public override int GetHashCode(string obj)
        {
            return (string.IsNullOrWhiteSpace(obj)) ? string.Empty.GetHashCode() : obj.GetHashCode();
        }
    }
}
