using static System.Console;

namespace GradeYourDay
{
    public class DayInFile : DayBase
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

        private string FileName = "_ratings.txt";

        public string Day { get; set; }

        public delegate void TextAddedToFile(object sender, EventArgs args);

        public event TextAddedToFile TextAdded;


        public DayInFile(string day) : base(day)
        {
            Day = day;
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

        public override void AddRating(float rating)
        {
            if (rating >= 0 && rating <= 10)
            {
                using (var writer = File.AppendText(FileName))
                {
                    writer.WriteLine(rating);
                    if (TextAdded != null)
                    {
                        TextAdded(this, new EventArgs());
                    }
                }
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
                WriteLine("String is not correct answer");
            }
        }

        public override bool CheckAnswer(string answer, out float result)
        {

            if (float.TryParse(answer, out result))
            {
                if (result >= 0 && result <= 10)
                {
                    return true;
                }
            }
            return false;
        }

        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();
            CountStatistics();
            ReadFromFile();

            return statistics;
        }

        public void CountStatistics()
        {
            if (File.Exists(FileName))
            {
                using (StreamReader reader = new StreamReader(FileName))
                {
                    string line;
                    float sum = 0;
                    int count = 0;
                    float min = float.MaxValue;
                    float max = float.MinValue;

                    while ((line = reader.ReadLine()) != null)
                    {
                        if (float.TryParse(line, out float value))
                        {
                            sum += value;

                            if (value < min)
                                min = value;

                            if (value > max)
                                max = value;
                            count++;
                        }
                        else
                        {
                            WriteLine($"Line parse error: {line}");
                        }
                    }

                    float average = count > 0 ? sum / count : 0;

                    WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                    WriteLine($"Statistics for {Day}:");
                    WriteLine($"Average grade counted from text file : {average}");
                    WriteLine($"Minimal grade from text file: {min}");
                    WriteLine($"Maximal grade from text file: {max}");
                    WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                }
            }
            else
            {
                WriteLine("File with ratings doesn't exist");
            }
        }

        public void ReadFromFile()
        {
            WriteLine();
            WriteLine("We read data from text file:");
            WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            using (StreamReader reader = new StreamReader("_ratings.txt"))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    WriteLine(line);
                }
            }
            WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        }
        public override void ShowQuestions()
        {
            int questionIndex = 0;

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
            WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            WriteLine("");
            WriteLine("\nThank you for rating your day.\n");
        }
    }
}
