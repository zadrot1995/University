using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Core.Commands;
using MediatR;
using University.Domain;
using University.Domain.Entities;

namespace Core.Handlers.Theachers
{
    public class UpdateTeacherHandler : IRequestHandler<UpdateTeacherCommand, Teacher>
    {
        private readonly UniversityIdentityDbContext _context;

        public UpdateTeacherHandler(UniversityIdentityDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<Teacher> Handle(UpdateTeacherCommand request, CancellationToken cancellationToken)
        {
            
            Teacher teacher = _context.Teachers.Where(t => t.Id == request.Id).FirstOrDefault();
            teacher.FullName = request.FullName;
            teacher.TeachingPositionType = request.TeachingPositionType;
            await _context.SaveChangesAsync();
            return teacher;
        }
    }
}
