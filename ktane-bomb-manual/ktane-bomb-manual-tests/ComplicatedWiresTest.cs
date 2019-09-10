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
            complicatedWires.Wires.Add(new ComplicatedWire("red and blue wire"));
            Assert.AreEqual("Don't cut wire number 1.", complicatedWires.Solve(bomb), "Error Test #1", null);

            complicatedWires = new ComplicatedWires();
            complicatedWires.Wires.Add(new ComplicatedWire("star and led wire"));
            Assert.AreEqual("Cut wire number 1.", complicatedWires.Solve(bomb), "Error Test #2", null);

            complicatedWires = new ComplicatedWires();
            complicatedWires.Wires.Add(new ComplicatedWire("white wire"));
            Assert.AreEqual("Cut wire number 1.", complicatedWires.Solve(bomb), "Error Test #3", null);

            complicatedWires = new ComplicatedWires();
            complicatedWires.Wires.Add(new ComplicatedWire("nothing special wire"));
            Assert.AreEqual("Cut wire number 1.", complicatedWires.Solve(bomb), "Error Test #4", null);

            complicatedWires = new ComplicatedWires();
            complicatedWires.Wires.Add(new ComplicatedWire("red, blue, star and led wire"));
            Assert.AreEqual("Don't cut wire number 1.", complicatedWires.Solve(bomb), "Error Test #5", null);
        }

        [Test]
        public void EvenSerialWith1BatteriesNoParallelPort()
        {
            bomb = new Bomb();
            bomb.Serial = "T5K8W8";
            bomb.BatteryAA = 1;

            var complicatedWires = new ComplicatedWires();
            complicatedWires.Wires.Add(new ComplicatedWire("red and blue wire"));
            Assert.AreEqual("Cut wire number 1.", complicatedWires.Solve(bomb), "Error Test #1", null);

            complicatedWires = new ComplicatedWires();
            complicatedWires.Wires.Add(new ComplicatedWire("star and led wire"));
            Assert.AreEqual("Don't cut wire number 1.", complicatedWires.Solve(bomb), "Error Test #2", null);
        }

        [Test]
        public void OddSerialWith1BatteriesWithParallelPort()
        {
            bomb = new Bomb();
            bomb.Serial = "T5K8W9";
            bomb.BatteryAA = 1;
            bomb.Ports.Add(new Port("parallel",1));

            var complicatedWires = new ComplicatedWires();
            complicatedWires.Wires.Add(new ComplicatedWire("red and blue wire"));
            Assert.AreEqual("Don't cut wire number 1.", complicatedWires.Solve(bomb), "Error Test #1", null);

            complicatedWires = new ComplicatedWires();
            complicatedWires.Wires.Add(new ComplicatedWire("star and led wire"));
            Assert.AreEqual("Don't cut wire number 1.", complicatedWires.Solve(bomb), "Error Test #2", null);
        }
    }
}