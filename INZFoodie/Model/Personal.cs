using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace INZFoodie.Model
{
    public class Personal
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("IdUser")]
        public Guid IdUser { get; set; }
        [JsonProperty("Mass")]
        public string Mass { get; set; } = string.Empty;
        [JsonProperty("Height")]
        public string Height { get; set; } = string.Empty;
        [JsonProperty("Age")]
        public string Age { get; set; } = string.Empty;
        [JsonProperty("Gender")]
        public string Gender { get; set; } = string.Empty;
        [JsonProperty("Pal")]
        public string Pal { get; set; } = string.Empty;
        [JsonProperty("Target")]
        public string Target { get; set; } = string.Empty;
        [JsonProperty("CPM")]
        public string CPM { get; set; } = string.Empty;
        [JsonProperty("Protein")]
        public string Protein { get; set; } = string.Empty;
        [JsonProperty("Carbonates")]
        public string Carbonates { get; set; } = string.Empty;
        [JsonProperty("Fat")]
        public string Fat { get; set; } = string.Empty;
        [JsonProperty("CPMTarget")]
        public string CPMTarget { get; set; } = string.Empty;
        [JsonProperty("IdealBodyMass")]
        public string IdealBodyMass { get; set; } = string.Empty;
        [JsonProperty("ProteinPer")]
        public double ProteinPer { get; set; } 
        [JsonProperty("CarbonatesPer")]
        public double CarbonatesPer { get; set; } 
        [JsonProperty("FatPer")]
        public double FatPer { get; set; }
        [JsonProperty("SaveTime")]
        public DateTime SaveTime { get; set; }

    }
}
