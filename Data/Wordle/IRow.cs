namespace WordleSolver.Data.Wordle
{
	public interface IRow
	{
		public List<ILetter> Letters { get; set; }
		public List<Word> Words { get; set; }
		public bool IsActive { get; set; }
		public string CssClass { get; }
		public void SetWord(Word word);
		public void SetWord(string word);
		public void LoadData(List<Word> words);
		public void Calculate();
		public void ClickedCell(ILetter letter);
		public bool RightLetters();
		public void Reset();
	}
}