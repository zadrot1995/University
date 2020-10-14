using Core.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using University.Domain;
using University.Domain.Entities;

namespace Core.Handlers.Students
{
    public class GetAllStudentsHandler : IRequestHandler<GetAllStudentsQuery, List<Student>>
    {
        private readonly UniversityIdentityDbContext _context;

        public GetAllStudentsHandler(UniversityIdentityDbContext dbContext)
        {
            _context = dbContext;
        }
        public async Task<List<Student>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Students
                 .Skip(request.Page * request.Size)
                 .Take(request.Size)
                 .Include(s=>s.Group)
                 .ToListAsync();
        }
    }
}
