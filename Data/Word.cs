using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordleSolver.Data
{
    public class Word : IWord
    {
        public Word(string word) {
            this.Value = word;
        }
        public string Value { get; set; }
    }
}
