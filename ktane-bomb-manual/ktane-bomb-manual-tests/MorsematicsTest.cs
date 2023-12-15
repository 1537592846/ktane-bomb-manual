using ktane_bomb_manual;
using ktane_bomb_manual.Modules;
using NUnit.Framework;

namespace Tests
{
    public class MorsematicsTest
    {
        public Bomb bomb;

        [SetUp]
        public void Setup()
        {
            bomb = new Bomb();
            bomb.Serial = "TH8ZK9";
            bomb.BatteryAA = 4;
            bomb.BatteryD = 1;
            bomb.Indicators.Add(new Indicator("msa", true));
            bomb.Ports.Add(new Port("parallel", 1));
        }

        [Test]
        public void Morsematics_Test()
        {
            var morsematicsModule = new Morsematics();
            morsematicsModule.Command(bomb,"the first one is dot dot dash dot next");
            morsematicsModule.Command(bomb, "the second is dash dot dash dot next");
            morsematicsModule.Command(bomb, "and the third is dash dot dash next");
            Assert.That(morsematicsModule.Command(bomb,"solve morsematics"), Is.EqualTo("Send dot dash dash dot done."), "Error Test #1",null);
        }
    }
}