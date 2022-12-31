namespace WordleSolver.Data.Wordle
{
	public interface IBoard
	{
		public List<Word> Words { get; set; }
		public List<IRow> Rows { get; set; }
		public IDialogService Dialog { get; set; }
		public void Calculate(IRow row);
		public Task LoadData();
		public Task LoadDataDeprecated();
		public Task Reset();
		public Task EnterWord(IRow row);
		public void ClickedWord(Word word);
	}
}