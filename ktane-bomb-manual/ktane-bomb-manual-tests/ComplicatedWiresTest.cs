using ktane_bomb_manual;
using ktane_bomb_manual.Modules;
using NUnit.Framework;

namespace Tests
{
    public class ComplicatedWiresTest
    {
        public Bomb bomb;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void OddSerialWith2BatteriesNoParallelPort()
        {
            bomb = new Bomb();
            bomb.Serial = "T5K8W9";
            bomb.BatteryAA = 2;

            var complicatedWires = new ComplicatedWires();
            Assert.That(complicatedWires.Command(bomb, "complicated wires is red blue"), Is.EqualTo("Leave it."), "Error Test #1", null);

            complicatedWires = new ComplicatedWires();
            Assert.That(complicatedWires.Command(bomb, "complicated wires is star led"), Is.EqualTo("Cut it."), "Error Test #2", null);

            complicatedWires = new ComplicatedWires();
            Assert.That(complicatedWires.Command(bomb, "complicated wires white"), Is.EqualTo("Cut it."), "Error Test #3", null);

            complicatedWires = new ComplicatedWires();
            Assert.That(complicatedWires.Command(bomb, "complicated wires notheing special"), Is.EqualTo("Cut it."), "Error Test #4", null);

            complicatedWires = new ComplicatedWires();
            Assert.That(complicatedWires.Command(bomb, "complicated wires red blue star led"), Is.EqualTo("Leave it."), "Error Test #5", null);
        }

        [Test]
        public void EvenSerialWith1BatteriesNoParallelPort()
        {
            bomb = new Bomb();
            bomb.Serial = "T5K8W8";
            bomb.BatteryAA = 1;

            var complicatedWires = new ComplicatedWires();
            Assert.That(complicatedWires.Command(bomb, "complicated wires red blue"), Is.EqualTo("Cut it."), "Error Test #1", null);

            complicatedWires = new ComplicatedWires();
            Assert.That(complicatedWires.Command(bomb, "complicated wires star led"), Is.EqualTo("Leave it."), "Error Test #2", null);
        }

        [Test]
        public void OddSerialWith1BatteriesWithParallelPort()
        {
            bomb = new Bomb();
            bomb.Serial = "T5K8W9";
            bomb.BatteryAA = 1;
            bomb.Ports.Add(new Port("parallel", 1));

            var complicatedWires = new ComplicatedWires();
            Assert.That(complicatedWires.Command(bomb, "complicated wires red blue"), Is.EqualTo("Leave it."), "Error Test #1", null);

            complicatedWires = new ComplicatedWires();
            Assert.That(complicatedWires.Command(bomb, "complicated wires star led"), Is.EqualTo("Leave it."), "Error Test #2", null);
        }
    }
}