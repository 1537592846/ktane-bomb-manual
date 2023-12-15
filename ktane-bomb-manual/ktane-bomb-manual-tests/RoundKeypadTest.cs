using ktane_bomb_manual;
using ktane_bomb_manual.Modules;
using NUnit.Framework;

namespace Tests
{
    public class RoundKeypadsTest
    {
        public Bomb bomb;

        [SetUp]
        public void Setup()
        {
            bomb = new Bomb();
            bomb.Serial = "T5K8W9";
        }

        [Test]
        public void RoundKeypads_Test()
        {
            var roundKeypadsModule = new RoundKeypads();
            roundKeypadsModule.AddSymbol("big yus");
            roundKeypadsModule.AddSymbol("yat");
            roundKeypadsModule.AddSymbol("little yus");
            roundKeypadsModule.AddSymbol("sigma");
            roundKeypadsModule.AddSymbol("omega");
            roundKeypadsModule.AddSymbol("question mark");
            roundKeypadsModule.AddSymbol("aesc");
            roundKeypadsModule.AddSymbol("lambda");
            Assert.That(roundKeypadsModule.Solve(bomb), Is.EqualTo("Press this ones: Aesc. Lambda. Little Yus. Lunate Sigma. Omega."), "Error Test #1", null);
        }
    }
}