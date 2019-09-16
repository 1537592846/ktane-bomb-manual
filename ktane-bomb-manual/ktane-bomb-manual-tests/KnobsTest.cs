using ktane_bomb_manual;
using ktane_bomb_manual.Modules;
using NUnit.Framework;

namespace Tests
{
    public class KnobsTest
    {
        public Bomb bomb;

        [SetUp]
        public void Setup()
        {
            bomb = new Bomb();
            bomb.Serial = "T5K8W9";
        }

        [Test]
        public void FullConfigTest()
        {
            //Can't tell yet
            var knobsModule = new Knobs();
            knobsModule.Sequence = "none none none none none none";
            Assert.AreEqual("Can't tell yet.", knobsModule.Solve(bomb), "Error test #1", null);

            //Up first config
            knobsModule = new Knobs();
            knobsModule.Sequence = "down down both down up both";
            Assert.AreEqual("Final position is up.", knobsModule.Solve(bomb), "Error test #2", null);

            //Up second config
            knobsModule = new Knobs();
            knobsModule.Sequence = "up down both none both down";
            knobsModule.Solve(bomb);
            Assert.AreEqual("Final position is up.", knobsModule.Solve(bomb), "Error test #3", null);

            //Down first config
            knobsModule = new Knobs();
            knobsModule.Sequence = "down both both down none both";
            knobsModule.Solve(bomb);
            Assert.AreEqual("Final position is down.", knobsModule.Solve(bomb), "Error test #4", null);

            //Down second config
            knobsModule = new Knobs();
            knobsModule.Sequence = "up down up none up down";
            knobsModule.Solve(bomb);
            Assert.AreEqual("Final position is down.", knobsModule.Solve(bomb), "Error test #5", null);

            //Left first config
            knobsModule = new Knobs();
            knobsModule.Sequence = "down none none down both down";
            knobsModule.Solve(bomb);
            Assert.AreEqual("Final position is left.", knobsModule.Solve(bomb), "Error test #6", null);

            //Left second config
            knobsModule = new Knobs();
            knobsModule.Sequence = "none none none down both none";
            knobsModule.Solve(bomb);
            Assert.AreEqual("Final position is left.", knobsModule.Solve(bomb), "Error test #7", null);

            //Right first config
            knobsModule = new Knobs();
            knobsModule.Sequence = "both down both up both up";
            knobsModule.Solve(bomb);
            Assert.AreEqual("Final position is right.", knobsModule.Solve(bomb), "Error test #8", null);

            //Right second config
            knobsModule = new Knobs();
            knobsModule.Sequence = "both down both up down none";
            knobsModule.Solve(bomb);
            Assert.AreEqual("Final position is right.", knobsModule.Solve(bomb), "Error test #9", null);
        }

        [Test]
        public void HalfConfigTest()
        {
            //Up first half config
            var knobsModule = new Knobs();
            knobsModule.Sequence = "down none both none up both";
            Assert.AreEqual("Can't tell yet.", knobsModule.Solve(bomb), "Error test #1", null);

            //Up second half config
            knobsModule = new Knobs();
            knobsModule.Sequence = "none none none none both down";
            Assert.AreEqual("Can't tell yet.", knobsModule.Solve(bomb), "Error test #2", null);
            knobsModule.Solve(bomb);

            //Down first half config
            knobsModule = new Knobs();
            knobsModule.Sequence = "none up both down none down";
            Assert.AreEqual("Can't tell yet.", knobsModule.Solve(bomb), "Error test #3", null);
            knobsModule.Solve(bomb);

            //Down second half config
            knobsModule = new Knobs();
            knobsModule.Sequence = "up none up none none down";
            Assert.AreEqual("Can't tell yet.", knobsModule.Solve(bomb), "Error test #4", null);
            knobsModule.Solve(bomb);

            //Left first half config
            knobsModule = new Knobs();
            knobsModule.Sequence = "down none none none down down";
            Assert.AreEqual("Can't tell yet.", knobsModule.Solve(bomb), "Error test #5", null);
            knobsModule.Solve(bomb);

            //Left second half config
            knobsModule = new Knobs();
            knobsModule.Sequence = "none none none down up none";
            Assert.AreEqual("Can't tell yet.", knobsModule.Solve(bomb), "Error test #6", null);
            knobsModule.Solve(bomb);

            //Right first half config
            knobsModule = new Knobs();
            knobsModule.Sequence = "down none both up both up";
            Assert.AreEqual("Can't tell yet.", knobsModule.Solve(bomb), "Error test #7", null);
            knobsModule.Solve(bomb);

            //Right second half config
            knobsModule = new Knobs();
            knobsModule.Sequence = "none down both up none none";
            Assert.AreEqual("Can't tell yet.", knobsModule.Solve(bomb), "Error test #8", null);
            knobsModule.Solve(bomb);
        }
    }
}