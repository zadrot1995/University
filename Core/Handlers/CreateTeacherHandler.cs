using System.Threading;
using System.Threading.Tasks;
using Core.Commands;
using MediatR;
using University.Domain;
using University.Domain.Entities;

namespace Core.Handlers
{
    public class CreateTeacherHandler : IRequestHandler<CreateTeacherCommand, Teacher>
    {
        private readonly UniversityIdentityDbContext _context;

        public CreateTeacherHandler(UniversityIdentityDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<Teacher> Handle(CreateTeacherCommand request, CancellationToken cancellationToken)
        {
            Teacher teacher = new Teacher
            {
                FullName = request.FullName,
                TeachingPositionType = request.TeachingPositionType
            };
            await _context.Teachers.AddAsync(teacher);
            await _context.SaveChangesAsync();
            return teacher;
        }
    }
}
