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
            Assert.AreEqual("Bottom left tile.", whosOnFirstModule.Command(bomb, "whos on first empty"), "Error test #1", null);
            Assert.AreEqual("Press the first one to appear: Right. Left. First. No. Middle. Yes. Blank. What. Uhhh. Wait. Press. Ready. Okay. Nothing.", whosOnFirstModule.Command(bomb, "whos on first left"), "Error test #2", null);
        }
    }
}