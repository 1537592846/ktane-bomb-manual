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
            Assert.That(wiresModule.Command(bomb,"wires colors are red black red"), Is.EqualTo("Cut the third one."), "Error Test #1", null);

            //Test #2 - Cut the last wire
            wiresModule = new Wires();
            Assert.That(wiresModule.Command(bomb,"wires colors are white yellow red"), Is.EqualTo("Cut the third one."), "Error Test #2", null);

            //Test #3 - Cut the second wire
            wiresModule = new Wires();
            Assert.That(wiresModule.Command(bomb,"wires are black black black"), Is.EqualTo("Cut the second one."), "Error Test #3", null);

            //Test #4 - Cut the second wire
            wiresModule = new Wires();
            Assert.That(wiresModule.Command(bomb,"wires are blue blue white"), Is.EqualTo("Cut the second one."), "Error Test #4", null);
        }

        [Test]
        public void Wires_FourWiresTest()
        {
            var wiresModule = new Wires();

            //Test #1 - Cut the last red wire
            Assert.That(wiresModule.Command(bomb,"wires are red yellow black and red"), Is.EqualTo("Cut the fourth one."), "Error Test #1", null);

            //Test #2 - Cut the last wire
            wiresModule = new Wires();
            Assert.That(wiresModule.Command(bomb,"wires are white yellow yellow black"), Is.EqualTo("Cut the fourth one."), "Error Test #2", null);

            //Test #3 - Cut the second wire
            wiresModule = new Wires();
            Assert.That(wiresModule.Command(bomb,"wires colors are black black black black"), Is.EqualTo("Cut the second one."), "Error Test #3", null);

            //Test #4 - Cut the first wire
            wiresModule = new Wires();
            Assert.That(wiresModule.Command(bomb,"wires are blue black white white"), Is.EqualTo("Cut the first one."), "Error Test #4", null);

            //Test #5 - Cut the last red wire
            wiresModule = new Wires();
            Assert.That(wiresModule.Command(bomb,"wires red blue red white"), Is.EqualTo("Cut the third one."), "Error Test #5", null);

            //Test #6 - Cut the first wire
            wiresModule = new Wires();
            Assert.That(wiresModule.Command(bomb,"wires are white yellow black yellow"), Is.EqualTo("Cut the first one."), "Error Test #6", null);
        }
        
        [Test]
        public void Wires_FiveWiresTest()
        {
            var wiresModule = new Wires();

            //Test #1 - Cut the first wire
            Assert.That(wiresModule.Command(bomb,"wires are red yellow yellow black red"), Is.EqualTo("Cut the first one."), "Error Test #1", null);

            //Test #2 - Cut the last wire
            wiresModule = new Wires();
            Assert.That(wiresModule.Command(bomb,"wires white red yellow yellow black"), Is.EqualTo("Cut the fourth one."), "Error Test #2", null);

            //Test #3 - Cut the last wire
            wiresModule = new Wires();
            Assert.That(wiresModule.Command(bomb,"wires black black black black black"), Is.EqualTo("Cut the fourth one."), "Error Test #3", null);

            //Test #4 - Cut the first wire
            wiresModule = new Wires();
            Assert.That(wiresModule.Command(bomb,"wires blue blue black white white"), Is.EqualTo("Cut the first one."), "Error Test #4", null);

            //Test #5 - Cut the second wire
            wiresModule = new Wires();
            Assert.That(wiresModule.Command(bomb,"wires are red blue red red white"), Is.EqualTo("Cut the second one."), "Error Test #5", null);

            //Test #6 - Cut the first wire
            wiresModule = new Wires();
            Assert.That(wiresModule.Command(bomb,"wires white yellow red black yellow"), Is.EqualTo("Cut the first one."), "Error Test #6", null);
        }

        [Test]
        public void Wires_SixWiresTest()
        {
            var wiresModule = new Wires();

            //Test #1 - Cut the fourth wire
            Assert.That(wiresModule.Command(bomb,"wires red yellow yellow blue black red"), Is.EqualTo("Cut the fourth one."), "Error Test #1", null);

            //Test #2 - Cut the fourth wire
            wiresModule = new Wires();
            Assert.That(wiresModule.Command(bomb,"wires white red yellow blue white black"), Is.EqualTo("Cut the fourth one."), "Error Test #2", null);

            //Test #3 - Cut the third wire
            wiresModule = new Wires();
            Assert.That(wiresModule.Command(bomb,"wires black black black black black black"), Is.EqualTo("Cut the third one."), "Error Test #3", null);

            //Test #4 - Cut the last wire
            wiresModule = new Wires();
            Assert.That(wiresModule.Command(bomb,"wires blue white yellow black yellow white"), Is.EqualTo("Cut the sixth one."), "Error Test #4", null);

            //Test #5 - Cut the third wire
            wiresModule = new Wires();
            Assert.That(wiresModule.Command(bomb,"wires red blue red white red white"), Is.EqualTo("Cut the third one."), "Error Test #5", null);

            //Test #6 - Cut the fourth wire
            wiresModule = new Wires();
            Assert.That(wiresModule.Command(bomb,"wires white yellow yellow red black yellow"), Is.EqualTo("Cut the fourth one."), "Error Test #6", null);
        }
    }
}