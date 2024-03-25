namespace lesson_03.Entities
{
    public class Department
    {
        public int  Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Instructor> Instructors { get; set; }
        public virtual ICollection<Course> Courses { get; set; }

        public Department() 
        {
            Instructors = new List<Instructor>(); 
            Courses = new List<Course>();
        }
    }
}
