using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PlaneBooking.Data
{
    public class AirplaneBooking
    {
        [Key]
        public int BookingId { get; set; }

        public int AirplaneId { get; set; }
        public virtual Airplane Airplane { get; set; }

        public int AirportId { get; set; }
        public virtual Airport Airport { get; set; }

        public int StudentId { get; set; }

        [ForeignKey("StudentId")]
        public virtual AppUser Student { get; set; }

        public int TutorId { get; set; }

        [ForeignKey("TutorId")]
        public virtual AppUser Tutor { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name="Booking Date")]
        public DateTime BookingDate { get; set; }

        [Display(Name = "Duration (minutes)")]
        [Range(60,300,ErrorMessage ="Minimun 60 minutes and maximum 300 minutes")]
        public int DurationMinutes { get; set; }

        public bool IsValidated { get; set; }

    }
}
