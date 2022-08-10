using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace INZFoodie.Model
{
    public class Ingredient
    {
        [JsonProperty("IdIgredient")]
        public int IdIgredient { get; set; }
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("Info")]
        public string Info { get; set; }
        [JsonProperty("HealthInfo")]
        public int HealthInfo { get; set; }
        [JsonIgnore]
        public string Color { get; set; }
        [JsonIgnore]
        public List<Product> Product { get; set; }


    }
}
