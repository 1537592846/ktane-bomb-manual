using System.Linq;

namespace ktane_bomb_manual.Modules
{
    public class MorseCode : Module
    {
        public string Sequence1;
        public string Sequence2;
        public string Sequence3;
        public string Sequence4;
        public string Sequence5;
        public string Sequence6;

        public override string Solve(Bomb bomb)
        {
            if (string.IsNullOrEmpty(Sequence1) || string.IsNullOrEmpty(Sequence2) || string.IsNullOrEmpty(Sequence3) || string.IsNullOrEmpty(Sequence4) || string.IsNullOrEmpty(Sequence5)) return "Can't solve it yet.";
            Solved = true;
            return "Frequence is 3 dot " + GetFrequence() + " megahertz.";
        }

        public override string Command(Bomb bomb, string command)
        {
            if (command.Contains("reset"))
            {
                ResetSequences();
                return "Module reseted";
            }
            AddSequence(command);

            return GetFrequence() != "" ? Solve(bomb) : "Sequence added";
        }

        public string GetFrequence()
        {
            var word = InternalFunctions.GetLetterFromMorse(Sequence1) + InternalFunctions.GetLetterFromMorse(Sequence2) + InternalFunctions.GetLetterFromMorse(Sequence3) + InternalFunctions.GetLetterFromMorse(Sequence4) + InternalFunctions.GetLetterFromMorse(Sequence5) + InternalFunctions.GetLetterFromMorse(Sequence6) + InternalFunctions.GetLetterFromMorse(Sequence1) + InternalFunctions.GetLetterFromMorse(Sequence2) + InternalFunctions.GetLetterFromMorse(Sequence3) + InternalFunctions.GetLetterFromMorse(Sequence4) + InternalFunctions.GetLetterFromMorse(Sequence5);

            return word.Contains("shell")
                ? "5 0 5"
                : word.Contains("halls")
                ? "5 1 5"
                : word.Contains("slick")
                ? "5 2 2"
                : word.Contains("trick")
                ? "5 3 2"
                : word.Contains("boxes")
                ? "5 3 5"
                : word.Contains("leaks")
                ? "5 4 2"
                : word.Contains("strobe")
                ? "5 4 5"
                : word.Contains("bistro")
                ? "5 5 2"
                : word.Contains("flick")
                ? "5 5 5"
                : word.Contains("bombs")
                ? "5 6 5"
                : word.Contains("break")
                ? "5 7 2"
                : word.Contains("brick")
                ? "5 7 5"
                : word.Contains("steak")
                ? "5 8 2"
                : word.Contains("sting")
                ? "5 9 2"
                : word.Contains("vector")
                ? "5 9 5"
                : word.Contains("beats")
                ? "6 0 0"
                : "";
        }

        public void AddSequence(string sequence)
        {
            var sequenceList = sequence.Split(' ').Where(x => x == "dash" || x == "dot");
            var morse = "";
            foreach(var dashDot in sequenceList)
            {
                morse += dashDot + " ";
            }

            morse += "next";
            if (string.IsNullOrEmpty(Sequence1)) { Sequence1 = morse; return; }
            if (string.IsNullOrEmpty(Sequence2)) { Sequence2 = morse; return; }
            if (string.IsNullOrEmpty(Sequence3)) { Sequence3 = morse; return; }
            if (string.IsNullOrEmpty(Sequence4)) { Sequence4 = morse; return; }
            if (string.IsNullOrEmpty(Sequence5)) { Sequence5 = morse; return; }
            if (string.IsNullOrEmpty(Sequence6)) { Sequence6 = morse; return; }
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
    }
}
