using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using University.Domain.Entities;

namespace Core.Queries
{
    public class GetAllStudentsQuery: IRequest<List<Student>>
    {
        public int Page { get; set; }
        public int Size { get; set; }
    }
}
