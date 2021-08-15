using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace  IndigenousLanguages.Authentication
{
    public class ApplicationRole : IdentityRole<int>
    {
        public ICollection<ApplicationUserRole> ApplicationUserRoles { get; set; }
    }
}
