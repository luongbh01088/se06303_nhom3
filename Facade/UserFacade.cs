using System.Net;
using WEB_Student.Models;
using WEB_Student.Repository;

namespace WEB_Student.Facade
{
    public class UserFacade : IUserFacade
    {
        private readonly IUserRepository _userRepository;

        public UserFacade(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User LoginUser(string username, string password)
        {
            return _userRepository.AuthenticateUser(username, password);
        }

        public void Register(User user)
        {
            _userRepository.AddUser(user);
        }

        public string RegisterUser(string username, string email, string password, int roleId, string fullName, string phone)
        {
            if (_userRepository.GetUserByUsername(username) != null)
            {
                return "Username already exists!";
            }

            var newUser = new User
            {
                FullName = fullName,
                Email = email,
                Password = password,
                RoleId = roleId,
                Username = username,
                Phone = phone
            };

            _userRepository.AddUser(newUser);
            return "User registered successfully!";
        }
    }
}
