using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbProject.Models {
    public class GradeDbContext : DbContext {
        public GradeDbContext(DbContextOptions<GradeDbContext> options) : base(options) { }
        public DbSet<CourseModel> Course { get; set; }
        public DbSet<GradeReceivedModel> GradeReceived { get; set; }
        public DbSet<InstructorModel> Instructor { get; set; }
        public DbSet<StudentModel> Student { get; set; }
        public DbSet<TeachesModel> Teaches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<GradeReceivedModel>()
                .HasKey(gr => new { gr.StudentId, gr.CourseId, gr.Semester, gr.Grade });

            modelBuilder.Entity<TeachesModel>()
                .HasKey(t => new { t.CourseId, t.InstructorId });
        }
    }
}
