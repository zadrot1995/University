using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Core.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using University.Domain;
using University.Domain.Entities;

namespace Core.Handlers
{
    public class GetAllTeachersHandler : IRequestHandler<GetAllTeacherQuery, List<Teacher>>
    {
        private readonly UniversityIdentityDbContext _context;

        public GetAllTeachersHandler(UniversityIdentityDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<List<Teacher>> Handle(GetAllTeacherQuery request, CancellationToken cancellationToken)
        {
            return await _context.Teachers
                .Skip(request.Page * request.Size)
                .Take(request.Size)
                .ToListAsync();
        }
    }
}
