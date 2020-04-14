using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DbProject.Models;
using System.Linq;
using System.Collections.Generic;
using System;

namespace DbProject.Controllers {
    public class HomeController : Controller {
        private readonly GradeDbContext _gradeDbContext;
        public HomeController(GradeDbContext gradeDbContext) {
            _gradeDbContext = gradeDbContext;
        }

        public IActionResult Index() {
            return View(_gradeDbContext.Course.ToList());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        [Route("AverageSemesterGPA")]
        public string AverageSemesterGPA(string courseIds) {
            //Remove all whitespaces and turn input into a list of strings.

            if (courseIds == null) {
                return "Input cannot be null";
            }

            var sanitizedCourses = courseIds.Replace(" ", "").Split(",");

            if (!sanitizedCourses.Any()) {
                return "Input cannot be empty";
            }

            var userClassGroups = _gradeDbContext.GradeReceived
                .ToList()
                .GroupBy(g => new { g.Semester, g.StudentId })
                .Where(semesterGrouping => {
                    foreach (var course in sanitizedCourses) {
                        if (!semesterGrouping.Any(sg => sg.CourseId.Equals(course, StringComparison.InvariantCultureIgnoreCase))) {
                            return false;
                        }
                    }
                    return true;
                })
                .ToList();

            if(!userClassGroups.Any()) {
                return $"There is no record for the class combination";
            }
            var averageGPA = userClassGroups.Average(group => group.Average(groupEntry => groupEntry.Grade));

            return $"Students who took the selected classes earned an average GPA of {averageGPA}";
        }

        [HttpGet]
        [Route("AverageGradeByInstructor")]
        public string AverageGradeByInstructor(string teacherId) {

            if (teacherId == null) {
                return "teacher id cannot be null";
            }

            var classGrades = from grade in _gradeDbContext.Set<GradeReceivedModel>()
                              join teaches in _gradeDbContext.Set<TeachesModel>() on grade.CourseId equals teaches.CourseId
                              join instructor in _gradeDbContext.Set<InstructorModel>() on teaches.InstructorId equals instructor.InstructorId
                              where instructor.InstructorId == teacherId
                              select grade.Grade;

            if (!classGrades.Any()) {
                return $"{teacherId} has not taught any courses";
            }
            var averageClassGrade = classGrades.Average();
            return $"The average grade for classes taught by {teacherId} is {averageClassGrade}";
        }
    }
}
