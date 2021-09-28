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
    public class DeleteModel : PageModel
    {
        private readonly PlaneBooking.Data.PlaneBookingDBContext _context;

        public DeleteModel(PlaneBooking.Data.PlaneBookingDBContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AppUser = await _context.AppUsers.FindAsync(id);

            if (AppUser != null)
            {
                _context.AppUsers.Remove(AppUser);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
