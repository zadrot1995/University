using Core.Commands.Students;
using MediatR;
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
    class UpdateStudentHandler : IRequestHandler<UpdateStudentCommand, Student>
    {
        private readonly UniversityIdentityDbContext _context;

        public UpdateStudentHandler(UniversityIdentityDbContext context)
        {
            _context = context;
        }

        public async Task<Student> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            Student student = _context.Students.Where(t => t.Id == request.Id).FirstOrDefault();
            student.FullName = request.FullName;
            student.GroupId = request.GroupId;
            
            await _context.SaveChangesAsync();
            return student;
        }
    }
}
