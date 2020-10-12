using MediatR;
using University.Domain.Entities;
using University.Domain.Enums;

namespace Core.Commands
{
    public class CreateTeacherCommand : IRequest<Teacher>
    {
        public string FullName { get; set; }
        public TeachingPositionType TeachingPositionType { get; set; }
    }
}
