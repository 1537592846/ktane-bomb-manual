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
            Assert.AreEqual("Can't tell yet.", knobsModule.Command(bomb, "knobs none none none none none none"), "Error test #1", null);

            //Up first config
            Assert.AreEqual("Final position is up.", knobsModule.Command(bomb, "knobs down down both down up both"), "Error test #2", null);

            //Up second config
            Assert.AreEqual("Final position is up.", knobsModule.Command(bomb, "knobs up down both none both down"), "Error test #3", null);

            //Down first config
            Assert.AreEqual("Final position is down.", knobsModule.Command(bomb, "knobs down both both down none both"), "Error test #4", null);

            //Down second config
            Assert.AreEqual("Final position is down.", knobsModule.Command(bomb, "knobs up down up none up down"), "Error test #5", null);

            //Left first config
            Assert.AreEqual("Final position is left.", knobsModule.Command(bomb, "knobs down none none down both down"), "Error test #6", null);

            //Left second config
            Assert.AreEqual("Final position is left.", knobsModule.Command(bomb, "knobs none none none down both none"), "Error test #7", null);

            //Right first config
            Assert.AreEqual("Final position is right.", knobsModule.Command(bomb, "knobs both down both up both up"), "Error test #8", null);

            //Right second config
            Assert.AreEqual("Final position is right.", knobsModule.Command(bomb, "knobs both down both up down none"), "Error test #9", null);
        }

        [Test]
        public void HalfConfigTest()
        {
            //Up first half config
            var knobsModule = new Knobs();
            Assert.AreEqual("Can't tell yet.", knobsModule.Command(bomb, "knobs down none both none up both"), "Error test #1", null);

            //Up second half config
            Assert.AreEqual("Can't tell yet.", knobsModule.Command(bomb, "knobs none none none none both down"), "Error test #2", null);
            knobsModule.Command(bomb, "both down both up down none");

            //Down first half config
            Assert.AreEqual("Can't tell yet.", knobsModule.Command(bomb, "knobs none up both down none down"), "Error test #3", null);
            knobsModule.Command(bomb, "both down both up down none");

            //Down second half config
            Assert.AreEqual("Can't tell yet.", knobsModule.Command(bomb, "knobs up none up none none down"), "Error test #4", null);
            knobsModule.Command(bomb, "both down both up down none");

            //Left first half config
            Assert.AreEqual("Can't tell yet.", knobsModule.Command(bomb, "knobs down none none none up none"), "Error test #5", null);
            knobsModule.Command(bomb, "both down both up down none");

            //Left second half config
            Assert.AreEqual("Can't tell yet.", knobsModule.Command(bomb, "knobs none none none down up none"), "Error test #6", null);
            knobsModule.Command(bomb, "both down both up down none");

            //Right first half config
            Assert.AreEqual("Can't tell yet.", knobsModule.Command(bomb, "knobs down none both up both up"), "Error test #7", null);
            knobsModule.Command(bomb, "both down both up down none");

            //Right second half config
            Assert.AreEqual("Can't tell yet.", knobsModule.Command(bomb, "knobs none down both up none none"), "Error test #8", null);
            knobsModule.Command(bomb, "both down both up down none");
        }
    }
}