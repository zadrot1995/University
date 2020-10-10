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
    class DeleteTeacherHandler : IRequestHandler<DeleteTeacherCommand, Teacher>
    {
        UniversityIdentityDbContext DbContext;

        public DeleteTeacherHandler(UniversityIdentityDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task<Teacher> Handle(DeleteTeacherCommand request, CancellationToken cancellationToken)
        {
            Teacher teacher = DbContext.Teachers.Where(t => t.Id == request.Id).FirstOrDefault();
            DbContext.Teachers.Remove(teacher);
            await DbContext.SaveChangesAsync();
            return teacher;
        }
    }
}
