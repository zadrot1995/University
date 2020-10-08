using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Mapster;
using MediatR;
using University.Core.ResponseModels;
using University.Domain;

namespace University.Core.Queries
{
    public class GetTeachersQuery : IRequest<BaseResponse<List<TeacherResponseModel>>>
    {
        public int Page { get; set; }
        public int Size { get; set; }
    }

    public class GetTeachersQueryHandler : IRequestHandler<GetTeachersQuery, BaseResponse<List<TeacherResponseModel>>>
    {
        private readonly UniversityIdentityDbContext _context;

        public GetTeachersQueryHandler(UniversityIdentityDbContext context)
        {
            _context = context;
        }

        public async Task<BaseResponse<List<TeacherResponseModel>>> Handle(GetTeachersQuery request, CancellationToken cancellationToken)
        {
            var teachers = _context.Teachers.Skip(request.Page * request.Size).Take(request.Size);

            var response = teachers.Adapt<List<TeacherResponseModel>>();

            return BaseResponse.Ok("Success", response);
        }
    }
}
