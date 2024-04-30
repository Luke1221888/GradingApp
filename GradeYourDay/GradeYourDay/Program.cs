using static System.Console;

namespace GradeYourDay
{
    class Program : Menu
    {
        static void Main(string[] args)
        {
            int desiredWidth = 190;
            int desiredHeight = 40;

            WindowHeight = desiredHeight;
            WindowWidth = desiredWidth;

            string day;
            string TextArt;
            bool isClosed = false;
            DayInFile dayInFile;
            DayInMemory dayInMemory;

            while (!isClosed)
            {
                TextArt = Menu.welcome;
                WriteLine(TextArt);
                DisplayMenu();

                var userChoice = "";

                if (string.IsNullOrEmpty(userChoice))
                {
                    userChoice = ReadLine().ToUpper();
                }

                switch (userChoice)
                {
                    case "1":
                        day = ReadData("Enter day:");
                        if (!string.IsNullOrEmpty(day))
                        {
                            dayInFile = new DayInFile(day);
                            dayInFile.SaveDayToList();
                            dayInFile.TextAdded += DayTextAdded;

                            DisplayInfo();
                            ShowQuestionsInChoiceOne(dayInFile);
                        }
                        else
                        {
                            WriteLine("Day can not be empty!");
                        }
                        break;


                    case "2":
                        day = ReadData("Enter day:");
                        if (!string.IsNullOrEmpty(day))
                        {
                            dayInMemory = new DayInMemory(day);
                            DisplayInfo();
                            ShowQuestionsInChoiceTwo(dayInMemory);
                            dayInMemory.ShowStatistics();
                        }
                        else
                        {
                            WriteLine("Day can not be empty!");
                        }
                        WriteLine("\nThank you for rating your day.\n");
                        break;


                    case "3":
                        WriteLine("We read data from text file:");
                        WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                        if (DayInFile.GetDayList())
                        {
                            day = ReadData("Please enter proper day");
                            var dayInFile3 = new DayInFile(day);

                            try
                            {
                                dayInFile3.ShowStatistics();
                            }
                            catch (Exception e)
                            {
                                WriteLine($"Exception catched ! {e.Message}");
                            }

                        }
                        else
                        {
                            WriteLine($"You must enter correct word or enter q to exit");
                        }
                        break;


                    case "Q":
                        WriteLine("Press any key to exit");
                        ReadKey();
                        isClosed = true;
                        break;


                    default:
                        WriteLine("You chose none of allowed options.");
                        userChoice = "";
                        continue;
                }
            }
        }

        static string ReadData(string comment)
        {
            WriteLine(comment);
            string userInput = ReadLine();
            return userInput;
        }

        static void DayTextAdded(object sender, EventArgs args)
        {
            WriteLine("Text was added to file!");
        }

        static void ShowQuestionsInChoiceOne(DayInFile dayInFile, int questionIndex = 0)
        {
            if (questionIndex >= dayInFile.questions.Count)
            {
                return;
            }

            WriteLine("--------------------------------------------------------------------------");
            WriteLine(dayInFile.questions[questionIndex]);
            WriteLine("--------------------------------------------------------------------------");

            string userInput = ReadLine();

            if (userInput == "exit")
            {
                return;
            }

            try
            {
                dayInFile.AddRating(userInput);

                ShowQuestionsInChoiceOne(dayInFile, questionIndex + 1);
                questionIndex++;
            }
            catch (Exception error)
            {
                WriteLine($"Exception catched: {error.Message}");

                ShowQuestionsInChoiceOne(dayInFile, questionIndex++);
            }
        }

        static void ShowQuestionsInChoiceTwo(DayInMemory dayInMemory, int questionIndex = 0)
        {
            if (questionIndex >= dayInMemory.questions.Count)
            {
                PrintLowestRatingQuestions(dayInMemory);
                return;
            }

            WriteLine("--------------------------------------------------------------------------");
            WriteLine(dayInMemory.questions[questionIndex]);
            WriteLine("--------------------------------------------------------------------------");

            string userInput = ReadLine();

            if (userInput == "exit")
            {
                return;
            }

            try
            {
                dayInMemory.AddRating(userInput);
                ShowQuestionsInChoiceTwo(dayInMemory, questionIndex + 1);
            }
            catch (Exception error)
            {
                WriteLine($"Exception catched: {error.Message}");
                ShowQuestionsInChoiceTwo(dayInMemory, questionIndex);
            }
        }

        static void PrintLowestRatingQuestions(DayInMemory dayInMemory)
        {
            var minRating = DayInMemory.ratings.Min();

            WriteLine("Try work a bit with following topics with lowest ratings:\n");

            for (int i = 0; i < dayInMemory.questions.Count; i++)
            {
                if (DayInMemory.ratings[i] < 5)
                {
                    WriteLine($"- {dayInMemory.questions[i]}: rating {DayInMemory.ratings[i]}\n");
                }
            }
        }
    }
}