using Bogus;
using lesson_03.Entities;
using static Bogus.DataSets.Name;

namespace lesson_03.DatabaseSeeder
{
    public class StudentCreator
    {
        public static Faker<Student> GetFaker()
        {
            var faker = new Faker<Student>()
                .RuleFor(x => x.FirsName, f => f.Person.FirstName)
                .RuleFor(x => x.LastName, f => f.Person.LastName)
                .RuleFor(x => x.StudentEmial, f => f.Person.Email)
                .RuleFor(x => x.PhoneNumber, f => f.Person.Phone)
                .RuleFor(x => x.Gender, f => f.PickRandom<Gender>().ToString());

            return faker;
        }
    }
}
