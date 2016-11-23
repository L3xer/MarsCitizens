using System.Collections.Generic;
using MarsCitizens.Models;


namespace MarsCitizens.Dtos
{
    public class CameraDataDto
    {
        public IEnumerable<Photo> Photos { get; set; }
    }
}
