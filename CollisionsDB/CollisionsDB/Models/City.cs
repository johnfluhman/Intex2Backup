using System;
using System.ComponentModel.DataAnnotations;

namespace CollisionsDB.Models
{
    public class City
    {
        [Key, Required]
        public int CityId { get; set; }
        [Required]
        public string CityName { get; set; }
    }
}
