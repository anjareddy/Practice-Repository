
using Microsoft.AspNetCore.Identity;
namespace Users.DAL.Models;

public partial class ApplicationUser: IdentityUser
{
    public string MobileNumber { get; set; }
}
