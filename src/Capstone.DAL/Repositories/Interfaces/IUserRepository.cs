using Users.ReadModels;

namespace Users.DAL.Repositories.Interfaces
{
    public interface IUserRepository
    {
        bool DeleteUser(int id);
        User GetUserById(int id);
        List<User> GetUsers();
        bool SaveUser(User user);
        void UpdateUser(User user);
    }
}
