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
            if (thirdStageHole == firstStageHole || thirdStageHole == secondStageHole) thirdStageHole++;
            if (thirdStageHole > 6) thirdStageHole = thirdStageHole % 6;
            if (thirdStageHole == -1) thirdStageHole = 0;
            if (thirdStageHole == firstStageHole || thirdStageHole == secondStageHole) thirdStageHole++;
            if (thirdStageHole > 6) thirdStageHole = thirdStageHole % 6;
            if (thirdStageHole == -1) thirdStageHole = 0;

            var colorFirstStage = Colors[firstStageHole];
            var colorSecondStage = Colors[secondStageHole];
            var colorThirdStage = Colors[thirdStageHole];

            var result = "First color " + colorFirstStage + ", press ";

            switch (colorFirstStage)
            {
                case "red":
                case "yellow":
                case "green":
                    {
                        if (firstStageHole < 3)
                        {
                            if (firstStageHole % 3 == bomb.GetBatteriesHolders() - 1) { result += "fourth. "; break; }
                            if (Buttons[0] == "alpha" || Buttons[2] == "alpha") { result += "charlie. "; break; }
                            if (bomb.HasPort("clr") || bomb.HasPort("frk") || bomb.HasPort("trn")) { result += "third. "; break; }
                            if (Colors[0] == "blue" || Colors[1] == "blue" || Colors[2] == "blue") { result += "first. "; break; }
                            result += "bravo. "; break;
                        }
                        else
                        {
                            if (firstStageHole % 3 == bomb.GetPortsQuantity() - 1) { result += "second. "; break; }
                            if (firstStageHole % 3 == bomb.GetBatteries() - 1) { result += "delta. "; break; }
                            if (Colors[(firstStageHole + 3) % 3] != "white") { result += "alpha. "; break; }
                            if ((Colors[3] != "magenta" && firstStageHole != 3) || (Colors[4] != "magenta" && firstStageHole != 4) || (Colors[5] != "magenta" && firstStageHole != 5)) { result += "charlie. "; break; }
                            result += "first. "; break;
                        }
                    }
                case "blue":
                case "magenta":
                case "white":
                    {
                        if (firstStageHole < 3)
                        {
                            if (firstStageHole % 3 == bomb.GetPortsQuantity() - 1) { result += "delta. "; break; }
                            if (Buttons[1] == "charle" || Buttons[3] == "charle") { result += "bravo. "; break; }
                            if (bomb.HasPort("car") || bomb.HasPort("frq") || bomb.HasPort("snd")) { result += "fourth. "; break; }
                            if (Colors[0] == "red" || Colors[1] == "red" || Colors[2] == "red") { result += "second. "; break; }
                            result += "alpha. "; break;
                        }
                        else
                        {
                            if (firstStageHole % 3 == bomb.GetPortsPlatesQuantity() - 1) { result += "second. "; break; }
                            if (firstStageHole % 3 == bomb.GetBatteries() - 1) { result += "delta. "; break; }
                            if (Colors[(firstStageHole + 3) % 3] != "white") { result += "alpha. "; break; }
                            if ((Colors[3] != "magenta" && firstStageHole != 3) || (Colors[4] != "magenta" && firstStageHole != 4) || (Colors[5] != "magenta" && firstStageHole != 5)) { result += "charlie. "; break; }
                            result += "first. "; break;
                        }
                    }
            }

            return result;
        }
    }
}
