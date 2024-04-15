using static System.Console;

namespace GradeYourDay
{
    class Program
    {
        private static void Main(string[] args)
        {
            Title = "GradeYourDay";
            WriteLine("Simply app for rating a day of patients");
            WriteLine("***********************************************");

            while (true)
            {
                WriteLine("Type on keyboard '1' to add ratings of your day into file and read statistics");
                WriteLine("Type on keyboard '2' to check your  day statistics in program memory");
                WriteLine("Type on keyboard 'Q' to quit program");
                WriteLine("What will you do?");

                string input = ReadLine();
                if (input == "1")
                {
                    string day = ReadData("Enter day:");
                    if (!string.IsNullOrEmpty(day))
                    {
                        var dayInFile = new DayInFile(day);
                        WriteLine("\nType number from 0 to 10 to answer questions.");
                        WriteLine("Or type 'exit' to end program\n");
                        WriteLine("0 means worst result");
                        WriteLine("10 means best result");
                        WriteLine("***********************************************");

                        dayInFile.TextAdded += DayTextAdded;
                        dayInFile.ShowQuestions();
                        dayInFile.GetStatistics();
                    }
                    else
                    {
                        WriteLine("Day can not be empty!");
                    }
                }
                else if (input == "2")
                {
                    string day = ReadData("Enter day:");
                    var dayInMemory = new DayInMemory(day);
                    dayInMemory.ShowQuestions();
                    break;
                }
                else if (input == "q".ToLower().Trim())
                {
                    break;
                }
                else
                {
                    WriteLine("You chose none of options.");
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
                Console.WriteLine("Text was added to file!");
            }
        }
    }
}
