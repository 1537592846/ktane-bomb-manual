using ktane_bomb_manual;
using ktane_bomb_manual.Modules;
using NUnit.Framework;

namespace Tests
{
    public class MorseCodeTest
    {
        public Bomb bomb;

        [SetUp]
        public void Setup()
        {
            bomb = new Bomb();
            bomb.Serial = "A1BC21";
        }

        [Test]
        public void Test()
        {
            var morseCodeModule = new MorseCode();
            morseCodeModule.Command(bomb, "morse dash next");
            morseCodeModule.Command(bomb, "morse dot dash dot next");
            morseCodeModule.Command(bomb, "morse dot dot next");
            morseCodeModule.Command(bomb, "morse dash dot dash dot next");
            morseCodeModule.Command(bomb, "morse dash dot dash next");
            Assert.AreEqual("Frequence is 3 dot 5 3 2 megahertz.", morseCodeModule.Command(bomb, "solve morse"), "Error Test #1", null);

            morseCodeModule.Command(bomb, "morse reset");
            morseCodeModule.Command(bomb, "morse dot dot next");
            morseCodeModule.Command(bomb, "morse dash dot dash dot next");
            morseCodeModule.Command(bomb, "morse dash dot dash next");
            morseCodeModule.Command(bomb, "morse dash next");
            morseCodeModule.Command(bomb, "morse dot dash dot next");
            Assert.AreEqual("Frequence is 3 dot 5 3 2 megahertz.", morseCodeModule.Command(bomb, "solve morse"), "Error Test #2", null);

            morseCodeModule.Command(bomb, "morse reset");
            morseCodeModule.Command(bomb, "morse dot dot dot next");
            morseCodeModule.Command(bomb, "morse dot dot dot dot next");
            morseCodeModule.Command(bomb, "morse dot next");
            morseCodeModule.Command(bomb, "morse dot dash dot dot next");
            morseCodeModule.Command(bomb, "morse dot dash dot dot next");
            Assert.AreEqual("Frequence is 3 dot 5 0 5 megahertz.", morseCodeModule.Command(bomb,"solve morse"), "Error Test #3", null);

            morseCodeModule.Command(bomb, "morse reset");
            morseCodeModule.Command(bomb, "morse dash dot dot dot next");
            morseCodeModule.Command(bomb, "morse dot dot next");
            morseCodeModule.Command(bomb, "morse dot dot dot next");
            morseCodeModule.Command(bomb, "morse dash next");
            morseCodeModule.Command(bomb, "morse dot dash dot next");
            morseCodeModule.Command(bomb, "morse dash dash dash next");
            Assert.AreEqual("Frequence is 3 dot 5 5 2 megahertz.", morseCodeModule.Command(bomb,"solve morse"), "Error Test #4", null);
        }
    }
}