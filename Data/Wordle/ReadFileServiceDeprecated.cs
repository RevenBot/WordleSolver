using System.Diagnostics;

namespace WordleSolver.Data.Wordle
{
	public static class ReadFileServiceDeprecated
	{
		private static List<Word> wordsList = null;
		public static async Task<List<Word>> GetWordsListAsync(string path)
		{
			if (wordsList != null)
			{
				Debug.WriteLine("File already loaded");
				return wordsList;
			}

			try
			{
				using var stream = await FileSystem.OpenAppPackageFileAsync(path);
				using var reader = new StreamReader(stream);
				var data = await reader.ReadToEndAsync();
				wordsList = new List<Word>();
				foreach (string s in data.Split("\n"))
				{
					wordsList.Add(new Word(s));
				}
				wordsList.Sort();

				await Utilities.CreateToast($"Succesfully read {wordsList.Count} words");
				return wordsList;
			}
			catch (FileNotFoundException ex)
			{
				Debug.WriteLine(ex);
				throw ex;
			}
		}
	}
}
