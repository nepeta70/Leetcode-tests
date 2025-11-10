namespace Leetcode_tests
{
    public class UnitTest1
    {
        [Fact]
        public void PlusOneTest()
        {
            var input = new int[] { 6, 1, 4, 5, 3, 9, 0, 1, 9, 5, 1, 8, 6, 7, 0, 5, 5, 4, 3 };

            var solution = new Solution().PlusOne(input);

            var expected = new int[] { 6, 1, 4, 5, 3, 9, 0, 1, 9, 5, 1, 8, 6, 7, 0, 5, 5, 4, 4 };

            Assert.Equal(expected, solution);
        }
    }
}
