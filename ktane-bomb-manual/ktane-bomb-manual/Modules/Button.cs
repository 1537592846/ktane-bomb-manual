using System.Linq;

namespace ktane_bomb_manual.Modules
{
    public class Button : Module
    {
        public string Color { get; set; }
        public string Text { get; set; }
        public string Stripe { get; set; }

        public override string Solve(Bomb bomb)
        {
            if (string.IsNullOrEmpty(Stripe))
            {
                return WhatToDoWithTheButton(bomb);
            }
            else
            {
                return WhatToDoWithTheStripe(bomb);
            }
        }

        public override string Command(Bomb bomb, string command)
        {
            if (command.Contains("solve"))
            {
                var solveReturn = Solve(bomb);
                Solved = !solveReturn.Contains("stripe");
                return solveReturn;
            }
            if (command.Contains("stripe"))
            {
                if (command.Contains("blue")) Stripe = "blue";
                if (command.Contains("white")) Stripe = "white";
                if (command.Contains("yellow")) Stripe = "yellow";
                if (string.IsNullOrEmpty(Stripe)) Stripe = "red";
                return Solve(bomb);
            }

            foreach (var word in command.Split(' ').Where(x => x == "blue" || x == "white" || x == "red" || x == "yellow" || x == "hold" || x == "detonate" || x == "abort"))
            {
                if (word == "hold" || word == "detonate" || word == "abort")
                {
                    Text = word;
                }
                else
                {
                   Color  = word;
                }
            }
            return "";
        }

        public string WhatToDoWithTheButton(Bomb bomb)
        {
            if (Color == "blue" && Text == "abort") return TextPressOrHold(1);
            if (bomb.HasManyBatteries(2) && Text == "detonate") return TextPressOrHold(2);
            if (Color == "white" && bomb.HasLitIndicator("car")) return TextPressOrHold(1);
            if (bomb.HasManyBatteries(3) && bomb.HasLitIndicator("frk")) return TextPressOrHold(2);
            if (Color == "yellow") return TextPressOrHold(1);
            if (Color == "red" && Text == "hold") return TextPressOrHold(2);
            return TextPressOrHold(1);
        }

        public string WhatToDoWithTheStripe(Bomb bomb)
        {
            switch (Stripe)
            {
                case "blue": return "Release when shown four.";
                case "white": return "Release when shown one.";
                case "yellow": return "Release when shown five.";
                default: return "Release when shown one.";
            }
        }

        public string TextPressOrHold(int op)
        {
            if (op == 1)
                return "Hold the button. What is the stripe color?";
            else
            {
                return "Just press it.";
            }
        }
    }
}
