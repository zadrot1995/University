using System;
namespace University.Domain.Entities
{
    public class Discipline
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
