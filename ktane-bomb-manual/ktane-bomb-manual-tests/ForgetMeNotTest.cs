using ktane_bomb_manual;
using ktane_bomb_manual.Modules;
using NUnit.Framework;

namespace Tests
{
    public class ForgetMeNotTest
    {
        public Bomb bomb;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ForgetMeNot_SerialOnlyOddBombTest()
        {
            bomb = new Bomb();
            bomb.Serial = "QS1LN4";
            bomb.BatteryAA = 4;
            bomb.Indicators.Add(new Indicator("sig", false));
            bomb.Indicators.Add(new Indicator("thn", true));
            bomb.Ports.Add(new Port("dvi", 1));

            var forgetMeNotModule = new ForgetMeNot();
            forgetMeNotModule.AddNumber(bomb, "9");
            forgetMeNotModule.AddNumber(bomb, "7");
            forgetMeNotModule.AddNumber(bomb, "7");
            forgetMeNotModule.AddNumber(bomb, "0");
            forgetMeNotModule.AddNumber(bomb, "5");
            forgetMeNotModule.AddNumber(bomb, "3");
            forgetMeNotModule.AddNumber(bomb, "9");
            forgetMeNotModule.AddNumber(bomb, "3");

            Assert.AreEqual("Listing the number, pay attention. 3, 9, 8 next. 1, 4, 8 next. 0, 7 done.", forgetMeNotModule.Solve(bomb), "Error test #1", null);

            bomb = new Bomb();
            bomb.Serial = "TH8ZK9";
            bomb.BatteryAA = 4;
            bomb.BatteryD = 1;
            bomb.Indicators.Add(new Indicator("msa", true));
            bomb.Ports.Add(new Port("parallel", 1));

            forgetMeNotModule = new ForgetMeNot();
            forgetMeNotModule.AddNumber(bomb, "3");
            forgetMeNotModule.AddNumber(bomb, "6");
            forgetMeNotModule.AddNumber(bomb, "2");
            forgetMeNotModule.AddNumber(bomb, "1");
            forgetMeNotModule.AddNumber(bomb, "5");
            forgetMeNotModule.AddNumber(bomb, "1");
            forgetMeNotModule.AddNumber(bomb, "5");
            forgetMeNotModule.AddNumber(bomb, "5");
            forgetMeNotModule.AddNumber(bomb, "3");
            forgetMeNotModule.AddNumber(bomb, "1");
            forgetMeNotModule.AddNumber(bomb, "3");
            forgetMeNotModule.AddNumber(bomb, "0");
            forgetMeNotModule.AddNumber(bomb, "0");
            forgetMeNotModule.AddNumber(bomb, "2");
            forgetMeNotModule.AddNumber(bomb, "7");
            forgetMeNotModule.AddNumber(bomb, "7");
            forgetMeNotModule.AddNumber(bomb, "9");
            forgetMeNotModule.AddNumber(bomb, "1");
            forgetMeNotModule.AddNumber(bomb, "6");
            forgetMeNotModule.AddNumber(bomb, "9");
            forgetMeNotModule.AddNumber(bomb, "5");
            forgetMeNotModule.AddNumber(bomb, "7");
            forgetMeNotModule.AddNumber(bomb, "1");
            forgetMeNotModule.AddNumber(bomb, "2");
            forgetMeNotModule.AddNumber(bomb, "2");
            forgetMeNotModule.AddNumber(bomb, "6");
            forgetMeNotModule.AddNumber(bomb, "1");
            forgetMeNotModule.AddNumber(bomb, "6");
            forgetMeNotModule.AddNumber(bomb, "1");
            forgetMeNotModule.AddNumber(bomb, "6");
            forgetMeNotModule.AddNumber(bomb, "7");
            forgetMeNotModule.AddNumber(bomb, "5");
            forgetMeNotModule.AddNumber(bomb, "5");
            forgetMeNotModule.AddNumber(bomb, "3");
            forgetMeNotModule.AddNumber(bomb, "6");
            forgetMeNotModule.AddNumber(bomb, "4");
            forgetMeNotModule.AddNumber(bomb, "7");
            forgetMeNotModule.AddNumber(bomb, "6");
            forgetMeNotModule.AddNumber(bomb, "8");
            forgetMeNotModule.AddNumber(bomb, "0");
            forgetMeNotModule.AddNumber(bomb, "4");
            forgetMeNotModule.AddNumber(bomb, "0");
            forgetMeNotModule.AddNumber(bomb, "8");
            forgetMeNotModule.AddNumber(bomb, "6");
            forgetMeNotModule.AddNumber(bomb, "7");
            forgetMeNotModule.AddNumber(bomb, "4");
            forgetMeNotModule.AddNumber(bomb, "0");
            forgetMeNotModule.AddNumber(bomb, "3");
            forgetMeNotModule.AddNumber(bomb, "1");
            forgetMeNotModule.AddNumber(bomb, "9");
            forgetMeNotModule.AddNumber(bomb, "3");
            forgetMeNotModule.AddNumber(bomb, "5");
            forgetMeNotModule.AddNumber(bomb, "0");
            forgetMeNotModule.AddNumber(bomb, "4");
            forgetMeNotModule.AddNumber(bomb, "7");
            forgetMeNotModule.AddNumber(bomb, "0");
            forgetMeNotModule.AddNumber(bomb, "6");
            forgetMeNotModule.AddNumber(bomb, "1");
            forgetMeNotModule.AddNumber(bomb, "8");
            forgetMeNotModule.AddNumber(bomb, "5");
            forgetMeNotModule.AddNumber(bomb, "9");
            forgetMeNotModule.AddNumber(bomb, "8");
            forgetMeNotModule.AddNumber(bomb, "7");
            forgetMeNotModule.AddNumber(bomb, "4");
            forgetMeNotModule.AddNumber(bomb, "5");
            forgetMeNotModule.AddNumber(bomb, "6");
            forgetMeNotModule.AddNumber(bomb, "8");
            forgetMeNotModule.AddNumber(bomb, "5");
            forgetMeNotModule.AddNumber(bomb, "7");
            forgetMeNotModule.AddNumber(bomb, "8");
            forgetMeNotModule.AddNumber(bomb, "5");
            forgetMeNotModule.AddNumber(bomb, "2");
            forgetMeNotModule.AddNumber(bomb, "1");
            forgetMeNotModule.AddNumber(bomb, "8");
            forgetMeNotModule.AddNumber(bomb, "0");
            forgetMeNotModule.AddNumber(bomb, "0");
            forgetMeNotModule.AddNumber(bomb, "3");
            forgetMeNotModule.AddNumber(bomb, "8");
            forgetMeNotModule.AddNumber(bomb, "8");
            forgetMeNotModule.AddNumber(bomb, "4");
            forgetMeNotModule.AddNumber(bomb, "8");
            forgetMeNotModule.AddNumber(bomb, "2");
            forgetMeNotModule.AddNumber(bomb, "1");
            forgetMeNotModule.AddNumber(bomb, "4");
            forgetMeNotModule.AddNumber(bomb, "5");
            forgetMeNotModule.AddNumber(bomb, "5");
            forgetMeNotModule.AddNumber(bomb, "6");
            forgetMeNotModule.AddNumber(bomb, "8");
            forgetMeNotModule.AddNumber(bomb, "7");
            forgetMeNotModule.AddNumber(bomb, "7");
            forgetMeNotModule.AddNumber(bomb, "6");
            forgetMeNotModule.AddNumber(bomb, "9");
            forgetMeNotModule.AddNumber(bomb, "3");
            forgetMeNotModule.AddNumber(bomb, "0");
            forgetMeNotModule.AddNumber(bomb, "9");
            forgetMeNotModule.AddNumber(bomb, "5");
            forgetMeNotModule.AddNumber(bomb, "9");

            Assert.AreEqual("Listing the number, pay attention. 4, 1, 7 next. 9, 6, 2 next. 4, 4, 2 next. 0, 2, 9 next. 1, 3, 1 next. 1, 1, 3 next. 0, 8, 4 next. 6, 0, 1 next. 1, 8, 0 next. 5, 0, 5 next. 6, 6, 4 next. 2, 5, 1 next. 3, 0, 7 next. 9, 5, 1 next. 4, 1, 2 next. 7, 9, 4 next. 2, 8, 2 next. 4, 9, 5 next. 8, 1, 5 next. 7, 9, 6 next. 0, 7, 6 next. 5, 6, 7 next. 9, 6, 8 next. 7, 6, 3 next. 0, 7, 9 next. 1, 4, 3 next. 5, 2, 5 next. 9, 2, 5 next. 2, 2, 5 next. 5, 8, 8 next. 5, 0, 2 next. 9, 0, 4 next. 8 done.", forgetMeNotModule.Solve(bomb), "Error test #1", null);
        }
    }
}