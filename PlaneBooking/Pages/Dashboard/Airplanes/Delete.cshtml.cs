using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PlaneBooking.Data;

namespace PlaneBooking.Pages.Dashboard.Airplanes
{
    public class DeleteModel : PageModel
    {
        private readonly PlaneBooking.Data.PlaneBookingDBContext _context;

        public DeleteModel(PlaneBooking.Data.PlaneBookingDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Airplane Airplane { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Airplane = await _context.Airplanes.FirstOrDefaultAsync(m => m.AirplaneId == id);

            if (Airplane == null)
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

            Airplane = await _context.Airplanes.FindAsync(id);

            if (Airplane != null)
            {
                _context.Airplanes.Remove(Airplane);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
