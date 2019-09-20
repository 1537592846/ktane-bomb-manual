using System.Collections.Generic;
using System.Linq;

namespace ktane_bomb_manual.Modules
{
    public class SquareButton : Module
    {
        public List<string> Colors = new List<string>() { "jade", "blue", "yellow", "dark grey", "red", "green", "white", "black", "purple", "cyan", "orange" };
        public string Color { get; set; }
        public string Text { get; set; }
        public string LED { get; set; }
        public bool BlinkingLED { get; set; }

        public override string Solve(Bomb bomb)
        {
            if (string.IsNullOrEmpty(LED))
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
                Solved = !solveReturn.Contains("led");
                return solveReturn;
            }
            if (command.Contains("led"))
            {
                LED = command.Replace("square button", "").Replace("led", "").Replace(" is ", "").Trim();
                BlinkingLED = command.Contains("blink") || command.Contains("flick");
                return Solve(bomb);
            }

            if (command.Contains("text"))
            {
                Text = command.Replace("square button", "").Replace("text", "").Replace(" is ", "").Trim();
                return "Text added.";
            }

            if (command.Contains("color"))
            {
                Color = command.Replace("square button", "").Replace("color", "").Replace(" is ", "").Trim();
                if (string.IsNullOrWhiteSpace(Color)) return "Color added.";
                if (!Colors.Contains(Color)) return "Color not added.";
                return "Color added.";
            }

            return "";
        }

        public string WhatToDoWithTheButton(Bomb bomb)
        {
            if (Color == "blue" && bomb.BatteryAA > bomb.BatteryD) return TextPressOrHold(1);
            if (Color == "blue" || Color == "yellow" || Text.Count() >= bomb.GetBiggestSerialDigit()) return TextPressOrHold(2);
            if (Color == "blue" || Color == "yellow" || Colors.Contains(Text)) return TextPressOrHold(1);
            if (string.IsNullOrWhiteSpace(Text)) return TextPressOrHold(1);
            if (Text != "dark grey" && Text.Count() > bomb.GetLitIndicators()) return TextPressOrHold(2);
            if (bomb.GetUnlitIndicators() <= 2 && bomb.HasSerialVowel()) return TextPressOrHold(2);
            return TextPressOrHold(1);
        }

        public string WhatToDoWithTheStripe(Bomb bomb)
        {
            switch (LED)
            {
                case "cyan": return BlinkingLED ? "Release when the seconds are a multiple of seven." : "Release when the seconds add up to seved.";
                case "orange": return BlinkingLED ? "Release when the seconds are prime or zero." : "Release when the seconds add up to three or thirteen.";
                default: return BlinkingLED ? "Release one second after the seconds are a multiple of four." : "Release when the seconds add up to five.";
            }
        }

        public string TextPressOrHold(int op)
        {
            if (op == 1)
                return "Hold the button. What is the LED color?";
            else
            {
                return "Just press it.";
            }
        }
    }
}
