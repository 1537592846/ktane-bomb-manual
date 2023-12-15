using ktane_bomb_manual;
using ktane_bomb_manual.Modules;
using NUnit.Framework;

namespace Tests
{
    public class SimonStatesTest
    {
        public Bomb bomb;

        [SetUp]
        public void Setup()
        {
            bomb = new Bomb();
        }

        [Test]
        public void SimonStates_Test()
        {
            var simonStatesModule = new SimonStates();
            simonStatesModule.Command(bomb, "simon states top left blue");
            Assert.That(simonStatesModule.Command(bomb, "simon states yellow"), Is.EqualTo("Press yellow."), "Error Test #1", null);
            Assert.That(simonStatesModule.Command(bomb, "simon states red green"), Is.EqualTo("Press yellow blue."), "Error Test #2", null);
            Assert.That(simonStatesModule.Command(bomb, "simon states yellow red"), Is.EqualTo("Press yellow blue yellow."), "Error Test #3", null);
            Assert.That(simonStatesModule.Command(bomb, "simon states all"), Is.EqualTo("Press yellow blue yellow red."), "Error Test #4", null);
            Assert.That(simonStatesModule.Command(bomb, "simon says solved"), Is.EqualTo("Module defused."), "Error Test #5", null);
        }
    }
}