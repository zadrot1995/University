using System.Collections.Generic;

namespace University.Domain.Entities
{
    public class Speciality
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int InstituteId { get; set; }
        public Institute Institute { get; set; }

        public List<Group> Groups { get; set; }
    }
}
