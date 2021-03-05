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
    public class GetStudentsByIdHandler : IRequestHandler<GetStudentByIdQuery, Student>
    {
        private readonly UniversityIdentityDbContext _context;

        public GetStudentsByIdHandler(UniversityIdentityDbContext context)
        {
            _context = context;
        }

        public async Task<Student> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _context.Students.Where(t => t.Id == request.Id).Include(s=>s.Group)
                .Include(s=>s.Group.GroupSubjects)
                .Include(s => s.Group.Speciality)
                .FirstOrDefaultAsync();
            return student;
        }
    }
}
