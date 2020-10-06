using University.Domain.Enums;

namespace University.Domain.Entities
{
    public class Teacher
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public TeachingPositionType TeachingPositionType { get; set; }
    }
}