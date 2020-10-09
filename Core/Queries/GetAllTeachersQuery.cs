using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using University.Domain.Entities;

namespace Core.Queries
{
    public class GetAllTeachersQuery : IRequest<List<Teacher>>
    {
    }
}
