using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lesson_03.Entities
{
    [Table(nameof(Student))]
    public class Student
    {
        public int Id { get; set; }
        [Required,
         MaxLength(255, ErrorMessage = "Maximum amount of characters exceeded."),
         MinLength(1, ErrorMessage = "Course name should contain at last 5 characters.")]
        public string  FirsName { get; set; }
        [Required,
         MaxLength(255, ErrorMessage = "Maximum amount of characters exceeded."),
         MinLength(1, ErrorMessage = "Course name should contain at last 5 characters.")]
        public string LastName {  get; set; }
        public string PhoneNumber { get; set; }
        public string  StudentEmial { get; set; }
        public string  Gender { get; set; }
        public virtual ICollection<Enrolment> Enrolments { get; set; }
        public Student() 
        {
            Enrolments = new List<Enrolment>();
        }
    }
}
