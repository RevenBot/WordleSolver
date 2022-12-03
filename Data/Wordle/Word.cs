using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordleSolver.Data.Wordle
{
    public class Word : IWord, IComparable
    {
        public Word(string word)
        {
            Value = word;
        }
        public string Value { get; set; }

        public int CompareTo(object obj)
        {
            Word w = obj as Word;
            return string.Compare(Value, w.Value);
        }
    }
}
