using System.ComponentModel.DataAnnotations;

namespace DbProject.Models {
    public class CourseModel {
        [Key]
        [Required]
        public string CourseId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public ushort CreditHours { get; set; }
    }
}
