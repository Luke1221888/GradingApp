using System.IO;

namespace GradeYourDay
{
    public class DayInFile : DayBase
    {

        private string fileName = "ratings.txt";

        public DayInFile(string firstName, string lastName) : base(firstName, lastName)
        {
        }

        public override void AddRating(float rating)
        {
            using (var writer = File.AppendText(fileName))
            {
                writer.WriteLine(rating);
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
            using (var reader = File.OpenText(fileName))
            {

                float sum = 0;
                var result = new Statistics();
                int count = 0;

                if (File.Exists(fileName))
                {
                   
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        var number = float.Parse(line);
                        result.Max = Math.Max(result.Max, number);
                        result.Min = Math.Min(result.Min, number);
                        result.Average += number;
                        
                    }

                    float average = count > 0 ? sum / count : 0;

                    Console.WriteLine($"Średnia: {average}");
                    Console.WriteLine($"Minimalna: {result.Min}");
                    Console.WriteLine($"Maksymalna: {result.Max}");
                     

                }
                else
                {
                    Console.WriteLine(  "Plik nie istnieje.");
                }


                return result;
            }
        }

        public override void Run()
        {
            throw new NotImplementedException();
        }
    }
}
