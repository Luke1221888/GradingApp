namespace GradeYourDay
{
    public abstract class DayBase : Person, IDay
    {
        protected DayBase(string name, string surname) : base(name, surname)
        {
        }

        public DayBase()
        { 
        }

        public override string FirstName { get; set; }

        public override string LastName { get; set; }

        public string DayName { get; set; }

        public event IDay.TextAddedToFile TextAdded;

        public abstract void AddRating(float rating);

        public abstract void AddRating(double rating);

        public abstract void AddRating(string answer);

        public abstract bool CheckAnswer(string answer, out float result);

        public abstract Statistics GetStatistics();

        public abstract void ShowQuestions();
    }
}
