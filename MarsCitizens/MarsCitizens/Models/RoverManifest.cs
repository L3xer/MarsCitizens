using Newtonsoft.Json;

namespace MarsCitizens.Models
{
    public class RoverManifest
    {
        [JsonProperty(PropertyName = "max_sol")]
        public int MaxSol { get; set; }
    }
}
