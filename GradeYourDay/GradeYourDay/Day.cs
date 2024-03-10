using static System.Console;


namespace GradeYourDay
{
    public class Day
    {

        private string DayName;

        private static List<float> ratings = new List<float>();
        private string[] questions = {

            "W jakim stopniu udało Ci się dzisiaj spożytkować czas?",
            "Jak się dzisiaj czułeś/aś?",
            "W jakim stopniu miałeś/aś dzisiaj kontakty społeczne?",
            "Na ile udało się wykonać dzisiaj zadań?",
            "Na ile myślałaś/eś dzisiaj pozytywnie?",
            "Na ile dbałaś dzisiaj o rozrywkę?",
            "Na ile udało Ci się zaoszczędzić dzisiaj pieniądze?",
            "Na ile miałeś/aś odpowiednią dawkę ruchu? (np. spacer, ćwiczenia itp.)",
            "Na ile uważasz zostawiłeś w miejscu domu, pracy porządek?",
            "Generalnie, jak oceniasz swój dzisiejszy dzień?"

        };

        public Day(string dayName)
        {
            DayName = dayName;
        }

        public void Run()
        {
            Title = "GradeYourDay";

            WriteLine("Program ten to prosta aplikacja do pomocy przy ocenie dnia");
            WriteLine("**********************************************************");

            bool saidYes = Day.PromptYesNo($"Czy chcesz ocenić swój dzień? Wpisz 'tak' by wyświetlić pytania lub 'nie' by zakończyć.");
            
            if (saidYes == true)
            {
                WriteLine("\nPodawaj odpowiedzi na pytania w postaci liczb w zakresie od 1-10\n");
                WriteLine("--------------------------------------------------------------------");
                AskQuestions();

                var statistics = GetStatistics();

                WriteLine($"Srednia z wprowadzonych danych: {statistics.Average:N2}"); 
                WriteLine($"Minimalna wprowadzona wartosc:{statistics.Min}"); 
                WriteLine($"Maksymalna wprowadzona wartosc: {statistics.Max}");
            }
            else
            {
                WriteLine("Może innym razem");
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

        public void AddRating(string rating)
        {
            if (float.TryParse(rating, out float result))
            {
                AddRating(result);
            }
            else
            {
                WriteLine("Podana nazwa to nie liczba!");
            }
        }

        public void AskQuestions()
        {

            for (int i = 0; i < questions.Length; i = i + 1)
            {

                WriteLine(questions[i]);

                float rating;

                while (!CheckAnswer(ReadLine(), out rating))
                {

                    WriteLine("Błędna odpowiedź. Spróbuj jeszcze raz.");

                }


                AddRating(rating);
                WriteLine("-----------------------------------------------------------------");
            }
        }

        public static bool CheckAnswer(string rating, out float result)
        {
            if (float.TryParse(rating, out result))
            {
                    return true;
            }
            return false;

        }

        public static bool PromptYesNo(string question)
        {
            WriteLine(question);
            string response = Console.ReadLine().ToLower().Trim();
            if (response == "tak")
            {
                return true;
            }
            else if (response == "nie")
            {
                return false;
            }
            else
            {
                return false;
            }
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
            return statistics;
        }
    }
}
