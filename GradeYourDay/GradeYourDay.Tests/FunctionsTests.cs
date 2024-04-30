namespace GradeYourDay.Tests
{
    public class Tests
    {
        [Test]
        public void WhenAddingPoints_ShouldThisPointsBeAddedToTheList()
        {
            DayInMemory day = new DayInMemory("monday");

            List<float> ratings = new List<float>();
            float numberToAdd1 = 5;
            float numberToAdd2 = 10;

            day.AddRating(numberToAdd1);
            day.AddRating(numberToAdd2);

            Assert.AreEqual(2, DayInMemory.ratings.Count);
            Assert.AreEqual(numberToAdd1, DayInMemory.ratings[0]);

        }
        [Test]
        public void WhenAddingPoints_ShouldReturnCorrectStatistics()
        {
            Statistics statistics = new Statistics();
            DayInMemory result = new DayInMemory("monday");

            statistics.AddRating(5);
            statistics.AddRating(4);
            statistics.AddRating(2);
            statistics.AddRating(1);

            result.GetStatistics();

            Assert.AreEqual(4, statistics.Count);
            Assert.AreEqual(12, statistics.Sum);
            Assert.AreEqual(3, statistics.Average);
            Assert.AreEqual(5, statistics.Max);
            Assert.AreEqual(1, statistics.Min);

        }
    }
}