namespace WordleSolver.Data.Wordle
{
	internal interface IWordSolverService
	{

		public List<char> CharsNotIn { get; set; }
		public Dictionary<int, char> YellowChars { get; set; }
		public Dictionary<int, char> GreenChars { get; set; }
		public List<Word> Words { get; set; }
		public List<Word> PreviousWords { get; set; }
		public void LoadWords(List<Word> wordsIN);
		public void AddCharsNotIn(char charNotIn);
		public void AddYellowCharsAt(char yellowChar, int position);
		public void AddGreenCharsAt(char greenChar, int position);
		public void ExcludeCharsNotIn();
		public Task<List<Word>> ExcludeCharsNotInAsync();
		public void ExcludeYellowChars();
		public Task<List<Word>> ExcludeYellowCharsAsync();
		public void CharGreenInWord();
		public Task<List<Word>> CharGreenInWordAsync();
		public void ResearchWords();
		public Task ResearchWordsAsync();
		public void Cleaner();
	}
}