using System;
using System.Collections.Generic;
using System.Text;

namespace PokemonTCG.ModelClass
{

    public class Cards
    {
        public string id { get; set; }
        public string name { get; set; }
        public string supertype { get; set; }
        public string[] subtypes { get; set; }
        public string level { get; set; }
        public string hp { get; set; }
        public string[] types { get; set; }
        public string evolvesFrom { get; set; }
        public Ability[] abilities { get; set; }
        public Attack[] attacks { get; set; }
        public Weakness[] weaknesses { get; set; }
        public string[] retreatCost { get; set; }
        public int convertedRetreatCost { get; set; }
        public Set set { get; set; }
        public string number { get; set; }
        public string artist { get; set; }
        public string rarity { get; set; }
        public string flavorText { get; set; }
        public int[] nationalPokedexNumbers { get; set; }
        public Legalities1 legalities { get; set; }
        public Images1 images { get; set; }
        public Tcgplayer tcgplayer { get; set; }
        public Cardmarket cardmarket { get; set; }
        public string[] evolvesTo { get; set; }
        public Resistance[] resistances { get; set; }
        public string[] rules { get; set; }

        public Cards(string id, string name, string supertype, string[] subtypes, string level, string hp, string[] types, string evolvesFrom, Ability[] abilities, 
            Attack[] attacks, Weakness[] weaknesses, string[] retreatCost, int convertedRetreatCost, Set set, string number, string artist, string rarity, 
            string flavorText, int[] nationalPokedexNumbers, Legalities1 legalities, Images1 images, Tcgplayer tcgplayer, Cardmarket cardmarket, string[] evolvesTo, 
            Resistance[] resistances, string[] rules)
        {
            this.id = id;
            this.name = name;
            this.supertype = supertype;
            this.subtypes = subtypes;
            this.level = level;
            this.hp = hp;
            this.types = types;
            this.evolvesFrom = evolvesFrom;
            this.abilities = abilities;
            this.attacks = attacks;
            this.weaknesses = weaknesses;
            this.retreatCost = retreatCost;
            this.convertedRetreatCost = convertedRetreatCost;
            this.set = set;
            this.number = number;
            this.artist = artist;
            this.rarity = rarity;
            this.flavorText = flavorText;
            this.nationalPokedexNumbers = nationalPokedexNumbers;
            this.legalities = legalities;
            this.images = images;
            this.tcgplayer = tcgplayer;
            this.cardmarket = cardmarket;
            this.evolvesTo = evolvesTo;
            this.resistances = resistances;
            this.rules = rules;
        }
    }

    public class Set
    {
        public string id { get; set; }
        public string name { get; set; }
        public string series { get; set; }
        public int printedTotal { get; set; }
        public int total { get; set; }
        public Legalities legalities { get; set; }
        public string ptcgoCode { get; set; }
        public string releaseDate { get; set; }
        public string updatedAt { get; set; }
        public Images images { get; set; }
    }

    public class Legalities1
    {
        public string unlimited { get; set; }
        public string expanded { get; set; }
        public string standard { get; set; }
    }

    public class Images1
    {
        public string small { get; set; }
        public string large { get; set; }
    }

    public class Tcgplayer
    {
        public string url { get; set; }
        public string updatedAt { get; set; }
        public Prices prices { get; set; }
    }

    public class Prices
    {
        public Holofoil holofoil { get; set; }
        public _1Steditionholofoil _1stEditionHolofoil { get; set; }
        public Normal normal { get; set; }
    }

    public class Holofoil
    {
        public float? low { get; set; }
        public float? mid { get; set; }
        public float? high { get; set; }
        public float? market { get; set; }
        public float? directLow { get; set; }
    }

    public class _1Steditionholofoil
    {
        public float? low { get; set; }
        public float? mid { get; set; }
        public float? high { get; set; }
        public float? market { get; set; }
        public float? directLow { get; set; }
    }

    public class Normal
    {
        public float? low { get; set; }
        public float? mid { get; set; }
        public float? high { get; set; }
        public float? market { get; set; }
        public float? directLow { get; set; }
    }

    public class Cardmarket
    {
        public string url { get; set; }
        public string updatedAt { get; set; }
        public Prices1 prices { get; set; }
    }

    public class Prices1
    {
        public float? averageSellPrice { get; set; }
        public float? lowPrice { get; set; }
        public float? trendPrice { get; set; }
        public object germanProLow { get; set; }
        public object suggestedPrice { get; set; }
        public object reverseHoloSell { get; set; }
        public object reverseHoloLow { get; set; }
        public float? reverseHoloTrend { get; set; }
        public float? lowPriceExPlus { get; set; }
        public float? avg1 { get; set; }
        public float? avg7 { get; set; }
        public float? avg30 { get; set; }
        public float? reverseHoloAvg1 { get; set; }
        public float? reverseHoloAvg7 { get; set; }
        public float? reverseHoloAvg30 { get; set; }
    }

    public class Ability
    {
        public string name { get; set; }
        public string text { get; set; }
        public string type { get; set; }
    }

    public class Attack
    {
        public string name { get; set; }
        public string[] cost { get; set; }
        public int convertedEnergyCost { get; set; }
        public string damage { get; set; }
        public string text { get; set; }
    }

    public class Weakness
    {
        public string type { get; set; }
        public string value { get; set; }
    }

    public class Resistance
    {
        public string type { get; set; }
        public string value { get; set; }
    }


    public class Rootobject
    {
        public Cards[] data { get; set; }
        public int page { get; set; }
        public int pageSize { get; set; }
        public int count { get; set; }
        public int totalCount { get; set; }
    }
}
