using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PlaneBooking.Data;

namespace PlaneBooking.Pages.Dashboard.Airplanes
{
    public class CreateModel : PageModel
    {
        private readonly PlaneBooking.Data.PlaneBookingDBContext _context;

        public CreateModel(PlaneBooking.Data.PlaneBookingDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Airplane Airplane { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Airplanes.Add(Airplane);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
