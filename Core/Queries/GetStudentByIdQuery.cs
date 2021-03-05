using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using University.Domain.Entities;

namespace Core.Queries
{
    public class GetStudentByIdQuery: IRequest<Student>
    {
        public GetStudentByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
