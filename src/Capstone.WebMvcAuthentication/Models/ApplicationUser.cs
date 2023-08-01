using Microsoft.AspNetCore.Identity;

namespace Capstone.WebMvcAuthentication.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
