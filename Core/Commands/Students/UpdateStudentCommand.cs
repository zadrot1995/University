using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using University.Domain.Entities;

namespace Core.Commands.Students
{
    public class UpdateStudentCommand : IRequest<Student>
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string FullName { get; set; }
        public int GroupId { get; set; }
    }
}
