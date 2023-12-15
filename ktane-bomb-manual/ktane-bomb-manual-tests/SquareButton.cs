using ktane_bomb_manual;
using ktane_bomb_manual.Modules;
using NUnit.Framework;

namespace Tests
{
    public class SquareButtonTest
    {
        public Bomb bomb;

        [SetUp]
        public void Setup()
        {
            bomb = new Bomb();
            bomb.BatteryAA = 4;
            bomb.BatteryD = 1;
            bomb.Ports.Add(new Port("dvi", 1));
            bomb.Ports.Add(new Port("rca", 1));
            bomb.Serial = "731NE8";
        }

        [Test]
        public void SquareButton_Test()
        {
            var squareButtonModule = new SquareButton();
            Assert.That(squareButtonModule.Command(bomb, "square button yellow elevate"), Is.EqualTo("Just press it."), "Error Test #1", null);

            squareButtonModule = new SquareButton();
            Assert.That(squareButtonModule.Command(bomb, "square button blue detonate"), Is.EqualTo("Hold the button. What is the LED color?"), "Error Test #4", null);
            Assert.That(squareButtonModule.Command(bomb, "square button led orange"), Is.EqualTo("Release when the seconds add up to three or thirteen."), "Error Test #7", null);
        }
    }
}