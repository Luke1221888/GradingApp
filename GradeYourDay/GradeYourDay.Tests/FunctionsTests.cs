namespace GradeYourDay.Tests
{
    public class Tests
    {
        private DayInMemory day;

        [SetUp]
        public void Setup()
        {
            day = new DayInMemory("Jan", "Kopernik");
        }

        [Test]
        public void WhenAddingNumber_ShouldThisNumberBeAddedToTheList()
        {
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
            day.AddRating(5);
            day.AddRating(4);

            var statistics = day.GetStatistics();

            Assert.AreEqual(2, statistics.Count);
            Assert.AreEqual(4.5, statistics.Average);
            Assert.AreEqual(5, statistics.Max);
            Assert.AreEqual(4, statistics.Min);

        }

    }

}