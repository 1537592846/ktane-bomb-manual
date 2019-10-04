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
        public void Wires_ThreeWiresTest()
        {
            var wiresModule = new Wires();

            //Test #1 - Cut the last wire
            Assert.AreEqual("Cut the third one.", wiresModule.Command(bomb,"wires colors are red black red"), "Error Test #1", null);

            //Test #2 - Cut the last wire
            wiresModule = new Wires();
            Assert.AreEqual("Cut the third one.", wiresModule.Command(bomb,"wires colors are white yellow red"), "Error Test #2", null);

            //Test #3 - Cut the second wire
            wiresModule = new Wires();
            Assert.AreEqual("Cut the second one.", wiresModule.Command(bomb,"wires are black black black"), "Error Test #3", null);

            //Test #4 - Cut the second wire
            wiresModule = new Wires();
            Assert.AreEqual("Cut the second one.", wiresModule.Command(bomb,"wires are blue blue white"), "Error Test #4", null);
        }

        [Test]
        public void Wires_FourWiresTest()
        {
            var wiresModule = new Wires();

            //Test #1 - Cut the last red wire
            Assert.AreEqual("Cut the fourth one.", wiresModule.Command(bomb,"wires are red yellow black and red"), "Error Test #1", null);

            //Test #2 - Cut the last wire
            wiresModule = new Wires();
            Assert.AreEqual("Cut the fourth one.", wiresModule.Command(bomb,"wires are white yellow yellow black"), "Error Test #2", null);

            //Test #3 - Cut the second wire
            wiresModule = new Wires();
            Assert.AreEqual("Cut the second one.", wiresModule.Command(bomb,"wires colors are black black black black"), "Error Test #3", null);

            //Test #4 - Cut the first wire
            wiresModule = new Wires();
            Assert.AreEqual("Cut the first one.", wiresModule.Command(bomb,"wires are blue black white white"), "Error Test #4", null);

            //Test #5 - Cut the last red wire
            wiresModule = new Wires();
            Assert.AreEqual("Cut the third one.", wiresModule.Command(bomb,"wires red blue red white"), "Error Test #5", null);

            //Test #6 - Cut the first wire
            wiresModule = new Wires();
            Assert.AreEqual("Cut the first one.", wiresModule.Command(bomb,"wires are white yellow black yellow"), "Error Test #6", null);
        }
        
        [Test]
        public void Wires_FiveWiresTest()
        {
            var wiresModule = new Wires();

            //Test #1 - Cut the first wire
            Assert.AreEqual("Cut the first one.", wiresModule.Command(bomb,"wires are red yellow yellow black red"), "Error Test #1", null);

            //Test #2 - Cut the last wire
            wiresModule = new Wires();
            Assert.AreEqual("Cut the fourth one.", wiresModule.Command(bomb,"wires white red yellow yellow black"), "Error Test #2", null);

            //Test #3 - Cut the last wire
            wiresModule = new Wires();
            Assert.AreEqual("Cut the fourth one.", wiresModule.Command(bomb,"wires black black black black black"), "Error Test #3", null);

            //Test #4 - Cut the first wire
            wiresModule = new Wires();
            Assert.AreEqual("Cut the first one.", wiresModule.Command(bomb,"wires blue blue black white white"), "Error Test #4", null);

            //Test #5 - Cut the second wire
            wiresModule = new Wires();
            Assert.AreEqual("Cut the second one.", wiresModule.Command(bomb,"wires are red blue red red white"), "Error Test #5", null);

            //Test #6 - Cut the first wire
            wiresModule = new Wires();
            Assert.AreEqual("Cut the first one.", wiresModule.Command(bomb,"wires white yellow red black yellow"), "Error Test #6", null);
        }

        [Test]
        public void Wires_SixWiresTest()
        {
            var wiresModule = new Wires();

            //Test #1 - Cut the fourth wire
            Assert.AreEqual("Cut the fourth one.", wiresModule.Command(bomb,"wires red yellow yellow blue black red"), "Error Test #1", null);

            //Test #2 - Cut the fourth wire
            wiresModule = new Wires();
            Assert.AreEqual("Cut the fourth one.", wiresModule.Command(bomb,"wires white red yellow blue white black"), "Error Test #2", null);

            //Test #3 - Cut the third wire
            wiresModule = new Wires();
            Assert.AreEqual("Cut the third one.", wiresModule.Command(bomb,"wires black black black black black black"), "Error Test #3", null);

            //Test #4 - Cut the last wire
            wiresModule = new Wires();
            Assert.AreEqual("Cut the sixth one.", wiresModule.Command(bomb,"wires blue white yellow black yellow white"), "Error Test #4", null);

            //Test #5 - Cut the third wire
            wiresModule = new Wires();
            Assert.AreEqual("Cut the third one.", wiresModule.Command(bomb,"wires red blue red white red white"), "Error Test #5", null);

            //Test #6 - Cut the fourth wire
            wiresModule = new Wires();
            Assert.AreEqual("Cut the fourth one.", wiresModule.Command(bomb,"wires white yellow yellow red black yellow"), "Error Test #6", null);
        }
    }
}