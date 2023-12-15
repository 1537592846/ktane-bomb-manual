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
            Assert.That(knobsModule.Command(bomb, "knobs none none none none none none"), Is.EqualTo("Can't tell yet."), "Error test #1", null);

            //top first config
            Assert.That(knobsModule.Command(bomb, "knobs bottom bottom both bottom top both"), Is.EqualTo("Final position is up."), "Error test #2", null);

            //top second config
            Assert.That(knobsModule.Command(bomb, "knobs top bottom both none both bottom"), Is.EqualTo("Final position is up."), "Error test #3", null);

            //bottom first config
            Assert.That(knobsModule.Command(bomb, "knobs bottom both both bottom none both"), Is.EqualTo("Final position is down."), "Error test #4", null);

            //bottom second config
            Assert.That(knobsModule.Command(bomb, "knobs top bottom top none top bottom"), Is.EqualTo("Final position is down."), "Error test #5", null);

            //Left first config
            Assert.That(knobsModule.Command(bomb, "knobs bottom none none bottom both bottom"), Is.EqualTo("Final position is left."), "Error test #6", null);

            //Left second config
            Assert.That(knobsModule.Command(bomb, "knobs none none none bottom both none"), Is.EqualTo("Final position is left."), "Error test #7", null);

            //Right first config
            Assert.That(knobsModule.Command(bomb, "knobs both bottom both top both top"), Is.EqualTo("Final position is right."), "Error test #8", null);

            //Right second config
            Assert.That(knobsModule.Command(bomb, "knobs both bottom both top bottom none"), Is.EqualTo("Final position is right."), "Error test #9", null);
        }

        [Test]
        public void Knobs_HalfConfigTest()
        {
            //top first half config
            var knobsModule = new Knobs();
            Assert.That(knobsModule.Command(bomb, "knobs bottom none both none top both"), Is.EqualTo("Can't tell yet."), "Error test #1", null);

            //top second half config
            Assert.That(knobsModule.Command(bomb, "knobs none none none none both bottom"), Is.EqualTo("Can't tell yet."), "Error test #2", null);
            knobsModule.Command(bomb, "both bottom both top bottom none");

            //bottom first half config
            Assert.That(knobsModule.Command(bomb, "knobs none top both bottom none bottom"), Is.EqualTo("Can't tell yet."), "Error test #3", null);
            knobsModule.Command(bomb, "both bottom both top bottom none");

            //bottom second half config
            Assert.That(knobsModule.Command(bomb, "knobs top none top none none bottom"), Is.EqualTo("Can't tell yet."), "Error test #4", null);
            knobsModule.Command(bomb, "both bottom both top bottom none");

            //Left first half config
            Assert.That(knobsModule.Command(bomb, "knobs bottom none none none top none"), Is.EqualTo("Can't tell yet."), "Error test #5", null);
            knobsModule.Command(bomb, "both bottom both top bottom none");

            //Left second half config
            Assert.That(knobsModule.Command(bomb, "knobs none none none bottom top none"), Is.EqualTo("Can't tell yet."), "Error test #6", null);
            knobsModule.Command(bomb, "both bottom both top bottom none");

            //Right first half config
            Assert.That(knobsModule.Command(bomb, "knobs bottom none both top both top"), Is.EqualTo("Can't tell yet."), "Error test #7", null);
            knobsModule.Command(bomb, "both bottom both top bottom none");

            //Right second half config
            Assert.That(knobsModule.Command(bomb, "knobs none bottom both top none none"), Is.EqualTo("Can't tell yet."), "Error test #8", null);
            knobsModule.Command(bomb, "both bottom both top bottom none");
        }
    }
}