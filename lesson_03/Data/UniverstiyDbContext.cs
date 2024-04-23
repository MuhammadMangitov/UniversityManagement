using lesson_03.Entities;
using Microsoft.EntityFrameworkCore;

namespace lesson_03.Data
{
    public class UniverstiyDbContext : DbContext
    {
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Instructor> Instructors { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Enrolment> Enrolments { get; set; }
        public virtual DbSet<CourseAssigment> CourseAssigments { get; set; }
        public virtual DbSet<Category> Categories { get; set; } 

        public UniverstiyDbContext(DbContextOptions<UniverstiyDbContext> options)
            :base(options)
        {
        }

        public UniverstiyDbContext()
        {
        }
    }
}
