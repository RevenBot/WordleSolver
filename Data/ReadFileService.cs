using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace WordleSolver.Data
{
    public sealed class ReadFileService
    {
        private static List<Word> wordList = null;
        public ReadFileService()
        {
        }

        public static async Task<List<Word>> GetWordsListAsync(string path)
        {

            if(wordList == null)
            {
            using var stream = await FileSystem.OpenAppPackageFileAsync(path);
            using var reader = new StreamReader(stream);
            var data = await reader.ReadToEndAsync();
            wordList = data.Split("\n").Select(i=>new Word
            {
                StringWord= i,
            }).ToList();
                return wordList;
            }
            else
            {
                return wordList;
            }
        }
    }
}
