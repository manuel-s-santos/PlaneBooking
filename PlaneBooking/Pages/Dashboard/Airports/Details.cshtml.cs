using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PlaneBooking.Data;

namespace PlaneBooking.Pages.Dashboard.Airports
{
    public class DetailsModel : PageModel
    {
        private readonly PlaneBooking.Data.PlaneBookingDBContext _context;

        public DetailsModel(PlaneBooking.Data.PlaneBookingDBContext context)
        {
            _context = context;
        }

        public Airport Airport { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Airport = await _context.Airports.FirstOrDefaultAsync(m => m.AirportId == id);

            if (Airport == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
