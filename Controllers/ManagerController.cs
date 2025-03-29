using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WEB_Student.Facade;
using WEB_Student.Models;
using WEB_Student.Data;

namespace WEB_Student.Controllers
{
    public class ManagerController : Controller
    {
        private readonly ICourseFacade _courseFacade;
        private readonly ApplicationDbContext _context;

        public ManagerController(ICourseFacade courseFacade, ApplicationDbContext context)
        {
            _courseFacade = courseFacade;
            _context = context;
        }

        public IActionResult ListCourse()
        {
            var courses = _courseFacade.GetAllCourses();
            return View(courses);
        }


        public IActionResult ListGrade()
        {
            return View();
        }
        public IActionResult CourseGrade()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddCourse()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCourse(Course course)
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine("Model is valid. Saving course: " + course.CourseName);
                _courseFacade.AddCourse(course);
                return RedirectToAction("ListCourse");
            }
            else
            {
                Console.WriteLine("ModelState is NOT valid!");
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine("Validation Error: " + error.ErrorMessage);
                }
            }
            return View(course);
        }

        [HttpGet]
        public IActionResult EditCourse(int id)
        {
            var course = _courseFacade.GetCourseById(id);
            if (course == null) return NotFound();
            return View(course);
        }

        [HttpPost]
        public IActionResult EditCourse(Course course)
        {
            if (ModelState.IsValid)
            {
                _courseFacade.UpdateCourse(course);
                return RedirectToAction("ListCourse");
            }
            return View(course);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var course = _courseFacade.GetCourseById(id);
            if (course == null) return NotFound();

            _courseFacade.DeleteCourse(id);

          
            return RedirectToAction("ListCourse");
        }

    }
}
