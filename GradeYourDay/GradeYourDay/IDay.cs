namespace GradeYourDay
{
    public interface IDay
    {
        string Day { get; set; }

        void AddRating(float rating);

        void AddRating(string answer);

        bool CheckAnswer(string answer, out float result);

        Statistics GetStatistics();

        delegate void TextAddedToFile(object sender, EventArgs args);

        event TextAddedToFile TextAdded;
    }
}
