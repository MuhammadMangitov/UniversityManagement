using Bogus;
using Humanizer;
using lesson_03.Data;
using lesson_03.Entities;

namespace lesson_03.DatabaseSeeder
{
    public class CourseAssigmentCreator
    {
        public static Faker<CourseAssigment> GetFaker(UniverstiyDbContext context)
        {
            char[] ABC =
            {
                'A','B','C','D','F','G','H','J','K'
            };

            Random rd = new Random();
            List<string> rooms = new List<string>();

            for (int i = 0; i < 54; i++)
            {
                rooms.Add($"{ABC[rd.Next(0, ABC.Length)]}-{rd.Next(100, 999)}");
            }

            var courseIds = context.Courses.Select(x => x.Id).ToArray();
            var instructorIds = context.Instructors.Select(x => x.Id).ToArray();

            var faker = new Faker<CourseAssigment>()
                .RuleFor(x => x.Room, f => f.Random.ArrayElement(rooms.ToArray()))
                .RuleFor(x => x.CourseId, f => f.Random.ArrayElement(courseIds))
                .RuleFor(x => x.InstructorId, f => f.Random.ArrayElement(instructorIds));
                
            return faker;
        }
    }
}
