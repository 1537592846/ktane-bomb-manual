namespace ktane_bomb_manual.Modules
{
    public class WhosOnFirst : Module
    {
        public bool FirstEntry;

        public override string Solve(Bomb bomb)
        {
            return "Use normal commands for this module.";
        }

        public override string Command(Bomb bomb, string command)
        {
            if (command.Contains("solved"))
            {
                Solved = true;
                return "Module solved.";
            }

            command = command.Replace("whos on first", "").Trim();
            FirstEntry = !FirstEntry;
            return FirstEntry ? WhichPosition(command.Replace("is ", "")) : "Press the first one to appear: "+WhichWords(command.Replace("is ", ""));
        }

        public string WhichPosition(string word)
        {
            switch (word)
            {
                case "ur": return "Top left tile.";
                case "first":
                case "okay":
                case "c": return "Top right tile.";
                case "yes":
                case "nothing":
                case "led":
                case "they are": return "Middle left tile.";
                case "blank":
                case "read":
                case "red":
                case "you":
                case "your":
                case "you're":
                case "their": return "Middle right tile.";
                case "":
                case "empty":
                case "reed":
                case "leed":
                case "they're": return "Bottom left tile.";
                case "display":
                case "says":
                case "no":
                case "lead":
                case "hold on":
                case "you are":
                case "there":
                case "see":
                case "cee": return "Bottom right tile.";
                default: return "";
            }
        }

        public string WhichWords(string word)
        {
            switch (word)
            {
                case "ready": return "Yes. Okay. What. Middle. Left. Press. Right. Blank. Ready. No. First. Uhhh. Nothing. Wait.";
                case "first": return "Left. Okay. Yes. Middle. No. Right. Nothing. Uhhh. Wait. Ready. Blank. What. Press. First.";
                case "no": return "Blank. Uhhh. Wait. First. What. Ready. Right. Yes. Nothing. Left. Press. Okay. No. Middle.";
                case "blank": return "Wait. Right. Okay. Middle. Blank. Press. Ready. Nothing. No. What. Left. Uhhh. Yes. First.";
                case "nothing": return "Uhhh. Right. Okay. Middle. Yes. Blank. No. Press. Left. What. Wait. First. Nothing. Ready.";
                case "yes": return "Okay. Right. Uhhh. Middle. First. What. Press. Ready. Nothing. Yes. Left. Blank. No. Wait.";
                case "what": return "Uhhh. What. Left. Nothing. Ready. Blank. Middle. No. Okay. First. Wait. Yes. Press. Right.";
                case "uhhh": return "Ready. Nothing. Left. What. Okay. Yes. Right. No. Press. Blank. Uhhh. Middle. Wait. First.";
                case "left": return "Right. Left. First. No. Middle. Yes. Blank. What. Uhhh. Wait. Press. Ready. Okay. Nothing.";
                case "right": return "Yes. Nothing. Ready. Press. No. Wait. What. Right. Middle. Left. Uhhh. Blank. Okay. First.";
                case "middle": return "Blank. Ready. Okay. What. Nothing. Press. No. Wait. Left. Middle. Right. First. Uhhh. Yes.";
                case "okay": return "Middle. No. First. Yes. Uhhh. Nothing. Wait. Okay. Left. Ready. Blank. Press. What. Right.";
                case "wait": return "Uhhh. No. Blank. Okay. Yes. Left. First. Press. What. Wait. Nothing. Ready. Right. Middle.";
                case "press": return "Right. Middle. Yes. Ready. Press. Okay. Nothing. Uhhh. Blank. Left. First. What. No. Wait.";
                case "you": return "Sure. You are. Your. You're. Next. Uh huh. Ur. Hold. What?. You. Uh uh. Like. Done. U.";
                case "you are": return "Your. Next. Like. Uh huh. What?. Done. Uh uh. Hold. You. U. You're. Sure. Ur. You are.";
                case "your": return "Uh uh. You are. Uh huh. Your. Next. Ur. Sure. U. You're. You. What?. Hold. Like. Done.";
                case "you're": return "You. You're. Ur. Next. Uh uh. You are. U. Your. What?. Uh huh. Sure. Done. Like. Hold.";
                case "ur": return "Done. U. Ur. Uh huh. What?. Sure. Your. Hold. You're. Like. Next. Uh uh. You are. You.";
                case "u": return "Uh huh. Sure. Next. What?. You're. Ur. Uh uh. Done. U. You. Like. Hold. You are. Your.";
                case "uh huh": return "Uh huh. Your. You are. You. Done. Hold. Uh uh. Next. Sure. Like. You're. Ur. U. What?.";
                case "uh uh": return "Ur. U. You are. You're. Next. Uh uh. Done. You. Uh huh. Like. Your. Sure. Hold. What?.";
                case "what?": return "You. Hold. You're. Your. U. Done. Uh uh. Like. You are. Uh huh. Ur. Next. What?. Sure.";
                case "done": return "Sure. Uh huh. Next. What?. Your. Ur. You're. Hold. Like. You. U. You are. Uh uh. Done.";
                case "next": return "What?. Uh huh. Uh uh. Your. Hold. Sure. Next. Like. Done. You are. Ur. You're. U. You.";
                case "hold": return "You are. U. Done. Uh uh. You. Ur. Sure. What?. You're. Next. Hold. Uh huh. Your. Like.";
                case "sure": return "You are. Done. Like. You're. You. Hold. Uh huh. Ur. Sure. U. What?. Next. Your. Uh uh.";
                case "like": return "You're. Next. U. Ur. Hold. Done. Uh uh. What?. Uh huh. You. Like. Sure. You are. Your.";
                default: return "";
            }
        }
    }
}
