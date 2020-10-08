using University.Domain.Enums;

namespace University.Domain.Entities
{
    public class StudentDisciplineMark
    {
        public int Id { get; set; }

      //  public int StudentId { get; set; }
        public Student Student { get; set; }

      //  public int GroupSubjectId { get; set; }
        public GroupSubject GroupSubject { get; set; }

        //Modules marks
        public int PK1 { get; set; }
        public int MK1 { get; set; }
        public int MO1 { get; private set; }  //PK1+MK1

        public int PK2 { get; set; }
        public int MK2 { get; set; }
        public int MO2 { get; private set; }  //PK2+MK2

        public int AdditionalMark { get; set; }

        public int CMO { get; private set; }  //MO1+MO2+AdditionalMark

        //Exam marks
        public int PK { get; private set; }  //PK1+PK2
        public int EK { get; set; }
        public int EO { get; private set; }  //PK+EK

        //Semester mark
        public int CO { get; set;  }  // = EO != 0 ? EO : CMO
     //   public EKTSScale EKTSScale { get; set; }
    //    public NationalScale NationalScale { get; set; }

    }
}
