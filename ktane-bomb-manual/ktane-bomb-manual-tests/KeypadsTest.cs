using ktane_bomb_manual;
using ktane_bomb_manual.Modules;
using NUnit.Framework;

namespace Tests
{
    public class KeypadsTest
    {
        public Bomb bomb;

        [SetUp]
        public void Setup()
        {
            bomb = new Bomb();
            bomb.Serial = "T5K8W9";
        }

        [Test]
        public void Keypads_TestFirstColumn()
        {
            var keypadsModule = new Keypads();
            keypadsModule.AddSymbol("a ballon");
            keypadsModule.AddSymbol("lambda");
            keypadsModule.AddSymbol("backwards c ");
            keypadsModule.AddSymbol("stylish x ");
            Assert.AreEqual("Order as follow: Archaic Koppa. Little Yus. Lambda. Koppa. Big Yus. Kai. Lunate Anti Sigma.", keypadsModule.Solve(bomb), "Error Test #1", null);

            keypadsModule = new Keypads();
            keypadsModule.AddSymbol("resistance");
            keypadsModule.AddSymbol(" a t ");
            keypadsModule.AddSymbol("lunate anti sigma");
            keypadsModule.AddSymbol("big yus");
            Assert.AreEqual("Order as follow: Archaic Koppa. Little Yus. Lambda. Koppa. Big Yus. Kai. Lunate Anti Sigma.", keypadsModule.Solve(bomb), "Error Test #2", null);
        }

        [Test]
        public void Keypads_TestSecondColumn()
        {
            var keypadsModule = new Keypads();
            keypadsModule.AddSymbol(" c l ");
            keypadsModule.AddSymbol("white star");
            keypadsModule.AddSymbol("backwards e ");
            keypadsModule.AddSymbol("stylish x ");
            Assert.AreEqual("Order as follow: E. Archaic Koppa. Lunate Anti Sigma. Ha. White Star. Kai. Inverted Question Mark.", keypadsModule.Solve(bomb), "Error Test #1", null);


            keypadsModule = new Keypads();
            keypadsModule.AddSymbol(" ha ");
            keypadsModule.AddSymbol("ballon");
            keypadsModule.AddSymbol("lunate anti sigma");
            keypadsModule.AddSymbol("stylish h ");
            Assert.AreEqual("Order as follow: E. Archaic Koppa. Lunate Anti Sigma. Ha. White Star. Kai. Inverted Question Mark.", keypadsModule.Solve(bomb), "Error Test #2", null);
        }

        [Test]
        public void Keypads_TestThirdColumn()
        {
            var keypadsModule = new Keypads();
            keypadsModule.AddSymbol("copyright");
            keypadsModule.AddSymbol("white star");
            keypadsModule.AddSymbol("broken three");
            keypadsModule.AddSymbol(" c l ");
            Assert.AreEqual("Order as follow: Copyright Sign. Broad Omega. Ha. Zhe. Komi Dzje. Lambda. White Star.", keypadsModule.Solve(bomb), "Error Test #1", null);

            keypadsModule = new Keypads();
            keypadsModule.AddSymbol("lambda");
            keypadsModule.AddSymbol("mirroed k ");
            keypadsModule.AddSymbol(" ha ");
            keypadsModule.AddSymbol("broad omega");
            Assert.AreEqual("Order as follow: Copyright Sign. Broad Omega. Ha. Zhe. Komi Dzje. Lambda. White Star.", keypadsModule.Solve(bomb), "Error Test #2", null);
        }

        [Test]
        public void Keypads_TestFourthColumn()
        {
            var keypadsModule = new Keypads();
            keypadsModule.AddSymbol("six");
            keypadsModule.AddSymbol("inverted question mark");
            keypadsModule.AddSymbol(" b t ");
            keypadsModule.AddSymbol("pilcrow");
            Assert.AreEqual("Order as follow: Be. Pilcrow. Yat. Big Yus. Zhe. Inverted Question Mark. Teh.", keypadsModule.Solve(bomb), "Error Test #1", null);

            keypadsModule = new Keypads();
            keypadsModule.AddSymbol("small b ");
            keypadsModule.AddSymbol("backwards p ");
            keypadsModule.AddSymbol(" x with a line on the middle");
            keypadsModule.AddSymbol("smiley face");
            Assert.AreEqual("Order as follow: Be. Pilcrow. Yat. Big Yus. Zhe. Inverted Question Mark. Teh.", keypadsModule.Solve(bomb), "Error Test #2", null);
        }

        [Test]
        public void Keypads_TestFifthColumn()
        {
            var keypadsModule = new Keypads();
            keypadsModule.AddSymbol("psi");
            keypadsModule.AddSymbol("teh");
            keypadsModule.AddSymbol("lunate sigma");
            keypadsModule.AddSymbol("pilcrow");
            Assert.AreEqual("Order as follow: Psi. Teh. Yat. Lunate Sigma. Pilcrow. Ksi. Black Star.", keypadsModule.Solve(bomb), "Error Test #1", null);

            keypadsModule = new Keypads();
            keypadsModule.AddSymbol("small b ");
            keypadsModule.AddSymbol("backwards p ");
            keypadsModule.AddSymbol(" x with a line on the middle");
            keypadsModule.AddSymbol("smiley face");
            Assert.AreEqual("Order as follow: Be. Pilcrow. Yat. Big Yus. Zhe. Inverted Question Mark. Teh.", keypadsModule.Solve(bomb), "Error Test #2", null);
        }

        [Test]
        public void Keypads_TestSixthColumn()
        {
            var keypadsModule = new Keypads();
            keypadsModule.AddSymbol("small b ");
            keypadsModule.AddSymbol("backwards e ");
            keypadsModule.AddSymbol("thousand");
            keypadsModule.AddSymbol("psi");
            Assert.AreEqual("Order as follow: Be. E. Thousand. Aesc. Psi. Short I. Omega.", keypadsModule.Solve(bomb), "Error Test #1", null);

            keypadsModule = new Keypads();
            keypadsModule.AddSymbol("backwards n ");
            keypadsModule.AddSymbol("six");
            keypadsModule.AddSymbol(" c with a dot in the middle");
            keypadsModule.AddSymbol(" a e ");
            Assert.AreEqual("Order as follow: Be. E. Thousand. Aesc. Psi. Short I. Omega.", keypadsModule.Solve(bomb), "Error Test #2", null);
        }
    }
}