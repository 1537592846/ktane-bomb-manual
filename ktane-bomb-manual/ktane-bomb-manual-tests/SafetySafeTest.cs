using ktane_bomb_manual;
using ktane_bomb_manual.Modules;
using NUnit.Framework;

namespace Tests
{
    public class SafetySafeTest
    {
        public Bomb bomb;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SafetySafe_Test()
        {
            var safetySafeModule = new SafetySafe();

            bomb = new Bomb();
            bomb.Serial = "VN5JP8";
            bomb.BatteryAA = 2;
            bomb.BatteryD = 2;
            bomb.Indicators.Add(new Indicator("trn", true));
            bomb.Indicators.Add(new Indicator("snd", true));
            Assert.That(safetySafeModule.Command(bomb, "safety safe configuration is 9 2 3 9 12 5"), Is.EqualTo("First dial: 9 turns. Second dial: 3 turns. Third dial: 1 turns. Fourth dial: 10 turns. Fifth dial: 7 turns. Sixth dial: 2 turns."), "Error Test #1", null);

            bomb = new Bomb();
            bomb.Serial = "TH8ZK9";
            bomb.BatteryAA = 4;
            bomb.BatteryD = 1;
            bomb.Indicators.Add(new Indicator("msa", true));
            bomb.Ports.Add(new Port("parallel", 1));
            Assert.That(safetySafeModule.Command(bomb, "safety safe configuration is 6 3 4 6 10 1"), Is.EqualTo("First dial: 2 turns. Second dial: 10 turns. Third dial: 4 turns. Fourth dial: 5 turns. Fifth dial: 7 turns. Sixth dial: 3 turns."), "Error Test #2", null);
        }
    }
}