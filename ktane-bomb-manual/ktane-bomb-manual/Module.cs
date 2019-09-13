namespace ktane_bomb_manual.Modules
{
    public abstract class Module
    {
        public bool Solved { get; set; }

        public abstract string Solve(Bomb bomb);
    }
}