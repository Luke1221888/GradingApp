using static System.Console;
namespace GradeYourDay
{
    public class Statistics
    {
        public float Min { get; private set; } 
        public float Max { get; private set; } 

        public float Sum { get; private set; }

        public float Count {  get; private set; }

        public float Average { 

            get
            {
                return Sum / Count;
            }
        }
        public char AverageLetter
        {

            get
            {
                switch (Average)
                {
                    case var average when average == 10:
                        WriteLine("Your day rating is excelent !");
                        break;
                    case var average when average >= 8:
                        WriteLine("Your day rating is very good");
                        break;
                    case var average when average >= 6:
                        WriteLine("Your day rating is good");
                        break;
                    case var average when average >= 3.50:
                        WriteLine("Your day rating is average");
                        break;
                    case var average when average >= 1:
                        WriteLine("Your day rating is low");
                        break;
                    default:
                        WriteLine("Your day rating is very low. Try get better result tomorow.");
                        break;
                }
                WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

                switch (Average)
                {
                    case var averageLetter when averageLetter >= 8:
                        return 'A';
                    case var averageLetter when averageLetter >= 6:
                        return 'B';
                    case var averageLetter when averageLetter >= 4:
                        return 'C';
                    case var averageLetter when averageLetter >= 2:
                        return 'D';
                    default:
                        return 'E';

                }
            }
        }
        public Statistics()
        {
            Min = float.MaxValue; 
            Max = float.MinValue;
        }

        public void AddRating(float rating)
        {
            Count++;
            Sum += rating;  
            Min = Math.Min(rating, Min);
            Max = Math.Max(rating, Max);
        }
    }
}
