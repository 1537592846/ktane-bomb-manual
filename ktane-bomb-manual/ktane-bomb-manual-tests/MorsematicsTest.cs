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
        public void Test()
        {
            var morsematicsModule = new Morsematics();
            morsematicsModule.AddCharacter("the first one is dot dot dash dot next");
            morsematicsModule.AddCharacter("the second is dash dot dash dot next");
            morsematicsModule.AddCharacter("and the third is dash dot dash next");
            Assert.AreEqual("Send dot dash dash dot done.", morsematicsModule.Solve(bomb),"Error Test #1",null);
        }
    }
}