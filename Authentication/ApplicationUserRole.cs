using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace IndigenousLanguages.Authentication
{
    public class ApplicationUserRole : IdentityUserRole<int>
    {

        public ApplicationUser ApplicationUser { get; set; }
        public ApplicationRole ApplicationRole { get; set; }
    }
}
