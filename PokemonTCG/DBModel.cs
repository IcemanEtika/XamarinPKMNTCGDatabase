using SQLite;

namespace PokemonTCG
{
    public class DBModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string name { get; set; }
        public string imgSmall { get; set; }
        public string imgLarge { get; set; }
        public string rarity { get; set; }
        public string artist { get; set; }
        public string setName { get; set; }
        public string setNumber { get; set; }
        public int setTotal { get; set; }

    }
}
