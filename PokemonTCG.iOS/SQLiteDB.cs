using SQLite;
using System;
using System.IO;
using System.Runtime.CompilerServices;

[assembly: Xamarin.Forms.Dependency(typeof(PokemonTCG.iOS.SQLiteDB))]
namespace PokemonTCG.iOS
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
