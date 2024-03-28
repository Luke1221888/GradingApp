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
            "In what number range did you care about physical avtivity? (Ex. a walk, exercises)",
            "In what number range did you care about tidyness in your house, workplace?",
            "In what number range this day was unusual in compare to other days?"

        };

        public DayInMemory(string name, string surname) : base(name, surname)
        {
        }


        public override void AddRating(float rating)
        {
            if (rating >= 0 && rating <= 10)
            {
                ratings.Add(rating);
            }
            else
            {
                WriteLine("Wpisano liczbe poza zakresem liczb!");
            }
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



            statistics.Count = ratings.Count;
            statistics.Min = float.MaxValue;
            statistics.Max = float.MinValue;
            statistics.Average = 0;

            foreach (var rating in ratings)
            {
                statistics.Min = Math.Min(statistics.Min, rating);
                statistics.Max = Math.Max(statistics.Max, rating);
                statistics.Average += rating;
            }

            statistics.Average /= ratings.Count;



            switch (statistics.Average)
            {
                case var average when average == 10:
                    WriteLine("Twój dzień był wzorowy ! Gratulacje !");
                    break;
                case var average when average >= 8:
                    WriteLine("Ocena Twojego dnia wyszła bardzo dobra");
                    break;
                case var average when average >= 6:
                    WriteLine("Ocena Twojego dnia wyszła dobra");
                    break;
                case var average when average >= 3.50:
                    WriteLine("Ocena Twojego dnia wyszła średnia");
                    break;
                case var average when average >= 1:
                    WriteLine("Ocena Twojego dnia wyszła niska");
                    break;
                default:
                    WriteLine("Ocena Twojego dnia wyszła bardzo nisko. Zawalcz o następny dzień.");
                    break;
            }

            return statistics;
        }

        public override void Run()
        {
            Title = "GradeYourDay";

            WriteLine("Simply app for rating a day of patients");
            WriteLine("*******************************************");

            WriteLine("\nType number from 0 to 10 to answer questions.");
            WriteLine("Or type 'exit' to end program\n");
            WriteLine("0 means worst result");
            WriteLine("10 means best result");
            WriteLine("*****************************************");


            for (int i = 0; i < questions.Length; i++)
            {
                WriteLine(questions[i]);

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

            WriteLine($"RESULT for day {DayName}: {statistics.Average:N2}");
            WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            WriteLine("");

            float minRating = ratings.Min();
            WriteLine($"Amount of grades: {statistics.Count}");

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

            WriteLine("Thank you for rating your day.\n");
        }
    }
}