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
        public void Knobs_FullConfigTest()
        {
            //Can't tell yet
            var knobsModule = new Knobs();
            Assert.AreEqual("Can't tell yet.", knobsModule.Command(bomb, "knobs none none none none none none"), "Error test #1", null);

            //top first config
            Assert.AreEqual("Final position is up.", knobsModule.Command(bomb, "knobs bottom bottom both bottom top both"), "Error test #2", null);

            //top second config
            Assert.AreEqual("Final position is up.", knobsModule.Command(bomb, "knobs top bottom both none both bottom"), "Error test #3", null);

            //bottom first config
            Assert.AreEqual("Final position is down.", knobsModule.Command(bomb, "knobs bottom both both bottom none both"), "Error test #4", null);

            //bottom second config
            Assert.AreEqual("Final position is down.", knobsModule.Command(bomb, "knobs top bottom top none top bottom"), "Error test #5", null);

            //Left first config
            Assert.AreEqual("Final position is left.", knobsModule.Command(bomb, "knobs bottom none none bottom both bottom"), "Error test #6", null);

            //Left second config
            Assert.AreEqual("Final position is left.", knobsModule.Command(bomb, "knobs none none none bottom both none"), "Error test #7", null);

            //Right first config
            Assert.AreEqual("Final position is right.", knobsModule.Command(bomb, "knobs both bottom both top both top"), "Error test #8", null);

            //Right second config
            Assert.AreEqual("Final position is right.", knobsModule.Command(bomb, "knobs both bottom both top bottom none"), "Error test #9", null);
        }

        [Test]
        public void Knobs_HalfConfigTest()
        {
            //top first half config
            var knobsModule = new Knobs();
            Assert.AreEqual("Can't tell yet.", knobsModule.Command(bomb, "knobs bottom none both none top both"), "Error test #1", null);

            //top second half config
            Assert.AreEqual("Can't tell yet.", knobsModule.Command(bomb, "knobs none none none none both bottom"), "Error test #2", null);
            knobsModule.Command(bomb, "both bottom both top bottom none");

            //bottom first half config
            Assert.AreEqual("Can't tell yet.", knobsModule.Command(bomb, "knobs none top both bottom none bottom"), "Error test #3", null);
            knobsModule.Command(bomb, "both bottom both top bottom none");

            //bottom second half config
            Assert.AreEqual("Can't tell yet.", knobsModule.Command(bomb, "knobs top none top none none bottom"), "Error test #4", null);
            knobsModule.Command(bomb, "both bottom both top bottom none");

            //Left first half config
            Assert.AreEqual("Can't tell yet.", knobsModule.Command(bomb, "knobs bottom none none none top none"), "Error test #5", null);
            knobsModule.Command(bomb, "both bottom both top bottom none");

            //Left second half config
            Assert.AreEqual("Can't tell yet.", knobsModule.Command(bomb, "knobs none none none bottom top none"), "Error test #6", null);
            knobsModule.Command(bomb, "both bottom both top bottom none");

            //Right first half config
            Assert.AreEqual("Can't tell yet.", knobsModule.Command(bomb, "knobs bottom none both top both top"), "Error test #7", null);
            knobsModule.Command(bomb, "both bottom both top bottom none");

            //Right second half config
            Assert.AreEqual("Can't tell yet.", knobsModule.Command(bomb, "knobs none bottom both top none none"), "Error test #8", null);
            knobsModule.Command(bomb, "both bottom both top bottom none");
        }
    }
}