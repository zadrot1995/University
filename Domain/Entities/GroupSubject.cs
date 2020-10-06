using System;
namespace University.Domain.Entities
{
    public class GroupSubject
    {
        public int Id { get; set; }

        public int DisciplineId { get; set; }
        public Discipline Discipline { get; set; }

        public int GroupId { get; set; }
        public Group Group { get; set; }

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
