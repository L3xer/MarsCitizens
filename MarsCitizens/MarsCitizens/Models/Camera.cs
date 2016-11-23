using Newtonsoft.Json;

namespace MarsCitizens.Models
{
    public class Camera
    {
        [JsonProperty(PropertyName = "full_name")]
        public string FullName { get; set; }
    }
}
