namespace GradeYourDay
{
    public abstract class DayBase : IDay
    {

        public List<string> questions = new List<string> {
            "In what number range did you make the most of your time??",
            "In what number range did you feel today?",
            "In what number range did you have contacts with people today?",
            "In what number range did you manage to complete tasks today?",
            "In what number range did you think positively today?",
            "In what number range did you care about entertainment?",
            "In what number range did you save money?",
            "In what number range did you care about physical activity?",
            "In what number range did you care about tidyness in your house, workplace?",
            "In what number range this day was unusual in compare to other days?"
        };

        public event IDay.TextAddedToFile TextAdded;

        public string Day { get; set; }

        protected DayBase(string day)
        {
        }

        public DayBase()
        {
        }

        public abstract void AddRating(float rating);

        public abstract void AddRating(double rating);

        public abstract void AddRating(string answer);

        public abstract bool CheckAnswer(string answer, out float result);

        public abstract Statistics GetStatistics();

        public abstract void ShowQuestions();
    }
}
