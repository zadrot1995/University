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

namespace Core.Handlers
{
    public class GetTeachersByIdHandler : IRequestHandler<GetTeachersByIdQuery, Teacher>
    {
        public GetTeachersByIdHandler(UniversityIdentityDbContext dbContext)
        {
            this.DbContext = dbContext;
        }

        private UniversityIdentityDbContext DbContext { get; set; }

        public async Task<Teacher> Handle(GetTeachersByIdQuery request, CancellationToken cancellationToken)
        {
             var teacher = await DbContext.Teachers.Where(t => t.Id == request.Id).FirstOrDefaultAsync();
            return teacher;

        }
    }
}
