using ktane_bomb_manual;
using ktane_bomb_manual.Modules;
using NUnit.Framework;

namespace Tests
{
    public class MemoryTest
    {
        public Bomb bomb;

        [SetUp]
        public void Setup() => bomb = new Bomb();

        [Test]
        public void Memory_Test()
        {
            var memoryModule = new Memory();
            Assert.Multiple(() =>
            {
                Assert.That(memoryModule.Command(bomb, "memory display 3 numbers 4 1 3 2"), Is.EqualTo("Press 3."), "Error Test #1", null);
                Assert.That(memoryModule.Command(bomb, "memory display 4 numbers 1 4 2 3"), Is.EqualTo("Press 2."), "Error Test #1", null);
                Assert.That(memoryModule.Command(bomb, "memory display 3 numbers 4 2 3 1"), Is.EqualTo("Press 3."), "Error Test #1", null);
                Assert.That(memoryModule.Command(bomb, "memory display 4 numbers 3 2 4 1"), Is.EqualTo("Press 4."), "Error Test #1", null);
                Assert.That(memoryModule.Command(bomb, "memory display 2 numbers 4 3 1 2"), Is.EqualTo("Press 2."), "Error Test #1", null);
            });
        }
    }
}