using MediatR;
using University.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Commands.Students
{
    public class CreateStudentCommand : IRequest<Student>
    {
        public string FullName { get; set; }
        public int GroupId { get; set; }
        //public Group Group { get; set; }
    }
}
