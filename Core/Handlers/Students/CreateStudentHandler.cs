using Core.Commands.Students;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using University.Domain;
using University.Domain.Entities;

namespace Core.Handlers.Students
{
    class CreateStudentHandler : IRequestHandler<CreateStudentCommand, Student>
    {
        private readonly UniversityIdentityDbContext _context;

        public CreateStudentHandler(UniversityIdentityDbContext context)
        {
            _context = context;
        }

        public async Task<Student> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {

            Student student = new Student
            {
                FullName = request.FullName,
                //Group = request.Group,
                GroupId = request.GroupId
            };
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
            return student;
        }
    }
}
