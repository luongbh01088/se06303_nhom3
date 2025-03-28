using WEB_Student.Models;

namespace WEB_Student.Facade
{
    public interface ICourseFacade
    {
        IEnumerable<Course> GetAllCourses();
        Course GetCourseById(int id);
        void AddCourse(Course course);
        void UpdateCourse(Course course);
        void DeleteCourse(int id);
    }
}
