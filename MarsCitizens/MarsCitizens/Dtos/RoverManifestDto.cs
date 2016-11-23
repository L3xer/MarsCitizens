using Newtonsoft.Json;
using MarsCitizens.Models;

namespace MarsCitizens.Dtos
{
    public class RoverManifestDto
    {
        [JsonProperty(PropertyName = "photo_manifest")]
        public RoverManifest Manifest { get; set; }
    }
}
