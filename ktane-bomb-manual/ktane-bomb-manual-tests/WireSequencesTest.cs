using ktane_bomb_manual;
using ktane_bomb_manual.Modules;
using NUnit.Framework;

namespace Tests
{
    public class WireSequencesTest
    {
        public Bomb bomb;

        [SetUp]
        public void Setup()
        {
            bomb = new Bomb();
        }

        [Test]
        public void WireSequences_Test()
        {
            var wireSequencesModule = new WireSequences();
            Assert.AreEqual("Cut it.", wireSequencesModule.Command(bomb, "wire sequences red charlie"), null, "Error Test #1");
            Assert.AreEqual("Cut it.", wireSequencesModule.Command(bomb, "wire sequences black alpha"), null, "Error Test #2");
            Assert.AreEqual("Leave it.", wireSequencesModule.Command(bomb, "wire sequences blue charlie"), null, "Error Test #3");
            Assert.AreEqual("Leave it.", wireSequencesModule.Command(bomb, "wire sequences black bravo"), null, "Error Test #4");
            Assert.AreEqual("Leave it.", wireSequencesModule.Command(bomb, "wire sequences black charlie"), null, "Error Test #5");
            Assert.AreEqual("Leave it.", wireSequencesModule.Command(bomb, "wire sequences red charlie"), null, "Error Test #6");
            Assert.AreEqual("Leave it.", wireSequencesModule.Command(bomb, "wire sequences black bravo"), null, "Error Test #7");
            Assert.AreEqual("Leave it.", wireSequencesModule.Command(bomb, "wire sequences blue bravo"), null, "Error Test #8");
            Assert.AreEqual("Leave it.", wireSequencesModule.Command(bomb, "wire sequences blue charlie"), null, "Error Test #9");
            Assert.AreEqual("Module solved.", wireSequencesModule.Command(bomb, "wire sequences solved"), null, "Error Test #10");
        }
    }
}