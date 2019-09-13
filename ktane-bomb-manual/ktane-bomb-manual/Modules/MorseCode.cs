namespace ktane_bomb_manual.Modules
{
    public class MorseCode : Module
    {
        public MorseCode()
        {

        }

        public string Sequence1;
        public string Sequence2;
        public string Sequence3;
        public string Sequence4;
        public string Sequence5;
        public string Sequence6;

        public override string Solve(Bomb bomb)
        {
            return "Frequence is 3 dot " + GetFrequence() + " megahertz.";
        }

        public string GetFrequence()
        {
            var word = Sequence1 + Sequence2 + Sequence3 + Sequence4 + Sequence5 + Sequence6 + Sequence1 + Sequence2 + Sequence3 + Sequence4 + Sequence5;

            if (word.Contains("shell")) return "5 0 5";
            if (word.Contains("halls")) return "5 1 5";
            if (word.Contains("slick")) return "5 2 2";
            if (word.Contains("trick")) return "5 3 2";
            if (word.Contains("boxes")) return "5 3 5";
            if (word.Contains("leaks")) return "5 4 2";
            if (word.Contains("strobe")) return "5 4 5";
            if (word.Contains("bistro")) return "5 5 2";
            if (word.Contains("flick")) return "5 5 5";
            if (word.Contains("bombs")) return "5 6 5";
            if (word.Contains("break")) return "5 7 2";
            if (word.Contains("brick")) return "5 7 5";
            if (word.Contains("steak")) return "5 8 2";
            if (word.Contains("sting")) return "5 9 2";
            if (word.Contains("vector")) return "5 9 5";
            if (word.Contains("beats")) return "6 0 0";
            return "";
        }

        public string GetLetterFromMorse(string morse)
        {
            switch (morse)
            {
                case "dot dash": return "A";
                case "dash dot dot dot": return "B";
                case "dash dot dash dot": return "C";
                case "dash dot dot": return "D";
                case "dot": return "E";
                case "dot dot dash dot": return "F";
                case "dash dash dot": return "G";
                case "dot dot dot dot": return "H";
                case "dot dot": return "I";
                case "dot dash dash dash": return "J";
                case "dash dot dash": return "K";
                case "dot dash dot dot": return "L";
                case "dash dash": return "M";
                case "dash dot": return "N";
                case "dash dash dash": return "O";
                case "dot dash dash dot": return "P";
                case "dash dash dot dash": return "Q";
                case "dot dash dot": return "R";
                case "dot dot dot": return "S";
                case "dash": return "T";
                case "dot dot dash": return "U";
                case "dot dot dot dash": return "V";
                case "dot dash dash": return "W";
                case "dash dot dot dash": return "X";
                case "dash dot dash dash": return "Y";
                case "dash dash dot dot": return "Z";
                case "dot dash dash dash dash": return "1";
                case "dot dot dash dash dash": return "2";
                case "dot dot dot dash dash": return "3";
                case "dot dot dot dot dash": return "4";
                case "dot dot dot dot dot": return "5";
                case "dash dot dot dot dot": return "6";
                case "dash dash dot dot dot": return "7";
                case "dash dash dash dot dot": return "8";
                case "dash dash dash dash dot": return "9";
                case "dash dash dash dash dash": return "0";
                default: return "";
            }
        }

        public void AddSequence(string sequence)
        {
            if (string.IsNullOrEmpty(Sequence1)) Sequence1 = sequence;
            if (string.IsNullOrEmpty(Sequence2)) Sequence2 = sequence;
            if (string.IsNullOrEmpty(Sequence3)) Sequence3 = sequence;
            if (string.IsNullOrEmpty(Sequence4)) Sequence4 = sequence;
            if (string.IsNullOrEmpty(Sequence5)) Sequence5 = sequence;
            if (string.IsNullOrEmpty(Sequence6)) Sequence6 = sequence;
        }
    }
}
