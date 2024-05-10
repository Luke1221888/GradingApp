using static System.Console;
using System.Collections.Generic;
using System.IO;

namespace GradeYourDay
{
    public class DayInMemory : DayBase
    {
        public static List<float> ratings = new List<float>();

        public override event RatingAddedDelegate RatingAdded;

        public DayInMemory(string day) : base(day)
        {
            Day = day;
        }

        public override void AddRating(float rating)
        {
            if (rating >= 0 && rating <= 10)
            {
                ratings.Add(rating);

                if (RatingAdded != null)
                {
                    RatingAdded(this, new EventArgs());
                }
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

        public override void ShowRatings()
        {
            foreach (var rating in ratings)
            {
                WriteLine($"{rating}");
            }
        }
    }
}