using System;
using Newtonsoft.Json;

namespace MarsCitizens.Models
{
    public class Photo
    {
        [JsonProperty(PropertyName = "img_src")]
        public string Url { get; set; }

        public Camera Camera { get; set; }

        [JsonProperty(PropertyName = "earth_date")]
        public DateTime EarthDate { get; set; }

        public int Sol { get; set; }

        public string CameraName => Camera.FullName;

        public string FormattedDescription => $"Sol {Sol} {EarthDate.ToString("dd MMM yyyy")}";
    }
}
