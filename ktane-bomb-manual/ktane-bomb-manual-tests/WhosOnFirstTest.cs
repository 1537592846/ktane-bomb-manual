using ktane_bomb_manual;
using ktane_bomb_manual.Modules;
using NUnit.Framework;

namespace Tests
{
    public class WhosOnFirstTest
    {
        public Bomb bomb;

        [SetUp]
        public void Setup()
        {
            bomb = new Bomb();
        }

        [Test]
        public void WhosOnFirst_Test()
        {
            var whosOnFirstModule = new WhosOnFirst();
            Assert.That(whosOnFirstModule.Command(bomb, "whos on first empty"), Is.EqualTo("Bottom left tile."), "Error test #1", null);
            Assert.That(whosOnFirstModule.Command(bomb, "whos on first left"), Is.EqualTo("Press the first one to appear: Right. Left. First. No. Middle. Yes. Blank. What. Uhhh. Wait. Press. Ready. Okay. Nothing."), "Error test #2", null);
        }
    }
}