namespace WordleSolver.Data.Wordle
{
    public interface IBoard
    {
        public List<IWord> Words { get; set; }
        public List<IRow> Rows { get; set; }
        public IDialogService Dialog { get; set; }
        public void Calculate(IRow row);
        public Task LoadData();
        public void Reset();
        public Task EnterWord(IRow row);
    }
}