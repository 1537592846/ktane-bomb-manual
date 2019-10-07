using System.Collections.Generic;

namespace ktane_bomb_manual.Modules
{
    public class AdjacentLetters : Module
    {
        public AdjacentLetters()
        {
            Letters = new List<string>();
        }

        public List<string> Letters;

        public override string Solve(Bomb bomb)
        {
            if (Letters.Count != 12) return "Not enough letters.";

            Solved = true;
            var message = "Press: ";

            string[,] grid = new string[3, 4];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    grid[i, j] = Letters[i * 4 + j];
                }
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (PressLetter(grid, i, j))
                    {
                        var letter = InternalFunctions.GetPhoneticLetterFromLetter(grid[i, j]) + ". ";
                        message += letter.ToUpper()[0] + letter.Substring(1);
                    }
                }
            }

            return message.Trim();
        }

        public override string Command(Bomb bomb, string command)
        {
            foreach (var word in command.Split(' '))
            {
                if (InternalFunctions.GetLetterFromPhoneticLetter(word) != "")
                {
                    Letters.Add(InternalFunctions.GetLetterFromPhoneticLetter(word).ToLower());
                }
            }

            return Solve(bomb);
        }

        public bool PressLetter(string[,] grid, int row, int column)
        {
            if (row > 0) if (PressUpDown(grid[row, column], grid[row - 1, column])) return true;
            if (row < 2) if (PressUpDown(grid[row, column], grid[row + 1, column])) return true;
            if (column > 0) if (PressLeftRight(grid[row, column], grid[row, column - 1])) return true;
            if (column < 3) if (PressLeftRight(grid[row, column], grid[row, column + 1])) return true;
            return false;
        }

        public bool PressLeftRight(string letter, string letterToFind)
        {
            switch (letter)
            {
                case "a": return "gjmoy".Contains(letterToFind);
                case "b": return "iklrt".Contains(letterToFind);
                case "c": return "bhijw".Contains(letterToFind);
                case "d": return "ikopq".Contains(letterToFind);
                case "e": return "acgij".Contains(letterToFind);
                case "f": return "cervy".Contains(letterToFind);
                case "g": return "acfns".Contains(letterToFind);
                case "h": return "lrtux".Contains(letterToFind);
                case "i": return "dlowz".Contains(letterToFind);
                case "j": return "bqtuw".Contains(letterToFind);
                case "k": return "afpxy".Contains(letterToFind);
                case "l": return "gkptz".Contains(letterToFind);
                case "m": return "eilqt".Contains(letterToFind);
                case "n": return "pqrsv".Contains(letterToFind);
                case "o": return "hjluz".Contains(letterToFind);
                case "p": return "dmnox".Contains(letterToFind);
                case "q": return "ceopv".Contains(letterToFind);
                case "r": return "aegsu".Contains(letterToFind);
                case "s": return "abekq".Contains(letterToFind);
                case "t": return "gvxyz".Contains(letterToFind);
                case "u": return "fmvxz".Contains(letterToFind);
                case "v": return "dhmnw".Contains(letterToFind);
                case "w": return "dfhmn".Contains(letterToFind);
                case "x": return "bdfkw".Contains(letterToFind);
                case "y": return "bchsu".Contains(letterToFind);
                case "z": return "jnrsy".Contains(letterToFind);
            }
            return false;
        }

        public bool PressUpDown(string letter, string letterToFind)
        {
            switch (letter)
            {
                case "a": return "hkprw".Contains(letterToFind);
                case "b": return "cdfyz".Contains(letterToFind);
                case "c": return "demtu".Contains(letterToFind);
                case "d": return "cjtuw".Contains(letterToFind);
                case "e": return "ksuwz".Contains(letterToFind);
                case "f": return "agjpq".Contains(letterToFind);
                case "g": return "hoqyz".Contains(letterToFind);
                case "h": return "dkmps".Contains(letterToFind);
                case "i": return "efnuv".Contains(letterToFind);
                case "j": return "ehios".Contains(letterToFind);
                case "k": return "diorz".Contains(letterToFind);
                case "l": return "abrvx".Contains(letterToFind);
                case "m": return "bfpwx".Contains(letterToFind);
                case "n": return "afghl".Contains(letterToFind);
                case "o": return "iqstx".Contains(letterToFind);
                case "p": return "cfhkr".Contains(letterToFind);
                case "q": return "bdikn".Contains(letterToFind);
                case "r": return "bnoxy".Contains(letterToFind);
                case "s": return "gmvyz".Contains(letterToFind);
                case "t": return "cjlsu".Contains(letterToFind);
                case "u": return "bilny".Contains(letterToFind);
                case "v": return "aejqx".Contains(letterToFind);
                case "w": return "glqrt".Contains(letterToFind);
                case "x": return "ajnov".Contains(letterToFind);
                case "y": return "egmtw".Contains(letterToFind);
                case "z": return "clmpv".Contains(letterToFind);
            }
            return false;
        }
    }
}
