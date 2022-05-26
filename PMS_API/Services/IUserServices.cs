using PMS_API;

namespace PMS_API
{
    public interface IUserServices
    {
        bool AddUser(User item);
        bool Disable(int id);
        IEnumerable<User> GetallUsers();
        object GetUser(int id);
        bool Save();
        bool UpdateUser(User item);
    }
}