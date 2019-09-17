namespace ktane_bomb_manual.Modules
{
    public class RotaryPhone : Module
    {
        public int Number100;
        public int Number10;
        public int Number1;

        public override string Solve(Bomb bomb)
        {
            return "Numbers are " + Numbers().Trim() + ".";
        }

        public override string Command(Bomb bomb, string command)
        {
            var count = 0;
            foreach (var word in command.Split(' '))
            {
                if (InternalFunctions.GetNumber(word) != -1)
                {
                    switch (count)
                    {
                        case 0: Number100 += InternalFunctions.GetNumber(word); count++; break;
                        case 1: Number10 += InternalFunctions.GetNumber(word); count++; break;
                        case 2: Number1 += InternalFunctions.GetNumber(word); count++; break;
                    }
                }
                if (Number1 > 9)
                {
                    Number1 -= 10;
                    Number10 += 1;
                }

                if (Number10 > 9)
                {
                    Number10 -= 10;
                    Number100 += 1;
                }

                if (Number100 > 9)
                {
                    Number100 -= 10;
                }
            }

            return Solve(bomb);
        }

        public string Numbers()
        {
            return Number100 + " " + Number10 + " " + Number1 + " ";
        }
    }
}
