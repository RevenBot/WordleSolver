namespace WordleSolver.Data.Wordle
{
	public interface ILetter
	{
		public char Value { get; set; }
		public int Position { get; set; }
		//-1 not in word
		// 0 in word not in this postition
		// 1 in word in this position
		public int Type { get; set; }
		public string CssClass { get; }

	}
}