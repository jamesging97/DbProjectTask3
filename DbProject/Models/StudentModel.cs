using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DbProject.Models {
    public class StudentModel {
        [Key]
        [Required]
        public string StudentId { get; set; }
        public string Name { get; set; }
        public double GPA { get; set; }
        public ushort CreditsEarned { get; set; }
    }
}
