using System.Collections.Generic;

namespace ktane_bomb_manual.Modules
{
    public class TextField :Module
    {
        private string Letter;
        private Dictionary<string, string> alphaPositions = new Dictionary<string, string> { { "FB01", "Row 1 column 4." }, { "DC52", "Row 2 column 1." }, { "965A", "Row 3 column 3, row 3 column 4." }, { "7F67", "Row 1 column 1, row 2 column 1, row 3 column 1, row 3 column 4." }, { "1459", "Row 1 column 2." }, { "A0C1", "Row 1 column 4." }, { "BBFF", "Row 1 column 2, row 3 column 4." }, { "AA12", "Row 1 column 3, row 2 column 4." } };
        private Dictionary<string, string> bravoPositions = new Dictionary<string, string> { { "FB01", "Row 2 column 1, row 3 column 1, row 3 column 2, row 3 column 3." }, { "DC52", "Row 1 column 2, row 3 column 1, row 3 column 3." }, { "965A", "Row 1 column 2, row 2 column 2." }, { "7F67", "Row 1 column 4, row 2 column 3." }, { "1459", "Row 1 column 1, row 1 column 3, row 1 column 4." }, { "A0C1", "Row 2 column 3, row 3 column 3." }, { "BBFF", "Row 1 column 3, row 2 column 3, row 3 column 3." }, { "AA12", "Row 1 column 1, row 1 column 4, row 3 column 1." } };
        private Dictionary<string, string> charliePositions = new Dictionary<string, string> { { "FB01", "Row 1 column 2, row 3 column 4." }, { "DC52", "Row 1 column 1, row 2 column 4." }, { "965A", "Row 1 column 1, row 3 column 2." }, { "7F67", "Row 1 column 3, row 2 column 2, row 2 column 4." }, { "1459", "Row 2 column 1, row 3 column 3." }, { "A0C1", "Row 1 column 2, row 2 column 1, row 3 column 4." }, { "BBFF", "Row 3 column 1." }, { "AA12", "Row 3 column 2, row 3 column 4." } };
        private Dictionary<string, string> deltaPositions = new Dictionary<string, string> { { "FB01", "Row 1 column 1." }, { "DC52", "Row 1 column 3, row 2 column 3, row 3 column 4." }, { "965A", "Row 3 column 1." }, { "7F67", "Row 1 column 2." }, { "1459", "Row 2 column 2, row 2 column 4, row 3 column 1." }, { "A0C1", "Row 2 column 4." }, { "BBFF", "Row 1 column 1, row 2 column 1." }, { "AA12", "Row 2 column 2." } };
        private Dictionary<string, string> echoPositions = new Dictionary<string, string> { { "FB01", "Row 2 column 2." }, { "DC52", "Row 1 column 4, row 3 column 2." }, { "965A", "Row 1 column 3, row 2 column 1, row 2 column 4." }, { "7F67", "Row 3 column 2." }, { "1459", "Row 3 column 4." }, { "A0C1", "Row 1 column 1." }, { "BBFF", "Row 2 column 4, row 3 column 2." }, { "AA12", "Row 1 column 2, row 2 column 1, row 3 column 3." } };
        private Dictionary<string, string> foxtrotPositions = new Dictionary<string, string> { { "FB01", "Row 1 column 3, row 2 column 3, row 2 column 4." }, { "DC52", "Row 2 column 2." }, { "965A", "Row 1 column 4, row 2 column 3." }, { "7F67", "Row 3 column 3." }, { "1459", "Row 2 column 3, row 3 column 2." }, { "A0C1", "Row 1 column 3, row 2 column 2, row 3 column 1, row 3 column 2." }, { "BBFF", "Row 1 column 4, row 2 column 2." }, { "AA12", "Row 2 column 3." } };

        public override string Command(Bomb bomb, string command)
        {
            foreach (var word in command.Split(' '))
                if (InternalFunctions.IsPhoneticLetter(word))
                    Letter = word;

            if (string.IsNullOrEmpty(Letter))
                return "Cannot solve without the letter.";
            return Solve(bomb);
        }

        public override string Solve(Bomb bomb)
        {
            Solved = true;
            return GetPositions()[GetCode(bomb)];
        }

        public Dictionary<string, string> GetPositions()
        {
            switch (Letter)
            {
                case "alpha":
                    return alphaPositions;
                case "bravo":
                    return bravoPositions;
                case "charlie":
                    return charliePositions;
                case "delta":
                    return deltaPositions;
                case "echo":
                    return echoPositions;
            }
            return foxtrotPositions;
        }

        public string GetCode(Bomb bomb)
        {
            switch (Letter)
            {
                case "alpha":
                    {
                        if (bomb.HasLitIndicator("CLR"))
                            return "1459";
                        if (bomb.HasManyBatteries(3))
                            return "BBFF";
                        if (bomb.HasExactlyBatteries(1))
                            return "7F67";
                        if (bomb.HasLitIndicator("FRK"))
                            return "DC52";
                        return "AOC1";
                    }
                case "bravo":
                    {
                        if (bomb.HasExactlyBatteries(0))
                            return "965A";
                        if (bomb.HasSerialLastDigitOdd())
                            return "1459";
                        if (!bomb.HasPort("serial"))
                            return "DC52";
                        if (bomb.HasLitIndicator("TRN"))
                            return "AOC1";
                        return "7F67";
                    }
                case "charlie":
                    {
                        if (bomb.HasPort("dvi"))
                            return "AA12";
                        if (bomb.HasExactlyBatteries(2))
                            return "FB01";
                        if (!bomb.HasSerialVowel())
                            return "DC52";
                        if (bomb.HasLitIndicator("CAR"))
                            return "1459";
                        return "7F67";
                    }
                case "delta":
                    {
                        if (bomb.HasPort("parallel"))
                            return "FB01";
                        if (!bomb.HasManyBatteries(2))
                            return "AA12";
                        if (bomb.HasLitIndicator("SIG"))
                            return "BBFF";
                        if (!bomb.HasPort("ps2"))
                            return "965A";
                        return "1459";
                    }
                case "echo":
                    {
                        if (!bomb.HasManyBatteries(3))
                            return "7F67";
                        if (!bomb.HasPort("stereo"))
                            return "AA12";
                        if (bomb.HasLitIndicator("BOB"))
                            return "AOC1";
                        if (bomb.HasPort("rj45"))
                            return "BBFF";
                        return "DC52";
                    }
            }
            if (!bomb.HasPort("serial"))
                return "DC52";
            if (bomb.HasSerialVowel())
                return "AOC1";
            if (bomb.HasLitIndicator("IND"))
                return "1459";
            if (bomb.HasSerialLastDigitEven())
                return "FB01";
            return "AA12";
        }
    }
}