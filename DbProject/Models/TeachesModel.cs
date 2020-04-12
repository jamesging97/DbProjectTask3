using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DbProject.Models {
    public class TeachesModel {
        [ForeignKey("CourseModel")]
        [Required]
        public string CourseId { get; set; }
        [ForeignKey("InstructorModel")]
        [Required]
        public string InstructorId { get; set; }
        public string Semester { get; set; }
    }
}
