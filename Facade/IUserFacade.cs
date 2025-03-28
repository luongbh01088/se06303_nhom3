using WEB_Student.Models;

namespace WEB_Student.Facade
{
    public interface IUserFacade
    {
        string RegisterUser(string username, string email, string password, int roleId, string fullName, string phone);
        void Register(User user);

        User LoginUser(string username, string password);
    }
}
