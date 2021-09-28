using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PlaneBooking.Data
{
    public class AppUser
    {
        [Key]
        public int UserId { get; set; }

        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Role { get; set; }

        public string Name { get { return Firstname + ' ' + Lastname; } }

        //public virtual ICollection<AirplaneBooking> Bookings { get; set; }
//public virtual ICollection<AirplaneBooking> TutorBookings { get; set; }

    }
}
