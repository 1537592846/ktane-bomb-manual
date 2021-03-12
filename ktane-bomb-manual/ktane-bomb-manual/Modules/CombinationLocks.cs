
namespace ktane_bomb_manual.Modules
{
    public class CombinationLocks :Module
    {
        public string TwoFactor1, TwoFactor2;

        public override string Command(Bomb bomb, string command)
        {
            if (command == "combination locks")
                return Solve(bomb);

            foreach (var word in command.Split(' '))
            {
                if (InternalFunctions.IsNumber(word))
                    if (TwoFactor1.Length < 6)
                        TwoFactor1 += InternalFunctions.GetNumber(word);
                    else
                        TwoFactor2 += InternalFunctions.GetNumber(word);
            }

            if (TwoFactor1.Length != 6 || TwoFactor2.Length != 6)
                return "Could not get two factors.";

            return Solve(bomb);
        }

        public override string Solve(Bomb bomb)
        {
            int number1=0, number2 = 0, number3 = 0;

            //Number 1
            if (!string.IsNullOrEmpty(TwoFactor1))
                number1 += InternalFunctions.GetNumber(TwoFactor1[5].ToString());

            if (!string.IsNullOrEmpty(TwoFactor2))
                number1 += InternalFunctions.GetNumber(TwoFactor2[5].ToString());

            number1 += bomb.GetBatteries();

            //Number 2
            if (!string.IsNullOrEmpty(TwoFactor1))
                number2 += InternalFunctions.GetNumber(TwoFactor1[0].ToString());

            if (!string.IsNullOrEmpty(TwoFactor2))
                number2 += InternalFunctions.GetNumber(TwoFactor2[0].ToString());
            number2 += bomb.GetSolvedModules();

            //Number 3
            number3 += number1 + number2;
            Solved = true;
            return $"The numbers are {number1%20}, {number2 % 20}, {number3 % 20}.";
        }
    }
}