using static System.Console;

namespace GradeYourDay
{
    public class DayInFile : DayBase
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

        private const string fileName = "ratings.txt";
        private string fullFileName;
        private const string DayList = "Day_list.txt";
        public string Day { get; set; }

        public delegate void TextAddedToFile(object sender, EventArgs args);

        public event TextAddedToFile TextAdded;

        public DayInFile(string day) : base(day)
        {
            Day = day;
            fullFileName = $"{day}_{fileName}";
        }

        public override void AddRating(double rating)
        {
            if (rating >= 0 && rating <= 10)
            {
                using (var writer = File.AppendText(fullFileName))
                {
                    writer.WriteLine(rating);
                    if (TextAdded != null)
                    {
                        TextAdded(this, new EventArgs());
                    }
                }
            }
            else
            {
                throw new Exception("Number can't be add to file because its over range");
            }
        }

        public override void AddRating(float rating)
        {
            if (rating >= 0 && rating <= 10)
            {
                using (var writer = File.AppendText(fullFileName))
                {
                    writer.WriteLine(rating);
                    if (TextAdded != null)
                    {
                        TextAdded(this, new EventArgs());
                    }
                }
            }
            else
            {
                throw new Exception("Number can't be add to file because its over range");
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

        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();

            if (File.Exists(fullFileName))
            {
                using (var reader = File.OpenText(fullFileName))
                {
                    var line = reader.ReadLine();
                    while (line is not null)
                    {
                        var number = float.Parse(line);
                        statistics.AddRating(number);
                        line = reader.ReadLine();
                    }
                }
            }
            return statistics;
        }

        public override void ShowRatings()
        {
            if (File.Exists(fullFileName))
            {
                using (var reader = File.OpenText(fullFileName))
                {
                    var line = reader.ReadLine();
                    while (line is not null)
                    {
                        WriteLine($"{line}");
                        line = reader.ReadLine();
                    }
                }
            }
            else
            {
                throw new Exception($"Not avalaible");
            }
        }

        public void SaveDayToList()
        {
            bool isExist = false;
            string dayInFile = $"{Day.ToLower()}_{fileName.ToLower()}";

            if (File.Exists(DayList))
            {
                using (var reader = File.OpenText(DayList))
                {
                    var line = reader.ReadLine();
                    while (line is not null)
                    {
                        if (line == dayInFile)
                        {
                            isExist = true;
                            break;
                        }
                        line = reader.ReadLine();
                    }
                }
            }
            if (!isExist || !File.Exists(DayList))
            {
                using (var writer = File.AppendText(DayList))
                {
                    writer.WriteLine(dayInFile);
                }
            }
        }

        public static bool GetDayList()
        {
            if (File.Exists(DayList))
            {
                using (var reader = File.OpenText(DayList))
                {
                    var line = reader.ReadLine();
                    int found = 0;

                    string lineDay;
                    List<string> listOfDay = new();

                    while (line is not null)
                    {
                        found = line.IndexOf('_');
                        lineDay = line.Substring(0, found);
                        lineDay = $"{char.ToUpper(lineDay[0])}{lineDay.Substring(1, lineDay.Length - 1)}";
                        listOfDay.Add($"{lineDay}");
                        line = reader.ReadLine();
                    }

                    listOfDay.Sort();
                    int n = 1;
                    foreach (var day in listOfDay)
                    {
                        WriteLine($"{n}. {day}");
                        n++;
                    }
                    WriteLine();
                }
                return true;
            }
            else
            {
                WriteLine("No day has been saved yet.\n");
                return false;
            }
        }
    }
}


