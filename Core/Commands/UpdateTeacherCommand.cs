using MediatR;
using Newtonsoft.Json;
using University.Domain.Entities;
using University.Domain.Enums;

namespace Core.Commands
{
    public class UpdateTeacherCommand : IRequest<Teacher>
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string FullName { get; set; }
        public TeachingPositionType TeachingPositionType { get; set; }
    }
}
