using System.Diagnostics;
using WordleSolver.Services.DbServices;

namespace WordleSolver.Data.Wordle
{
    internal class Board : IBoard
    {
        public List<Word> Words { get; set; }
        public List<IRow> Rows { get; set; } = new List<IRow>()
        {
            new Row(){IsActive = true},
            new Row(),
            new Row(),
            new Row(),
            new Row(),
            new Row(),
        };
        public Word Word { get; set; }
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
        //DEPRECATED FOR DB
        public async Task LoadDataDeprecated()
        {
            try
            {
                Words = await ReadFileServiceDeprecated.GetWordsListAsync("words.txt");

            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }
        public async Task LoadData()
        {
            if (Words == null)
                try
                {
                    Words = await App.WordRepo.GetAllWords();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
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

        public void ClickedWord(Word word)
        {
            foreach (var item in Rows)
            {
                if( item.IsActive)
                {
                    item.SetWord(word);
                }
            }
        }
    }
}
