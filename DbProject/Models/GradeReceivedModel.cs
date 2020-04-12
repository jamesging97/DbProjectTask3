using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbProject.Models {
    public class GradeReceivedModel {
        [ForeignKey("StudentModel")]
        [Required]
        public string StudentId { get; set; }

        [ForeignKey("CourseModel")]
        [Required]
        public string CourseId { get; set; }
        public float Grade { get; set; }
        public string Semester { get; set; }
    }
}
