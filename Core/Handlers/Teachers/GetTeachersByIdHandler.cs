using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Core.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Domain;
using University.Domain.Entities;

namespace Core.Handlers.Theachers
{
    public class GetTeachersByIdHandler : IRequestHandler<GetTeacherByIdQuery, Teacher>
    {
        private readonly UniversityIdentityDbContext _context;

        public GetTeachersByIdHandler(UniversityIdentityDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<Teacher> Handle(GetTeacherByIdQuery request, CancellationToken cancellationToken)
        {
             var teacher = await _context.Teachers.Where(t => t.Id == request.Id).FirstOrDefaultAsync();
            return teacher;

        }
    }
}
