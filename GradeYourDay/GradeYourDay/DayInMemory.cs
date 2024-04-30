using static System.Console;

namespace GradeYourDay
{
    public class DayInMemory : DayBase
    {
        public string Day { get; set; }

        public static List<float> ratings = new List<float>();
        public List<string> questions = new List<string> {
            "In what number range did you make the most of your time?",
            "In what number range did you feel today?",
            "In what number range did you have contacts with people?",
            "In what number range did you manage to complete tasks?",
            "In what number range did you think positively today?",
            "In what number range did you care about entertainment?",
            "In what number range did you save money?",
            "In what number range did you care about physical activity?",
            "In what number range did you care about tidyness in your house, workplace?",
            "In what number range this day was unusual in compare to other days?"
        };

        public DayInMemory(string day) : base(day)
        {
            Day = day;
        }

        public override void AddRating(float rating)
        {
            if (rating >= 0.0 && rating <= 10.0)
            {
                ratings.Add(rating);
            }
            else
            {
                throw new Exception($"You must enter number between 0 and 10");
            }
        }

        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();

            foreach (var rating in ratings)
            {
                statistics.AddRating(rating);
            }

            return statistics;
        }

        public override void AddRating(double rating)
        {
            if (rating >= 0 && rating <= 10)
            {
                AddRating(rating);
            }
            else
            {
                throw new Exception("Rating must be between 0 and 100.");
            }
        }

        public void AddRating(string answer)
        {
            if (float.TryParse(answer, out float floatResult))
            {
                if (CheckAnswer(answer, out float rating))
                {
                    AddRating(rating);
                }
            }
            else if (char.TryParse(answer, out char charResult))
            {
                if (CheckAnswer(answer, out float rating))
                {
                    AddRating(rating);
                }
            }
            else
            {
                throw new Exception("String is not correct answer");
            }
        }

        public override void ShowRatings()
        {
            foreach (var rating in ratings)
            {
                WriteLine($"{rating}");
            }
        }

        public bool CheckAnswer(string answer, out float result)
        {
            if (float.TryParse(answer, out result))
            {
                if (result >= 0 || result <= 10)
                {
                    return true;
                }
            }
            return false;
        }
    }
}