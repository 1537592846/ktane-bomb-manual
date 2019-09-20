using System.Collections.Generic;
using System.Linq;

namespace ktane_bomb_manual.Modules
{
    public class SimonStates : Module
    {
        public SimonStates()
        {
            ColorsBlinked = new List<string>();
            Priority = new Dictionary<string, List<string>>();
            Priority.Add("red", new List<string>() { "red", "blue", "green", "yellow" });
            Priority.Add("yellow", new List<string>() { "blue", "yellow", "red", "green" });
            Priority.Add("green", new List<string>() { "green", "red", "yellow", "blue" });
            Priority.Add("blue", new List<string>() { "yellow", "green", "blue", "red" });
        }

        public List<string> ColorsBlinked;
        public Dictionary<string, List<string>> Priority;
        public string TopLeft;

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

            if (command.Contains("top")||command.Contains("left"))
            {
                foreach (var word in command.Split(' '))
                {
                    if (word == "yellow" || word == "red" || word == "blue" || word == "green") { TopLeft = word; return "Top left color added."; }
                }
            }

            if (command.Contains("all"))
            {
                ColorsBlinked.Add("red blue green yellow");
            }

            ColorsBlinked.Add(command.Replace("simon states ", ""));
            return Solve(bomb);
        }

        public string ColorsToPress(Bomb bomb)
        {
            var message = "";

            for (int i = 0; i < ColorsBlinked.Count; i++)
            {
                message += WhichColor(i + 1, ColorsBlinked[i]) + " ";
            }

            return message.Trim();
        }


        public string WhichColor(int position, string color)
        {
            var yellowBlinked = color.Contains("yellow");
            var redBlinked = color.Contains("red");
            var greenBlinked = color.Contains("green");
            var blueBlinked = color.Contains("blue");

            switch (position)
            {
                case 1:
                    {
                        switch ((yellowBlinked ? 1 : 0) + (redBlinked ? 1 : 0) + (greenBlinked ? 1 : 0) + (blueBlinked ? 1 : 0))
                        {
                            case 1:
                                {
                                    return color;
                                }
                            case 2:
                                {
                                    if (blueBlinked)
                                    {
                                        var color1 = color.Split(' ')[0];
                                        var color2 = color.Split(' ')[1];
                                        var colorPriority1 = Priority[TopLeft].FindIndex(x => x == color1);
                                        var colorPriority2 = Priority[TopLeft].FindIndex(x => x == color2);
                                        if (colorPriority1 > colorPriority2) return color2;
                                        else return color1;
                                    }
                                    else return "blue";
                                }
                            case 3:
                                {
                                    if (redBlinked)
                                    {
                                        var color1 = color.Split(' ')[0];
                                        var color2 = color.Split(' ')[1];
                                        var color3 = color.Split(' ')[2];
                                        var colorPriority1 = Priority[TopLeft].FindIndex(x => x == color1);
                                        var colorPriority2 = Priority[TopLeft].FindIndex(x => x == color2);
                                        var colorPriority3 = Priority[TopLeft].FindIndex(x => x == color3);
                                        if (colorPriority1 < colorPriority2)
                                            if (colorPriority1 < colorPriority3)
                                                return color1;
                                            else
                                                return color3;
                                        else
                                            if (colorPriority2 < colorPriority3)
                                            return color2;
                                        else
                                            return color3;
                                    }
                                    else return "red";
                                }
                            case 4:
                                {
                                    return Priority[TopLeft].ElementAt(1);
                                }
                        }
                        break;
                    }
                case 2:
                    {
                        switch ((yellowBlinked ? 1 : 0) + (redBlinked ? 1 : 0) + (greenBlinked ? 1 : 0) + (blueBlinked ? 1 : 0))
                        {
                            case 1:
                                {
                                    if (!blueBlinked) return "blue";
                                    return "yellow";
                                }
                            case 2:
                                {
                                    if (redBlinked && blueBlinked)
                                    {
                                        var color1 = "yellow";
                                        var color2 = "green";
                                        var colorPriority1 = Priority[TopLeft].FindIndex(x => x == color1);
                                        var colorPriority2 = Priority[TopLeft].FindIndex(x => x == color2);
                                        if (colorPriority1 > colorPriority2) return color1;
                                        else return color2;
                                    }
                                    else
                                    {
                                        var color1 = "red blue green yellow".Replace(color.Split(' ')[0],"").Replace(color.Split(' ')[1], "").Trim().Replace("  "," ").Split(' ')[0];
                                        var color2 = "red blue green yellow".Replace(color.Split(' ')[0],"").Replace(color.Split(' ')[1], "").Trim().Replace("  ", " ").Split(' ')[1];
                                        var colorPriority1 = Priority[TopLeft].FindIndex(x => x == color1);
                                        var colorPriority2 = Priority[TopLeft].FindIndex(x => x == color2);
                                        if (colorPriority1 < colorPriority2) return color2;
                                        else return color1;
                                    }
                                }
                            case 3:
                                {
                                    return (!redBlinked ? "red" : "") + (!blueBlinked ? "blue" : "") + (!yellowBlinked ? "yellow" : "") + (!greenBlinked ? "green" : "");
                                }
                            case 4:
                                {
                                    return WhichColor(1, ColorsBlinked[0]);
                                }
                        }
                        break;
                    }
                case 3:
                    {
                        switch ((yellowBlinked ? 1 : 0) + (redBlinked ? 1 : 0) + (greenBlinked ? 1 : 0) + (blueBlinked ? 1 : 0))
                        {
                            case 1:
                                {
                                    return color;
                                }
                            case 2:
                                {
                                    var colorStage1 = WhichColor(1, ColorsBlinked[0]);
                                    var colorStage2 = WhichColor(2, ColorsBlinked[1]);
                                    if (color.Contains(colorStage1) && color.Contains(colorStage2))
                                        return Priority[TopLeft].Where(x => x != colorStage1 && x != colorStage2).Last();
                                    else
                                        return colorStage1;
                                }
                            case 3:
                                {
                                    var colorStage1 = WhichColor(1, ColorsBlinked[0]);
                                    var colorStage2 = WhichColor(2, ColorsBlinked[1]);

                                    if (color.Contains(colorStage1) || color.Contains(colorStage2))
                                        return Priority[TopLeft].Where(x => x != (redBlinked ? "" : "red") + (blueBlinked ? "" : "blue") + (yellowBlinked ? "" : "yellow") + (greenBlinked ? "" : "green") && (x == colorStage1 || x == colorStage2)).First();
                                    else
                                        return Priority[TopLeft].Where(x => x != (redBlinked ? "" : "red") + (blueBlinked ? "" : "blue") + (yellowBlinked ? "" : "yellow") + (greenBlinked ? "" : "green")).First();
                                }
                            case 4:
                                {
                                    return Priority[TopLeft][2];

                                }
                        }
                        break;
                    }
                case 4:
                    {
                        var color1 = WhichColor(1, ColorsBlinked[0]);
                        var color2 = WhichColor(2, ColorsBlinked[1]);
                        var color3 = WhichColor(3, ColorsBlinked[2]);

                        if (color1 != color2 && color2 != color3&&color1!=color3) return Priority[TopLeft].Where(x => x != color1 && x != color2 && x != color3).First();

                        switch ((yellowBlinked ? 1 : 0) + (redBlinked ? 1 : 0) + (greenBlinked ? 1 : 0) + (blueBlinked ? 1 : 0))
                        {
                            case 1:
                                {
                                    return color;
                                }
                            case 2:
                                {
                                    return "green";
                                }
                            case 3:
                                {
                                    if ((color.Contains(color1) ? 1 : 0) + (color.Contains(color2) ? 1 : 0) + (color.Contains(color3) ? 1 : 0) == 2)
                                    {
                                        return color.Replace(color1, "").Replace(color2, "").Replace(color3, "").Trim();
                                    }
                                    return Priority[TopLeft][3];
                                }
                            case 4:
                                {
                                    return Priority[TopLeft][3];
                                }
                        }
                        break;
                    }
            }

            return "";
        }
    }
}
