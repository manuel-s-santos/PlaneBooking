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
    public class IndexModel : PageModel
    {
        private readonly PlaneBooking.Data.PlaneBookingDBContext _context;

        public IndexModel(PlaneBooking.Data.PlaneBookingDBContext context)
        {
            _context = context;
        }

        public IList<Airplane> Airplane { get;set; }

        public async Task OnGetAsync()
        {
            Airplane = await _context.Airplanes.ToListAsync();
        }
    }
}
