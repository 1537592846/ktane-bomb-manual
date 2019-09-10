using ktane_bomb_manual;
using ktane_bomb_manual.Modules;
using NUnit.Framework;

namespace Tests
{
    public class WiresTest
    {
        public Bomb bomb;

        [SetUp]
        public void Setup()
        {
            bomb = new Bomb();
            bomb.Serial="T5K8W9";
        }

        [Test]
        public void ThreeWiresTest()
        {
            var wiresModule = new Wires();

            //Test #1 - Cut the last wire
            wiresModule.WireColors.Add("red");
            wiresModule.WireColors.Add("black");
            wiresModule.WireColors.Add("red");
            Assert.AreEqual("Cut the third one.", wiresModule.Solve(bomb), "Error Test #1", null);

            //Test #2 - Cut the last wire
            wiresModule = new Wires();
            wiresModule.WireColors.Add("white");
            wiresModule.WireColors.Add("yellow");
            wiresModule.WireColors.Add("red");
            Assert.AreEqual("Cut the third one.", wiresModule.Solve(bomb), "Error Test #2", null);

            //Test #3 - Cut the second wire
            wiresModule = new Wires();
            wiresModule.WireColors.Add("black");
            wiresModule.WireColors.Add("black");
            wiresModule.WireColors.Add("black");
            Assert.AreEqual("Cut the second one.", wiresModule.Solve(bomb), "Error Test #3", null);

            //Test #4 - Cut the second wire
            wiresModule = new Wires();
            wiresModule.WireColors.Add("blue");
            wiresModule.WireColors.Add("blue");
            wiresModule.WireColors.Add("white");
            Assert.AreEqual("Cut the second one.", wiresModule.Solve(bomb), "Error Test #4", null);
        }

        [Test]
        public void FourWiresTest()
        {
            var wiresModule = new Wires();

            //Test #1 - Cut the last red wire
            wiresModule.WireColors.Add("red");
            wiresModule.WireColors.Add("yellow");
            wiresModule.WireColors.Add("black");
            wiresModule.WireColors.Add("red");
            Assert.AreEqual("Cut the fourth one.", wiresModule.WireToCut(bomb), "Error Test #1", null);

            //Test #2 - Cut the last wire
            wiresModule = new Wires();
            wiresModule.WireColors.Add("white");
            wiresModule.WireColors.Add("yellow");
            wiresModule.WireColors.Add("yellow");
            wiresModule.WireColors.Add("black");
            Assert.AreEqual("Cut the fourth one.", wiresModule.WireToCut(bomb), "Error Test #2", null);

            //Test #3 - Cut the second wire
            wiresModule = new Wires();
            wiresModule.WireColors.Add("black");
            wiresModule.WireColors.Add("black");
            wiresModule.WireColors.Add("black");
            wiresModule.WireColors.Add("black");
            Assert.AreEqual("Cut the second one.", wiresModule.WireToCut(bomb), "Error Test #3", null);

            //Test #4 - Cut the first wire
            wiresModule = new Wires();
            wiresModule.WireColors.Add("blue");
            wiresModule.WireColors.Add("black");
            wiresModule.WireColors.Add("white");
            wiresModule.WireColors.Add("white");
            Assert.AreEqual("Cut the first one.", wiresModule.WireToCut(bomb), "Error Test #4", null);

            //Test #5 - Cut the last red wire
            wiresModule = new Wires();
            wiresModule.WireColors.Add("red");
            wiresModule.WireColors.Add("blue");
            wiresModule.WireColors.Add("red");
            wiresModule.WireColors.Add("white");
            Assert.AreEqual("Cut the third one.", wiresModule.WireToCut(bomb), "Error Test #5", null);

            //Test #6 - Cut the first wire
            wiresModule = new Wires();
            wiresModule.WireColors.Add("white");
            wiresModule.WireColors.Add("yellow");
            wiresModule.WireColors.Add("black");
            wiresModule.WireColors.Add("yellow");
            Assert.AreEqual("Cut the first one.", wiresModule.WireToCut(bomb), "Error Test #6", null);
        }
        
        [Test]
        public void FiveWiresTest()
        {
            var wiresModule = new Wires();

            //Test #1 - Cut the first wire
            wiresModule.WireColors.Add("red");
            wiresModule.WireColors.Add("yellow");
            wiresModule.WireColors.Add("yellow");
            wiresModule.WireColors.Add("black");
            wiresModule.WireColors.Add("red");
            Assert.AreEqual("Cut the first one.", wiresModule.WireToCut(bomb), "Error Test #1", null);

            //Test #2 - Cut the last wire
            wiresModule = new Wires();
            wiresModule.WireColors.Add("white");
            wiresModule.WireColors.Add("red");
            wiresModule.WireColors.Add("yellow");
            wiresModule.WireColors.Add("yellow");
            wiresModule.WireColors.Add("black");
            Assert.AreEqual("Cut the fourth one.", wiresModule.WireToCut(bomb), "Error Test #2", null);

            //Test #3 - Cut the last wire
            wiresModule = new Wires();
            wiresModule.WireColors.Add("black");
            wiresModule.WireColors.Add("black");
            wiresModule.WireColors.Add("black");
            wiresModule.WireColors.Add("black");
            wiresModule.WireColors.Add("black");
            Assert.AreEqual("Cut the fourth one.", wiresModule.WireToCut(bomb), "Error Test #3", null);

            //Test #4 - Cut the first wire
            wiresModule = new Wires();
            wiresModule.WireColors.Add("blue");
            wiresModule.WireColors.Add("blue");
            wiresModule.WireColors.Add("black");
            wiresModule.WireColors.Add("white");
            wiresModule.WireColors.Add("white");
            Assert.AreEqual("Cut the first one.", wiresModule.WireToCut(bomb), "Error Test #4", null);

            //Test #5 - Cut the second wire
            wiresModule = new Wires();
            wiresModule.WireColors.Add("red");
            wiresModule.WireColors.Add("blue");
            wiresModule.WireColors.Add("red");
            wiresModule.WireColors.Add("red");
            wiresModule.WireColors.Add("white");
            Assert.AreEqual("Cut the second one.", wiresModule.WireToCut(bomb), "Error Test #5", null);

            //Test #6 - Cut the first wire
            wiresModule = new Wires();
            wiresModule.WireColors.Add("white");
            wiresModule.WireColors.Add("yellow");
            wiresModule.WireColors.Add("red");
            wiresModule.WireColors.Add("black");
            wiresModule.WireColors.Add("yellow");
            Assert.AreEqual("Cut the first one.", wiresModule.WireToCut(bomb), "Error Test #6", null);
        }

        [Test]
        public void SixWiresTest()
        {
            var wiresModule = new Wires();

            //Test #1 - Cut the fourth wire
            wiresModule.WireColors.Add("red");
            wiresModule.WireColors.Add("yellow");
            wiresModule.WireColors.Add("yellow");
            wiresModule.WireColors.Add("blue");
            wiresModule.WireColors.Add("black");
            wiresModule.WireColors.Add("red");
            Assert.AreEqual("Cut the fourth one.", wiresModule.WireToCut(bomb), "Error Test #1", null);

            //Test #2 - Cut the fourth wire
            wiresModule = new Wires();
            wiresModule.WireColors.Add("white");
            wiresModule.WireColors.Add("red");
            wiresModule.WireColors.Add("yellow");
            wiresModule.WireColors.Add("blue");
            wiresModule.WireColors.Add("white");
            wiresModule.WireColors.Add("black");
            Assert.AreEqual("Cut the fourth one.", wiresModule.WireToCut(bomb), "Error Test #2", null);

            //Test #3 - Cut the third wire
            wiresModule = new Wires();
            wiresModule.WireColors.Add("black");
            wiresModule.WireColors.Add("black");
            wiresModule.WireColors.Add("black");
            wiresModule.WireColors.Add("black");
            wiresModule.WireColors.Add("black");
            wiresModule.WireColors.Add("black");
            Assert.AreEqual("Cut the third one.", wiresModule.WireToCut(bomb), "Error Test #3", null);

            //Test #4 - Cut the last wire
            wiresModule = new Wires();
            wiresModule.WireColors.Add("blue");
            wiresModule.WireColors.Add("white");
            wiresModule.WireColors.Add("yellow");
            wiresModule.WireColors.Add("black");
            wiresModule.WireColors.Add("yellow");
            wiresModule.WireColors.Add("white");
            Assert.AreEqual("Cut the sixth one.", wiresModule.WireToCut(bomb), "Error Test #4", null);

            //Test #5 - Cut the third wire
            wiresModule = new Wires();
            wiresModule.WireColors.Add("red");
            wiresModule.WireColors.Add("blue");
            wiresModule.WireColors.Add("red");
            wiresModule.WireColors.Add("white");
            wiresModule.WireColors.Add("red");
            wiresModule.WireColors.Add("white");
            Assert.AreEqual("Cut the third one.", wiresModule.WireToCut(bomb), "Error Test #5", null);

            //Test #6 - Cut the fourth wire
            wiresModule = new Wires();
            wiresModule.WireColors.Add("white");
            wiresModule.WireColors.Add("yellow");
            wiresModule.WireColors.Add("yellow");
            wiresModule.WireColors.Add("red");
            wiresModule.WireColors.Add("black");
            wiresModule.WireColors.Add("yellow");
            Assert.AreEqual("Cut the fourth one.", wiresModule.WireToCut(bomb), "Error Test #6", null);
        }
    }
}