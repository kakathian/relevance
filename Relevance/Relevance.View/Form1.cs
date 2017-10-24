using Relevance.Core;
using Relevance.Core.Summary;
using Relevance.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Relevance.View
{
    public partial class Form1 : Form
    {
        List<string> rawWords = null;
        Word[] referenceWords = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            textBox1.Text = openFileDialog1.FileName;

            string text = new TextFileReader().Read(textBox1.Text);
            richTextBox1.Text = text;
            label6.Text = ((Encoding.UTF8.GetByteCount(text)) / 1000.00).ToString();
            rawWords = GetWords(text);
            referenceWords = CountWords(rawWords);
            Array.Sort(referenceWords);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            rawWords = null;
            referenceWords = null;
            richTextBox1.Text = string.Empty;
            richTextBox2.Text = string.Empty;
            label5.Text = "N/A";
            label6.Text = "N/A";

            DialogResult result = openFileDialog1.ShowDialog(this);
            if (result == DialogResult.OK) textBox1.Text = openFileDialog1.FileName;
        }

        private static List<string> GetWords(string text)
        {
            WordProcessor wordProcessor = new WordProcessor(text);
            return wordProcessor.ReadWords();
        }

        private static Word[] CountWords(List<string> words)
        {
            WordCounter counter = new WordCounter();
            return counter.DoCount(words);
        }

        private static List<string> GetSentences(string text)
        {
            WordProcessor wordProcessor = new WordProcessor(text);
            return wordProcessor.ReadSentences();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StringBuilder summaryView = new StringBuilder();
            List<string> sentences = GetSentences(richTextBox1.Text);
            SentenceRanker sentenceRanker = new SentenceRanker();
            Sentence[] rankedSentences = sentenceRanker.DoRank(sentences, referenceWords);
            float sentenceTolerance = Sundry.ReadSetting<float>("SentenceTolerance");
            sentenceTolerance = sentences.Count() * (sentenceTolerance <= 0 ? 1 : sentenceTolerance);
            summaryView.Append("--Top 2 highly used words-- " + "\t");
            summaryView.Append((referenceWords.GetValue(0) as Word).Value);
            summaryView.AppendLine("\t" + (referenceWords.GetValue(1) as Word).Value);
            summaryView.AppendLine("---------------------------------");
            if (null != rankedSentences)
            {
                Array.Sort(rankedSentences);
                for (int sentenceIndex = 0; sentenceIndex < sentenceTolerance;)
                    summaryView.AppendLine(rankedSentences[sentenceIndex++].Value);
            }

            richTextBox2.Text = summaryView.ToString();
            label5.Text = ((Encoding.UTF8.GetByteCount(richTextBox2.Text)) / 1000.00).ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            RelevanceContext.Current.StopWordTree.Add(textBox2.Text.Trim(), RelevanceContext.Current.StopWordTree);
            label3.Text = "Last word stopped was: '" + textBox2.Text + "'";
            textBox2.Text = string.Empty;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
