using ktane_bomb_manual;
using ktane_bomb_manual.Modules;
using NUnit.Framework;

namespace Tests
{
    public class SimonSaysTest
    {
        public Bomb bomb;

        [SetUp]
        public void SimonSays_Setup()
        {
            bomb = new Bomb();
        }

        [Test]
        public void SimonSays_NoStrikesVowelTest()
        {
            var simonSaysModule = new SimonSays();
            bomb.Serial = "AB12C3";
            Assert.That(simonSaysModule.Command(bomb, "simon says blue"), Is.EqualTo("Press red."), "Error Test #1", null);
            Assert.That(simonSaysModule.Command(bomb, "simon says red"), Is.EqualTo("Press red blue."), "Error Test #2", null);
            Assert.That(simonSaysModule.Command(bomb, "simon says green"), Is.EqualTo("Press red blue yellow."), "Error Test #3", null);
            Assert.That(simonSaysModule.Command(bomb, "simon says yellow"), Is.EqualTo("Press red blue yellow green."), "Error Test #4", null);
            Assert.That(simonSaysModule.Command(bomb, "simon says solved"), Is.EqualTo("Module defused."), "Error Test #5", null);
        }

        [Test]
        public void SimonSays_OneStrikeVowelTest()
        {
            var simonSaysModule = new SimonSays();
            bomb.Serial = "AB12C3";
            Assert.That(simonSaysModule.Command(bomb, "simon says blue"), Is.EqualTo("Press red."), "Error Test #1", null);
            Assert.That(simonSaysModule.Command(bomb, "simon says red"), Is.EqualTo("Press red blue."), "Error Test #2", null);
            bomb.Command("bomb add strike");
            Assert.That(simonSaysModule.Command(bomb, "simon says green"), Is.EqualTo("Press green yellow blue."), "Error Test #3", null);
            Assert.That(simonSaysModule.Command(bomb, "simon says yellow"), Is.EqualTo("Press green yellow blue red."), "Error Test #4", null);
            Assert.That(simonSaysModule.Command(bomb, "simon says yellow"), Is.EqualTo("Press green yellow blue red red."), "Error Test #5", null);
            Assert.That(simonSaysModule.Command(bomb, "simon says solved"), Is.EqualTo("Module defused."), "Error Test #6", null);

            simonSaysModule = new SimonSays();
            Assert.That(simonSaysModule.Command(bomb, "simon says blue"), Is.EqualTo("Press green."), "Error Test #1", null);
            Assert.That(simonSaysModule.Command(bomb, "simon says red"), Is.EqualTo("Press green yellow."), "Error Test #2", null);
            Assert.That(simonSaysModule.Command(bomb, "simon says green"), Is.EqualTo("Press green yellow blue."), "Error Test #3", null);
            Assert.That(simonSaysModule.Command(bomb, "simon says yellow"), Is.EqualTo("Press green yellow blue red."), "Error Test #4", null);
            Assert.That(simonSaysModule.Command(bomb, "simon says yellow"), Is.EqualTo("Press green yellow blue red red."), "Error Test #5", null);
            Assert.That(simonSaysModule.Command(bomb, "simon says solved"), Is.EqualTo("Module defused."), "Error Test #6", null);
        }

        [Test]
        public void SimonSays_TwoStrikesVowelTest()
        {
            var simonSaysModule = new SimonSays();
            bomb.Serial = "AB12C3";
            Assert.That(simonSaysModule.Command(bomb, "simon says blue"), Is.EqualTo("Press red."), "Error Test #1", null);
            bomb.Command("bomb add strike");
            Assert.That(simonSaysModule.Command(bomb, "simon says red"), Is.EqualTo("Press green yellow."), "Error Test #2", null);
            bomb.Command("bomb add strike");
            Assert.That(simonSaysModule.Command(bomb, "simon says green"), Is.EqualTo("Press red green yellow."), "Error Test #3", null);
            Assert.That(simonSaysModule.Command(bomb, "simon says yellow"), Is.EqualTo("Press red green yellow blue."), "Error Test #4", null);
            Assert.That(simonSaysModule.Command(bomb, "simon says solved"), Is.EqualTo("Module defused."), "Error Test #5", null);
        }

        [Test]
        public void SimonSays_NoStrikesNoVowelTest()
        {
            var simonSaysModule = new SimonSays();
            bomb.Serial = "TB12C3";
            Assert.That(simonSaysModule.Command(bomb, "simon says blue"), Is.EqualTo("Press yellow."), "Error Test #1", null);
            Assert.That(simonSaysModule.Command(bomb, "simon says red"), Is.EqualTo("Press yellow blue."), "Error Test #2", null);
            Assert.That(simonSaysModule.Command(bomb, "simon says green"), Is.EqualTo("Press yellow blue green."), "Error Test #3", null);
            Assert.That(simonSaysModule.Command(bomb, "simon says yellow"), Is.EqualTo("Press yellow blue green red."), "Error Test #4", null);
            Assert.That(simonSaysModule.Command(bomb, "simon says solved"), Is.EqualTo("Module defused."), "Error Test #5", null);
        }

        [Test]
        public void SimonSays_OneStrikeNoVowelTest()
        {
            var simonSaysModule = new SimonSays();
            bomb.Serial = "TB12C3";
            Assert.That(simonSaysModule.Command(bomb, "simon says blue"), Is.EqualTo("Press yellow."), "Error Test #1", null);
            Assert.That(simonSaysModule.Command(bomb, "simon says red"), Is.EqualTo("Press yellow blue."), "Error Test #2", null);
            bomb.Command("bomb add strike");
            Assert.That(simonSaysModule.Command(bomb, "simon says green"), Is.EqualTo("Press blue red yellow."), "Error Test #3", null);
            Assert.That(simonSaysModule.Command(bomb, "simon says yellow"), Is.EqualTo("Press blue red yellow green."), "Error Test #4", null);
            Assert.That(simonSaysModule.Command(bomb, "simon says yellow"), Is.EqualTo("Press blue red yellow green green."), "Error Test #5", null);
            Assert.That(simonSaysModule.Command(bomb, "simon says solved"), Is.EqualTo("Module defused."), "Error Test #6", null);

            simonSaysModule = new SimonSays();
            Assert.That(simonSaysModule.Command(bomb, "simon says blue"), Is.EqualTo("Press blue."), "Error Test #1", null);
            Assert.That(simonSaysModule.Command(bomb, "simon says red"), Is.EqualTo("Press blue red."), "Error Test #2", null);
            Assert.That(simonSaysModule.Command(bomb, "simon says green"), Is.EqualTo("Press blue red yellow."), "Error Test #3", null);
            Assert.That(simonSaysModule.Command(bomb, "simon says yellow"), Is.EqualTo("Press blue red yellow green."), "Error Test #4", null);
            Assert.That(simonSaysModule.Command(bomb, "simon says yellow"), Is.EqualTo("Press blue red yellow green green."), "Error Test #5", null);
            Assert.That(simonSaysModule.Command(bomb, "simon says solved"), Is.EqualTo("Module defused."), "Error Test #6", null);
        }

        [Test]
        public void SimonSays_TwoStrikesNoVowelTest()
        {
            var simonSaysModule = new SimonSays();
            bomb.Serial = "TB12C3";
            Assert.That(simonSaysModule.Command(bomb, "simon says blue"), Is.EqualTo("Press yellow."), "Error Test #1", null);
            bomb.Command("bomb add strike");
            Assert.That(simonSaysModule.Command(bomb, "simon says red"), Is.EqualTo("Press blue red."), "Error Test #2", null);
            bomb.Command("bomb add strike");
            Assert.That(simonSaysModule.Command(bomb, "simon says green"), Is.EqualTo("Press green yellow blue."), "Error Test #3", null);
            Assert.That(simonSaysModule.Command(bomb, "simon says yellow"), Is.EqualTo("Press green yellow blue red."), "Error Test #4", null);
            Assert.That(simonSaysModule.Command(bomb, "simon says solved"), Is.EqualTo("Module defused."), "Error Test #5", null);
        }
    }
}