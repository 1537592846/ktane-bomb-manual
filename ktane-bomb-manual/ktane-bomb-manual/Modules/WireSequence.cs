namespace ktane_bomb_manual.Modules
{
    public class WireSequences : Module
    {
        public int RedWiresQuantity;
        public int BlackWiresQuantity;
        public int BlueWiresQuantity;

        public override string Solve(Bomb bomb)
        {
            return "Use normal commands for this module.";
        }

        public override string Command(Bomb bomb, string command)
        {
            if (command.Contains("solved"))
            {
                Solved = true;
                return "Module solved.";
            }
            var wireColor = command.Replace("wire sequences ", "").Split(' ')[0];
            var wireConnection = command.Replace("wire sequences ", "").Split(' ')[1];

            return ShouldICutThisOne(wireColor, wireConnection);
        }

        public string ShouldICutThisOne(string color, string connection)
        {
            switch (color)
            {
                case "red":
                    {
                        RedWiresQuantity++;
                        switch (connection)
                        {
                            case "alpha": return RedWiresQuantity == 3 || RedWiresQuantity == 4 || RedWiresQuantity == 6 || RedWiresQuantity == 7 || RedWiresQuantity == 8 ? "Cut it." : "Leave it.";
                            case "bravo": return RedWiresQuantity == 2 || RedWiresQuantity == 5 || RedWiresQuantity == 8 || RedWiresQuantity == 9 ? "Cut it." : "Leave it.";
                            case "charlie": return RedWiresQuantity == 1 || RedWiresQuantity == 4 || RedWiresQuantity == 6 || RedWiresQuantity == 7 ? "Cut it." : "Leave it.";
                            default: return "";
                        }
                    }
                case "black":
                    {
                        BlackWiresQuantity++;
                        switch (connection)
                        {
                            case "alpha": return BlackWiresQuantity == 1 || BlackWiresQuantity == 2 || BlackWiresQuantity == 4 || BlackWiresQuantity == 7 || BlackWiresQuantity == 8 ? "Cut it." : "Leave it.";
                            case "bravo": return BlackWiresQuantity == 1 || BlackWiresQuantity == 3 || BlackWiresQuantity == 5 || BlackWiresQuantity == 6 || BlackWiresQuantity == 7 ? "Cut it." : "Leave it.";
                            case "charlie": return BlackWiresQuantity == 1 || BlackWiresQuantity == 2 || BlackWiresQuantity == 4 || BlackWiresQuantity == 5 || BlackWiresQuantity == 6 || BlackWiresQuantity == 9 ? "Cut it." : "Leave it.";
                            default: return "";
                        }
                    }
                case "blue":
                    {
                        BlueWiresQuantity++;
                        switch (connection)
                        {
                            case "alpha": return BlueWiresQuantity == 2 || BlueWiresQuantity == 4 || BlueWiresQuantity == 8 || BlueWiresQuantity == 9 ? "Cut it." : "Leave it.";
                            case "bravo": return BlueWiresQuantity == 1 || BlueWiresQuantity == 3 || BlueWiresQuantity == 5 || BlueWiresQuantity == 6 ? "Cut it." : "Leave it.";
                            case "charlie": return BlueWiresQuantity == 2 || BlueWiresQuantity == 6 || BlueWiresQuantity == 7 || BlueWiresQuantity == 8 ? "Cut it." : "Leave it.";
                            default: return "";
                        }
                    }
                default: return "";
            }
        }
    }
}