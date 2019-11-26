
using System.Collections.Generic;

namespace ktane_bomb_manual.Modules
{
    public class SimonScreams : Module
    {
        public List<string> Colors;
        public List<string> ColorsFlashed;
        public int Stage;

        public SimonScreams()
        {
            Colors = new List<string>();
            ColorsFlashed = new List<string>();
            Stage = 0;
        }

        public override string Command(Bomb bomb, string command)
        {
            if (command.Contains("color"))
            {
                foreach (var word in command.Split(' '))
                {
                    if (InternalFunctions.IsColor(word))
                    {
                        Colors.Add(word);
                    }
                }

                return "Sequence saved.";
            }

            Stage++;
            ColorsFlashed.Clear();

            foreach (var word in command.Split(' '))
            {
                if (InternalFunctions.IsColor(word))
                {
                    ColorsFlashed.Add(word);
                }
            }

            return Solve(bomb);
        }

        public override string Solve(Bomb bomb)
        {
            var letter = GetLetter();

            if (Stage == 3) Solved = true;

            return ColorSequence(bomb, letter);
        }

        public string GetLetter()
        {
            var threeAdjacentColorsClockwise = false;
            var twoColorsAdjacent = false;
            var oneOutOfRedYellowBlue = false;
            var twoOppositeDidntFlash = false;
            var twoAdjacentColorsClockwise = false;
            var sequence = "";

            int indexFirstColor = -1;
            int indexSecondColor = -1;
            int indexThirdColor = -1;
            int indexFourthColor = -1;
            int indexFifthColor = -1;

            indexFirstColor = Colors.FindIndex(x => x == ColorsFlashed[0]);
            sequence += indexFirstColor;
            indexSecondColor = Colors.FindIndex(x => x == ColorsFlashed[1]);
            sequence += indexSecondColor;
            indexThirdColor = Colors.FindIndex(x => x == ColorsFlashed[2]);
            sequence += indexThirdColor;
            if (Stage == 2)
            {
                indexFourthColor = Colors.FindIndex(x => x == ColorsFlashed[3]);
                sequence += indexFourthColor;
            }
            if (Stage == 3)
            {
                indexFifthColor = Colors.FindIndex(x => x == ColorsFlashed[4]);
                sequence += indexFifthColor;
            }

            if (sequence.Contains("012") || sequence.Contains("123") || sequence.Contains("234") || sequence.Contains("345") || sequence.Contains("450") || sequence.Contains("501"))
                threeAdjacentColorsClockwise = true;

            if ((indexFirstColor == indexThirdColor) && (indexFirstColor == indexSecondColor + 1 || indexFirstColor == indexSecondColor - 1) ||
                (indexSecondColor == indexFourthColor) && (indexSecondColor == indexThirdColor + 1 || indexSecondColor == indexThirdColor - 1) ||
                (indexThirdColor == indexFifthColor) && (indexThirdColor == indexFourthColor + 1 || indexThirdColor == indexFourthColor - 1) ||
                (indexFourthColor == indexFirstColor) && (indexFourthColor == indexFifthColor + 1 || indexFourthColor == indexFifthColor - 1) ||
                (indexFifthColor == indexSecondColor) && (indexFifthColor == indexFirstColor + 1 || indexFifthColor == indexFirstColor - 1))
                twoColorsAdjacent = true;

            if ((ColorsFlashed.Contains("red") && !ColorsFlashed.Contains("yellow") && !ColorsFlashed.Contains("blue")) ||
                (!ColorsFlashed.Contains("red") && ColorsFlashed.Contains("yellow") && !ColorsFlashed.Contains("blue")) ||
                (!ColorsFlashed.Contains("red") && !ColorsFlashed.Contains("yellow") && ColorsFlashed.Contains("blue")))
                oneOutOfRedYellowBlue = true;

            if (!(sequence.Contains("0") || sequence.Contains("3")) ||
                !(sequence.Contains("1") || sequence.Contains("4")) ||
                !(sequence.Contains("2") || sequence.Contains("5")))
                twoOppositeDidntFlash = true;

            if (sequence.Contains("01") || sequence.Contains("12") || sequence.Contains("23") || sequence.Contains("34") || sequence.Contains("45") || sequence.Contains("50"))
                twoAdjacentColorsClockwise = true;

            switch (ColorsFlashed[Stage - 1])
            {
                case "red": return (threeAdjacentColorsClockwise ? "FFC" : twoColorsAdjacent ? "AHF" : oneOutOfRedYellowBlue ? "DED" : twoOppositeDidntFlash ? "HCE" : twoAdjacentColorsClockwise ? "CAH" : "EDA")[Stage - 1].ToString();
                case "orange": return (threeAdjacentColorsClockwise ? "CEH" : twoColorsAdjacent ? "DFC" : oneOutOfRedYellowBlue ? "ECF" : twoOppositeDidntFlash ? "ADA" : twoAdjacentColorsClockwise ? "FHD" : "HAE")[Stage - 1].ToString();
                case "yellow": return (threeAdjacentColorsClockwise ? "HAF" : twoColorsAdjacent ? "ECH" : oneOutOfRedYellowBlue ? "FHE" : twoOppositeDidntFlash ? "CFD" : twoAdjacentColorsClockwise ? "DDA" : "AEC")[Stage - 1].ToString();
                case "green": return (threeAdjacentColorsClockwise ? "ECD" : twoColorsAdjacent ? "CDE" : oneOutOfRedYellowBlue ? "HAA" : twoOppositeDidntFlash ? "DHH" : twoAdjacentColorsClockwise ? "AEC" : "FFF")[Stage - 1].ToString();
                case "blue": return (threeAdjacentColorsClockwise ? "DDE" : twoColorsAdjacent ? "FEA" : oneOutOfRedYellowBlue ? "AFH" : twoOppositeDidntFlash ? "EAC" : twoAdjacentColorsClockwise ? "HCF" : "CHD")[Stage - 1].ToString();
                case "purple": return (threeAdjacentColorsClockwise ? "AHA" : twoColorsAdjacent ? "HAD" : oneOutOfRedYellowBlue ? "CDC" : twoOppositeDidntFlash ? "FEF" : twoAdjacentColorsClockwise ? "EFE" : "DCH")[Stage - 1].ToString();
            }
            return "";
        }

        public string ColorSequence(Bomb bomb, string letter)
        {
            var result = "Press ";
            switch (letter)
            {
                case "A":
                    {
                        if (bomb.HasManyIndicators(3)) result += "yellow, then ";
                        if (bomb.HasManyPorts(3)) result += "purple, then ";
                        if (bomb.HasManyDigitsInSerial(3)) result += "orange, then ";
                        if (bomb.HasManyCharactersInSerial(3)) result += "green, then ";
                        if (bomb.HasManyBatteries(3)) result += "red, then ";
                        if (bomb.HasManyBatteriesHolders(3)) result += "blue, then ";
                        break;
                    }
                case "C":
                    {
                        if (bomb.HasManyIndicators(3)) result += "orange, then ";
                        if (bomb.HasManyPorts(3)) result += "yellow, then ";
                        if (bomb.HasManyDigitsInSerial(3)) result += "green, then ";
                        if (bomb.HasManyCharactersInSerial(3)) result += "blue, then ";
                        if (bomb.HasManyBatteries(3)) result += "purple, then ";
                        if (bomb.HasManyBatteriesHolders(3)) result += "red, then ";
                        break;
                    }
                case "D":
                    {
                        if (bomb.HasManyIndicators(3)) result += "green, then ";
                        if (bomb.HasManyPorts(3)) result += "red, then ";
                        if (bomb.HasManyDigitsInSerial(3)) result += "blue, then ";
                        if (bomb.HasManyCharactersInSerial(3)) result += "orange, then ";
                        if (bomb.HasManyBatteries(3)) result += "yellow, then ";
                        if (bomb.HasManyBatteriesHolders(3)) result += "purple, then ";
                        break;
                    }
                case "E":
                    {
                        if (bomb.HasManyIndicators(3)) result += "red, then ";
                        if (bomb.HasManyPorts(3)) result += "blue, then ";
                        if (bomb.HasManyDigitsInSerial(3)) result += "purple, then ";
                        if (bomb.HasManyCharactersInSerial(3)) result += "yellow, then ";
                        if (bomb.HasManyBatteries(3)) result += "orange, then ";
                        if (bomb.HasManyBatteriesHolders(3)) result += "green, then ";
                        break;
                    }
                case "F":
                    {
                        if (bomb.HasManyIndicators(3)) result += "blue, then ";
                        if (bomb.HasManyPorts(3)) result += "orange, then ";
                        if (bomb.HasManyDigitsInSerial(3)) result += "red, then ";
                        if (bomb.HasManyCharactersInSerial(3)) result += "purple, then ";
                        if (bomb.HasManyBatteries(3)) result += "green, then ";
                        if (bomb.HasManyBatteriesHolders(3)) result += "yellow, then ";
                        break;
                    }
                case "H":
                    {
                        if (bomb.HasManyIndicators(3)) result += "purple, then ";
                        if (bomb.HasManyPorts(3)) result += "green, then ";
                        if (bomb.HasManyDigitsInSerial(3)) result += "yellow, then ";
                        if (bomb.HasManyCharactersInSerial(3)) result += "red, then ";
                        if (bomb.HasManyBatteries(3)) result += "blue, then ";
                        if (bomb.HasManyBatteriesHolders(3)) result += "orange, then ";
                        break;
                    }
            }

            return result.Substring(0, result.Length - 7) + ".";
        }
    }
}
