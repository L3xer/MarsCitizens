using System;

namespace MarsCitizens.Models
{
    public class Citizen
    {
        public string Name { get; set; }

        public string Image { get; set; }

        public string Thumbnail { get; set; }

        public string Wiki { get; set; }

        public DateTime LandingDate { get; set; }

        public DateTime LaunchDate { get; set; }

        public string Operator { get; set; }

        public string Rocket { get; set; }

        public string Status { get; set; }

        public string LivingDays => $"{(DateTime.Today - LandingDate).Days} Days on Mars";
    }
}
