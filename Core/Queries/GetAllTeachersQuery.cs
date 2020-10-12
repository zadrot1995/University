using System.Collections.Generic;
using MediatR;
using University.Domain.Entities;

namespace Core.Queries
{
    public class GetAllTeacherQuery : IRequest<List<Teacher>>
    {
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
