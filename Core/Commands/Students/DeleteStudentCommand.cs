using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Commands.Students
{
    public class DeleteStudentCommand : IRequest<Unit>
    {
        [JsonIgnore]
        public int Id { get; set; }

    }
}
