using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PlaneBooking.Data
{
    public class TutorAvailability
    {
        [Key]
        public int Id { get; set; }


        [DataType(DataType.DateTime)]
        [Display(Name = "Available From")]
        public DateTime DateFrom { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Available Until")]
        public DateTime DateUntil { get; set; }

    }
}
