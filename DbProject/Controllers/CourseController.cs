using System.Linq;
using DbProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace DbProject.Controllers
{
    public class CourseController : Controller
    {
        private readonly GradeDbContext _gradeDbContext;

        public CourseController(GradeDbContext gradeDbContext)
        {
            _gradeDbContext = gradeDbContext;
        }

        public IActionResult Index()
        {
            return View(_gradeDbContext.Course.ToList());
        }

        [HttpPost("CreateCourse")]
        public IActionResult CreateCourse(string id, string title, ushort hours)
        {
            //check if primary key is already exists
            var key = _gradeDbContext.Course.FirstOrDefault(i => i.CourseId.Equals(id, System.StringComparison.InvariantCultureIgnoreCase));
            if (key == null)
            {
                _gradeDbContext.Add(new CourseModel
                {
                    CourseId = id,
                    Title = title,
                    CreditHours = hours
                });

                _gradeDbContext.SaveChanges();
                _gradeDbContext.Dispose();
                return RedirectToAction("Index");
            }
            else
                return BadRequest($"Cannot insert course: {id} already exists");
        }


        [HttpPost("DeleteCourse")]
        public IActionResult DeleteCourse(string id)
        {
            var instructor = _gradeDbContext.Course.FirstOrDefault(i => i.CourseId.Equals(id, System.StringComparison.InvariantCultureIgnoreCase));

            if (instructor == null)
            {
                return BadRequest($"Cannot delete course: {id} does not exist");
            }

            _gradeDbContext.Remove(instructor);
            _gradeDbContext.SaveChanges();
            _gradeDbContext.Dispose();
            return RedirectToAction("Index");
        }
    }
}