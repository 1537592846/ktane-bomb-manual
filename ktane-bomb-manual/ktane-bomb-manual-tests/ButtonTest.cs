using ktane_bomb_manual;
using ktane_bomb_manual.Modules;
using NUnit.Framework;

namespace Tests
{
    public class ButtonTest
    {
        public Bomb bomb;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void BombWith1BaterryAndNoTags()
        {
            bomb = new Bomb();
            bomb.Serial = "T5K8W4";
            bomb.BatteryAA = 1;

            //Hold button, release on number 1
            var buttonModule = new Button();
            Assert.AreEqual("Hold the button. What is the stripe color?", buttonModule.Command(bomb,"button is red detonate"), "Error Test #1, hold/press", null);
            Assert.AreEqual("Release when shown one.", buttonModule.Command(bomb,"button stripe is white"), "Error Test #1, stripe", null);

            //Hold button, release on number 5
            buttonModule = new Button();
            Assert.AreEqual("Hold the button. What is the stripe color?", buttonModule.Command(bomb, "button is white abort"), "Error Test #2, hold/press", null);
            Assert.AreEqual("Release when shown five.", buttonModule.Command(bomb, "button stripe is yellow"), "Error Test #2, stripe", null);

            //Hold button, release on number 1
            buttonModule = new Button();
            Assert.AreEqual("Hold the button. What is the stripe color?", buttonModule.Command(bomb, "button is blue abort"), "Error Test #3, hold/press", null);
            Assert.AreEqual("Release when shown one.", buttonModule.Command(bomb, "button stripe is red"), "Error Test #3, stripe", null);


            //Press button
            buttonModule = new Button();
            Assert.AreEqual("Just press it.", buttonModule.Command(bomb, "button is red hold"), "Error Test #4, hold/press", null);
        }

        [Test]
        public void BombWith2BaterryAndTags()
        {
            bomb = new Bomb();
            bomb.Serial = "T5K8W4";
            bomb.BatteryAA = 2;
            bomb.Indicators.Add(new Indicator("car", true));
            bomb.Indicators.Add(new Indicator("frk", false));

            //Press button
            var buttonModule = new Button();
            Assert.AreEqual("Just press it.", buttonModule.Command(bomb,"button is red detonate"), "Error Test #1, hold/press", null);

            //Hold button, release on number 5
            buttonModule = new Button();
            Assert.AreEqual("Hold the button. What is the stripe color?", buttonModule.Command(bomb,"button is white abort"), "Error Test #2, hold/press", null);
            Assert.AreEqual("Release when shown five.", buttonModule.Command(bomb,"button stripe is yellow"), "Error Test #2, stripe", null);

            bomb = new Bomb();
            bomb.Serial = "T5K8W4";
            bomb.BatteryAA = 2;
            bomb.Indicators.Add(new Indicator("car", false));
            bomb.Indicators.Add(new Indicator("frk", true));

            //Press button
            buttonModule = new Button();
            Assert.AreEqual("Just press it.", buttonModule.Command(bomb, "button is red hold"), "Error Test #3, hold/press", null);
        }
    }
}