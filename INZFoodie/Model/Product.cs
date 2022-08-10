using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace INZFoodie.Model
{
    public class Product
    {
        [JsonProperty("Barcode")]
        public string Barcode { get; set; } = string.Empty;
        [JsonProperty("ProductName")]
        public string ProductName { get; set; } = string.Empty;
        [JsonProperty("Producer")]
        public string Producer { get; set; } = string.Empty;
        [JsonProperty("ProductWeight")]
        public string ProductWeight { get; set; } = string.Empty;
        [JsonProperty("Kcal100")]
        public string Kcal100 { get; set; } = string.Empty;
        [JsonProperty("KcalTotal")]
        public string KcalTotal { get; set; } = string.Empty;
        [JsonProperty("Fat")]
        public string Fat { get; set; } = string.Empty;
        [JsonProperty("SaturatesFat")]
        public string SaturatesFat { get; set; } = string.Empty;
        [JsonProperty("Carbohydrate")]
        public string Carbohydrate { get; set; } = string.Empty;
        [JsonProperty("Sugar")]
        public string Sugar { get; set; } = string.Empty;
        [JsonProperty("Protein")]
        public string Protein { get; set; } = string.Empty;
        [JsonProperty("Salt")]
        public string Salt { get; set; } = string.Empty;
        [JsonProperty("Ingredients")]
        public List<Ingredient> Ingredients { get; set; } 
    }
}
