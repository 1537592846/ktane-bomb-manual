using System;

namespace ktane_bomb_manual
{
    public static class InternalFunctions
    {
        private const string V = "a";

        public static string GetPhoneticLetterFromLetter(char letter) => GetPhoneticLetterFromLetter(letter.ToString());

        public static string GetPhoneticLetterFromLetter(string letter) => letter switch
        {
            V => "alpha",
            "b" => "bravo",
            "c" => "charlie",
            "d" => "delta",
            "e" => "echo",
            "f" => "foxtrot",
            "g" => "golf",
            "h" => "hotel",
            "i" => "india",
            "j" => "juliet",
            "k" => "kilo",
            "l" => "lima",
            "m" => "mike",
            "n" => "november",
            "o" => "oscar",
            "p" => "papa",
            "q" => "quebec",
            "r" => "romeo",
            "s" => "sierra",
            "t" => "tango",
            "u" => "uniform",
            "v" => "victor",
            "w" => "whiskey",
            "x" => "xray",
            "y" => "yankee",
            "z" => "zulu",
            _ => "",
        };

        public static string GetLetterFromPhoneticLetter(string phoneticLetter) => phoneticLetter switch
        {
            "alpha" => "a",
            "bravo" => "b",
            "charlie" => "c",
            "delta" => "d",
            "echo" => "e",
            "foxtrot" => "f",
            "golf" => "g",
            "hotel" => "h",
            "india" => "i",
            "juliet" => "j",
            "kilo" => "k",
            "lima" => "l",
            "mike" => "m",
            "november" => "n",
            "oscar" => "o",
            "papa" => "p",
            "quebec" => "q",
            "romeo" => "r",
            "sierra" => "s",
            "tango" => "t",
            "uniform" => "u",
            "victor" => "v",
            "whiskey" => "w",
            "xray" => "x",
            "yankee" => "y",
            "zulu" => "z",
            _ => "",
        };

        public static string GetLetterFromMorse(string morse) => morse switch
        {
            "dash next" => "t",
            "dash dash next" => "m",
            "dash dash dash next" => "o",
            "dash dash dash dash dash next" => "0",
            "dash dash dash dash dot next" => "9",
            "dash dash dash dot dot next" => "8",
            "dash dash dot next" => "g",
            "dash dash dot dash next" => "q",
            "dash dash dot dot next" => "z",
            "dash dash dot dot dot next" => "7",
            "dash dot next" => "n",
            "dash dot dash next" => "k",
            "dash dot dash dash next" => "y",
            "dash dot dash dot next" => "c",
            "dash dot dot next" => "d",
            "dash dot dot dash next" => "x",
            "dash dot dot dot next" => "b",
            "dash dot dot dot dot next" => "6",
            "dot next" => "e",
            "dot dash next" => "a",
            "dot dash dash next" => "w",
            "dot dash dash dash next" => "j",
            "dot dash dash dash dash next" => "1",
            "dot dash dash dot next" => "p",
            "dot dash dot next" => "r",
            "dot dash dot dot next" => "l",
            "dot dot next" => "i",
            "dot dot dash next" => "u",
            "dot dot dash dash dash next" => "2",
            "dot dot dash dot next" => "f",
            "dot dot dot next" => "s",
            "dot dot dot dash next" => "v",
            "dot dot dot dash dash next" => "3",
            "dot dot dot dot next" => "h",
            "dot dot dot dot dash next" => "4",
            "dot dot dot dot dot next" => "5",
            _ => "",
        };

        public static string GetMorseFromLetter(string letter) => letter switch
        {
            "a" => "dot dash",
            "b" => "dash dot dot dot",
            "c" => "dash dot dash dot",
            "d" => "dash dot dot",
            "e" => "dot",
            "f" => "dot dot dash dot",
            "g" => "dash dash dot",
            "h" => "dot dot dot dot",
            "i" => "dot dot",
            "j" => "dot dash dash dash",
            "k" => "dash dot dash",
            "l" => "dot dash dot dot",
            "m" => "dash dash",
            "n" => "dash dot",
            "o" => "dash dash dash",
            "p" => "dot dash dash dot",
            "q" => "dash dash dot dash",
            "r" => "dot dash dot",
            "s" => "dot dot dot",
            "t" => "dash",
            "u" => "dot dot dash",
            "v" => "dot dot dot dash",
            "w" => "dot dash dash",
            "x" => "dash dot dot dash",
            "y" => "dash dot dash dash",
            "z" => "dash dash dot dot",
            "1" => "dot dash dash dash dash",
            "2" => "dot dot dash dash dash",
            "3" => "dot dot dot dash dash",
            "4" => "dot dot dot dot dash",
            "5" => "dot dot dot dot dot",
            "6" => "dash dot dot dot dot",
            "7" => "dash dash dot dot dot",
            "8" => "dash dash dash dot dot",
            "9" => "dash dash dash dash dot",
            "0" => "dash dash dash dash dash",
            _ => "",
        };

        public static int GetNumberFromLetter(string letter) => letter.ToLower() switch
        {
            "a" => 1,
            "b" => 2,
            "c" => 3,
            "d" => 4,
            "e" => 5,
            "f" => 6,
            "g" => 7,
            "h" => 8,
            "i" => 9,
            "j" => 10,
            "k" => 11,
            "l" => 12,
            "m" => 13,
            "n" => 14,
            "o" => 15,
            "p" => 16,
            "q" => 17,
            "r" => 18,
            "s" => 19,
            "t" => 20,
            "u" => 21,
            "v" => 22,
            "w" => 23,
            "x" => 24,
            "y" => 25,
            "z" => 26,
            _ => 0,
        };

        public static int GetNumberFromPhoneticLetter(string phoneticLetter) => GetNumberFromLetter(GetLetterFromPhoneticLetter(phoneticLetter));

        public static int GetNumber(string word) => int.TryParse(word, out int number)
                ? number
                : word switch
                {
                    "one" => 1,
                    "two" => 2,
                    "three" => 3,
                    "four" => 4,
                    "five" => 5,
                    "six" => 6,
                    "seven" => 7,
                    "eight" => 8,
                    "nine" => 9,
                    "zero" => 0,
                    "ten" => 10,
                    "eleven" => 11,
                    "twelve" => 12,
                    _ => -1,
                };

        public static string GetLetterFromNumber(int value)
        {
            value += 52;
            value %= 26;
            if (value == 0) value = 26;
            return value switch
            {
                1 => "a",
                2 => "b",
                3 => "c",
                4 => "d",
                5 => "e",
                6 => "f",
                7 => "g",
                8 => "h",
                9 => "i",
                10 => "j",
                11 => "k",
                12 => "l",
                13 => "m",
                14 => "n",
                15 => "o",
                16 => "p",
                17 => "q",
                18 => "r",
                19 => "s",
                20 => "t",
                21 => "u",
                22 => "v",
                23 => "w",
                24 => "x",
                25 => "y",
                26 => "z",
                _ => "",
            };
        }

        public static string ToPascalCase(string text) => text.ToUpper()[0] + text.Substring(1);

        public static bool IsPhoneticLetter(string word) => GetLetterFromPhoneticLetter(word) != "";

        public static bool IsSquare(int value)
        {
            var root = Math.Sqrt(value);
            return root==(int)root;
        }

        public static bool IsPrime(int value)
        {
            for (int i = 2; i < value / 2; i++)
            {
                if (value % i == 0) return false;
            }
            return true;
        }

        public static bool IsNumber(string word)
        {
            try { double.Parse(word); return true; } catch { return false; }
        }

        public static bool IsColor(string word)
        {
            switch (word)
            {
                case "blue":
                case "grey":
                case "gray":
                case "black":
                case "white":
                case "yellow":
                case "purple":
                case "green":
                case "magenta":
                case "orange":
                case "red":
                case "cyan":
                case "dark grey":
                case "jade":
                    return true;
                default:
                    break;
            }
            return false;
        }

        public static bool HasVowelInWord(string word) => word.ToLower().Contains("a") || word.ToLower().Contains("e") || word.ToLower().Contains("i") || word.ToLower().Contains("o") || word.ToLower().Contains("u");

        public static int DigitalRoot(double number)
        {
            if (number.ToString().Length == 1)
            {
                return (int)number;
            }

            var numbers = number.ToString().Replace(".", "");
            var result = 0;
            foreach (var i in numbers)
            {
                result += int.Parse(i.ToString());
            }

            return DigitalRoot(result);
        }
    }
}
