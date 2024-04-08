using static System.Console;

namespace GradeYourDay
{
    public class Person
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public Person()
        {
        }
    }
}
