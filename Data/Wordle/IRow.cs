namespace WordleSolver.Data.Wordle
{
	public interface IRow
	{
		public List<ILetter> Letters { get; set; }
		public List<IWord> Words { get; set; }
		public bool IsActive { get; set; }
		public string CssClass { get; }
		public void SetWord(IWord word);
		public void SetWord(string word);
		public void LoadData(List<IWord> words);
		public void Calculate();
		public void ClickedCell(ILetter letter);
		public bool RightLetters();
		public void Reset();
	}
}