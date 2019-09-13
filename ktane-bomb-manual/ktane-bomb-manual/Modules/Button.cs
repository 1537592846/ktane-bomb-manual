namespace ktane_bomb_manual.Modules
{
    public class Button : Module
    {
        public Button(string color, string text)
        {
            Color = color;
            Text = text;
        }

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
                Solved = true;
                return WhatToDoWithTheStripe(bomb);
            }
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
                case "blue": return "Release when shown 4.";
                case "white": return "Release when shown 1.";
                case "yellow": return "Release when shown 5.";
                default: return "Release when shown 1.";
            }
        }

        public string TextPressOrHold(int op)
        {
            if (op == 1)
                return "Hold the button. What is the stripe color?";
            else
            {
                Solved = true;
                return "Just press it.";
            }
        }
    }
}
