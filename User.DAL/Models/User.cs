
namespace Users.DAL.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? EmailId { get; set; }

    public string? MobileNumber { get; set; }

    public string? EmergencyContactEmailId { get; set; }

    public string? EmergencyContactMobileNumber { get; set; }
}
