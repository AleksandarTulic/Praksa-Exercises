using Microsoft.EntityFrameworkCore;
using MyRepository.PostgreSQL;
using StudentService.Models;

namespace StudentService.Data{
    public class StudentServiceContext : DbContext{
        public virtual Repository<Student> Students {get; set;}
        public virtual Repository<CollegeYear> CollegeYears {get; set;}

        public StudentServiceContext(DbContextOptions<StudentServiceContext> options) : base(options){
            Students = new Repository<Student>(this);
            CollegeYears = new Repository<CollegeYear>(this);

            Students.Rows = Set<Student>();
            CollegeYears.Rows = Set<CollegeYear>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>(e => {
                e.HasOne(d => d.CollegeYear)
                    .WithMany(p => p.Students)
                    .HasForeignKey(p => p.CollegeYearId)
                    .HasPrincipalKey(p => p.Id)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Student_CollegeYear");
            });

            /*
            modelBuilder.Entity<CollegeYear>()
                .HasMany(e => e.Students)
                .WithOne(e => e.CollegeYear)
                .HasForeignKey(e => e.CollegeYearId)
                .HasPrincipalKey(e => e.Id);
            */

            modelBuilder.Entity<CollegeYear>().HasData(
                new CollegeYear{Id = Guid.NewGuid(), Year = 1},
                new CollegeYear{Id = Guid.NewGuid(), Year = 2},
                new CollegeYear{Id = Guid.NewGuid(), Year = 3},
                new CollegeYear{Id = Guid.NewGuid(), Year = 4},
                new CollegeYear{Id = Guid.NewGuid(), Year = 5},
                new CollegeYear{Id = Guid.NewGuid(), Year = 6}
            );
        }

    }
}