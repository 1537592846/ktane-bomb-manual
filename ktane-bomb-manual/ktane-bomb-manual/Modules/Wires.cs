using System.Collections.Generic;
using System.Linq;

namespace ktane_bomb_manual.Modules
{
    public class Wires : Module
    {
        public Wires()
        {
            WireColors = new List<string>();
        }

        public List<string> WireColors { get; set; }

        public override string Solve(Bomb bomb)
        {
            Solved = true;
            return WireToCut(bomb);
        }

        public override string Command(Bomb bomb, string command)
        {
            if (command.Contains("solve") || command.Contains("solution"))
            {
                return Solve(bomb);
            }

            if (command.Contains("colors") || command.Contains("wires"))
            {
                foreach (var wire in command.Split(' ').Where(x => IsWireColor(x)))
                {
                    AddWire(wire);
                }
            }
            return "";
        }

        public void AddWire(string wire)
        {
            WireColors.Add(wire);
        }

        public bool IsWireColor(string wire)
        {
            switch (wire)
            {
                case "white":
                case "black":
                case "blue":
                case "yellow":
                case "red": return true;
                default: return false;
            }
        }

        public int ColorCount(string color)
        {
            return WireColors.Where(x => x == color).Count();
        }

        public string LastColor()
        {
            return WireColors.Last();
        }

        public string WireToCut(Bomb bomb)
        {
            string wireToCut = "";
            switch (WireColors.Count)
            {
                case 3: wireToCut = ThreeWires(bomb); break;
                case 4: wireToCut = FourWires(bomb); break;
                case 5: wireToCut = FiveWires(bomb); break;
                case 6: wireToCut = SixWires(bomb); break;
            }
            return "Cut the " + wireToCut + " one.";
        }

        public string ThreeWires(Bomb bomb)
        {
            if (ColorCount("red") == 0) return Position(2);
            if (LastColor() == "white") return Position(3);
            if (ColorCount("blue") == 1)
                Position(WireColors.LastIndexOf("blue") + 1);
            return Position(3);
        }

        public string FourWires(Bomb bomb)
        {
            if (ColorCount("red") > 1 && bomb.HasSerialLastDigitOdd()) return Position(WireColors.LastIndexOf("red") + 1);
            if (ColorCount("red") == 0 && LastColor() == "yellow") return Position(1);
            if (ColorCount("blue") == 1) return Position(1);
            if (ColorCount("yellow") > 1) return Position(4);
            return Position(2);
        }

        public string FiveWires(Bomb bomb)
        {
            if (LastColor() == "black" && bomb.HasSerialLastDigitOdd()) return Position(4);
            if (ColorCount("red") == 1 && ColorCount("yellow") > 1) return Position(1);
            if (ColorCount("black") == 0) return Position(2);
            return Position(1);
        }

        public string SixWires(Bomb bomb)
        {
            if (ColorCount("yellow") == 0 && bomb.HasSerialLastDigitOdd()) return Position(3);
            if (ColorCount("yellow") == 1 && ColorCount("white") > 1) return Position(4);
            if (ColorCount("red") == 0) return Position(6);
            return Position(4);
        }

        public string Position(int number)
        {
            switch (number)
            {
                case 1: return "first";
                case 2: return "second";
                case 3: return "third";
                case 4: return "fourth";
                case 5: return "fifth";
                case 6: return "sixth";
                default: return "";
            }
        }
    }
}
