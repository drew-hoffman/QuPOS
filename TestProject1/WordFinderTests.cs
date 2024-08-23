using QuPOS;

namespace TestProject1
{
    public class WordFinderTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestHorizontalTextSearch()
        {
            List<string> matrix = ["xxxxxx", "WORLDx", "xxxxxx", "HELLOx", "xHello", "xWORLx"];
            List<string> myList = ["world", "Hello ", "Fail"];
            WordFinder finder = new(matrix);
            var results = finder.Find(myList);
            Assert.NotNull(results);
            Assert.That(results.Count(), Is.EqualTo(2));
            Assert.That(results.First(), Is.EqualTo("Hello"));
            Assert.True(results.Contains("world"));
            Assert.False(results.Contains("Fail"));
        }

        [Test]
        public void TestMaxSizeSearch()
        {
            List<string> matrix = [
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "WORLDxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxHELLO",
                "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx",
                "xWORLxDxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx"];
            while (matrix.Count() < 64)
            {
                matrix.Add("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
            }

            List<string> myList = ["Hello", "world", "Fail"];
            WordFinder finder = new(matrix);
            var results = finder.Find(myList);
            Assert.NotNull(results);
            Assert.That(results.Count(), Is.EqualTo(2));
            Assert.True(results.Contains("Hello"));
            Assert.True(results.Contains("world"));
            Assert.False(results.Contains("Fail"));
            Assert.That(matrix.Count(), Is.EqualTo(64));
            Assert.That(matrix[63].Count(), Is.EqualTo(64));
        }

        [Test]
        public void TestMinSizeSearch()
        {
            List<string> matrix = ["x"];
            List<string> myList = ["x", "Fail"];
            WordFinder finder = new(matrix);
            var results = finder.Find(myList);
            Assert.NotNull(results);
            Assert.That(results.Count(), Is.EqualTo(1));
            Assert.True(results.Contains("x"));
            Assert.False(results.Contains("Fail"));
            Assert.That(matrix.Count(), Is.EqualTo(1));
            Assert.That(matrix[0].Count(), Is.EqualTo(1));
        }

        [Test]
        public void TestHorizontalTextSearchTwice()
        {
            List<string> matrix = ["xHELLO", "WORLDx", "xxxxxx", "xxxxxx", "xxxxxx", "xxxxxx"];
            WordFinder finder = new(matrix);
            var results = finder.Find(["Hello"]);
            var results2 = finder.Find(["World"]);
            Assert.NotNull(results2);
            Assert.That(results2.Count(), Is.EqualTo(1));
            Assert.True(results2.Contains("World"));
        }

        [Test]
        public void TestVerticalTextSearch()
        {
            List<string> matrix = ["Hxxxxx", "ExxxWx", "LxxxOx", "LxxxRx", "OxxxLx", "xxxxDx"];
            List<string> myList = ["Hello", "World", "Fail"];
            WordFinder finder = new(matrix);
            var results = finder.Find(myList);
            Assert.NotNull(results);
            Assert.That(results.Count(), Is.EqualTo(2));
            Assert.True(results.Contains("Hello"));
            Assert.True(results.Contains("World"));
            Assert.False(results.Contains("Fail"));
        }

        [Test]
        public void TestNonSquareMatrix()
        {
            List<string> matrix = ["HxxxHOWDY", "ExxxWxxxx", "LxxxOxxxx", "LxxxRxxxx", "OxxxLxxxx", "xxxxDxxxx"];
            List<string> myList = ["Hello", "World", "Howdy", "Fail"];
            WordFinder finder = new(matrix);
            var results = finder.Find(myList);
            Assert.NotNull(results);
            Assert.That(results.Count(), Is.EqualTo(3));
            Assert.True(results.Contains("Hello"));
            Assert.True(results.Contains("World"));
            Assert.True(results.Contains("Howdy"));
            Assert.False(results.Contains("Fail"));
        }
    }
}