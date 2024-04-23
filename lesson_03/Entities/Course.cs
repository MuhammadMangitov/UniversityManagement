using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lesson_03.Entities
{
    [Table (nameof(Course))]
    public class Course
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, 
         MaxLength(255,ErrorMessage ="Maximum amount of characters exceeded."),
         MinLength(5,ErrorMessage ="Course name should contain at last 5 characters.")]
        public string Name { get; set; }
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        public int Hourse {  get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public virtual ICollection<CourseAssigment> Assigments { get; set; }

        public Course()
        {
            Assigments = new List<CourseAssigment>();
        }
    }
}
