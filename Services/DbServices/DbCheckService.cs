using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordleSolver.Services.DbService
{
    public static class DbCheckService 
    {
        public const string nameDB = "DbWords.db3";

        public static string Start(string nameDB)
        {
            Debug.WriteLine("check if loca");
            if (!IsInLocal(nameDB))
            {
            Debug.WriteLine("not in loocal");
                return Transfer(nameDB).Result;
            }
            Debug.WriteLine("in loocal");
            return System.IO.Path.Combine(FileSystem.Current.AppDataDirectory, nameDB);
        }
        private static bool IsInLocal(string nameDB)
        {
            string pathDb = System.IO.Path.Combine(FileSystem.Current.AppDataDirectory, nameDB);
            return File.Exists(pathDb);

        }
        private static async Task<string> Transfer(string nameDB)
        {

            string targetPath = Path.Combine(FileSystem.Current.AppDataDirectory, nameDB);
            using FileStream outputStream = System.IO.File.OpenWrite(targetPath);
            using var fileStream = await FileSystem.Current.OpenAppPackageFileAsync(nameDB);
            fileStream.CopyTo(outputStream);
            return targetPath;
        }


    }

}
