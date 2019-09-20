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
        public void Test()
        {
            var simonStatesModule = new SimonStates();
            simonStatesModule.Command(bomb, "simon states top left blue");
            Assert.AreEqual("Press yellow.", simonStatesModule.Command(bomb, "simon states yellow"), "Error Test #1", null);
            Assert.AreEqual("Press yellow blue.", simonStatesModule.Command(bomb, "simon states red green"), "Error Test #2", null);
            Assert.AreEqual("Press yellow blue yellow.", simonStatesModule.Command(bomb, "simon states yellow red"), "Error Test #3", null);
            Assert.AreEqual("Press yellow blue yellow red.", simonStatesModule.Command(bomb, "simon states all"), "Error Test #4", null);
            Assert.AreEqual("Module defused.", simonStatesModule.Command(bomb, "simon says solved"), "Error Test #5", null);
        }
    }
}