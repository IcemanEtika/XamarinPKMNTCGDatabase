using System.Collections.Generic;

namespace PokemonTCG.ModelClass
{
    public class TCGSets
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

        public TCGSets(string id, string name, string series, int printedTotal, int total, Legalities legalities, string ptcggoCode,
            string releaseDate, string updatedAt, Images images) {
            this.id = id;
            this.name = name;
            this.series = series;
            this.printedTotal = printedTotal;
            this.total = total;
            this.legalities = legalities;
            this.ptcgoCode = ptcgoCode;
            this.releaseDate = releaseDate;
            this.updatedAt = updatedAt;
            this.images = images;

        }
    }

    public class Legalities
    {
        public string unlimited { get; set; }
        public string expanded { get; set; }
    }

    public class Images
    {
        public string symbol { get; set; }
        public string logo { get; set; }
    }

    public class Root
    {
        public List<TCGSets> data { get; set; }
        public int page { get; set; }
        public int pageSize { get; set; }
        public int count { get; set; }
        public int totalCount { get; set; }
    }

}
        