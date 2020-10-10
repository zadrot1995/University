using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using University.Domain.Entities;

namespace Core.Queries
{
    public class GetTeachersByIdQuery : IRequest<Teacher>
    {
        public GetTeachersByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }

    }
}
