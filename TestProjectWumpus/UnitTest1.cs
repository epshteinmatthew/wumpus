namespace TestProjectWumpus
{
    using Chan_WumpusTest;
    using Wumpus;
    public class UnitTest1
    {
        [Fact]
        public void TestCaveAdjacent()
        {
            Cave cave = new Cave("1", 1, 1);
            string expectedReturn = "25 26 2 7 6 30";
            int room = 1;

            var testvar = cave.GetAdjacentCaves(room)[0].ToString() + " " + cave.GetAdjacentCaves(room)[1].ToString() + " " +
                cave.GetAdjacentCaves(room)[2].ToString() + " " + cave.GetAdjacentCaves(room)[3].ToString() + " " +
                cave.GetAdjacentCaves(room)[4].ToString() + " " + cave.GetAdjacentCaves(room)[5].ToString();

            Assert.Equal(expectedReturn, testvar);
        }

    }
}