using ktane_bomb_manual;
using ktane_bomb_manual.Modules;
using NUnit.Framework;

namespace Tests
{
    public class PlumbingTest
    {
        public Bomb bomb;

        [SetUp]
        public void Setup()
        {
            bomb = new Bomb();
            bomb.Serial = "JR14B9";
            bomb.Ports.Add(new Port("rj", 2));
            bomb.Ports.Add(new Port("rca", 1));
            bomb.Ports.Add(new Port("dvi", 1));
            bomb.BatteryAA = 2;
            bomb.BatteryD = 2;
        }

        [Test]
        public void Plumbing_Test()
        {
            var plumbingModule = new Plumbing();
            Assert.AreEqual("Input: blue. Output: yellow.",plumbingModule.Command(bomb,"solve plumbing"),"Error test #1",null);
        }
    }
}