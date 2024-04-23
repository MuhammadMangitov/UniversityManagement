using Bogus;
using lesson_03.Data;
using lesson_03.Entities;

namespace lesson_03.DatabaseSeeder
{
    public class InstructorCreator
    {
        public static Faker<Instructor> GetFaker(UniverstiyDbContext context)
        {
            var depatrmentsIds = context.Departments.Select(x => x.Id).ToArray();

            var faker = new Faker<Instructor>()
                .RuleFor(x => x.FirstName, f => f.Person.FirstName)
                .RuleFor(x => x.LastName, f => f.Person.LastName)
                .RuleFor(x => x.Email, f => f.Person.Email)
                .RuleFor(x => x.DepartmentId, f => f.Random.ArrayElement(depatrmentsIds));

            return faker;
        }
    }
}
