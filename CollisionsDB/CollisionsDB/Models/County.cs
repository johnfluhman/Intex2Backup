using System;
using System.ComponentModel.DataAnnotations;

namespace CollisionsDB.Models
{
    public class County
    {
        [Required, Key]
        public int CountyId { get; set; }

        [Required]
        public string CountyName { get; set; }
    }
}
