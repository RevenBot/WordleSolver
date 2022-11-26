namespace WordleSolver.Data
{
    public interface IRow
    {
        public List<ILetter> Letters { get; set; }
        public List<IWord> Words { get; set; }
        public void SetWord(IWord word);
        public void SetWord(string word);
        public void LoadData(List<IWord> words);
        public void Calculate();
        public void ClickedCell(ILetter letter);
    }
}