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
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        [Route("AverageSemesterGPA")]
        public IActionResult AverageSemesterGPA(string courseIds) {
            //Remove all whitespaces and turn input into a list of strings.
            var sanitizedCourses = courseIds.Replace(" ", "").Split(",");

            if(!sanitizedCourses.Any()) {
                return BadRequest("Input cannot be empty");
            }

            var userClassGroups = _gradeDbContext.GradeReceived
                .ToList()
                .GroupBy(g => new { g.Semester, g.StudentId })
                .Where(semesterGrouping => { 
                    foreach(var course in sanitizedCourses) {
                        if (!semesterGrouping.Any(sg => sg.CourseId.Equals(course, StringComparison.InvariantCultureIgnoreCase))) return false;
                    }
                    return true;
                })
                .ToList();

            var averageGPA = userClassGroups.Average(group => group.Average(groupEntry => groupEntry.Grade));
            
            return Ok($"Students who took the selected classes earned an average GPA of {averageGPA}");
        }

        [HttpGet]
        [Route("AverageGradeByInstructor")]
        public IActionResult AverageGradeByInstructor(string teacherId) {
            var classGrades = from grade in _gradeDbContext.Set<GradeReceivedModel>()
                              join teaches in _gradeDbContext.Set<TeachesModel>() on grade.CourseId equals teaches.CourseId
                              join instructor in _gradeDbContext.Set<InstructorModel>() on teaches.InstructorId equals instructor.InstructorId
                              where instructor.InstructorId == teacherId
                              select grade.Grade;
            var averageClassGrade = classGrades.Average();
            return Ok($"The average grade for classes taught by {teacherId} is {averageClassGrade}");
        }
    }
}
