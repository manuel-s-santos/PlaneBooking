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
    public class IndexModel : PageModel
    {
        private readonly PlaneBooking.Data.PlaneBookingDBContext _context;

        public IndexModel(PlaneBooking.Data.PlaneBookingDBContext context)
        {
            _context = context;
        }

        public IList<Airport> Airport { get;set; }

        public async Task OnGetAsync()
        {
            Airport = await _context.Airports.ToListAsync();
        }
    }
}
