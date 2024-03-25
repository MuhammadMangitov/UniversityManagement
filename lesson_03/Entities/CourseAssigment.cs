using System.ComponentModel;

namespace lesson_03.Entities
{
    public class CourseAssigment
    {
        public int  Id { get; set; }
        public string Room { get; set; }

        [DisplayName("Course")]
        public  int  CoureseId { get; set; }
        public Course? Course { get; set; }

        [DisplayName("Instructor")]
        public int InstructorId {  get; set; }
        public Instructor? Instructor { get; set; }
        public virtual ICollection<Enrolment> Enrolments { get; set; }
        public CourseAssigment()
        {
            Enrolments = new List<Enrolment>();
        }
    }
}
