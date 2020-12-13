using System;
using System.Collections.Generic;
using System.Text;

namespace ClientAdmin.Common.DTO
{
    public class TeacherDTO
    {
        public Guid Id { get; set; }

        public TeachingPositionType TeachingPositionType { get; set; }

        public Guid? CreatedBy { get; set; }

        public Guid DepartmentId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
