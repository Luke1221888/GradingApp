using static System.Console;

namespace GradeYourDay
{
    class Program
    {
        private static void Main(string[] args)
        {
            Title = "GradeYourDay";

            WriteLine("Simply app for rating a day of patients");
            WriteLine("*******************************************");
            WriteLine("Type on keyboard '1' to add your day data into file");
            WriteLine("Type on keyboard '2' to check your day average");
            WriteLine("Type on keyboard 'Q' to quit program");
            WriteLine("What will you do?");

            while (true)
            {
                string input = ReadLine();
                if (input == "1")
                {
                    string firstName = ReadData("Enter first name:");
                    string lastName = ReadData("Enter second name:");
                    string dayName = ReadData("Enter day name:");
                    if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName) && !string.IsNullOrEmpty(dayName))
                    {
                        var dayInFile = new DayInFile(firstName, lastName, dayName);

                        WriteLine("\nType number from 0 to 10 to answer questions.");
                        WriteLine("Or type 'exit' to end program\n");
                        WriteLine("0 means worst result");
                        WriteLine("10 means best result");
                        WriteLine("*****************************************");

                        dayInFile.TextAdded += DayTextAdded;
                        dayInFile.ShowQuestions();
                        dayInFile.SaveToFileAndReadFromFile();
                    }
                    else
                    {
                        WriteLine("Patient's firstname, lastname and dayname can not be empty!");

                       
                        WriteLine("Type on keyboard '1' to start program");
                        WriteLine("Type on keyboard 'Q' to quit program");
                        WriteLine("What will you do?");
                    }
                }
                else if (input == "2")
                {
                    var dayInMemory = new DayInMemory();
                    dayInMemory.ShowQuestions();
                    break;
                }
                else if(input == "q".ToLower())
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








