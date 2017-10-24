using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relevance.Model
{
    public class WordTrie
    {
        public WordTrie()
        {
            this.Nodes = new Dictionary<char, WordTrie>();
        }

        public Dictionary<char, WordTrie> Nodes { get; private set; }

        public char Base { get; set; }
        public bool IsEdge
        {
            get { return Nodes.Count == 0; }
        }

        public virtual void Add(string word, WordTrie root)
        {
            if (string.IsNullOrWhiteSpace(word)) return;
            if (this.AreLettersEqual(root.Base, word[0]))
            {
                Add(word.Substring(1), root);
            }

            WordTrie node = null;
            if (root.Nodes.TryGetValue(word[0], out node))
            {
                node.Add(word.Substring(1), node);
                return;
            }

            root.Nodes.Add(word[0], new WordTrie());
            root.Nodes[word[0]].Base = word[0];
            root = root.Nodes[word[0]];
            Add(word.Substring(1), root);
        }

        public virtual bool Find(string word, WordTrie root)
        {
            if (string.IsNullOrWhiteSpace(word)) return true;
            if (root.IsEdge) return false;
            if (this.AreLettersEqual(root.Base, word[0]))
            {
                if (Find(word.Substring(1), root)) return true;
            }

            WordTrie node = null;
            if (root.Nodes.TryGetValue(word[0], out node))
            {
                if (node.Find(word.Substring(1), node)) return true;
            }

            return false;
        }

        protected virtual bool AreLettersEqual(char sourceLetter, char destinationLetter)
        {
            return (string.Equals(sourceLetter + "", destinationLetter + "", StringComparison.OrdinalIgnoreCase));
        }
    }
}
