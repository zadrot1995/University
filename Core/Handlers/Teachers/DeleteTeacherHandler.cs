using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Core.Commands;
using MediatR;
using University.Domain;
using University.Domain.Entities;

namespace Core.Handlers.Theachers
{
    public class DeleteTeacherHandler : IRequestHandler<DeleteTeacherCommand>
    {
        private readonly UniversityIdentityDbContext _context;

        public DeleteTeacherHandler(UniversityIdentityDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<Unit> Handle(DeleteTeacherCommand request, CancellationToken cancellationToken)
        {
            Teacher teacher = _context.Teachers.Where(t => t.Id == request.Id).FirstOrDefault();
            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
