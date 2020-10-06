using System.Collections.Generic;

namespace University.Domain.Entities
{
    public class Institute
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Speciality> Specialities { get; set; }
    }
}
