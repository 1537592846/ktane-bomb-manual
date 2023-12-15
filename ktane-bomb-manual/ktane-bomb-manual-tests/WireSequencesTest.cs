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
            Assert.That(wireSequencesModule.Command(bomb, "wire sequences red charlie"), Is.EqualTo("Cut it."), null, "Error Test #1");
            Assert.That(wireSequencesModule.Command(bomb, "wire sequences black alpha"), Is.EqualTo("Cut it."), null, "Error Test #2");
            Assert.That(wireSequencesModule.Command(bomb, "wire sequences blue charlie"), Is.EqualTo("Leave it."), null, "Error Test #3");
            Assert.That(wireSequencesModule.Command(bomb, "wire sequences black bravo"), Is.EqualTo("Leave it."), null, "Error Test #4");
            Assert.That(wireSequencesModule.Command(bomb, "wire sequences black charlie"), Is.EqualTo("Leave it."), null, "Error Test #5");
            Assert.That(wireSequencesModule.Command(bomb, "wire sequences red charlie"), Is.EqualTo("Leave it."), null, "Error Test #6");
            Assert.That(wireSequencesModule.Command(bomb, "wire sequences black bravo"), Is.EqualTo("Leave it."), null, "Error Test #7");
            Assert.That(wireSequencesModule.Command(bomb, "wire sequences blue bravo"), Is.EqualTo("Leave it."), null, "Error Test #8");
            Assert.That(wireSequencesModule.Command(bomb, "wire sequences blue charlie"), Is.EqualTo("Leave it."), null, "Error Test #9");
            Assert.That(wireSequencesModule.Command(bomb, "wire sequences solved"), Is.EqualTo("Module solved."), null, "Error Test #10");
        }
    }
}