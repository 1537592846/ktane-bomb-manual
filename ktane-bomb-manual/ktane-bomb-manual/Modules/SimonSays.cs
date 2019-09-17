using System.Collections.Generic;

namespace ktane_bomb_manual.Modules
{
    public class SimonSays : Module
    {
        public SimonSays()
        {
            ColorsBlinked = new List<string>();
        }

        public List<string> ColorsBlinked;

        public override string Solve(Bomb bomb)
        {
            return "Press " + ColorsToPress(bomb) + ".";
        }

        public override string Command(Bomb bomb, string command)
        {
            if (command.Contains("solved"))
            {
                Solved = true;
                return "Module defused.";
            }

            ColorsBlinked.Add(command.Replace("simon says ", ""));
            return Solve(bomb);
        }

        public string ColorsToPress(Bomb bomb)
        {
            var message = "";

            foreach (var color in ColorsBlinked)
            {
                message += WhichColor(bomb, color) + " ";
            }

            return message.Trim();
        }

        public string WhichColor(Bomb bomb, string color)
        {
            if (bomb.HasSerialVowel())
            {
                switch (bomb.Strikes)
                {
                    case 0:
                        switch (color)
                        {
                            case "red": return "blue";
                            case "blue": return "red";
                            case "green": return "yellow";
                            case "yellow": return "green";
                            default: return "";
                        }
                    case 1:
                        switch (color)
                        {
                            case "red": return "yellow";
                            case "blue": return "green";
                            case "green": return "blue";
                            case "yellow": return "red";
                            default: return "";
                        }
                    case 2:
                        switch (color)
                        {
                            case "red": return "green";
                            case "blue": return "red";
                            case "green": return "yellow";
                            case "yellow": return "blue";
                            default: return "";
                        }
                    default: return "";
                }
            }
            else
            {
                switch (bomb.Strikes)
                {
                    case 0:
                        switch (color)
                        {
                            case "red": return "blue";
                            case "blue": return "yellow";
                            case "green": return "green";
                            case "yellow": return "red";
                            default: return "";
                        }
                    case 1:
                        switch (color)
                        {
                            case "red": return "red";
                            case "blue": return "blue";
                            case "green": return "yellow";
                            case "yellow": return "green";
                            default: return "";
                        }
                    case 2:
                        switch (color)
                        {
                            case "red": return "yellow";
                            case "blue": return "green";
                            case "green": return "blue";
                            case "yellow": return "red";
                            default: return "";
                        }
                    default: return "";
                }
            }
        }
    }
}
