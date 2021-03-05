using MediatR;
using Newtonsoft.Json;

namespace Core.Commands
{
    public class DeleteTeacherCommand : IRequest<Unit>
    {
        [JsonIgnore]
        public int Id { get; set; }

    }
}
