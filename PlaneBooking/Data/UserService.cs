using PlaneBooking.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PlaneBooking.Data
{
    public class UserService
    {
        private readonly PlaneBookingDBContext _context;
        public UserService(PlaneBookingDBContext context)
        {
            _context = context;
        }

        public AppUser GetUserById(int id)
        {
            var appUser = _context.AppUsers.Find(id);
            return appUser;
        }

        public List<Claim> GetUserClaims(AppUser appUser)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier, appUser.Email));
            claims.Add(new Claim(ClaimTypes.Name, appUser.Name));
            claims.Add(new Claim(ClaimTypes.GivenName, appUser.Firstname));
            claims.Add(new Claim(ClaimTypes.Surname, appUser.Lastname));
            claims.Add(new Claim(ClaimTypes.Email, appUser.Email));
            claims.Add(new Claim(ClaimTypes.Role, appUser.Role));
            return claims;    
        }

        public AppUser ValidateUser(string email, string password)
        {
            var appUser = _context.AppUsers
                .Where(a => a.Email == email)
                .Where(a => a.Password == password).FirstOrDefault();

            return appUser; // is null);

            //if (appUser is null)
            //{
            //    return false;
            //}
            //else
            //{
            //    claims.Add(new Claim(ClaimTypes.NameIdentifier, appUser.Email));
            //    claims.Add(new Claim(ClaimTypes.Name, appUser.Name));
            //    claims.Add(new Claim(ClaimTypes.GivenName, appUser.Firstname));
            //    claims.Add(new Claim(ClaimTypes.Surname, appUser.Lastname));
            //    claims.Add(new Claim(ClaimTypes.Email, appUser.Email));
            //    claims.Add(new Claim(ClaimTypes.Role, appUser.Role));                
            //    return true;
            //}
        }

        public AppUser AddUser(AppUser appUser)
        {
            var existingUser = _context.AppUsers
                .Where(a => a.Email == appUser.Email).FirstOrDefault();

            if (existingUser is null)
            {
                var entity = _context.AppUsers.Add(appUser);
                _context.SaveChanges();
                return entity.Entity;
            }
            return null;
        }

        //public AppUser AddNewUser(List<Claim> claims)
        //{
        //    var appUser = new AppUser();
        //    appUser.Firstname = claims.GetClaim(ClaimTypes.GivenName);
        //    appUser.Lastname = claims.GetClaim(ClaimTypes.Surname);
        //    appUser.Email = claims.GetClaim(ClaimTypes.Email);   
            
        //    appUser.Role = "Student";
        //    var entity = _context.AppUsers.Add(appUser);
        //    _context.SaveChanges();
        //    return entity.Entity;
        //}
    }

    public static class Extensions
    {
        public static string GetClaim(this List<Claim> claims, string name)
        {
            return claims.FirstOrDefault(c => c.Type == name)?.Value;
        }
    }
}

