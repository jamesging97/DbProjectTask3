using System.Linq;
using DbProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace DbProject.Controllers
{
    public class TeachesController : Controller
    {
        private readonly GradeDbContext _gradeDbContext;

        public TeachesController(GradeDbContext gradeDbContext)
        {
            _gradeDbContext = gradeDbContext;
        }

        public IActionResult Index()
        {
            return View(_gradeDbContext.Teaches.ToList());
        }

        [HttpPost("CreateTeaches")]
        public IActionResult CreateTeaches(string cid, string iid, string semester)
        {
            //check if primary key is already exists
            var cidkey = _gradeDbContext.Teaches.FirstOrDefault(i => i.CourseId.Equals(cid, System.StringComparison.InvariantCultureIgnoreCase));
            var courseKey = _gradeDbContext.Course.FirstOrDefault(i => i.CourseId.Equals(cid, System.StringComparison.InvariantCultureIgnoreCase));
            var instKey = _gradeDbContext.Instructor.FirstOrDefault(i => i.InstructorId.Equals(iid, System.StringComparison.InvariantCultureIgnoreCase));

            //We need the courseid NOT TO BE in teaches table --> cidkey
            //We need the courseid to BE in course table      --> courseKey
            //We need the instructorId to be in instr table   --> instKey
            if (cidkey == null || courseKey != null || instKey != null)
            {
                _gradeDbContext.Add(new TeachesModel
                {
                    CourseId = cid,
                    InstructorId = iid,
                    Semester = semester
                });

                _gradeDbContext.SaveChanges();
                _gradeDbContext.Dispose();
                return RedirectToAction("Index");
            }
            else
                return BadRequest($"Cannot insert teaches:{cid} already exists or instructor id {iid} is not created!");
        }


        [HttpPost("DeleteTeaches")]
        public IActionResult DeleteTeaches(string cid)
        {
            var instructor = _gradeDbContext.Teaches.FirstOrDefault(i => i.CourseId.Equals(cid, System.StringComparison.InvariantCultureIgnoreCase));

            if (instructor == null)
            {
                return BadRequest($"Cannot delete course: {cid} does not exist");
            }

            _gradeDbContext.Remove(instructor);
            _gradeDbContext.SaveChanges();
            _gradeDbContext.Dispose();
            return RedirectToAction("Index");
        }
    }
}