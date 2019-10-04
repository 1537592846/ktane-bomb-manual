using System.Linq;

namespace ktane_bomb_manual.Modules
{
    public class ComplicatedWires : Module
    {
        public ComplicatedWire wire;

        public override string Solve(Bomb bomb)
        {
            if (string.IsNullOrEmpty(bomb.Serial)) return "Can't solve it. Bomb has no serial number.";

            return ShouldICutThisWire(bomb, wire);
        }

        public override string Command(Bomb bomb, string command)
        {
            string config = "";

            foreach (var word in command.Split(' ').Where(x => x == "none" || x == "white" || x == "blue" || x == "red" || x == "star" || x == "led"))
            {
                config += word + " ";
            }
            wire = new ComplicatedWire(config.Trim());
            Solved = true;
            return Solve(bomb);
        }

        public string ShouldICutThisWire(Bomb bomb, ComplicatedWire wire)
        {
            wire.HasSerialLastDigitEven = bomb.HasSerialLastDigitEven();
            wire.HasParallelPort = bomb.HasPort("parallel");
            wire.HasBatteries = bomb.HasManyBatteries(2);

            return CutThisWire(wire) ? "Cut it." : "Leave it.";
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
