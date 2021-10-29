using Newtonsoft.Json;
using PokemonTCG.ModelClass;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace PokemonTCG
{
    class NetworkingManager
    {
        HttpClient client = new HttpClient();
        string url = "https://api.pokemontcg.io/v2/";
        public NetworkingManager()
        {
            client.DefaultRequestHeaders.Add("X-Api-Key", "961ffd89-3b26-43c0-8b5d-67822bf50d9e");
        }
        async public Task<List<TCGSets>> getSets()
        {
            string completeURL = url + "sets";
            var response = await client.GetAsync(completeURL);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return new List<TCGSets>();
            }
            else
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var dic = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonString.ToString()); 
                var array = dic["data"];
                var setList = JsonConvert.DeserializeObject<List<TCGSets>>(array.ToString());
           
                return setList;
            }
        }

        async public Task<List<Cards>> getCards(string query)
        {
            string completeURL = url + "cards?q=set.id:" + query;
            var response = await client.GetAsync(completeURL);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return new List<Cards>();
            }
            else
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var dic = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonString.ToString()); 
                var array = dic["data"];

                var cardList = JsonConvert.DeserializeObject<List<Cards>>(array.ToString());

                return cardList;
            }
        }
    }
}
