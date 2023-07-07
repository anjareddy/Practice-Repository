using Users.DAL.DBContext;
using Users.DAL.Models;
using Users.DAL.Repositories.Interfaces;
using Users.ReadModels;

namespace Users.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private UsersDbContext _context;
        public UserRepository(UsersDbContext context) 
        {
            _context = context;
        }

        public bool DeleteUser(int id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            if (user != null)
            {
                _context.Users.Remove(user);
            }
            else
            {
                throw new Exception("User doesn't Exists");
            }
            
            _context.SaveChanges();

            return true;
        }

        public ReadModels.User GetUserById(int id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            return new ReadModels.User
            {
                Id = user.Id,
                EmailId = user.EmailId,
                EmergencyContactName = user.EmergencyContactName,
                EmergencyContactEmailId = user.EmergencyContactEmailId,
                EmergencyContactMobileNumber = user.EmergencyContactMobileNumber,
                MobileNumber = user.MobileNumber,
                Name = user.Name,
            };
        }

        public List<ReadModels.User> GetUsers()
        {
            return _context.Users.Select(x => new ReadModels.User
            {
                Id = x.Id,
                EmailId = x.EmailId,
                EmergencyContactName = x.EmergencyContactName,
                EmergencyContactEmailId = x.EmergencyContactEmailId,
                EmergencyContactMobileNumber = x.EmergencyContactMobileNumber,
                MobileNumber = x.MobileNumber,
                Name = x.Name,
            }).ToList();
        }

        public bool SaveUser(ReadModels.User user)
        {
            Models.User dalUser = new Models.User
            {
                Id = user.Id,
                EmailId = user.EmailId,
                EmergencyContactName = user.EmergencyContactName,
                EmergencyContactEmailId = user.EmergencyContactEmailId,
                EmergencyContactMobileNumber = user.EmergencyContactMobileNumber,
                MobileNumber = user.MobileNumber,
                Name = user.Name,
            };

            _context.Users.Add(dalUser);
            _context.SaveChanges();

            return true;
        }

        public void UpdateUser(ReadModels.User user)
        {
            var dalUser = _context.Users.FirstOrDefault(x => x.Id == user.Id);
            dalUser.EmailId = user.EmailId;
            dalUser.EmergencyContactName = user.EmergencyContactName;
            dalUser.EmergencyContactEmailId = user.EmergencyContactEmailId;
            dalUser.EmergencyContactMobileNumber = user.EmergencyContactMobileNumber;
            dalUser.MobileNumber = user.MobileNumber;
            dalUser.Name = user.Name;
            _context.SaveChanges();
        }
    }
}
