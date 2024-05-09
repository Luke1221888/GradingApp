using static GradeYourDay.DayBase;

namespace GradeYourDay
{
    public interface IDay
    {
        string Day { get; set; }

        void AddRating(float rating);
        void AddRating(string answer);

        bool CheckAnswer(string answer, out float result);

        void ShowStatistics();
        void ShowRatings();

        Statistics GetStatistics();

        event RatingAddedDelegate RatingAdded;  
    }
}
