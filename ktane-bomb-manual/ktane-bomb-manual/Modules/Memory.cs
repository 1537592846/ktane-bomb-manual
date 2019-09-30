using System.Collections.Generic;

namespace ktane_bomb_manual.Modules
{
    public class Memory : Module
    {
        public Memory()
        {
            Stages = new List<Stage>();
        }

        public List<Stage> Stages { get; set; }

        public override string Solve(Bomb bomb)
        {
            return "Use normal commands for this module";
        }

        public override string Command(Bomb bomb, string command)
        {
            if (command.Contains("reset"))
            {
                Stages.Clear(); return "Moduled reseted";
            }

            var op = 0;
            var numberDisplayed = 0;
            var value1 = "";
            var value2 = "";
            var value3 = "";
            var value4 = "";

            foreach (var word in command.Split(' '))
            {
                if (word == "display" || word == "monitor" || word == "show")
                {
                    op = 1;
                }
                if (word == "numbers")
                {
                    op = 2;
                }
                if (InternalFunctions.GetNumber(word) != -1)
                {
                    if (op == 1)
                    {
                        numberDisplayed = InternalFunctions.GetNumber(word);
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(value1)) { value1 = word; continue; }
                        if (string.IsNullOrEmpty(value2)) { value2 = word; continue; }
                        if (string.IsNullOrEmpty(value3)) { value3 = word; continue; }
                        if (string.IsNullOrEmpty(value4)) { value4 = word; continue; }
                    }
                }
            }
            return StageOption(numberDisplayed.ToString(), value1, value2, value3, value4);
        }

        public string StageOption(string numberDisplayed, string value1, string value2, string value3, string value4)
        {
            switch (Stages.Count)
            {
                case 0:
                    {
                        switch (numberDisplayed)
                        {

                            case "1":
                                {
                                    Stages.Add(new Stage("2", value2));
                                    return "Press " + Stages[0].Value + ".";
                                }
                            case "2":
                                {
                                    Stages.Add(new Stage("2", value2));
                                    return "Press " + Stages[0].Value + ".";
                                }
                            case "3":
                                {
                                    Stages.Add(new Stage("3", value3));
                                    return "Press " + Stages[0].Value + ".";
                                }
                            case "4":
                                {
                                    Stages.Add(new Stage("4", value4));
                                    return "Press " + Stages[0].Value + ".";
                                }
                            default: return "";
                        }
                    }
                case 1:
                    {
                        switch (numberDisplayed)
                        {

                            case "1":
                                {
                                    Stages.Add(new Stage(value1 == "4" ? "1" : value2 == "4" ? "2" : value3 == "4" ? "3" : "4", "4"));
                                    return "Press " + Stages[1].Value + ".";
                                }
                            case "2":
                                {
                                    Stages.Add(new Stage(Stages[0].Position, Stages[0].Position == "1" ? value1 : Stages[0].Position == "2" ? value2 : Stages[0].Position == "3" ? value3 : value4));
                                    return "Press " + Stages[1].Value + ".";
                                }
                            case "3":
                                {
                                    Stages.Add(new Stage("1", value1));
                                    return "Press " + Stages[1].Value + ".";
                                }
                            case "4":
                                {
                                    Stages.Add(new Stage(Stages[0].Position, Stages[0].Position == "1" ? value1 : Stages[0].Position == "2" ? value2 : Stages[0].Position == "3" ? value3 : value4));
                                    return "Press " + Stages[1].Value + ".";
                                }
                            default: return "";
                        }
                    }
                case 2:
                    {
                        switch (numberDisplayed)
                        {

                            case "1":
                                {
                                    Stages.Add(new Stage(Stages[1].Value == value1 ? "1" : Stages[1].Value == value2 ? "2" : Stages[1].Value == value3 ? "3" : "4", Stages[1].Value));
                                    return "Press " + Stages[2].Value + ".";
                                }
                            case "2":
                                {
                                    Stages.Add(new Stage(Stages[0].Value == value1 ? "1" : Stages[0].Value == value2 ? "2" : Stages[0].Value == value3 ? "3" : "4", Stages[0].Value));
                                    return "Press " + Stages[2].Value + ".";
                                }
                            case "3":
                                {
                                    Stages.Add(new Stage("3", value3));
                                    return "Press " + Stages[2].Value + ".";
                                }
                            case "4":
                                {
                                    Stages.Add(new Stage(value1 == "4" ? "1" : value2 == "4" ? "2" : value3 == "4" ? "3" : "4", "4"));
                                    return "Press " + Stages[2].Value + ".";
                                }
                            default: return "";
                        }
                    }
                case 3:
                    {
                        switch (numberDisplayed)
                        {

                            case "1":
                                {
                                    Stages.Add(new Stage(Stages[0].Position, Stages[0].Position == "1" ? value1 : Stages[0].Position == "2" ? value2 : Stages[0].Position == "3" ? value3 : value4));
                                    return "Press " + Stages[3].Value + ".";
                                }
                            case "2":
                                {
                                    Stages.Add(new Stage("1", value1));
                                    return "Press " + Stages[3].Value + ".";
                                }
                            case "3":
                                {
                                    Stages.Add(new Stage(Stages[2].Position, Stages[2].Position == "1" ? value1 : Stages[2].Position == "2" ? value2 : Stages[2].Position == "3" ? value3 : value4));
                                    return "Press " + Stages[3].Value + ".";
                                }
                            case "4":
                                {
                                    Stages.Add(new Stage(Stages[2].Position, Stages[2].Position == "1" ? value1 : Stages[2].Position == "2" ? value2 : Stages[2].Position == "3" ? value3 : value4));
                                    return "Press " + Stages[3].Value + ".";
                                }
                            default: return "";
                        }
                    }
                case 4:
                    {
                        Solved = true;
                        switch (numberDisplayed)
                        {

                            case "1":
                                {
                                    Stages.Add(new Stage(Stages[0].Value == value1 ? "1" : Stages[0].Value == value2 ? "2" : Stages[0].Value == value3 ? "3" : "4", Stages[0].Value));
                                    return "Press " + Stages[4].Value + ".";
                                }
                            case "2":
                                {
                                    Stages.Add(new Stage(Stages[1].Value == value1 ? "1" : Stages[1].Value == value2 ? "2" : Stages[1].Value == value3 ? "3" : "4", Stages[1].Value));
                                    return "Press " + Stages[4].Value + ".";
                                }
                            case "3":
                                {
                                    Stages.Add(new Stage(Stages[3].Value == value1 ? "1" : Stages[3].Value == value2 ? "2" : Stages[3].Value == value3 ? "3" : "4", Stages[3].Value));
                                    return "Press " + Stages[4].Value + ".";
                                }
                            case "4":
                                {
                                    Stages.Add(new Stage(Stages[2].Value == value1 ? "1" : Stages[2].Value == value2 ? "2" : Stages[2].Value == value3 ? "3" : "4", Stages[2].Value));
                                    return "Press " + Stages[4].Value + ".";
                                }
                            default: return "";
                        }
                    }
                default: return "";
            }
        }
    }

    public class Stage
    {
        public Stage(string position, string value)
        {
            Position = position;
            Value = value;
        }

        public string Position;
        public string Value;
    }
}
