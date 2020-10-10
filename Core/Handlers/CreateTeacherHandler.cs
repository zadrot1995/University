using Core.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using University.Domain;
using University.Domain.Entities;

namespace Core.Handlers
{
    class CreateTeacherHandler : IRequestHandler<CreateTeacherCommand, Teacher>
    {
        UniversityIdentityDbContext DbContext;

        public CreateTeacherHandler(UniversityIdentityDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<Teacher> Handle(CreateTeacherCommand request, CancellationToken cancellationToken)
        {
            Teacher teacher = new Teacher
            {
                FullName = request.FullName,
                TeachingPositionType = request.TeachingPositionType
            };
            await DbContext.Teachers.AddAsync(teacher);
            await DbContext.SaveChangesAsync();
            return teacher;
        }
    }
}
