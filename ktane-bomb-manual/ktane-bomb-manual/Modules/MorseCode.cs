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
            var word = GetLetterFromMorse(Sequence1) + GetLetterFromMorse(Sequence2) + GetLetterFromMorse(Sequence3) + GetLetterFromMorse(Sequence4) + GetLetterFromMorse(Sequence5) + GetLetterFromMorse(Sequence6) + GetLetterFromMorse(Sequence1) + GetLetterFromMorse(Sequence2) + GetLetterFromMorse(Sequence3) + GetLetterFromMorse(Sequence4) + GetLetterFromMorse(Sequence5);

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
                case "dot dash next": return "a";
                case "dash dot dot dot next": return "b";
                case "dash dot dash dot next": return "c";
                case "dash dot dot next": return "d";
                case "dot next": return "e";
                case "dot dot dash dot next": return "f";
                case "dash dash dot next": return "g";
                case "dot dot dot dot next": return "h";
                case "dot dot next": return "i";
                case "dot dash dash dash next": return "j";
                case "dash dot dash next": return "k";
                case "dot dash dot dot next": return "l";
                case "dash dash next": return "m";
                case "dash dot next": return "n";
                case "dash dash dash next": return "o";
                case "dot dash dash dot next": return "p";
                case "dash dash dot dash next": return "q";
                case "dot dash dot next": return "r";
                case "dot dot dot next": return "s";
                case "dash next": return "t";
                case "dot dot dash next": return "u";
                case "dot dot dot dash next": return "v";
                case "dot dash dash next": return "w";
                case "dash dot dot dash next": return "x";
                case "dash dot dash dash next": return "y";
                case "dash dash dot dot next": return "z";
                case "dot dash dash dash dash next": return "1";
                case "dot dot dash dash dash next": return "2";
                case "dot dot dot dash dash next": return "3";
                case "dot dot dot dot dash next": return "4";
                case "dot dot dot dot dot next": return "5";
                case "dash dot dot dot dot next": return "6";
                case "dash dash dot dot dot next": return "7";
                case "dash dash dash dot dot next": return "8";
                case "dash dash dash dash dot next": return "9";
                case "dash dash dash dash dash next": return "0";
                default: return "";
            }
        }

        public void AddSequence(string sequence)
        {
            if (string.IsNullOrEmpty(Sequence1)) { Sequence1 = sequence; return; }
            if (string.IsNullOrEmpty(Sequence2)) { Sequence2 = sequence; return; }
            if (string.IsNullOrEmpty(Sequence3)) { Sequence3 = sequence; return; }
            if (string.IsNullOrEmpty(Sequence4)) { Sequence4 = sequence; return; }
            if (string.IsNullOrEmpty(Sequence5)) { Sequence5 = sequence; return; }
            if (string.IsNullOrEmpty(Sequence6)) { Sequence6 = sequence; return; }
        }

        public void ResetSequences()
        {
            Sequence1 = "";
            Sequence2 = "";
            Sequence3 = "";
            Sequence4 = "";
            Sequence5 = "";
            Sequence6 = "";
        }

        public override string Command(Bomb bomb, string command)
        {
            throw new System.NotImplementedException();
        }
    }
}
