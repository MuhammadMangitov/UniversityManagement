using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lesson_03.Entities
{
    public class Instructor
    {
        public int Id { get; set; }
        public string FirstName {  get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        [DisplayName("Department")]
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
        public virtual ICollection<CourseAssigment> Assigments { get; set; }
        public Instructor() 
        {
            Assigments = new List<CourseAssigment>();
        } 
    }
}
