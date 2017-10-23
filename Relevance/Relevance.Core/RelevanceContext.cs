using Relevance.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Relevance.Core
{
    public class RelevanceContext
    {
        protected static readonly RelevanceContext _context;
        static RelevanceContext()
        {
            _context = new RelevanceContext();
            _context.Init();
        }

        private void Init()
        {
            // TODO: This is initiliazed based on the language culture information
            this.StopWordTree = new EnglishWordTrie()
            {
                Base = ' '
            };

            using (TextReader reader = File.OpenText(Path.Combine(Sundry.ReadSetting<string>("ConfigStore"), Sundry.ReadSetting<string>("EnglishStopWordList"))))
            {
                string stopWord = reader.ReadLine();
                while (!string.IsNullOrWhiteSpace(stopWord))
                {
                    this.StopWordTree.Add(stopWord, this.StopWordTree);
                    stopWord = reader.ReadLine();
                }
            }
        }

        public static RelevanceContext Current
        {
            get
            {
                return _context;
            }
        }

        public WordTrie StopWordTree { get; private set; }
    }
}
