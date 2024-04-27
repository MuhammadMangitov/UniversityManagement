using Bogus;
using lesson_03.Data;
using lesson_03.Entities;
using Microsoft.EntityFrameworkCore;

namespace lesson_03.DatabaseSeeder
{
    public class DatabaseSeder
    {
        public static void Seed(UniverstiyDbContext context)
        {
            CreateStudent(context);
            CreateDepartments(context);
            CreatCategory(context);
            CreateCourse(context);
            CreateInstructor(context);
            CreateCourseAssigment(context);
            CreateEnrolment(context);
        }
        public static void CreateStudent(UniverstiyDbContext context)
        {
            if(context.Students.Any()) return;
            var faker = StudentCreator.GetFaker();
            var student = faker.Generate(40);

            context.Students.AddRange(student);
            context.SaveChanges();
        }
        public static void CreateCourse(UniverstiyDbContext context)
        {
            if (context.Courses.Any()) return;

            var faker = CourseCreator.GetFaker(context);
            var courses = faker.Generate(100);

            context.Courses.AddRange(courses);
            context.SaveChanges();
        }
        public static void CreateInstructor(UniverstiyDbContext context)
        {
            if (context.Instructors.Any()) return;

            var faker = InstructorCreator.GetFaker(context);
            var instructor1 = faker.Generate(40);

            context.Instructors.AddRange(instructor1);
            context.SaveChanges();
        }
        public static void CreateDepartments(UniverstiyDbContext context)
        {
            if(context.Departments.Any()) return;

            var faker = DepartmentsCreator.GetFaker();
            var departments = faker.Generate(20);

            context.Departments.AddRange(departments);
            context.SaveChanges();
        }
        public static void CreatCategory(UniverstiyDbContext context)
        {   
            List<string> categories = new List<string>()
            {
                "Web Development","Data Science",
                "Graphic Design","Business & Finance","Language Learning",
                "Project Management","Photography","Health & Fitness",
                "Digital Marketing","Cybersecurity","Creative Writing",
                "Art and Design","Personal Development","Software Engineering",
                "E-commerce","Environmental Science","Public Speaking","Music",
                "History and Culture:","Mobile App Development",
            };

            if (context.Categories.Any()) return;
            Faker faker = new Faker();

            for(int i = 0; i < 10; i++)
            {
                Category category = new Category()
                {
                    Name = faker.Random.ArrayElement(categories.ToArray()),
                    Description = faker.Lorem.Sentence(4),
                    ParentId = null
                };
                context.Categories.Add(category);
            }

            context.SaveChanges();

            var parentIds = context.Categories.Select(x => x.Id);
            for (int i = 0; i < 20; i++)
            {
                Category category = new Category()
                {
                    Name = faker.Random.ArrayElement(categories.ToArray()),
                    Description = faker.Lorem.Sentence(4),
                    ParentId = faker.Random.ArrayElement(parentIds.ToArray())
                };
                context.Categories.Add(category);
            }
            context.SaveChanges();
        }
        public static void CreateCourseAssigment(UniverstiyDbContext context)
        {
            if (context.CourseAssigments.Any()) return;
            var faker = CourseAssigmentCreator.GetFaker(context);
            var assigment = faker.Generate(30);

            context.AddRange(assigment);
            context.SaveChanges();
        }
        public static void CreateEnrolment(UniverstiyDbContext context)
        {
            if (context.Enrolments.Any()) return;
            var faker = EnrolmentCreator.GetFaker(context);
            var enrolment = faker.Generate(30);

            context.AddRange(enrolment);
            context.SaveChanges();
        }
    }
}
