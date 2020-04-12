using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DbProject.Models {
    public class CourseModel {
        [Key]
        [Required]
        public string CourseId { get; set; }
        public string Title { get; set; }

        public string Semester { get; set; }
    }
}
