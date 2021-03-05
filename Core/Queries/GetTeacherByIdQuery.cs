using MediatR;
using University.Domain.Entities;

namespace Core.Queries
{
    public class GetTeacherByIdQuery : IRequest<Teacher>
    {
        public GetTeacherByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }

    }
}
