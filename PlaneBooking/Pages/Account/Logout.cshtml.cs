using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using PlaneBooking.Data;

namespace PlaneBooking.Pages.Account
{
    [AllowAnonymous]
    public class LogoutModel : PageModel
    {
     
        private readonly ILogger<LogoutModel> _logger;

        public LogoutModel(ILogger<LogoutModel> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> OnGet()
        {
            await HttpContext.SignOutAsync();
            _logger.LogInformation("User logged out.");

            return RedirectToPage("/Index");
         }

        //public async Task<IActionResult> OnPost()
        //{
        //    //await _signInManager.SignOutAsync();
        //    await HttpContext.SignOutAsync();
        //    _logger.LogInformation("User logged out.");

        //        return RedirectToPage();
         
        //}
    }
}
