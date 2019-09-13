namespace ktane_bomb_manual
{
    public static class InternalFunctions
    {
        public static string GetLetterFromMorse(string morse)
        {
            switch (morse)
            {
                case "dash next": return "t";
                case "dash dash next": return "m";
                case "dash dash dash next": return "o";
                case "dash dash dash dash dash next": return "0";
                case "dash dash dash dash dot next": return "9";
                case "dash dash dash dot dot next": return "8";
                case "dash dash dot next": return "g";
                case "dash dash dot dash next": return "q";
                case "dash dash dot dot next": return "z";
                case "dash dash dot dot dot next": return "7";
                case "dash dot next": return "n";
                case "dash dot dash next": return "k";
                case "dash dot dash dash next": return "y";
                case "dash dot dash dot next": return "c";
                case "dash dot dot next": return "d";
                case "dash dot dot dash next": return "x";
                case "dash dot dot dot next": return "b";
                case "dash dot dot dot dot next": return "6";
                case "dot next": return "e";
                case "dot dash next": return "a";
                case "dot dash dash next": return "w";
                case "dot dash dash dash next": return "j";
                case "dot dash dash dash dash next": return "1";
                case "dot dash dash dot next": return "p";
                case "dot dash dot next": return "r";
                case "dot dash dot dot next": return "l";
                case "dot dot next": return "i";
                case "dot dot dash next": return "u";
                case "dot dot dash dash dash next": return "2";
                case "dot dot dash dot next": return "f";
                case "dot dot dot next": return "s";
                case "dot dot dot dash next": return "v";
                case "dot dot dot dash dash next": return "3";
                case "dot dot dot dot next": return "h";
                case "dot dot dot dot dash next": return "4";
                case "dot dot dot dot dot next": return "5";
                default: return "";
            }
        }

        public static string GetMorseFromLetter(string letter)
        {
            switch (letter)
            {
                case "a": return "dot dash";
                case "b": return "dash dot dot dot";
                case "c": return "dash dot dash dot";
                case "d": return "dash dot dot";
                case "e": return "dot";
                case "f": return "dot dot dash dot";
                case "g": return "dash dash dot";
                case "h": return "dot dot dot dot";
                case "i": return "dot dot";
                case "j": return "dot dash dash dash";
                case "k": return "dash dot dash";
                case "l": return "dot dash dot dot";
                case "m": return "dash dash";
                case "n": return "dash dot";
                case "o": return "dash dash dash";
                case "p": return "dot dash dash dot";
                case "q": return "dash dash dot dash";
                case "r": return "dot dash dot";
                case "s": return "dot dot dot";
                case "t": return "dash";
                case "u": return "dot dot dash";
                case "v": return "dot dot dot dash";
                case "w": return "dot dash dash";
                case "x": return "dash dot dot dash";
                case "y": return "dash dot dash dash";
                case "z": return "dash dash dot dot";
                case "1": return "dot dash dash dash dash";
                case "2": return "dot dot dash dash dash";
                case "3": return "dot dot dot dash dash";
                case "4": return "dot dot dot dot dash";
                case "5": return "dot dot dot dot dot";
                case "6": return "dash dot dot dot dot";
                case "7": return "dash dash dot dot dot";
                case "8": return "dash dash dash dot dot";
                case "9": return "dash dash dash dash dot";
                case "0": return "dash dash dash dash dash";
                default: return "";
            }
        }

        public static int GetNumberFromLetter(string letter)
        {
            switch (letter)
            {
                case "a": return 1;
                case "b": return 2;
                case "c": return 3;
                case "d": return 4;
                case "e": return 5;
                case "f": return 6;
                case "g": return 7;
                case "h": return 8;
                case "i": return 9;
                case "j": return 10;
                case "k": return 11;
                case "l": return 12;
                case "m": return 13;
                case "n": return 14;
                case "o": return 15;
                case "p": return 16;
                case "q": return 17;
                case "r": return 18;
                case "s": return 19;
                case "t": return 20;
                case "u": return 21;
                case "v": return 22;
                case "w": return 23;
                case "x": return 24;
                case "y": return 25;
                case "z": return 26;
                default: return 0;
            }
        }

        public static string GetLetterFromNumber(int value)
        {
            value += 52;
            value = value % 26;
            if (value == 0) value = 26;
            switch (value)
            {
                case 1: return "a";
                case 2: return "b";
                case 3: return "c";
                case 4: return "d";
                case 5: return "e";
                case 6: return "f";
                case 7: return "g";
                case 8: return "h";
                case 9: return "i";
                case 10: return "j";
                case 11: return "k";
                case 12: return "l";
                case 13: return "m";
                case 14: return "n";
                case 15: return "o";
                case 16: return "p";
                case 17: return "q";
                case 18: return "r";
                case 19: return "s";
                case 20: return "t";
                case 21: return "u";
                case 22: return "v";
                case 23: return "w";
                case 24: return "x";
                case 25: return "y";
                case 26: return "z";
                default: return "";
            }
        }

        public static bool IsSquare(int value)
        {
            for (int i = 1; i * i <= value; i++)
            {
                if (i * i == value) return true;
            }
            return false;
        }

        public static bool IsPrime(int value)
        {
            for (int i = 2; i < value / 2; i++)
            {
                if (value % i == 0) return false;
            }
            return true;
        }
    }
}
