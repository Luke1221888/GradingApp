using static System.Console;


namespace GradeYourDay
{
    public class Day
    {

        private string DayName;

        public static List<float> ratings = new List<float>();
        private string[] questions = {


            "W jakim stopniu udało Ci się dzisiaj spożytkować czas?",
            "Jak się dzisiaj czułeś/aś?",
            "Na ile miałaś dzisiaj kontakty z innymi ludźmi?",
            "Na ile udało się wykonać dzisiaj zadań?",
            "Na ile myślałaś/eś dzisiaj pozytywnie?",
            "Na ile dbałaś dzisiaj o rozrywkę?",
            "Na ile udało Ci się zaoszczędzić dzisiaj pieniądze?",
            "Na ile miałeś/aś odpowiednią dawkę ruchu? (np. spacer, ćwiczenia itp.)",
            "Na ile uważasz zostawiłeś w miejscu domu, pracy porządek?",
            "Na ile ten dzień był inny od pozostałych?"

        };

        public Day(string dayName)
        {
            DayName = dayName;
        }

        public void Run()
        {
            Title = "GradeYourDay";

            WriteLine("Prosta aplikacja do pomocy oceny dnia");
            WriteLine("*******************************************");


            WriteLine("\nPodawaj liczby od 0-10 by odpowiedzieć na pytania.");
            WriteLine("Lub wpisz 'exit' aby zakończyć program\n");
            WriteLine("0 oznacza najgorszy wynik");
            WriteLine("10 oznacza najlepszy wynik");
            WriteLine("*****************************************");



            for (int i = 0; i < questions.Length; i++)
            {
                WriteLine(questions[i]);

                float rating;
                string userInput;
                do
                {
                    userInput = ReadLine();
                    if (userInput.ToLower().Trim() == "exit") // Sprawdź, czy użytkownik chce wyjść
                    {
                        return; 

                    }
                    else
                    {
                        Write("\nWpisz liczbę od 0-10 lub 'exit' aby wyjść\n");
                    }

                } while (!CheckAnswer(userInput, out rating));

                AddRating(rating);
            }

            Clear();
            WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            var statistics = GetStatistics();
            WriteLine($"WYNIK: {statistics.Average:N2}");
            WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            WriteLine("");

            float minRating = ratings.Min();
            WriteLine($"Ilość ocen: {statistics.Count}");
            
            WriteLine("Popracuj nad poniższymi tematami o najniższych ocenach:");
            for (int i = 0; i < questions.Length; i++)
            {
                if (ratings[i] == minRating)
                {
                    WriteLine($"- {questions[i]}: ocena {ratings[i]}");
                }
               
                if (ratings[i] == minRating + 1)
                {
                    WriteLine($"- {questions[i]}: ocena {ratings[i]}");
                }
            }

                WriteLine("Dziękuję za ocenę Twojego dnia.");

            WriteLine();
            ReadKey();
        }

        public static void AddRating(float rating)
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


        public static bool CheckAnswer(string answer, out float result)
        {
            if (float.TryParse(answer, out result))
            {
                if (result >= 0 && result <= 10)
                    return true;
            }
            return false;
        }

        public static Statistics GetStatistics()
        {
            var statistics = new Statistics();
            statistics.Average = 0;
            statistics.Max = float.MinValue;
            statistics.Min = float.MaxValue;

            foreach (var rating in ratings)
            {
                statistics.Max = Math.Max(statistics.Max, rating);
                statistics.Min = Math.Min(statistics.Min, rating);
                statistics.Average += rating;
            }
            statistics.Average = statistics.Average /= ratings.Count;
            statistics.Count = ratings.Count;

            switch (statistics.Average)
            {
                case var average when average == 10:
                    WriteLine("Twój dzień był wzorowy ! Gratulacje !");
                    break;
                case var average when average >= 8:
                    WriteLine("Twój dzień był bardzo dobry");
                    break;
                case var average when average >= 6:
                    WriteLine("Twój dzień był dobry");
                    break;
                case var average when average >= 3.50:
                    WriteLine("Twój dzień był średni");
                    break;
                case var average when average >= 1:
                    WriteLine("Twój dzień był słaby");
                    break;
                default:
                    WriteLine("Twój dzień był fatalny. Zawalcz o następny dzień.");
                    break;
            }

            return statistics;

        }
    }
}
