using ktane_bomb_manual;
using ktane_bomb_manual.Modules;
using NUnit.Framework;

namespace Tests
{
    public class MazeTest
    {
        public Bomb bomb;

        [SetUp]
        public void Setup()
        {
            bomb = new Bomb();
        }

        [Test]
        public void Maze1()
        {
            var mazeModule = new Maze();
            mazeModule.Circle1 = "1,0";
            mazeModule.Circle2 = "2,5";
            mazeModule.ExitPosition = "2,3";
            mazeModule.PlayerPosition = "1,3";

            Assert.AreEqual("Take a right, right, down, left, left, and you are there.", mazeModule.Solve(bomb), "Error Text #1", null);

            mazeModule.ExitPosition = "5,1";
            mazeModule.PlayerPosition = "5,4";

            Assert.AreEqual("Take a right, up, up, up, left, left, down, left, up, left, up, right, up, left, left, down, down, down, down, down, right, and you are there.", mazeModule.Solve(bomb), "Error Text #2", null);
        }

        [Test]
        public void Maze2()
        {
            var mazeModule = new Maze();
            mazeModule.Circle1 = "1,4";
            mazeModule.Circle2 = "3,1";
            mazeModule.ExitPosition = "3,1";
            mazeModule.PlayerPosition = "3,2";

            Assert.AreEqual("Take a right, up, right, right, up, left, up, left, down, left, down, left, down, and you are there.", mazeModule.Solve(bomb), "Error Text #1", null);

            mazeModule.ExitPosition = "5,1";
            mazeModule.PlayerPosition = "3,2";

            Assert.AreEqual("Take a down, down, left, and you are there.", mazeModule.Solve(bomb), "Error Text #2", null);
        }


        [Test]
        public void Maze3()
        {
            var mazeModule = new Maze();
            mazeModule.Circle1 = "3,3";
            mazeModule.Circle2 = "3,5";
            mazeModule.ExitPosition = "5,5";
            mazeModule.PlayerPosition = "0,0";

            Assert.AreEqual("Take a right, right, down, down, down, down, left, up, up, left, down, down, down, right, right, right, up, up, up, right, down, down, down, right, and you are there.", mazeModule.Solve(bomb), "Error Text #1", null);

            mazeModule.ExitPosition = "1,0";
            mazeModule.PlayerPosition = "0,0";

            Assert.AreEqual("Take a down, and you are there.", mazeModule.Solve(bomb), "Error Text #2", null);
        }


        [Test]
        public void Maze4()
        {
            var mazeModule = new Maze();
            mazeModule.Circle1 = "0,0";
            mazeModule.Circle2 = "0,3";
            mazeModule.ExitPosition = "3,2";
            mazeModule.PlayerPosition = "3,1";

            Assert.AreEqual("Take a right, and you are there.", mazeModule.Solve(bomb), "Error Text #1", null);

            mazeModule.ExitPosition = "3,2";
            mazeModule.PlayerPosition = "5,1";

            Assert.AreEqual("Take a left, up, up, up, up, up, right, down, down, right, up, right, right, right, down, down, left, left, left, and you are there.", mazeModule.Solve(bomb), "Error Text #2", null);
        }


        [Test]
        public void Maze5()
        {
            var mazeModule = new Maze();
            mazeModule.Circle1 = "2,4";
            mazeModule.Circle2 = "5,3";
            mazeModule.ExitPosition = "3,2";
            mazeModule.PlayerPosition = "3,1";

            Assert.AreEqual("Take a right, and you are there.", mazeModule.Solve(bomb), "Error Text #1", null);

            mazeModule.ExitPosition = "3,2";
            mazeModule.PlayerPosition = "5,1";

            Assert.AreEqual("Take a up, right, right, up, left, and you are there.", mazeModule.Solve(bomb), "Error Text #2", null);
        }


        [Test]
        public void Maze6()
        {
            var mazeModule = new Maze();
            mazeModule.Circle1 = "0,4";
            mazeModule.Circle2 = "4,2";
            mazeModule.ExitPosition = "3,2";
            mazeModule.PlayerPosition = "3,1";

            Assert.AreEqual("Take a down, left, down, right, right, right, up, up, left, and you are there.", mazeModule.Solve(bomb), "Error Text #1", null);

            mazeModule.ExitPosition = "3,2";
            mazeModule.PlayerPosition = "5,1";

            Assert.AreEqual("Take a right, right, up, up, left, and you are there.", mazeModule.Solve(bomb), "Error Text #2", null);
        }


        [Test]
        public void Maze7()
        {
            var mazeModule = new Maze();
            mazeModule.Circle1 = "0,1";
            mazeModule.Circle2 = "5,1";
            mazeModule.ExitPosition = "3,2";
            mazeModule.PlayerPosition = "3,1";

            Assert.AreEqual("Take a left, down, down, right, right, right, right, up, left, left, up, and you are there.", mazeModule.Solve(bomb), "Error Text #1", null);

            mazeModule.ExitPosition = "3,2";
            mazeModule.PlayerPosition = "5,1";

            Assert.AreEqual("Take a right, right, right, up, left, left, up, and you are there.", mazeModule.Solve(bomb), "Error Text #2", null);
        }


        [Test]
        public void Maze8()
        {
            var mazeModule = new Maze();
            mazeModule.Circle1 = "0,3";
            mazeModule.Circle2 = "3,2";
            mazeModule.ExitPosition = "3,2";
            mazeModule.PlayerPosition = "3,1";

            Assert.AreEqual("Take a right, and you are there.", mazeModule.Solve(bomb), "Error Text #1", null);

            mazeModule.ExitPosition = "3,2";
            mazeModule.PlayerPosition = "5,1";

            Assert.AreEqual("Take a left, up, up, up, up, right, up, right, right, down, right, up, right, down, down, down, left, up, left, left, left, down, right, and you are there.", mazeModule.Solve(bomb), "Error Text #2", null);
        }

        [Test]
        public void Maze9()
        {
            var mazeModule = new Maze();
            mazeModule.Circle1 = "4,0";
            mazeModule.Circle2 = "1,2";
            mazeModule.ExitPosition = "3,2";
            mazeModule.PlayerPosition = "3,1";

            Assert.AreEqual("Take a down, down, left, up, up, up, right, up, up, right, right, right, down, down, left, down, left, and you are there.", mazeModule.Solve(bomb), "Error Text #1", null);

            mazeModule.ExitPosition = "3,2";
            mazeModule.PlayerPosition = "5,1";

            Assert.AreEqual("Take a left, up, up, up, right, up, up, right, right, right, down, down, left, down, left, and you are there.", mazeModule.Solve(bomb), "Error Text #2", null);
        }
    }
}