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
            bomb.Serial ="A1BC21";
        }

        [Test]
        public void Test()
        {
            var morseCodeModule = new MorseCode();
            morseCodeModule.AddSequence("dash next");
            morseCodeModule.AddSequence("dot dash dot next");
            morseCodeModule.AddSequence("dot dot next");
            morseCodeModule.AddSequence("dash dot dash dot next");
            morseCodeModule.AddSequence("dash dot dash next");
            Assert.AreEqual("Frequence is 3 dot 5 3 2 megahertz.",morseCodeModule.Solve(bomb),"Error Test #1",null);
        }
    }
}