using ktane_bomb_manual;
using ktane_bomb_manual.Modules;
using NUnit.Framework;

namespace Tests
{
    public class RotaryPhoneTest
    {
        public Bomb bomb;

        [SetUp]
        public void Setup()
        {
            bomb = new Bomb();
        }

        [Test]
        public void RotaryPhone_Test()
        {
            var rotaryPhoneModule = new RotaryPhone();
            Assert.That(rotaryPhoneModule.Command(bomb, "rotary phone numbers are 8 2 7"), Is.EqualTo("Numbers are 8 2 7."), "Error test #1", null);
            Assert.That(rotaryPhoneModule.Command(bomb, "rotary phone numbers are 1 1 1"), Is.EqualTo("Numbers are 9 3 8."), "Error test #1", null);
            Assert.That(rotaryPhoneModule.Command(bomb, "rotary phone numbers are 1 1 1"), Is.EqualTo("Numbers are 0 4 9."), "Error test #2", null);
            Assert.That(rotaryPhoneModule.Command(bomb, "rotary phone numbers are 1 1 1"), Is.EqualTo("Numbers are 1 6 0."), "Error test #3", null);
            Assert.That(rotaryPhoneModule.Command(bomb, "rotary phone numbers are 1 1 1"), Is.EqualTo("Numbers are 2 7 1."), "Error test #4", null);
            Assert.That(rotaryPhoneModule.Command(bomb, "rotary phone numbers are 1 1 1"), Is.EqualTo("Numbers are 3 8 2."), "Error test #5", null);
            Assert.That(rotaryPhoneModule.Command(bomb, "rotary phone numbers are 1 1 1"), Is.EqualTo("Numbers are 4 9 3."), "Error test #6", null);
        }
    }
}