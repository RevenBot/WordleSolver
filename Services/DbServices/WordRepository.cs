using SQLite;
using System.Diagnostics;
using WordleSolver.Data.Wordle;

namespace WordleSolver.Services.DbServices
{
    public class WordRepository
    {
        public string _dbPath;
        public string StatusMessage { get; set; }
        public SQLiteAsyncConnection conn;

        public WordRepository(string dbPath)
        {
            _dbPath = dbPath;
        }
        private async Task Init()
        {
            if (conn != null)
            {
                return;
            }
            conn = new SQLiteAsyncConnection(_dbPath);
            await conn.CreateTableAsync<Word>();
        }
        public async Task AddNewWord(string value)
        {
            int result;
            try
            {
                await Init();
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Valid word required");
                }
                result = await conn.InsertAsync(new Word { Value = value });
                StatusMessage = $"{result} record added : {value}";
            }
            catch (Exception e)
            {
                StatusMessage = $"Failed to add {value}. Error {e.Message} ";
            }
        }
        public async Task<List<Word>> GetAllWords()
        {
            try
            {
                Debug.WriteLine("try");
                await Init();
                return await conn.Table<Word>().ToListAsync() ;
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
                Debug.WriteLine(StatusMessage);
            }

            return new List<Word>();
        }

        public async Task<Word> GetWord(string value)
        {
            await Init();

            var word = await (from u in conn.Table<Word>()
                              where u.Value == value
                              select u).ToListAsync();

            return word.FirstOrDefault();
        }
    }
}