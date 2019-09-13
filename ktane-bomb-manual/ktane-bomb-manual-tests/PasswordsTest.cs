using ktane_bomb_manual;
using ktane_bomb_manual.Modules;
using NUnit.Framework;

namespace Tests
{

    public class PasswordsTest
    {
        public Bomb bomb;

        [SetUp]
        public void Setup()
        {
            bomb = new Bomb();
        }

        [Test]
        public void Passwords()
        {
            var passwordsModule = new Passwords();
            passwordsModule.AddLetters("first slot is alpha tango charlie lima kilo romeo");
            passwordsModule.AddLetters("second has kilo mike sierra echo delta");
            passwordsModule.AddLetters("third one is alpha tango sierra hotel xray");
            passwordsModule.AddLetters("fourth is mike november uniform whiskey romeo");
            passwordsModule.AddLetters("last one is november foxtrot lima delta alpha");
            Assert.AreEqual("The password is learn.", passwordsModule.Solve(bomb), "Error Test #1", null);
        }
    }
}
