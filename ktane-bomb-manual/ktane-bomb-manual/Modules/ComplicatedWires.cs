using System.Collections.Generic;
using System.Linq;

namespace ktane_bomb_manual.Modules
{
    public class ComplicatedWires : Module
    {
        public ComplicatedWires()
        {
            Wires = new List<ComplicatedWire>();
        }

        public List<ComplicatedWire> Wires;

        public override string Solve(Bomb bomb)
        {
            if (string.IsNullOrEmpty(bomb.Serial)) return "Can't solve it yet.";

            var message = "";
            foreach (var wire in Wires)
            {
                message += ShouldICutThisWire(bomb, wire) + " wire number " + (Wires.IndexOf(wire) + 1) + ". ";
            }
            return message.TrimEnd();
        }

        public override string Command(Bomb bomb, string command)
        {
            if (command.Contains("solve"))
            {
                var solveReturn = Solve(bomb);
                Solved = solveReturn != "Can't solve it yet.";
                return solveReturn;
            }
            string config = "";

            foreach (var word in command.Split(' ').Where(x => x=="none"||x == "white" || x == "blue" || x == "red" || x == "star" || x == "led"))
            {
                config += word + " ";
            }
            Wires.Add(new ComplicatedWire(config));
            return "Complicated wire added.";
        }

        public string ShouldICutThisWire(Bomb bomb, ComplicatedWire wire)
        {
            wire.HasSerialLastDigitEven = bomb.HasSerialLastDigitEven();
            wire.HasParallelPort = bomb.HasPort("parallel");
            wire.HasBatteries = bomb.HasManyBatteries(2);

            return CutThisWire(wire) ? "Cut" : "Don't cut";
        }

        public bool CutThisWire(ComplicatedWire wire)
        {
            if (wire.HasRed)
            {
                if (wire.HasBlue)
                {
                    if (wire.HasStar)
                    {
                        if (wire.HasLed)
                        {
                            return false;
                        }
                        else
                        {
                            return wire.HasParallelPort;
                        }
                    }
                    else
                    {
                        return wire.HasSerialLastDigitEven;
                    }
                }
                else
                {
                    if (wire.HasStar)
                    {
                        if (wire.HasLed)
                        {
                            return wire.HasBatteries;
                        }
                        else
                        {
                            return true;
                        }
                    }
                    else
                    {
                        if (wire.HasLed)
                        {
                            return wire.HasBatteries;
                        }
                        else
                        {
                            return wire.HasSerialLastDigitEven;
                        }
                    }
                }
            }
            else
            {
                if (wire.HasBlue)
                {
                    if (wire.HasStar)
                    {
                        if (wire.HasLed)
                        {
                            return wire.HasParallelPort;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (wire.HasLed)
                        {
                            return wire.HasParallelPort;
                        }
                        else
                        {
                            return wire.HasSerialLastDigitEven;
                        }
                    }
                }
                else
                {
                    if (wire.HasStar)
                    {
                        if (wire.HasLed)
                        {
                            return wire.HasBatteries;
                        }
                        else
                        {
                            return true;
                        }
                    }
                    else
                    {
                        if (wire.HasLed)
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                }
            }
        }
    }

    public class ComplicatedWire
    {
        public bool HasRed;
        public bool HasBlue;
        public bool HasStar;
        public bool HasLed;
        public bool HasSerialLastDigitEven;
        public bool HasParallelPort;
        public bool HasBatteries;

        public ComplicatedWire(string parameters)
        {
            if (parameters.Contains("red")) HasRed = true;
            if (parameters.Contains("blue")) HasBlue = true;
            if (parameters.Contains("star")) HasStar = true;
            if (parameters.Contains("led")) HasLed = true;
        }
    }
}
