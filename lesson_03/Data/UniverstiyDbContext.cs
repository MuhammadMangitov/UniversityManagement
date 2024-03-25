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

        public UniverstiyDbContext(DbContextOptions<UniverstiyDbContext> options)
            :base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseAssigment>().ToTable(nameof(CourseAssigment));
            modelBuilder.Entity<CourseAssigment>().
                HasKey(x => x.Id);
            modelBuilder.Entity<CourseAssigment>().Property(x => x.Room)
                .HasMaxLength(15)
                .IsRequired();
            modelBuilder.Entity<CourseAssigment>()
                .HasOne(x => x.Instructor)
                .WithMany(i => i.Assigments)
                .HasForeignKey(x => x.InstructorId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<CourseAssigment>()
                .HasOne(c => c.Course)
                .WithMany(c => c.Assigments)
                .HasForeignKey(c => c.CoureseId)
                .OnDelete(DeleteBehavior.NoAction);
                base.OnModelCreating(modelBuilder);
        }
    }
}
