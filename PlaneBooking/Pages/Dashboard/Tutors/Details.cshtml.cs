using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PlaneBooking.Data;

namespace PlaneBooking.Pages.Dashboard.Tutors
{
    public class DetailsModel : PageModel
    {
        private readonly PlaneBooking.Data.PlaneBookingDBContext _context;

        public DetailsModel(PlaneBooking.Data.PlaneBookingDBContext context)
        {
            _context = context;
        }

        public AppUser AppUser { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AppUser = await _context.AppUsers.FirstOrDefaultAsync(m => m.UserId == id);

            if (AppUser == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
