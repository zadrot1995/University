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
    class GetAllTeachersHandler : IRequestHandler<GetAllTeacherQuery, List<Teacher>>
    {
        private readonly UniversityIdentityDbContext dbContext;

        public GetAllTeachersHandler(UniversityIdentityDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Teacher>> Handle(GetAllTeacherQuery request, CancellationToken cancellationToken)
        {
            return await dbContext.Teachers.ToListAsync();
        }
    }
}
