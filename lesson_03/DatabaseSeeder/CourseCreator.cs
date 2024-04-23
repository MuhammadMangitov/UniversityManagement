using Bogus;
using Bogus.DataSets;
using Humanizer;
using lesson_03.Data;
using lesson_03.Entities;

namespace lesson_03.DatabaseSeeder
{
    public class CourseCreator
    {
        public static Faker<Course> GetFaker(UniverstiyDbContext context)
        {
            List<string> courses = new List<string>()
            {
                "Frontend Development","Backend Development","Full-Stack Development",
                "Introduction to Data Science","Data Analysis with Python",
                "Machine Learning","Deep Learning","Adobe Photoshop Basics",
                "Adobe Illustrator Basics","Logo Design",
                "Typography in Design","Introduction to Finance",
                "Financial Modeling","Marketing Strategies",
                "Entrepreneurship","English Language Basics","Intermediate English Conversation",
                "Business English","Language Proficiency Test Preparation",
                "Project Planning","Agile Project Management",
                "Risk Management","Project Leadership","Basics of Photography","Portrait Photography",
                "Landscape Photography","Photo Editing with Adobe Lightroom","Nutrition Fundamentals",
                "Workout Planning","Yoga & Meditation","Personal Training Certification",
                "Social Media Marketing","Search Engine Optimization (SEO)",
                "Email Marketing","Content Marketing",
            };
            var arr = courses.ToArray();

            var categoryIds = context.Categories.Select(c => c.Id).ToArray(); 

            var faker = new Faker<Course>()
                .RuleFor(x => x.Name, f => f.Random.ArrayElement(arr))
                .RuleFor(x => x.Price, f => f.Finance.Amount())
                .RuleFor(x => x.Hourse, f => f.Random.Number(5, 12))
                .RuleFor(x => x.CategoryId, f => f.Random.ArrayElement(categoryIds));

            return faker;
        }
    }
}
