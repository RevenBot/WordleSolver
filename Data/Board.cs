using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordleSolver.Data
{
    internal class Board : IBoard
    {
        public List<IWord> Words { get; set; }
        public List<IRow> Rows { get; set; } = new List<IRow>()
        { 
            new Row(),
            new Row(),
            new Row(),
            new Row(),
            new Row(),
        };
        public IWord Word { get; set; }
        public IDialogService Dialog { get; set; } = new DialogService();

        public void Calculate(IRow row)
        {
            row.LoadData(Words);
            row.Calculate();
            Words= row.Words;
            Debug.WriteLine(Words.Count);
        }

        public async Task EnterWord(IRow row)
        {
            var wordString = Dialog.DisplayPromptAsync("WORDLE", "INSERT", "OK", "CANCEL", "ANGEL");
            var result = await Task.FromResult(wordString).Result;
            Word = new Word(result);
            row.SetWord(Word);
            Debug.WriteLine("word" + Word.Value.Length);
        }

        public async void LoadData()
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

        public async void Reset()
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
    }
}
