using System.Collections.Generic;

namespace ktane_bomb_manual.Modules
{
    public class RememberMe :Module
    {
        List<int> Numbers = new List<int>();

        public override string Solve(Bomb bomb)
        {
            var text = "Listen carefully, for this is a big list of number. ";

            for (int i = 0;i < Numbers.Count;i = i + 3)
            {
                int? number1 = Numbers.Count-1 < i ? null : Numbers[i];
                int? number2 = Numbers.Count-1 < i+1 ? null : Numbers[i + 1];
                int? number3 = Numbers.Count-1 < i+2 ? null : Numbers[i + 2];

                if (number1.HasValue)
                    text += $"{number1} ";
                if (number2.HasValue)
                    text += $"{number2} ";
                if (number3.HasValue)
                    text += $"{number3} ";
                text = $"{text.Trim()}. ";
            }
            Solved = true;

            return text.Trim();
        }

        public override string Command(Bomb bomb, string command)
        {
            if (command.Contains("solve"))
                return Solve(bomb);

            foreach (var word in command.Split(' '))
            {
                if (InternalFunctions.IsNumber(word))
                {
                    Numbers.Add(InternalFunctions.GetNumber(word));
                    return $"Added number {Numbers[Numbers.Count - 1]}.";
                }
            }

            return "No number added.";
        }
    }
}