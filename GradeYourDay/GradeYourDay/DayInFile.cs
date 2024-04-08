using static System.Console;

namespace GradeYourDay
{
    public class DayInFile : DayBase
    {

        public List<float> ratings = new List<float>();
        public List<string> questions = new List<string> {


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

        private string FileName = "_ratings.txt";
        public override string FirstName { get; set; }
        public override string LastName { get; set; }
        private string FullFileName { get; set; }
        public string DayName { get; set; }

        public delegate void TextAddedToFile(object sender, EventArgs args);

        public event TextAddedToFile TextAdded;


        public DayInFile(string firstName, string lastName, string dayName) : base(firstName, lastName)
        {
            FullFileName = $"{firstName}_{lastName}_{dayName}{FileName}";
            DayName = dayName;
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

        public override void AddRating(float rating)
        {
            if (rating >= 0 && rating <= 10)
            {
                ratings.Add(rating);
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

            foreach (var rating in ratings)
            {
                statistics.AddRating(rating);
            }

            return statistics;
        }

        FileStream fout, fin;

        public void SaveToFileAndReadFromFile()
        {
            var result = GetStatistics();
            fout = new FileStream(FileName, FileMode.Append);
            StreamWriter fstr_out = new StreamWriter(fout);
            fstr_out.WriteLine(FullFileName);
            fstr_out.WriteLine($"Average for this day: {result.Average}");
            fstr_out.WriteLine($"Minimal rating for this day: {result.Min}");
            fstr_out.WriteLine($"Maximal rating for this day: {result.Max}");
            fstr_out.WriteLine($"Grade as letter(A-E) for {FirstName} is: {result.AverageLetter}");
            if (TextAdded != null)
            {
                TextAdded(this, new EventArgs());
            }
            WriteLine();
            WriteLine("We read data from text file:");
            WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            fstr_out.Close();
            fout.Close();
            fin = new FileStream(FileName, FileMode.Open);
            StreamReader fstr_in = new StreamReader(fin);
            while ((FileName = fstr_in.ReadLine()) != null)
            {
                WriteLine(FileName);
            }
            WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            fstr_in.Close();
            fin.Close();
        }

        public override void ShowQuestions()
        {

            int questionIndex = 0;

            while (questionIndex < questions.Count)
            {
                try
                {
                    WriteLine("------------------------------------------------------------------------");
                    Console.WriteLine(questions[questionIndex]);
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
                    Console.WriteLine("This should not have happen");
                }
            }

            Clear();
            WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            WriteLine("");

            float minRating = ratings.Min();

            WriteLine("Try work a bit with following topics with lowest ratings:");
            for (int i = 0; i < questions.Count; i++)
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

            WriteLine("\nThank you for rating your day.\n");
        }

    }
}
