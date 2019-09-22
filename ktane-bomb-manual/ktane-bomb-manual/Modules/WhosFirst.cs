namespace ktane_bomb_manual.Modules
{
    public class WhosFirst : Module
    {
        public bool FirstEntry;

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

            while (command.Split(' ')[0] != "is") command = command.Replace(command.Split(' ')[0], "").Trim();

            return FirstEntry ? WhichPosition(command.Replace("is ", "")) : WhichWords(command.Replace("is ", ""));
        }

        public string WhichPosition(string word)
        {
            return "";
        }

        public string WhichWords(string word)
        {
            return "";
        }
    }
}
