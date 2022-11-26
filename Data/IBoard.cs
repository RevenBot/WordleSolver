namespace WordleSolver.Data
{
    public interface IBoard
    {
        public List<IWord> Words { get; set; }
        public List<IRow> Rows { get; set; }
        public IDialogService Dialog { get; set; }
        public void Calculate(IRow row);
        public void LoadData();
        public void Reset();
        public Task EnterWord(IRow row);
    }
}