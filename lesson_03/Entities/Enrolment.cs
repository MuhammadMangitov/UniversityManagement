using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lesson_03.Entities
{
    [Table(nameof(Enrolment))]
    public class Enrolment
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime  EnrolmentDate { get; set; }
        [DisplayName("Student")]
        public int StudentId { get; set; }
        public Student? Student { get; set; }
        [DisplayName("CourseAssigment")]
        public int CourseAssigmentId {  get; set; }
        public CourseAssigment? CourseAssigment { get; set; }

    }
}
