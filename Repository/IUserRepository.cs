using WEB_Student.Models;

namespace WEB_Student.Repository
{
    public interface IUserRepository
    {
        User GetUserByUsername(string username);
        void AddUser(User user);

        User AuthenticateUser(string username, string password);
    }
}
