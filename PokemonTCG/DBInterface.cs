using System;
using SQLite;

namespace PokemonTCG
{
    public interface DBInterface
    {
        SQLiteAsyncConnection createDB();
    }
}
