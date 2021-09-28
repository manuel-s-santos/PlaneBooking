using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PlaneBooking.Data;

namespace PlaneBooking.Pages.Dashboard.Airplanes
{
    public class EditModel : PageModel
    {
        private readonly PlaneBooking.Data.PlaneBookingDBContext _context;

        public EditModel(PlaneBooking.Data.PlaneBookingDBContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Airplane).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AirplaneExists(Airplane.AirplaneId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AirplaneExists(int id)
        {
            return _context.Airplanes.Any(e => e.AirplaneId == id);
        }
    }
}
