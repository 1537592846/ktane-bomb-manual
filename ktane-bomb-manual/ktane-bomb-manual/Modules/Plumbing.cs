namespace ktane_bomb_manual.Modules
{
    public class Plumbing : Module
    {
        public bool RedInput;
        public bool BlueInput;
        public bool YellowInput;
        public bool GreenInput;
        public bool RedOutput;
        public bool BlueOutput;
        public bool YellowOutput;
        public bool GreenOutput;

        public override string Solve(Bomb bomb)
        {
            var message = "Input: ";
            message += IsPipeActive(bomb, "red", "input");
            message += IsPipeActive(bomb, "yellow", "input");
            message += IsPipeActive(bomb, "green", "input");
            message += IsPipeActive(bomb, "blue", "input");
            message = message.Trim() + ". Output: ";

            message += IsPipeActive(bomb, "red", "output");
            message += IsPipeActive(bomb, "yellow", "output");
            message += IsPipeActive(bomb, "green", "output");
            message += IsPipeActive(bomb, "blue", "output");
            message = message.Trim() + ".";

            Solved = true;
            return message;
        }

        public override string Command(Bomb bomb, string command)
        {
            if (command.Contains("solve"))
            {
                return Solve(bomb);
            }
            return "Command not executed.";
        }

        public string IsPipeActive(Bomb bomb, string color, string type)
        {
            var count = 0;

            switch (type)
            {
                case "input":
                    {
                        switch (color)
                        {
                            case "red":
                                {
                                    count += bomb.HasSerialChar('1') ? 1 : 0;
                                    count += bomb.GetPortsQuantity("rj") == 1 ? 1 : 0;
                                    count += bomb.HasAnyDuplicatedPort() ? -1 : 0;
                                    count += bomb.HasAnyDuplicatedSerialChar() ? -1 : 0;
                                    RedInput = count > 0;
                                    break;
                                }
                            case "yellow":
                                {
                                    count += bomb.HasSerialChar('2') ? 1 : 0;
                                    count += bomb.HasPort("rca") ? 1 : 0;
                                    count += !bomb.HasAnyDuplicatedPort() ? -1 : 0;
                                    count += bomb.HasSerialChar('1') || bomb.HasSerialChar('L') ? -1 : 0;
                                    YellowInput = count > 0;
                                    break;
                                }
                            case "green":
                                {
                                    count += bomb.GetSerialDigits().Count >= 3 ? 1 : 0;
                                    count += bomb.HasPort("dvi") ? 1 : 0;
                                    count += IsPipeActive(bomb, "red", "input") == "" ? -1 : 0;
                                    count += IsPipeActive(bomb, "yellow", "input") == "" ? -1 : 0;
                                    GreenInput = count > 0;
                                    break;
                                }
                            case "blue":
                                {
                                    count += bomb.HasSerialChar('1') ? 1 : 0;
                                    count += bomb.GetPortsQuantity("rj") == 1 ? 1 : 0;
                                    count += bomb.HasAnyDuplicatedPort() ? -1 : 0;
                                    count += bomb.HasAnyDuplicatedSerialChar() ? -1 : 0;
                                    BlueInput = count > 0 || (!RedInput && !YellowInput && !GreenInput);
                                    count += BlueInput ? 1 : -1;
                                    break;
                                }
                        }
                        break;
                    }
                case "output":
                    {
                        switch (color)
                        {
                            case "red":
                                {
                                    count += bomb.HasPort("serial") ? 1 : 0;
                                    count += bomb.GetBatteries() == 1 ? 1 : 0;
                                    count += bomb.GetManyDigitsInSerial() > 2 ? -1 : 0;
                                    count += (RedInput ? 1 : 0) + (BlueInput ? 1 : 0) + (GreenInput ? 1 : 0) + (YellowInput ? 1 : 0) > 2 ? -1 : 0;
                                    RedOutput = count > 0;
                                    break;
                                }
                            case "yellow":
                                {
                                    count += bomb.HasAnyDuplicatedPort() ? 1 : 0;
                                    count += bomb.HasSerialChar('4') || bomb.HasSerialChar('8') ? 1 : 0;
                                    count += !bomb.HasSerialChar('2') ? -1 : 0;
                                    count += GreenInput || bomb.HasSerialChar('L') ? -1 : 0;
                                    YellowOutput = count > 0;
                                    break;
                                }
                            case "green":
                                {
                                    count += (RedInput ? 1 : 0) + (BlueInput ? 1 : 0) + (GreenInput ? 1 : 0) + (YellowInput ? 1 : 0) == 3 ? 1 : 0;
                                    count += bomb.GetPortsQuantity() == 3 ? 1 : 0;
                                    count += bomb.GetPortsQuantity() < 3 ? -1 : 0;
                                    count += bomb.GetSerialDigits().Count > 3 ? -1 : 0;
                                    GreenOutput = count > 0;
                                    break;
                                }
                            case "blue":
                                {
                                    count += RedInput && GreenInput && YellowInput && BlueInput ? 1 : 0;
                                    count += !RedOutput || !GreenOutput || !YellowOutput ? 1 : 0;
                                    count += !bomb.HasManyBatteries(2) ? -1 : 0;
                                    count += !bomb.HasPort("parallel") ? -1 : 0;
                                    BlueOutput = count > 0 || (!RedOutput && !YellowOutput && !GreenOutput);
                                    count += BlueOutput ? 1 : -1;
                                    break;
                                }
                        }
                        break;
                    }

            }
            return count > 0 ? color + " " : "";
        }
    }
}