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
            Assert.AreEqual("Don't cut it.", complicatedWires.Command(bomb, "complicated wires is red blue"), "Error Test #1", null);

            complicatedWires = new ComplicatedWires();
            Assert.AreEqual("Cut it.", complicatedWires.Command(bomb, "complicated wires is star led"), "Error Test #2", null);

            complicatedWires = new ComplicatedWires();
            Assert.AreEqual("Cut it.", complicatedWires.Command(bomb, "complicated wires white"), "Error Test #3", null);

            complicatedWires = new ComplicatedWires();
            Assert.AreEqual("Cut it.", complicatedWires.Command(bomb, "complicated wires notheing special"), "Error Test #4", null);

            complicatedWires = new ComplicatedWires();
            Assert.AreEqual("Don't cut it.", complicatedWires.Command(bomb, "complicated wires red blue star led"), "Error Test #5", null);
        }

        [Test]
        public void EvenSerialWith1BatteriesNoParallelPort()
        {
            bomb = new Bomb();
            bomb.Serial = "T5K8W8";
            bomb.BatteryAA = 1;

            var complicatedWires = new ComplicatedWires();
            Assert.AreEqual("Cut it.", complicatedWires.Command(bomb, "complicated wires red blue"), "Error Test #1", null);

            complicatedWires = new ComplicatedWires();
            Assert.AreEqual("Don't cut it.", complicatedWires.Command(bomb, "complicated wires star led"), "Error Test #2", null);
        }

        [Test]
        public void OddSerialWith1BatteriesWithParallelPort()
        {
            bomb = new Bomb();
            bomb.Serial = "T5K8W9";
            bomb.BatteryAA = 1;
            bomb.Ports.Add(new Port("parallel", 1));

            var complicatedWires = new ComplicatedWires();
            Assert.AreEqual("Don't cut it.", complicatedWires.Command(bomb, "complicated wires red blue"), "Error Test #1", null);

            complicatedWires = new ComplicatedWires();
            Assert.AreEqual("Don't cut it.", complicatedWires.Command(bomb, "complicated wires star led"), "Error Test #2", null);
        }
    }
}