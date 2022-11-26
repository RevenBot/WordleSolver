using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordleSolver.Data
{
    internal class Row : IRow
    {
        private List<ILetter> letters = new List<ILetter>()
        {
            new Letter(),
            new Letter(),
            new Letter(),
            new Letter(),
            new Letter()
        };
        IWordSolverService solver = new WordSolverService();

        public List<ILetter> Letters { get => letters; set => letters = value; }
        public List<IWord> Words { get; set; }

        public void Calculate()
        {

            foreach (var item in letters)
            {
                Debug.WriteLine(item.Value);
                if (item.Type < 0)
                    solver.AddCharsNotIn(item.Value);
                else if (item.Type == 0)
                    solver.AddYellowCharsAt(item.Value, item.Position);
                else if (item.Type > 0)
                    solver.AddGreenCharsAt(item.Value, item.Position);
            }
            solver.ResearchWords();
            Words = solver.Words;
            Debug.WriteLine(Words.Count);
        }

        public void LoadData(List<IWord> words)
        {
            solver.LoadWords(words);
            Words= words;
            
        }
        public void ClickedCell(ILetter letter)
        {
            letter.Type = letter.Type == 1 ? -1 : letter.Type + 1;
        }

        public void SetWord(IWord word)
        {
            for (int i = 0; i < word.Value.Length; i++)
            {
                letters[i].Value = word.Value[i];
                letters[i].Position = i;
            }
        }

        public void SetWord(string word)
        {
         for (int i = 0; i < word.Length; i++)
            {
                letters[i].Value = word[i];
                letters[i].Position = i;
            }
}
    }
}
