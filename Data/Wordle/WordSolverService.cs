using System.Diagnostics;

namespace WordleSolver.Data.Wordle
{
	public class WordSolverService : IWordSolverService
	{
		private List<char> charsNotIn = new List<char>();
		private Dictionary<int, char> yellowChars = new Dictionary<int, char>();
		private Dictionary<int, char> greenChars = new Dictionary<int, char>();
		private List<IWord> words = new List<IWord>();
		private List<IWord> previousWords = new List<IWord>();
		public List<char> CharsNotIn { get => charsNotIn; set => charsNotIn = value; }
		public Dictionary<int, char> YellowChars { get => yellowChars; set => yellowChars = value; }
		public Dictionary<int, char> GreenChars { get => greenChars; set => greenChars = value; }
		public List<IWord> Words { get => words; set => words = value; }
		public List<IWord> PreviousWords { get => previousWords; set => previousWords = value; }
		public void LoadWords(List<IWord> wordsIN)
		{
			words = wordsIN;
		}

		public void AddCharsNotIn(char charNotIn)
		{
			Debug.WriteLine($"Add char to exclude < {charNotIn} >");
			charsNotIn.Add(charNotIn);
		}
		public void AddYellowCharsAt(char yellowChar, int position)
		{
			Debug.WriteLine($"Add char < {yellowChar} > to exclude as position {position}");
			yellowChars.Add(position, yellowChar);
		}
		public void AddGreenCharsAt(char greenChar, int position)
		{
			Debug.WriteLine($"Add char < {greenChar} >  at position {position}");
			greenChars.Add(position, greenChar);
		}
		public void ExcludeCharsNotIn()
		{
			var temp = words.Where(
				x => x.Value.IndexOfAny(charsNotIn.ToArray()) == -1
				);
			words = temp.ToList();
		}
		public Task<List<IWord>> ExcludeCharsNotInAsync()
		{
			return Task.FromResult(words.Where(
					x => x.Value.IndexOfAny(charsNotIn.ToArray()) == -1
					).ToList().ToList()
			);
		}


		public void ExcludeYellowChars()
		{
			var temp = words.Where(
				x => CheckYellow(x)
				);
			words = temp.ToList();
		}
		public Task<List<IWord>> ExcludeYellowCharsAsync()
		{
			return Task.FromResult(
				words.Where(x => CheckYellow(x)
					).ToList()
				);
		}

		private bool CheckYellow(IWord x)
		{
			foreach (var ychar in yellowChars)
			{
				//elimino le parole che non contengo una lettera gialla 
				// devo eliminare le parole che contongone le gialle n in postion 
				var position = ychar.Key;
				if (!x.Value.Contains(ychar.Value) || x.Value[position] == ychar.Value)
				{
					return false;
				}
			}
			return true;
		}

		public void CharGreenInWord()
		{
			var temp = words.Where(
				x => CheckGreen(x)
				);
			words = temp.ToList();
		}
		public Task<List<IWord>> CharGreenInWordAsync()
		{
			return Task.FromResult(
				words.Where(x => CheckGreen(x))
				.ToList()
				);
		}

		private bool CheckGreen(IWord x)
		{
			foreach (var gchar in greenChars)
			{
				//escludo altre parole che hanno un char diverso dal green in quella position
				if (x.Value[gchar.Key] != gchar.Value)
				{
					return false;
				}
			}
			return true;
		}

		public void ResearchWords()
		{
			var sw = new Stopwatch();
			sw.Start();
			Debug.WriteLine("Start sync = Words {0}", words.Count);
			Debug.WriteLine("sync running for {0} s ", sw.Elapsed.TotalSeconds);
			ExcludeCharsNotIn();
			ExcludeYellowChars();
			CharGreenInWord();
			Debug.WriteLine("sync running for {0} s ", sw.Elapsed.TotalSeconds);
			Cleaner();
			Debug.WriteLine("Done--Words {0}", words.Count());
		}
		public void Cleaner()
		{
			charsNotIn.Clear();
			greenChars.Clear();
			yellowChars.Clear();
		}
		public async Task ResearchWordsAsync()
		{
			var sw = new Stopwatch();
			sw.Start();
			Debug.WriteLine("Start async = Words {0}", words.Count);
			Debug.WriteLine("async running for {0} s ", sw.Elapsed.TotalSeconds);
			var delay = Task.Delay(5000);
			var resultNotIn = ExcludeCharsNotInAsync();
			var resultYellowAt = ExcludeYellowCharsAsync();
			var resultGreenAt = CharGreenInWordAsync();
			var result = await Task.WhenAll(resultNotIn, resultYellowAt, resultGreenAt);
			var data = result[0].Intersect(result[1]).Intersect(result[2]);
			words = data.ToList();
			await delay;
			Debug.WriteLine("async running for {0} s ", sw.Elapsed.TotalSeconds);
			Cleaner();
			Debug.WriteLine("done");
		}
	}
}
//async running for 0,0016121 s 
//async running for 0,0074788 s 

//sync running for 0,0009165 s 
//sync running for 0,0043043 s 
