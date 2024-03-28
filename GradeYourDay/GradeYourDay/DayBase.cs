namespace GradeYourDay
{
    public abstract class DayBase : Person, IDay
    {
        protected DayBase(string name, string surname) : base(name, surname)
        {
        }

        public override string Name {get; set;}

        public override string Surname { get; set; }

        public string DayName { get; set; }

        public abstract void AddRating(float rating);

        public abstract bool CheckAnswer(string answer, out float result);

        public abstract Statistics GetStatistics();

        public abstract void Run();
    }
}
