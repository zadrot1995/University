using Core.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using University.Domain;
using University.Domain.Entities;

namespace Core.Handlers
{
    class UpdateTeacherHandler : IRequestHandler<UpdateTeacherCommand, Teacher>
    {
        UniversityIdentityDbContext DbContext;

        public UpdateTeacherHandler(UniversityIdentityDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<Teacher> Handle(UpdateTeacherCommand request, CancellationToken cancellationToken)
        {
            
            Teacher teacher = DbContext.Teachers.Where(t => t.Id == request.Id).FirstOrDefault();
            teacher.FullName = request.FullName;
            teacher.TeachingPositionType = request.TeachingPositionType;
            await DbContext.SaveChangesAsync();
            return teacher;
        }
    }
}
