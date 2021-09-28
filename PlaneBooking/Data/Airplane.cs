using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PlaneBooking.Data
{
    public class Airplane
    {
        [Key]
        public int AirplaneId { get; set; }

        [Required]
        public string AirPlaneName { get; set; }

        [Display(Name="Available")]
        public bool IsAvailable { get; set; }


    }
}
