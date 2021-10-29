using SQLite;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PokemonTCG
{
    public class DatabaseManager
    {
        SQLiteAsyncConnection _connection;
        public DatabaseManager()
        {
            _connection = DependencyService.Get<DBInterface>().createDB();
        }

        async public Task<ObservableCollection<DBModel>> CreateTable()
        {
            await _connection.CreateTableAsync<DBModel>();
            var dbResult = await _connection.Table<DBModel>().ToListAsync();
            var results = new ObservableCollection<DBModel>(dbResult);
            return results;
        }

        async public void AddNewCard(DBModel card)
        {
            await _connection.InsertAsync(card);
        }

        async public void RemoveCard(DBModel card)
        {
            await _connection.DeleteAsync(card);
        }

        async public Task<string> RemoveAllCards()
        {
            await _connection.DeleteAllAsync<DBModel>();
            return "Success";
        }
    }
}
