using Microsoft.EntityFrameworkCore;
using StudentService.Models;

namespace StudentService.Data{
    public class StudentContext : DbContext{
        
        public virtual DbSet<Student> Students {get; set;}
        public virtual DbSet<CollegeYear> CollegeYears {get; set;}

        public StudentContext(DbContextOptions<StudentContext> options) : base(options){
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>(e => {
                e.HasOne(y => y.CollegeYear)
                    .WithMany(p => p.Students)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Student_College_Year");
            });

            modelBuilder.Entity<CollegeYear>().HasData(
                new CollegeYear(Guid.NewGuid(), 1),
                new CollegeYear(Guid.NewGuid(), 2),
                new CollegeYear(Guid.NewGuid(), 3),
                new CollegeYear(Guid.NewGuid(), 4)
            );
        }

    }
}