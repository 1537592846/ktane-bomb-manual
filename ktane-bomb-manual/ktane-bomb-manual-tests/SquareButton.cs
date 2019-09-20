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
        public void Test()
        {
            var squareButtonModule = new SquareButton();
            Assert.AreEqual("Text added.", squareButtonModule.Command(bomb, "square button text elevate"), "Error Test #1", null);
            Assert.AreEqual("Color added.", squareButtonModule.Command(bomb, "square button color yellow"), "Error Test #2", null);
            Assert.AreEqual("Just press it.", squareButtonModule.Command(bomb, "solve square button"), "Error Test #3", null);

            squareButtonModule = new SquareButton();
            Assert.AreEqual("Text added.", squareButtonModule.Command(bomb, "square button text detonate"), "Error Test #4", null);
            Assert.AreEqual("Color added.", squareButtonModule.Command(bomb, "square button color blue"), "Error Test #5", null);
            Assert.AreEqual("Hold the button. What is the LED color?", squareButtonModule.Command(bomb, "solve square button"), "Error Test #6", null);
            Assert.AreEqual("Release when the seconds add up to three or thirteen.", squareButtonModule.Command(bomb, "square button led orange"), "Error Test #7", null);
        }
    }
}