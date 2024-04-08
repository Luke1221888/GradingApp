using System.Threading.Channels;
using System.Xml.Linq;
using static System.Console;

namespace GradeYourDay
{
    public class DayInMemory : DayBase
    {

        public static List<float> ratings = new List<float>();
        public string[] questions = {


            "In what number range did you make the most of your time??",
            "In what number range did you feel today?",
            "In what number range did you have contacts with people today?",
            "In what number range did you manage to complete tasks today?",
            "In what number range did you think positively today?",
            "In what number range did you care about entertainment?",
            "In what number range did you save money?",
            "In what number range did you care about physical activity? (Ex. a walk, exercises)",
            "In what number range did you care about tidyness in your house, workplace?",
            "In what number range this day was unusual in compare to other days?"

        };

        public DayInMemory(string name, string surname) : base(name, surname)
        {
        }

        public DayInMemory()
        {
            
        }
        public override void AddRating(float rating)
        {
                ratings.Add(rating);
        }

        public override bool CheckAnswer(string answer, out float result)
        {
            if (float.TryParse(answer, out result))
            {
                if (result >= 0 && result <= 10)
                    return true;
            }
            return false;
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

        public override void ShowQuestions()
        {

            WriteLine("\nType number from 0 to 10 to answer questions.");
            WriteLine("Or type 'exit' to end program\n");
            WriteLine("0 means worst result");
            WriteLine("10 means best result");
            WriteLine("*****************************************");

            for (int i = 0; i < questions.Length; i++)
            {
                WriteLine("------------------------------------------------------------------------");
                WriteLine(questions[i]);
                WriteLine("------------------------------------------------------------------------");

                float rating;
                string getNumbers;
                do
                {
                    getNumbers = ReadLine();
                    if (getNumbers.ToLower().Trim() == "exit")
                    {
                        return;

                    }
                    else
                    {
                        Write("\nType number from 0-10 or 'exit' to quit program\n");
                    }

                } while (!CheckAnswer(getNumbers, out rating));
                AddRating(rating);
            }

            Clear();
            WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            var statistics = GetStatistics();

            WriteLine($"RESULT for day is {statistics.Average:N2}");
            WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            WriteLine("");

            float minRating = ratings.Min();
            
            WriteLine("Try work a bit with following topics with lowest ratings:");
            for (int i = 0; i < questions.Length; i++)
            {
                if (minRating < 6)
                {

                    if (ratings[i] == minRating)
                    {
                        WriteLine($"- {questions[i]}: rating {ratings[i]}");
                    }

                    if (ratings[i] == minRating + 1)
                    {
                        WriteLine($"- {questions[i]}: rating {ratings[i]}");
                    }
                }
            }
            
        }

        public override void AddRating(double rating)
        {
            if (rating >= 0 && rating <= 10)
            {
                AddRating(rating);
            }
            else
            {
                Console.WriteLine("Rating must be between 0 and 10.");
            }
        }

        public override void AddRating(string answer)
        {
            if (CheckAnswer(answer, out float rating))
            {
                AddRating(rating);
            }
            else
            {
                Console.WriteLine("Błędna odpowiedź. Spróbuj jeszcze raz.");
            }
        }
    }
}