using System.ComponentModel;

namespace Users.ReadModels
{
    public class User
    {
        public int Id { get; set; }

        [DisplayName("Full Name")]
        public string Name { get; set; }

        [DisplayName("Email Id")]
        public string EmailId { get; set; }
        
        [DisplayName("Mobile")]
        public string MobileNumber { get; set; }

        [DisplayName("Emergency Contact Email")]
        public string EmergencyContactEmailId { get; set; }

        [DisplayName("Emergency Contact Mobile")]
        public string EmergencyContactMobileNumber { get; set; }

    }
}
