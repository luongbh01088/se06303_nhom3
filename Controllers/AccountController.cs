using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WEB_Student.Data;
using WEB_Student.Facade;
using WEB_Student.Models;
using WEB_Student.Repository;

namespace WEB_Student.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserFacade _userFacade;
        private readonly ApplicationDbContext _context;

        public AccountController(IUserFacade userFacade, ApplicationDbContext context)
        {
            _userFacade = userFacade;
            _context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Register(string fullName, string email, string password, int roleId, string username, string phone)
        {
            string result = _userFacade.RegisterUser(fullName, email, password, roleId, username, phone);

            if (result == "User registered successfully!")
            {
                return RedirectToAction("Login");
            }
            else
            {
                ViewBag.ErrorMessage = result;
                return View();
            }
        }



        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            var user = _userFacade.LoginUser(username, password);

            if (user != null)
            {
                var claims = new List<Claim>
        {        
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
            new Claim(ClaimTypes.Role, user.Role?.RoleName ?? "Unknown") // Gán vai trò
        };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(claimsIdentity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                switch (user.RoleId)
                {
                    case 1: return RedirectToAction("ListCourse", "Manager");
                    case 2: return RedirectToAction("ListGrade", "Manager");
                    case 3: return RedirectToAction("CourseGrade", "Manager");
                    default: return RedirectToAction("Index", "Home");
                }
            }

            ViewBag.ErrorMessage = "Invalid email or password!";
            return View();
        }
    }
}
