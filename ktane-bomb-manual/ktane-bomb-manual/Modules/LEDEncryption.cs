namespace ktane_bomb_manual.Modules
{
    public class LEDEncryption : Module
    {
        public string StageColor;
        public string FirstLetter;
        public string SecondLetter;
        public string ThirdLetter;
        public string FourthLetter;

        public override string Command(Bomb bomb, string command)
        {
            foreach (var word in command.Split(' '))
            {
                if (InternalFunctions.IsColor(word)) StageColor = word;
                if (InternalFunctions.IsPhoneticLetter(word))
                {
                    if (string.IsNullOrWhiteSpace(FirstLetter)) { FirstLetter = word; continue; }
                    if (string.IsNullOrWhiteSpace(SecondLetter)) { SecondLetter = word; continue; }
                    if (string.IsNullOrWhiteSpace(ThirdLetter)) { ThirdLetter = word; continue; }
                    if (string.IsNullOrWhiteSpace(FourthLetter)) { FourthLetter = word; continue; }
                }
            }

            if (!string.IsNullOrWhiteSpace(StageColor) && !string.IsNullOrWhiteSpace(FirstLetter) && !string.IsNullOrWhiteSpace(SecondLetter) && !string.IsNullOrWhiteSpace(ThirdLetter) && !string.IsNullOrWhiteSpace(FourthLetter)) return Solve(bomb);
            else return "Cannot resolve, try again.";
        }

        public override string Solve(Bomb bomb)
        {
            var stageMultiplier = 0;
            switch (StageColor)
            {
                case "red": stageMultiplier = 2; break;
                case "green": stageMultiplier = 3; break;
                case "blue": stageMultiplier = 4; break;
                case "yellow": stageMultiplier = 5; break;
                case "purple": stageMultiplier = 6; break;
                case "orange": stageMultiplier = 7; break;
            }

            var firstLetterMultiplier = InternalFunctions.GetNumberFromPhoneticLetter(FirstLetter)-1;
            var secondLetterMultiplier = InternalFunctions.GetNumberFromPhoneticLetter(SecondLetter)-1;
            var thirdLetterMultiplier = InternalFunctions.GetNumberFromPhoneticLetter(ThirdLetter)-1;
            var fourthLetterMultiplier = InternalFunctions.GetNumberFromPhoneticLetter(FourthLetter)-1;
            Solved = true;
            if (stageMultiplier * firstLetterMultiplier % 26 == fourthLetterMultiplier) return "Press " + FirstLetter + ".";
            if (stageMultiplier * secondLetterMultiplier % 26 == thirdLetterMultiplier) return "Press " + SecondLetter + ".";
            if (stageMultiplier * thirdLetterMultiplier % 26 == secondLetterMultiplier) return "Press " + ThirdLetter + ".";
            if (stageMultiplier * fourthLetterMultiplier % 26 == firstLetterMultiplier) return "Press " + FourthLetter + ".";
            Solved = false;
            return "Cannot solve, try again.";
        }
    }
}
