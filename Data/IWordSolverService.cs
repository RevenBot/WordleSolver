namespace WordleSolver.Data
{
    internal interface IWordSolverService
    {

        public List<char> CharsNotIn { get; set; }
        public Dictionary<int,char> YellowChars { get; set; }
        public Dictionary<int, char> GreenChars { get; set; }
        public List<IWord> Words { get; set; }
        public List<IWord> PreviousWords { get; set; }
        public void LoadWords(List<IWord> wordsIN);
        public void AddCharsNotIn(char charNotIn);
        public void AddYellowCharsAt(char yellowChar, int position);
        public void AddGreenCharsAt(char greenChar, int position);
        public void ExcludeCharsNotIn();
        public Task<List<IWord>> ExcludeCharsNotInAsync();
        public void ExcludeYellowChars();
        public Task<List<IWord>> ExcludeYellowCharsAsync();
        public void CharGreenInWord();
        public Task<List<IWord>> CharGreenInWordAsync();
        public void ResearchWords();
        public Task ResearchWordsAsync();
        public void Cleaner();
    }
}