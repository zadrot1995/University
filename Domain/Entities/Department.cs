using System.Collections.Generic;

namespace University.Domain.Entities
{
    public class Department
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Discipline> Disciplines { get; set; }
    }
}
