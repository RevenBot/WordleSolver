using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WordleSolver.Data.Wordle
{
    internal class Board : IBoard
    {
        public List<IWord> Words { get; set; }
        public List<IRow> Rows { get; set; } = new List<IRow>()
        {
            new Row(){IsActive = true},
            new Row(),
            new Row(),
            new Row(),
            new Row(),
            new Row(),
        };
        public IWord Word { get; set; }
        public IDialogService Dialog { get; set; } = new DialogService();
        private void SetRowsStage(IRow row)
        {
            int nextR = Rows.IndexOf(row) + 1;
            row.IsActive = false;
            if (nextR < Rows.Count)
            {
                Rows[nextR].IsActive = true;
            }
        }
        public void Calculate(IRow row)
        {
            if (row.IsActive && row.RightLetters() && Words != null)
            {
                Debug.WriteLine(Words.Count);

                row.LoadData(Words);
                row.Calculate();
                SetRowsStage(row);
                Words = row.Words;
            }
            Debug.WriteLine("None input, invalid row, data not loaded");
        }

        public async Task EnterWord(IRow row)
        {
            if (row.IsActive)
            {
                var wordString = Dialog.DisplayPromptAsync("WORDLE", "INSERT", "OK", "CANCEL", "ANGEL");
                var result = await Task.FromResult(wordString).Result;
                if (result != null && result.All(Char.IsLetter))
                {
                    Word = new Word(result.ToUpper());
                    row.SetWord(Word);
                }
                else
                {
                    Debug.WriteLine("Cancel or word doesn't contain a letter");
                }
            }
        }

        public async Task LoadData()
        {
            try
            {
                Words = await ReadFileService.GetWordsListAsync("words.txt");

            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }

        public async Task Reset()
        {
            await LoadData();
            Rows = new List<IRow>()
            {
                new Row(){IsActive = true},
                new Row(),
                new Row(),
                new Row(),
                new Row(),
                new Row(),
            };
        }

    }
}
