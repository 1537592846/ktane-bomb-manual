using ktane_bomb_manual;
using ktane_bomb_manual.Modules;
using NUnit.Framework;

namespace Tests
{
    public class WhosFirstTest
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
            var whosFirstModule = new WhosFirst();
            Assert.AreEqual("Bottom left tile.", whosFirstModule.Command(bomb, "who is first empty"), "Error test #1", null);
            Assert.AreEqual("Press the first one to appear: Right. Left. First. No. Middle. Yes. Blank. What. U triple h. Wait. Press. Ready. Okay. Nothing.", whosFirstModule.Command(bomb, "who is first left"), "Error test #2", null);
        }
    }
}