using SQLite;
using System;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(PokemonTCG.Droid.SQLiteDB))]
namespace PokemonTCG.Droid
{
    public class SQLiteDB : DBInterface
    {

        public SQLiteAsyncConnection createDB()
        {
            var document_path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(document_path, "pkmnDB.db3");
            return new SQLiteAsyncConnection(path);
        }
    }
}
