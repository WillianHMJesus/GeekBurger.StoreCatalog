using Newtonsoft.Json;
using System.Collections.Generic;

namespace GeekBurger.StoreCatalog.Contract
{
    public class Item
    {
        [JsonProperty("id")]
        public string ItemId { get; set; }
        [JsonProperty("ingredients")]
        public IEnumerable<string> ingredients { get; set; }
    }
}
