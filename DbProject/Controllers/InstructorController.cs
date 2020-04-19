using DbProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DbProject.Controllers {
    public class InstructorController : Controller {
        private readonly GradeDbContext _gradeDbContext;

        public InstructorController(GradeDbContext gradeDbContext) {
            _gradeDbContext = gradeDbContext;
        }

        public IActionResult Index() {
            return View(_gradeDbContext.Instructor.ToList());
        }

        [HttpPost("Create")]
        public IActionResult CreateInstructor(string id, string name, string department) {
            //check if primary key is already exists
            var key = _gradeDbContext.Instructor.FirstOrDefault(i => i.InstructorId.Equals(id, System.StringComparison.InvariantCultureIgnoreCase));
            if (key == null)
            {
                _gradeDbContext.Add(new InstructorModel
                {
                    InstructorId = id,
                    InstructorName = name,
                    Department = department
                });

                _gradeDbContext.SaveChanges();
                _gradeDbContext.Dispose();
                return RedirectToAction("Index");
            }
            else
                return BadRequest($"Cannot insert instructor: {id} already exists");
        }

        [HttpPost("Delete")]
        public IActionResult DeleteInstructor(string id) {
            var instructor = _gradeDbContext.Instructor.FirstOrDefault(i => i.InstructorId.Equals(id, System.StringComparison.InvariantCultureIgnoreCase));

            if(instructor == null) {
                return BadRequest($"Cannot delete instructor: {id} does not exist");
            }

            _gradeDbContext.Remove(instructor);
            _gradeDbContext.SaveChanges();
            _gradeDbContext.Dispose();
            return RedirectToAction("Index");
        }
    }
}