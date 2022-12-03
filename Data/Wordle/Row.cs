using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordleSolver.Data.Wordle
{
    internal class Row : IRow
    {
        public bool IsActive { get; set; } = false;
        public string CssClass
        {
            get
            {
                if (IsActive)
                {
                    return "active-row";
                }
                return "inactive-row";
            }
        }
        public IWordSolverService Solver { get; set; } = new WordSolverService();

        public List<ILetter> Letters { get; set; } = new List<ILetter>()
        {
            new Letter(),
            new Letter(),
            new Letter(),
            new Letter(),
            new Letter()
        };
        public List<IWord> Words { get; set; }

        public void Calculate()
        {
            
            foreach (var item in Letters)
            {
                Debug.WriteLine(item.Value);
                if (item.Type < 0)
                    Solver.AddCharsNotIn(item.Value);
                else if (item.Type == 0)
                    Solver.AddYellowCharsAt(item.Value, item.Position);
                else if (item.Type > 0)
                    Solver.AddGreenCharsAt(item.Value, item.Position);
            }
            Solver.ResearchWords();
            Words = Solver.Words;
            Debug.WriteLine(Words.Count);

            
        }

        public void LoadData(List<IWord> words)
        {
            Solver.LoadWords(words);
            Words = words;

        }
        public void ClickedCell(ILetter letter)
        {
            if (this.IsActive)
            {
                letter.Type = letter.Type == 1 ? -1 : letter.Type + 1;
            }
        }

        public void SetWord(IWord word)
        {
            for (int i = 0; i < word.Value.Length; i++)
            {
                Letters[i].Value = word.Value[i];
                Letters[i].Position = i;
            }
        }

        public void SetWord(string word)
        {
            for (int i = 0; i < word.Length; i++)
            {
                Letters[i].Value = word[i];
                Letters[i].Position = i;
            }
        }
        public bool RightLetters()
        {
            if (Letters.All(x => (Char.IsLetter(x.Value))))
            {
                return true;
            }
            else return false;

        }
        public void Reset()
        {
            Letters = new List<ILetter>()
            {
                new Letter(),
                new Letter(),
                new Letter(),
                new Letter(),
                new Letter()
            };
        }
    }
}
