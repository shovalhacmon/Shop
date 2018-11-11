using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Shop.Data
{
    public static class Authorization
    {
        //emails of admins
        public static List<String> GetAdmins(ApplicationDbContext _context)
        {
            return (from userRole in _context.UserRoles
                    join user in _context.Users on userRole.UserId equals user.Id
                    select user.Email).ToList();
        }

        public static bool IsAdmin(ClaimsPrincipal user, ApplicationDbContext _context)
        {
            return GetAdmins(_context).Contains(user.Identity.Name);
        }
    }
}
