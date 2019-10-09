using System.Collections.Generic;
using System.Linq;

namespace ktane_bomb_manual.Modules
{
    public class Bulb : Module
    {
        public Bulb()
        {
            CommandsExecuted = new List<string>();
        }

        public string Color;
        public bool Opaque;
        public bool Lit;
        public bool Screwed;
        public List<string> CommandsExecuted;

        public override string Solve(Bomb bomb)
        {
            return "First " + Step1(bomb);
        }

        public override string Command(Bomb bomb, string command)
        {
            Color = (command.Contains("blue") ? "blue" : "") + (command.Contains("green") ? "green" : "") + (command.Contains("purple") ? "purple" : "") + (command.Contains("red") ? "red" : "") + (command.Contains("white") ? "white" : "") + (command.Contains("yellow") ? "yellow" : "");
            Lit = !(command.Contains(" lit") || command.Contains(" off"));
            Screwed = !command.Contains("screwed");
            Opaque = command.Contains("opaque");

            return Solve(bomb);
        }

        public string Step1(Bomb bomb)
        {
            if (Lit && !Opaque) { CommandsExecuted.Add("I"); return "press I, then " + Step2(bomb); }
            if (Lit && Opaque) { CommandsExecuted.Add("O"); return "press O, then " + Step3(bomb); }
            CommandsExecuted.Add("unscrew");
            return "unscrew, then " + Step4(bomb);
        }

        public string Step2(Bomb bomb)
        {
            if (Color == "red") { CommandsExecuted.Add("I"); CommandsExecuted.Add("unscrew"); return "press I, then unscrew, then " + Step5(bomb); }
            if (Color == "white") { CommandsExecuted.Add("O"); CommandsExecuted.Add("unscrew"); return "press O, then unscrew, then " + Step6(bomb); }
            CommandsExecuted.Add("unscrew");
            return "unscrew, then " + Step7(bomb);
        }

        public string Step3(Bomb bomb, bool returnStepOnly = false)
        {
            if (returnStepOnly)
            {
                if (Color == "green") return "I";
                if (Color == "purple") return "O";
            }
            if (Color == "green") { CommandsExecuted.Add("I"); CommandsExecuted.Add("unscrew"); return "press I, then unscrew, then " + Step6(bomb); }
            if (Color == "purple") { CommandsExecuted.Add("O"); CommandsExecuted.Add("unscrew"); return "press O, then unscrew, then " + Step5(bomb); }
            CommandsExecuted.Add("unscrew");
            return "unscrew, then " + Step8(bomb);
        }

        public string Step4(Bomb bomb)
        {
            if (bomb.HasIndicator("car") || bomb.HasIndicator("ind") || bomb.HasIndicator("msa") || bomb.HasIndicator("snd")) { CommandsExecuted.Add("I"); return "press I, then " + Step9(bomb); }
            CommandsExecuted.Add("O");
            return "press O, then " + Step10(bomb);
        }

        public string Step5(Bomb bomb)
        {
            var commandExecutedAtStep1 = CommandsExecuted[0];
            return "if the bulb went off at step 1, press " + commandExecutedAtStep1 + ", else press " + (commandExecutedAtStep1 == "I" ? "O" : "I") + ", then screw, and you're done.";
        }

        public string Step6(Bomb bomb)
        {
            var commandExecutedAtStep1 = CommandsExecuted[0];
            var commandExecutedAtNextStep = CommandsExecuted[1];
            return "if the bulb went off when you pressed I, press " + commandExecutedAtStep1 + ", else press " + commandExecutedAtNextStep + ", then screw, and you're done.";
        }

        public string Step7(Bomb bomb)
        {
            if (Color == "green") { CommandsExecuted.Add("I");return "press I, then "+Step11(bomb,"sig"); }
            if(Color=="purple") { CommandsExecuted.Add("I"); CommandsExecuted.Add("screw"); return "press I, then screw, then " + Step12(bomb); }
            if (Color=="blue") { CommandsExecuted.Add("O"); return "press O, then " + Step11(bomb, "clr"); }
            CommandsExecuted.Add("O"); CommandsExecuted.Add("screw"); return "press O, then screw, then " + Step13(bomb);
        }

        public string Step8(Bomb bomb)
        {
            if (Color == "white") { CommandsExecuted.Add("I"); return "press I, then " + Step11(bomb, "frq"); }
            if (Color == "red") { CommandsExecuted.Add("I"); CommandsExecuted.Add("screw"); return "press I, then screw, then " + Step13(bomb); }
            if (Color == "yellow") { CommandsExecuted.Add("O"); return "press O, then " + Step11(bomb, "frk"); }
            CommandsExecuted.Add("O"); CommandsExecuted.Add("screw"); return "press O, then screw, then " + Step12(bomb);
        }

        public string Step9(Bomb bomb)
        {
            switch (Color)
            {
                case "blue": { CommandsExecuted.Add("I"); return "press I, then " + Step14(bomb); }
                case "green": { CommandsExecuted.Add("I"); CommandsExecuted.Add("screw"); return "press I, then screw, then " + Step12(bomb); }
                case "yellow": { CommandsExecuted.Add("O"); return "press O, then " + Step15(bomb); }
                case "white": { CommandsExecuted.Add("O"); CommandsExecuted.Add("screw"); return "press O, then screw, then " + Step13(bomb); }
                case "purple": { CommandsExecuted.Add("screw"); CommandsExecuted.Add("I"); return "screw, then press I, then " + Step12(bomb); }
                default: { CommandsExecuted.Add("screw"); CommandsExecuted.Add("O"); return "screw, then press O, then " + Step13(bomb); }
            }
        }

        public string Step10(Bomb bomb)
        {
            switch (Color)
            {
                case "purple": { CommandsExecuted.Add("I"); return "press I, then " + Step14(bomb); } 
                case "red": { CommandsExecuted.Add("I"); CommandsExecuted.Add("screw"); return "press I, then screw, then " + Step13(bomb); } 
                case "blue": { CommandsExecuted.Add("O"); return "press O, then " + Step15(bomb); }
                case "yellow": { CommandsExecuted.Add("O"); CommandsExecuted.Add("screw"); return "press O, then screw, then " + Step12(bomb); }
                case "green": { CommandsExecuted.Add("screw"); CommandsExecuted.Add("I"); return "screw, then press I, then " + Step13(bomb); }
                default: { CommandsExecuted.Add("screw"); CommandsExecuted.Add("O"); return "screw, then press O, then " + Step12(bomb); }
            }
        }

        public string Step11(Bomb bomb, string indicator)
        {
            if (bomb.HasIndicator(indicator)) {CommandsExecuted.Add("I"); CommandsExecuted.Add("screw"); return "press I, then screw, the you're done."; }
            CommandsExecuted.Add("O");
            CommandsExecuted.Add("screw");
            return "press O, then screw, the you're done.";
        }

        public string Step12(Bomb bomb)
        {
            return "if the light is now on, press I, else press O, then you're done.";
        }

        public string Step13(Bomb bomb)
        {
            return "if the light is now on, press O, else press I, then you're done.";
        }

        public string Step14(Bomb bomb)
        {
            return "press " + (Opaque ? "I" : "O") + ", then screw, then you're done.";
        }

        public string Step15(Bomb bomb)
        {
            return "press " + (!Opaque ? "I" : "O") + ", then screw, then you're done.";
        }
    }
}
