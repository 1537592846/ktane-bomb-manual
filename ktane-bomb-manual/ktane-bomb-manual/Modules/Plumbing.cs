namespace ktane_bomb_manual.Modules
{
    public class Plumbing : Module
    {
        public override string Solve(Bomb bomb)
        {
            var message = "Input: ";
            message += IsPipeActive(bomb, "red", "input");
            message += IsPipeActive(bomb, "yellow", "input");
            message += IsPipeActive(bomb, "green", "input");
            message += IsPipeActive(bomb, "blue", "input");
            if (message == "Input: ") message += "blue ";
            message = message.Trim() + ". Output: ";

            message += IsPipeActive(bomb, "red", "output");
            message += IsPipeActive(bomb, "blue", "output");
            message += IsPipeActive(bomb, "yellow", "output");
            message += IsPipeActive(bomb, "green", "output");
            message = message.Trim() + ".";

            return message;
        }

        public override string Command(Bomb bomb, string command)
        {
            throw new System.NotImplementedException();
        }

        public string IsPipeActive(Bomb bomb, string color, string type)
        {
            var count = 0;

            if (type == "input")
            {
                if (color == "red")
                {
                    count += bomb.HasSerialChar('1') ? 1 : 0;
                    count += bomb.GetPortsQuantity("rj") == 1 ? 1 : 0;
                    count += bomb.HasAnyDuplicatedPort() ? -1 : 0;
                    count += bomb.HasAnyDuplicatedSerialChar() ? -1 : 0;
                }
                if (color == "yellow")
                {
                    count += bomb.HasSerialChar('2') ? 1 : 0;
                    count += bomb.HasPort("rca") ? 1 : 0;
                    count += !bomb.HasAnyDuplicatedPort() ? -1 : 0;
                    count += bomb.HasSerialChar('1') || bomb.HasSerialChar('L') ? -1 : 0;
                }
                if (color == "green")
                {
                    count += bomb.GetSerialDigits().Count>=3 ? 1 : 0;
                    count += bomb.HasPort("dvi") ? 1 : 0;
                    count += IsPipeActive(bomb,"red","input")=="" ? -1 : 0;
                    count += IsPipeActive(bomb, "yellow", "input") == "" ? -1 : 0;
                }
                if (color == "blue")
                {
                    count += bomb.HasSerialChar('1') ? 1 : 0;
                    count += bomb.GetPortsQuantity("rj") == 1 ? 1 : 0;
                    count += bomb.HasAnyDuplicatedPort() ? -1 : 0;
                    count += bomb.HasAnyDuplicatedSerialChar() ? -1 : 0;
                }
            }
            else
            {

            }

            return count > 0 ? color+" " : "";
        }
    }
}
