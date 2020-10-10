using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using University.Domain.Entities;
using University.Domain.Enums;

namespace Core.Commands
{
    public class UpdateTeacherCommand:IRequest<Teacher>
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public TeachingPositionType TeachingPositionType { get; set; }
    }
}
