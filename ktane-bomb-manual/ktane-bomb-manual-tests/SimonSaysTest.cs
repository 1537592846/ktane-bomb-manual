using ktane_bomb_manual;
using ktane_bomb_manual.Modules;
using NUnit.Framework;

namespace Tests
{
    public class SimonSaysTest
    {
        public Bomb bomb;

        [SetUp]
        public void Setup()
        {
            bomb = new Bomb();
        }

        [Test]
        public void NoStrikesVowelTest()
        {
            var simonSaysModule = new SimonSays();
            bomb.Serial = "AB12C3";
            Assert.AreEqual("Press red.", simonSaysModule.Command(bomb, "simon says blue"), "Error Test #1", null);
            Assert.AreEqual("Press red blue.", simonSaysModule.Command(bomb, "simon says red"), "Error Test #2", null);
            Assert.AreEqual("Press red blue yellow.", simonSaysModule.Command(bomb, "simon says green"), "Error Test #3", null);
            Assert.AreEqual("Press red blue yellow green.", simonSaysModule.Command(bomb, "simon says yellow"), "Error Test #4", null);
            Assert.AreEqual("Module defused.", simonSaysModule.Command(bomb, "simon says solved"), "Error Test #5", null);
        }

        [Test]
        public void OneStrikeVowelTest()
        {
            var simonSaysModule = new SimonSays();
            bomb.Serial = "AB12C3";
            Assert.AreEqual("Press red.", simonSaysModule.Command(bomb, "simon says blue"), "Error Test #1", null);
            Assert.AreEqual("Press red blue.", simonSaysModule.Command(bomb, "simon says red"), "Error Test #2", null);
            bomb.Command("bomb add strike");
            Assert.AreEqual("Press green yellow blue.", simonSaysModule.Command(bomb, "simon says green"), "Error Test #3", null);
            Assert.AreEqual("Press green yellow blue red.", simonSaysModule.Command(bomb, "simon says yellow"), "Error Test #4", null);
            Assert.AreEqual("Press green yellow blue red red.", simonSaysModule.Command(bomb, "simon says yellow"), "Error Test #5", null);
            Assert.AreEqual("Module defused.", simonSaysModule.Command(bomb, "simon says solved"), "Error Test #6", null);

            simonSaysModule = new SimonSays();
            Assert.AreEqual("Press green.", simonSaysModule.Command(bomb, "simon says blue"), "Error Test #1", null);
            Assert.AreEqual("Press green yellow.", simonSaysModule.Command(bomb, "simon says red"), "Error Test #2", null);
            Assert.AreEqual("Press green yellow blue.", simonSaysModule.Command(bomb, "simon says green"), "Error Test #3", null);
            Assert.AreEqual("Press green yellow blue red.", simonSaysModule.Command(bomb, "simon says yellow"), "Error Test #4", null);
            Assert.AreEqual("Press green yellow blue red red.", simonSaysModule.Command(bomb, "simon says yellow"), "Error Test #5", null);
            Assert.AreEqual("Module defused.", simonSaysModule.Command(bomb, "simon says solved"), "Error Test #6", null);
        }

        [Test]
        public void TwoStrikesVowelTest()
        {
            var simonSaysModule = new SimonSays();
            bomb.Serial = "AB12C3";
            Assert.AreEqual("Press red.", simonSaysModule.Command(bomb, "simon says blue"), "Error Test #1", null);
            bomb.Command("bomb add strike");
            Assert.AreEqual("Press green yellow.", simonSaysModule.Command(bomb, "simon says red"), "Error Test #2", null);
            bomb.Command("bomb add strike");
            Assert.AreEqual("Press red green yellow.", simonSaysModule.Command(bomb, "simon says green"), "Error Test #3", null);
            Assert.AreEqual("Press red green yellow blue.", simonSaysModule.Command(bomb, "simon says yellow"), "Error Test #4", null);
            Assert.AreEqual("Module defused.", simonSaysModule.Command(bomb, "simon says solved"), "Error Test #5", null);
        }

        [Test]
        public void NoStrikesNoVowelTest()
        {
            var simonSaysModule = new SimonSays();
            bomb.Serial = "TB12C3";
            Assert.AreEqual("Press yellow.", simonSaysModule.Command(bomb, "simon says blue"), "Error Test #1", null);
            Assert.AreEqual("Press yellow blue.", simonSaysModule.Command(bomb, "simon says red"), "Error Test #2", null);
            Assert.AreEqual("Press yellow blue green.", simonSaysModule.Command(bomb, "simon says green"), "Error Test #3", null);
            Assert.AreEqual("Press yellow blue green red.", simonSaysModule.Command(bomb, "simon says yellow"), "Error Test #4", null);
            Assert.AreEqual("Module defused.", simonSaysModule.Command(bomb, "simon says solved"), "Error Test #5", null);
        }

        [Test]
        public void OneStrikeNoVowelTest()
        {
            var simonSaysModule = new SimonSays();
            bomb.Serial = "TB12C3";
            Assert.AreEqual("Press yellow.", simonSaysModule.Command(bomb, "simon says blue"), "Error Test #1", null);
            Assert.AreEqual("Press yellow blue.", simonSaysModule.Command(bomb, "simon says red"), "Error Test #2", null);
            bomb.Command("bomb add strike");
            Assert.AreEqual("Press blue red yellow.", simonSaysModule.Command(bomb, "simon says green"), "Error Test #3", null);
            Assert.AreEqual("Press blue red yellow green.", simonSaysModule.Command(bomb, "simon says yellow"), "Error Test #4", null);
            Assert.AreEqual("Press blue red yellow green green.", simonSaysModule.Command(bomb, "simon says yellow"), "Error Test #5", null);
            Assert.AreEqual("Module defused.", simonSaysModule.Command(bomb, "simon says solved"), "Error Test #6", null);

            simonSaysModule = new SimonSays();
            Assert.AreEqual("Press blue.", simonSaysModule.Command(bomb, "simon says blue"), "Error Test #1", null);
            Assert.AreEqual("Press blue red.", simonSaysModule.Command(bomb, "simon says red"), "Error Test #2", null);
            Assert.AreEqual("Press blue red yellow.", simonSaysModule.Command(bomb, "simon says green"), "Error Test #3", null);
            Assert.AreEqual("Press blue red yellow green.", simonSaysModule.Command(bomb, "simon says yellow"), "Error Test #4", null);
            Assert.AreEqual("Press blue red yellow green green.", simonSaysModule.Command(bomb, "simon says yellow"), "Error Test #5", null);
            Assert.AreEqual("Module defused.", simonSaysModule.Command(bomb, "simon says solved"), "Error Test #6", null);
        }

        [Test]
        public void TwoStrikesNoVowelTest()
        {
            var simonSaysModule = new SimonSays();
            bomb.Serial = "TB12C3";
            Assert.AreEqual("Press yellow.", simonSaysModule.Command(bomb, "simon says blue"), "Error Test #1", null);
            bomb.Command("bomb add strike");
            Assert.AreEqual("Press blue red.", simonSaysModule.Command(bomb, "simon says red"), "Error Test #2", null);
            bomb.Command("bomb add strike");
            Assert.AreEqual("Press green yellow blue.", simonSaysModule.Command(bomb, "simon says green"), "Error Test #3", null);
            Assert.AreEqual("Press green yellow blue red.", simonSaysModule.Command(bomb, "simon says yellow"), "Error Test #4", null);
            Assert.AreEqual("Module defused.", simonSaysModule.Command(bomb, "simon says solved"), "Error Test #5", null);
        }
    }
}