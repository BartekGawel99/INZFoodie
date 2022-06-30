using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace INZFoodie.Model
{
    public class Ingredient
    {
        [JsonProperty("idIgredient")]
        public string IdIgredient { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("info")]
        public string Info { get; set; }
        [JsonProperty("healthInfo")]
        public int HealthInfo { get; set; }       
  
    }
}
