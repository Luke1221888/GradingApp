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
            "In what number range did you have contacts with people today?",
            "In what number range did you manage to complete tasks today?",
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


            var questionIndex = 0;

            while (questionIndex < questions.Count)
            {
                try
                {
                    WriteLine("------------------------------------------------------------------------");
                    WriteLine(questions[questionIndex]);
                    WriteLine("------------------------------------------------------------------------");

                    string getNumbers = ReadLine();


                    if (getNumbers.ToLower().Trim() == "exit")
                    {
                        break;
                    }
                    if (CheckAnswer(getNumbers, out float rating))
                    {
                        AddRating(getNumbers);
                        questionIndex++;
                    }
                    else
                    {
                        WriteLine("Answer is wrong. Try again.");
                    }

                }
                catch (Exception)
                {
                    WriteLine("This should not have happen");
                }
            }

            Clear();
            WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            var result = GetStatistics();
            WriteLine($"Statistics for {Day}:");
            WriteLine($"Average is {result.Average}");
            WriteLine($"Grade as letter is: {result.AverageLetter}");
            WriteLine($"Maximal entered grade is: {result.Max}");
            WriteLine($"Minimal entered  grade is: {result.Min}");
            WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            WriteLine("");

            var minRating = result.Min;

            WriteLine("Try work a bit with following topics with lowest ratings:");
            for (int i = 0; i < questions.Count; i++)
            {
                if (ratings[i] < 5)
                {
                    for (int j = 0; j < 1; j++)
                    {
                        if (minRating < 5)
                        {
                            WriteLine($"- {questions[i]}: rating {ratings[i]}");
                        }
                    }
                }
            }

            WriteLine("\nThank you for rating your day.\n");
        }

        public override void AddRating(double rating)
        {
            if (rating >= 0 && rating <= 10)
            {
                AddRating(rating);
            }
            else
            {
                WriteLine("Rating must be between 0 and 10.");
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
                WriteLine("Rating can't be string.");
            }
        }
    }
}