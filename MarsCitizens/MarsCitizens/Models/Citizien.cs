using System;

namespace MarsCitizens.Models
{
    public class Citizien
    {
        public string Name { get; set; }

        public string Image { get; set; }

        public string Thumbnail { get; set; }

        public string LivingDays => $"{(DateTime.Today - LandingDate).Days} Days on Mars";

        public DateTime LandingDate { get; set; }
    }
}
