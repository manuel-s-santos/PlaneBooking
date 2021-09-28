using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PlaneBooking.Data
{
    public class Airport
    {

        [Key]
        public int AirportId { get; set; }

        [Required]
        public string AirportName { get; set; }


    }
}
