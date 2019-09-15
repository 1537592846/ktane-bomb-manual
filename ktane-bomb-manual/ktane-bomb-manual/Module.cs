namespace ktane_bomb_manual.Modules
{
    public abstract class Module
    {
        public bool Solved { get; set; }

        public string ModuleName { get { return GetType().Name; } }

        public abstract string Solve(Bomb bomb);

        public abstract string Command(Bomb bomb, string command);
    }
}