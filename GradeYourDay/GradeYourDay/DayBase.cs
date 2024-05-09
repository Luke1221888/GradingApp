using System;
namespace GradeYourDay
{
    public abstract class DayBase : IDay
    {
        public List<string> questions = new List<string> {
            "In what number range did you make the most of your time?",
            "In what number range did you feel?",
            "In what number range did you have contacts with people?",
            "In what number range did you manage to complete tasks?",
            "In what number range did you think positively?",
            "In what number range did you care about entertainment?",
            "In what number range did you save money?",
            "In what number range did you care about physical activity?",
            "In what number range did you care about tidyness in your house, workplace?",
            "In what number range this day was unusual in compare to other days?"
        };

        public delegate void RatingAddedDelegate(object sender, EventArgs args);

        public abstract event RatingAddedDelegate RatingAdded;

        public string Day { get; set; }

        public DayBase(string day)
        {
            Day = day;
        }

        public abstract void AddRating(float rating);

        public abstract void AddRating(double rating);

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

        public abstract void ShowRatings();

        public abstract Statistics GetStatistics();

        public void ShowStatistics()
        {
            var statistics = GetStatistics();
            Console.WriteLine($"Statistics for {Day}");
            Console.WriteLine();
            Console.Write("Ratings : \n");
            ShowRatings();
            Console.WriteLine();
            Console.WriteLine($"Count of entered numbers:  {statistics.Count}");
            Console.WriteLine($"Highest rating:            {statistics.Max}");
            Console.WriteLine($"Lowest rating:             {statistics.Min}");
            Console.WriteLine($"Average rating:            {statistics.Average:F2}");
            Console.WriteLine($"Grade as letter is:        {statistics.AverageLetter}");
            Console.WriteLine($"Sum of entered numbers:    {statistics.Sum}");
        }
    }
}
