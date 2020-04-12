using System.ComponentModel.DataAnnotations;

namespace DbProject.Models {
    public class InstructorModel {
        [Key]
        [Required]
        public string InstructorId { get; set; }
        public string InstructorName { get; set; }
        public string Department { get; set; }
    }
}
