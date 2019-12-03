using System.Collections.Generic;

namespace ktane_bomb_manual.Modules
{
    public class Screw : Module
    {
        public List<string> Colors;
        public List<string> Buttons;

        public Screw()
        {
            Colors = new List<string>();
            Buttons = new List<string>();
        }

        public override string Command(Bomb bomb, string command)
        {
            foreach (var word in command.Split(' '))
            {
                if (InternalFunctions.IsColor(word)) Colors.Add(word);
                if (InternalFunctions.GetLetterFromPhoneticLetter(word) != "") Buttons.Add(word);
            }

            if (Colors.Count != 6) return "Not enough colors.";

            return Solve(bomb);
        }

        public override string Solve(Bomb bomb)
        {
            var firstStageHole = bomb.GetBatteries() + bomb.GetUnlitIndicators() - 1;
            var secondStageHole = bomb.GetSerialLastNumberDigit() + bomb.GetLitIndicators() - 1;
            var thirdStageHole = bomb.GetPortsQuantity() + bomb.GetBatteriesHolders() - 1;

            if (firstStageHole > 6) firstStageHole = firstStageHole % 6;
            if (firstStageHole == -1) firstStageHole = 0;

            if (secondStageHole > 6) secondStageHole = secondStageHole % 6;
            if (secondStageHole == -1) secondStageHole = 0;
            if (secondStageHole == firstStageHole) secondStageHole++;
            if (secondStageHole > 6) secondStageHole = secondStageHole % 6;
            if (secondStageHole == -1) secondStageHole = 0;

            if (thirdStageHole > 6) thirdStageHole = thirdStageHole % 6;
            if (thirdStageHole == -1) thirdStageHole = 0;
            if (thirdStageHole == secondStageHole) thirdStageHole++;
            if (thirdStageHole > 6) thirdStageHole = thirdStageHole % 6;
            if (thirdStageHole == -1) thirdStageHole = 0;

            var colorFirstStage = Colors[firstStageHole];
            var colorSecondStage = Colors[secondStageHole];
            var colorThirdStage = Colors[thirdStageHole];

            var result = "First color " + colorFirstStage + ", press " + GetButton(bomb, colorFirstStage, firstStageHole);
            result += "Second color " + colorSecondStage + ", press " + GetButton(bomb, colorSecondStage, secondStageHole);
            result += "Third color " + colorThirdStage + ", press " + GetButton(bomb, colorThirdStage, thirdStageHole);

            Solved = true;

            return result.Trim();
        }

        public string GetButton(Bomb bomb, string color, int index)
        {
            switch (color)
            {
                case "red":
                case "yellow":
                case "green":
                    {
                        if (index < 3)
                        {
                            if (index % 3 == bomb.GetBatteriesHolders() - 1) return "fourth. ";
                            if (Buttons[0] == "alpha" || Buttons[2] == "alpha") return "charlie. ";
                            if (bomb.HasPort("clr") || bomb.HasPort("frk") || bomb.HasPort("trn")) return "third. ";
                            if (Colors[0] == "blue" || Colors[1] == "blue" || Colors[2] == "blue") return "first. ";
                            return "bravo. ";
                        }
                        else
                        {
                            if (index % 3 == bomb.GetPortsQuantity() - 1) return "second. ";
                            if (index % 3 == bomb.GetBatteries() - 1) return "delta. ";
                            if (Colors[(index + 3) % 3] != "white") return "alpha. ";
                            if ((Colors[3] != "magenta" && index != 3) || (Colors[4] != "magenta" && index != 4) || (Colors[5] != "magenta" && index != 5)) return "charlie. ";
                            return "first. ";
                        }
                    }
                case "blue":
                case "magenta":
                case "white":
                    {
                        if (index < 3)
                        {
                            if (index % 3 == bomb.GetPortTypesQuantity() - 1) return "delta. ";
                            if (Buttons[1] == "charle" || Buttons[3] == "charle") return "bravo. ";
                            if (bomb.HasPort("car") || bomb.HasPort("frq") || bomb.HasPort("snd")) return "fourth. ";
                            if (Colors[0] == "red" || Colors[1] == "red" || Colors[2] == "red") return "second. ";
                            return "alpha. ";
                        }
                        else
                        {
                            if (index % 3 == bomb.GetPortPlatesQuantity() - 1) return "second. ";
                            if (index % 3 == bomb.GetBatteries() - 1) return "delta. ";
                            if (Colors[(index + 3) % 3] != "white") return "alpha. ";
                            if ((Colors[3] != "magenta" && index != 3) || (Colors[4] != "magenta" && index != 4) || (Colors[5] != "magenta" && index != 5)) return "charlie. ";
                            return "first. ";
                        }
                    }
            }
            return "";
        }
    }
}
