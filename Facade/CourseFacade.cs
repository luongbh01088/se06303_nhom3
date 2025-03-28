﻿using WEB_Student.Models;
using WEB_Student.Repository;

namespace WEB_Student.Facade
{
    public class CourseFacade : ICourseFacade
    {
        private readonly ICourseRepository _courseRepository;

        public CourseFacade(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public IEnumerable<Course> GetAllCourses()
        {
            return _courseRepository.GetAllCourses();
        }

        public Course GetCourseById(int id)
        {
            return _courseRepository.GetCourseById(id);
        }

        public void AddCourse(Course course)
        {
            _courseRepository.AddCourse(course);
            Console.WriteLine(course.CourseName);
        }

        public void UpdateCourse(Course course)
        {
            _courseRepository.UpdateCourse(course);
        }

        public void DeleteCourse(int id)
        {
            _courseRepository.DeleteCourse(id);
        }
    }
}
