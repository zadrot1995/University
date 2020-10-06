using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using University.Domain.Entities;

namespace University.Infrastructure
{
    public class UniversityIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public UniversityIdentityDbContext(DbContextOptions<IdentityDbContext> options) : base(options)
        {
        }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Discipline> Disciplines { get; set; }

        public DbSet<Group> Groups { get; set; }

        public DbSet<GroupSubject> GroupSubjects { get; set; }

        public DbSet<Institute> Institutes { get; set; }

        public DbSet<Speciality> Specialities { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<StudentDisciplineMark> studentDisciplineMarks { get; set; }

        public DbSet<Teacher> Teachers { get; set; }
    }
}
