using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LamaPlugin;
using RestSharp;

namespace ManiaExchange
{
    public struct MXMap
    {
        public int Id { get; set; }
        public string UId { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Version { get; set; }
        public int Cost { get; set; }
    }

    public class ManiaExchange
    {

        RestClient client;
        private Logger Log;

        
        public ManiaExchange(Game game,Logger log)
        {
            this.Log = log;
            string uri;

            if(game == Game.ShootMania)
            {
                uri = "https://sm.mania-exchange.com";
            }
            else
            {
                uri = "https://tm.mania-exchange.com";
            }

            client = new RestClient(uri);

        

            //foreach (JsonObject obj in pluginsList)
        }

        public List<MXMap> getMapList()
        {
            //  mapsearch2 / search ? api = on

            RestRequest request = new RestRequest("mapsearch2/search?api=on", DataFormat.Json);

            IRestResponse response = client.Get(request);

            JsonObject mapList = (JsonObject)SimpleJson.DeserializeObject(response.Content);

            
            
            foreach(KeyValuePair<string, object> kvp in mapList)
            {
                Log("TEST", kvp.Key + " - " + kvp.Value);
            }

            return null;
        }
       

    }
}
