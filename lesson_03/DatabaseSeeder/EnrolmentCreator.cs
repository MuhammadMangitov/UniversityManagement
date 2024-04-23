using Bogus;
using Humanizer;
using lesson_03.Data;
using lesson_03.Entities;
using System.Formats.Asn1;

namespace lesson_03.DatabaseSeeder
{
    public class EnrolmentCreator
    {
        public static Faker<Enrolment> GetFaker(UniverstiyDbContext context)
        {
            var studentIds = context.Students.Select(x => x.Id).ToArray();
            var assigmentIds = context.CourseAssigments.Select(x => x.Id).ToArray() ;

            var faker = new Faker<Enrolment>()
                .RuleFor(x => x.EnrolmentDate, f => f.Date.Between(DateTime.Now.AddYears(-3), DateTime.Now))
                .RuleFor(x => x.StudentId, f => f.Random.ArrayElement(studentIds))
                .RuleFor(x => x.CourseAssigmentId, f => f.Random.ArrayElement(assigmentIds));

            return faker;
        }
    }
}
