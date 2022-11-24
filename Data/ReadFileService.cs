using System.Diagnostics;

namespace WordleSolver.Data
{
	public static class ReadFileService
	{
		private static List<string> wordList = null;
		public static async Task<List<string>> GetWordsListAsync(string path)
		{
			if (wordList != null)
			{
				Debug.WriteLine("File already loaded");
				return wordList;
			}

			try
			{
				using var stream = await FileSystem.OpenAppPackageFileAsync(path);
				using var reader = new StreamReader(stream);
				var data = await reader.ReadToEndAsync();
				wordList = data.Split("\n").Select(i => i).ToList();

				Debug.WriteLine("File read successfully");
				return wordList;
			}
			catch (FileNotFoundException ex)
			{
				Debug.WriteLine(ex);
				throw ex;
			}
		}
	}
}
