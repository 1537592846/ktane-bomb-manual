namespace ktane_bomb_manual.Modules
{
    public class Clock : Module
    {
        public string NumeralType = "none";
        public string CaseColor;
        public bool NumeralTickmarksMatchesHands;
        public string HandShapes;
        public string NumeralTickmarksColor;
        public string AmPmIndicator;
        public bool SecondHandPresent;
        public bool ShowHourSolution;
        public bool ShowedHours;
        public bool ShowedMinutes;

        public override string Solve(Bomb bomb)
        {
            if (ShowHourSolution)
            {
                if (string.IsNullOrWhiteSpace(CaseColor)) return "Can't solve it for hours yet.";
                ShowedHours = true;
                if (ShowedMinutes) Solved = true;
                switch (NumeralType)
                {
                    case "roman":
                        if (CaseColor == "silver")
                            if (NumeralTickmarksMatchesHands) return "Set the hours to the 11 o'clock position.";
                            else return "Set the hours to the 12 o'clock position.";
                        else
                            if (NumeralTickmarksMatchesHands) return "Set the hours to the 1 o'clock position.";
                        else return "Set the hours to the 2 o'clock position.";
                    case "none":
                        if (CaseColor == "silver")
                            if (NumeralTickmarksMatchesHands) return "Set the hours to the 3 o'clock position.";
                            else return "Set the hours to the 4 o'clock position.";
                        else
                            if (NumeralTickmarksMatchesHands) return "Set the hours to the 5 o'clock position.";
                        else return "Set the hours to the 6 o'clock position.";
                    case "arabic":
                        if (CaseColor == "silver")
                            if (NumeralTickmarksMatchesHands) return "Set the hours to the 7 o'clock position.";
                            else return "Set the hours to the 8 o'clock position.";
                        else
                            if (NumeralTickmarksMatchesHands) return "Set the hours to the 9 o'clock position.";
                        else return "Set the hours to the 10 o'clock position.";
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(HandShapes) || string.IsNullOrWhiteSpace(NumeralTickmarksColor) || string.IsNullOrWhiteSpace(AmPmIndicator)) return "Can't solve it for minutes yet.";
                ShowedMinutes = true;
                if (ShowedHours) Solved = true;
                switch (HandShapes)
                {
                    case "lines":
                        switch (NumeralTickmarksColor)
                        {
                            case "red":
                                if (AmPmIndicator == "black")
                                    if (SecondHandPresent) return "Set the minutes to 51.";
                                    else return "Set the minutes to 52.";
                                else
                                    if (SecondHandPresent) return "Set the minutes to 53.";
                                else return "Set the minutes to 54.";
                            case "green":
                                if (AmPmIndicator == "black")
                                    if (SecondHandPresent) return "Set the minutes to 55.";
                                    else return "Set the minutes to 56.";
                                else
                                    if (SecondHandPresent) return "Set the minutes to 57.";
                                else return "Set the minutes to 58.";
                            case "blue":
                                if (AmPmIndicator == "black")
                                    if (SecondHandPresent) return "Set the minutes to 59.";
                                    else return "Set the minutes to 0.";
                                else
                                    if (SecondHandPresent) return "Set the minutes to 1.";
                                else return "Set the minutes to 2.";
                            case "gold":
                                if (AmPmIndicator == "black")
                                    if (SecondHandPresent) return "Set the minutes to 3.";
                                    else return "Set the minutes to 4.";
                                else
                                    if (SecondHandPresent) return "Set the minutes to 5.";
                                else return "Set the minutes to 6.";
                            case "black":
                                if (AmPmIndicator == "black")
                                    if (SecondHandPresent) return "Set the minutes to 7.";
                                    else return "Set the minutes to 8.";
                                else
                                    if (SecondHandPresent) return "Set the minutes to 9.";
                                else return "Set the minutes to 10.";
                        }
                        break;
                    case "spades":
                        switch (NumeralTickmarksColor)
                        {
                            case "red":
                                if (AmPmIndicator == "black")
                                    if (SecondHandPresent) return "Set the minutes to 11.";
                                    else return "Set the minutes to 12.";
                                else
                                    if (SecondHandPresent) return "Set the minutes to 13.";
                                else return "Set the minutes to 14.";
                            case "green":
                                if (AmPmIndicator == "black")
                                    if (SecondHandPresent) return "Set the minutes to 15.";
                                    else return "Set the minutes to 16.";
                                else
                                    if (SecondHandPresent) return "Set the minutes to 17.";
                                else return "Set the minutes to 18.";
                            case "blue":
                                if (AmPmIndicator == "black")
                                    if (SecondHandPresent) return "Set the minutes to 19.";
                                    else return "Set the minutes to 20.";
                                else
                                    if (SecondHandPresent) return "Set the minutes to 21.";
                                else return "Set the minutes to 22.";
                            case "gold":
                                if (AmPmIndicator == "black")
                                    if (SecondHandPresent) return "Set the minutes to 23.";
                                    else return "Set the minutes to 24.";
                                else
                                    if (SecondHandPresent) return "Set the minutes to 25.";
                                else return "Set the minutes to 26.";
                            case "black":
                                if (AmPmIndicator == "black")
                                    if (SecondHandPresent) return "Set the minutes to 27.";
                                    else return "Set the minutes to 28.";
                                else
                                    if (SecondHandPresent) return "Set the minutes to 29.";
                                else return "Set the minutes to 30.";
                        }
                        break;
                    case "arrow":
                        switch (NumeralTickmarksColor)
                        {
                            case "red":
                                if (AmPmIndicator == "black")
                                    if (SecondHandPresent) return "Set the minutes to 31.";
                                    else return "Set the minutes to 32.";
                                else
                                    if (SecondHandPresent) return "Set the minutes to 33.";
                                else return "Set the minutes to 34.";
                            case "green":
                                if (AmPmIndicator == "black")
                                    if (SecondHandPresent) return "Set the minutes to 35.";
                                    else return "Set the minutes to 36.";
                                else
                                    if (SecondHandPresent) return "Set the minutes to 37.";
                                else return "Set the minutes to 38.";
                            case "blue":
                                if (AmPmIndicator == "black")
                                    if (SecondHandPresent) return "Set the minutes to 39.";
                                    else return "Set the minutes to 40.";
                                else
                                    if (SecondHandPresent) return "Set the minutes to 41.";
                                else return "Set the minutes to 42.";
                            case "gold":
                                if (AmPmIndicator == "black")
                                    if (SecondHandPresent) return "Set the minutes to 43.";
                                    else return "Set the minutes to 44.";
                                else
                                    if (SecondHandPresent) return "Set the minutes to 45.";
                                else return "Set the minutes to 46.";
                            case "black":
                                if (AmPmIndicator == "black")
                                    if (SecondHandPresent) return "Set the minutes to 47.";
                                    else return "Set the minutes to 48.";
                                else
                                    if (SecondHandPresent) return "Set the minutes to 49.";
                                else return "Set the minutes to 50.";
                        }
                        break;
                }
            }

            return "";
        }

        public override string Command(Bomb bomb, string command)
        {
            if (command.Contains("hour"))
            {
                foreach (var word in command.Split(' '))
                {
                    if (word.Contains("roman") || word.Contains("arabic")) NumeralType = word;
                    if (word.Contains("gold") || word.Contains("silver")) CaseColor = word;
                    if (word.Contains("match")) NumeralTickmarksMatchesHands = true;
                }
                ShowHourSolution = true;
            }
            else
            {
                foreach (var word in command.Split(' '))
                {
                    if (word.Contains("arrow") || word.Contains("line") || word.Contains("spade")) HandShapes = word;
                    if (word.Contains("gold") || word.Contains("blue") || word.Contains("green") || word.Contains("red") || (word.Contains("black") && command.Replace(word + " am", "").Replace(word + " pm", "").Contains(word))) NumeralTickmarksColor = word;
                    if (command.Contains(word + " am") || command.Contains(word + " pm")) AmPmIndicator = word;
                    if (word.Contains("present")) SecondHandPresent = true;
                }
                ShowHourSolution = false;
            }

            return Solve(bomb);
        }
    }
}
