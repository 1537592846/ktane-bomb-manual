using ktane_bomb_manual;
using ktane_bomb_manual.Modules;

using NUnit.Framework;

namespace Tests
{
    public class MorseCodeTest
    {
        public Bomb bomb;

        [SetUp]
        public void Setup() => bomb = new Bomb { Serial = "A1BC21" };

        [Test]
        public void MorseCode_Test()
        {
            var morseCodeModule = new MorseCode();
            morseCodeModule.Command(bomb, "morse dash next");
            morseCodeModule.Command(bomb, "morse dot dash dot next");
            morseCodeModule.Command(bomb, "morse dot dot next");
            morseCodeModule.Command(bomb, "morse dash dot dash dot next");
            morseCodeModule.Command(bomb, "morse dash dot dash next");
            Assert.That(morseCodeModule.Command(bomb, "solve morse"), Is.EqualTo("Frequence is 3 dot 5 3 2 megahertz."), "Error Test #1", null);

            morseCodeModule.Command(bomb, "morse reset");
            morseCodeModule.Command(bomb, "morse dot dot next");
            morseCodeModule.Command(bomb, "morse dash dot dash dot next");
            morseCodeModule.Command(bomb, "morse dash dot dash next");
            morseCodeModule.Command(bomb, "morse dash next");
            morseCodeModule.Command(bomb, "morse dot dash dot next");
            Assert.That(morseCodeModule.Command(bomb, "solve morse"), Is.EqualTo("Frequence is 3 dot 5 3 2 megahertz."), "Error Test #2", null);

            morseCodeModule.Command(bomb, "morse reset");
            morseCodeModule.Command(bomb, "morse dot dot dot next");
            morseCodeModule.Command(bomb, "morse dot dot dot dot next");
            morseCodeModule.Command(bomb, "morse dot next");
            morseCodeModule.Command(bomb, "morse dot dash dot dot next");
            morseCodeModule.Command(bomb, "morse dot dash dot dot next");
            Assert.That(morseCodeModule.Command(bomb, "solve morse"), Is.EqualTo("Frequence is 3 dot 5 0 5 megahertz."), "Error Test #3", null);

            morseCodeModule.Command(bomb, "morse reset");
            morseCodeModule.Command(bomb, "morse dash dot dot dot next");
            morseCodeModule.Command(bomb, "morse dot dot next");
            morseCodeModule.Command(bomb, "morse dot dot dot next");
            morseCodeModule.Command(bomb, "morse dash next");
            morseCodeModule.Command(bomb, "morse dot dash dot next");
            morseCodeModule.Command(bomb, "morse dash dash dash next");
            Assert.That(morseCodeModule.Command(bomb, "solve morse"), Is.EqualTo("Frequence is 3 dot 5 5 2 megahertz."), "Error Test #4", null);
        }
    }
}