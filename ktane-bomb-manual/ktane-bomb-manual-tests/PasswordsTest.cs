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
        public void Passwords_Test()
        {
            var passwordsModule = new Passwords();
            passwordsModule.Command(bomb, "passwords first slot is alpha tango charlie lima kilo romeo");
            passwordsModule.Command(bomb, "passwords second has kilo mike sierra echo delta");
            passwordsModule.Command(bomb, "passwords third one is alpha tango sierra hotel xray");
            passwordsModule.Command(bomb, "passwords fourth is mike november uniform whiskey romeo");
            passwordsModule.Command(bomb, "passwords last one is november foxtrot lima delta alpha");
            Assert.That(passwordsModule.Command(bomb,"solve passwords"), Is.EqualTo("The password is learn."), "Error Test #1", null);
        }
    }
}
