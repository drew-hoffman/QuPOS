
using QuPOS;

namespace QuPOSTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            List<string> matrix = ["AHELLO", "WORLDB", "ABCDEF", "GHIJKL", "MNOPQR", "STUVWX"];
            List<string> myList = ["Hello", "World", "Fail"];
            WordFinder finder = new(matrix);
            var results = finder.Find(myList);
            Assert.NotNull(results);
            Assert.Equal(2, results.Count());
            Assert.Contains("Hello", results);
            Assert.Contains("World", results);
            Assert.DoesNotContain("Fail", results);
        }

        [Fact]
        public void Test2()
        {
            List<string> matrix = ["AHELLO", "WORLDB", "ABCDEF", "GHIJKL", "MNOPQR", "STUVWX"];
            List<string> myList = ["Hello", "World", "Fail"];
            WordFinder finder = new(matrix);
            var results = finder.Find(myList);
            Assert.NotNull(results);
            Assert.Equal(2, results.Count());
            Assert.Contains("Hello", results);
            Assert.Contains("World", results);
            Assert.DoesNotContain("Fail", results);
        }
    }
}