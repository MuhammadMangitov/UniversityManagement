using Bogus;
using lesson_03.Entities;

namespace lesson_03.DatabaseSeeder
{
    public class DepartmentsCreator
    {
        public static Faker<Department> GetFaker()
        {
            List<string> departments = new List<string>()
            {
                "Department of Mathematics",
                "Department of Physics",
                "Department of Chemistry",
                "Department of Biology",
                "Department of Computer Science",
                "Department of Electrical Engineering",
                "Department of Mechanical Engineering",
                "Department of Civil Engineering",
                "Department of Environmental Science",
                "Department of Psychology",
                "Department of Sociology",
                "Department of Economics",
                "Department of History",
                "Department of Literature",
                "Department of Languages",
                "Department of Political Science",
                "Department of Business Administration",
                "Department of Law",
                "Department of Medicine",
                "Department of Education"
            };
            var faker = new Faker<Department>()
                .RuleFor(d => d.Name, f => departments[f.Random.Int(0, departments.Count - 1)])
                .RuleFor(x => x.Description, f => f.Lorem.Sentences(1));

            return faker;
        }
    }
}
