namespace WordleSolver.Data.Wordle
{
	internal class Letter : ILetter
	{
		public char Value { get; set; } = '?';
		public int Position { get; set; }
		public int Type { get; set; } = -1;
		public string CssClass
		{
			get
			{
				return Type switch
				{
					0 => "letter-yellow",
					1 => "letter-green",
					_ => "letter-grey",
				};
			}
		}
	}
}
