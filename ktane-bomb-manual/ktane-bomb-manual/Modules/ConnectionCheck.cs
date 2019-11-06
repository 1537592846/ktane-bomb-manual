using System.Collections.Generic;
using System.Linq;

namespace ktane_bomb_manual.Modules
{
    public class ConnectionCheck : Module
    {
        public ConnectionCheck()
        {
            Connections = new List<Connection>();
        }

        public string CharacterToCheck;
        public List<Connection> Connections;
        public Dictionary<string, string> _SLIM = new Dictionary<string, string>() { { "1", "236" }, { "2", "16" }, { "3", "146" }, { "4", "35678" }, { "5", "467" }, { "6", "12345" }, { "7", "458" }, { "8", "47" } };
        public Dictionary<string, string> _15BRO = new Dictionary<string, string>() { { "1", "27" }, { "2", "17" }, { "3", "48" }, { "4", "38" }, { "5", "67" }, { "6", "57" }, { "7", "1256" }, { "8", "34" } };
        public Dictionary<string, string> _20DGT = new Dictionary<string, string>() { { "1", "23" }, { "2", "147" }, { "3", "157" }, { "4", "2678" }, { "5", "367" }, { "6", "458" }, { "7", "2345" }, { "8", "46" } };
        public Dictionary<string, string> _34XYZ = new Dictionary<string, string>() { { "1", "246" }, { "2", "134" }, { "3", "2" }, { "4", "127" }, { "5", "6" }, { "6", "1578" }, { "7", "468" }, { "8", "67" } };
        public Dictionary<string, string> _7HPJ = new Dictionary<string, string>() { { "1", "23" }, { "2", "13" }, { "3", "12" }, { "4", "67" }, { "5", "67" }, { "6", "45" }, { "7", "45" }, { "8", "" } };
        public Dictionary<string, string> _6WUF = new Dictionary<string, string>() { { "1", "267" }, { "2", "1378" }, { "3", "2568" }, { "4", "578" }, { "5", "3467" }, { "6", "135" }, { "7", "124568" }, { "8", "2347" } };
        public Dictionary<string, string> _8CAKE = new Dictionary<string, string>() { { "1", "2368" }, { "2", "146" }, { "3", "14678" }, { "4", "23567" }, { "5", "478" }, { "6", "1234" }, { "7", "3458" }, { "8", "1357" } };
        public Dictionary<string, string> _9QVN = new Dictionary<string, string>() { { "1", "248" }, { "2", "1367" }, { "3", "2467" }, { "4", "135" }, { "5", "478" }, { "6", "1234" }, { "7", "3458" }, { "8", "1357" } };
        public Dictionary<string, Dictionary<string, string>> Charts;

        public override string Solve(Bomb bomb)
        {
            SetCharacter(bomb);
            CharacterToCheck = CharacterToCheck.ToUpper();

            var chart = Charts.Where(x => x.Key.Contains(CharacterToCheck)).FirstOrDefault().Value;

            var message = "";
            var i = 1;
            foreach (var connection in Connections)
            {
                message += "Connection " + i + " is ";
                message += chart[connection.LeftSide].Contains(connection.RightSide) ? "connected. " : "not connected. ";
                i++;
            }

            Solved = true;

            return message.Trim();
        }

        public override string Command(Bomb bomb, string command)
        {
            var connection = new Connection();
            foreach (var word in command.Split(' '))
            {
                if (InternalFunctions.IsNumber(word))
                {
                    connection.LeftSide = word[0].ToString();
                    connection.RightSide = word[1].ToString();
                }

                if (connection.IsComplete())
                {
                    Connections.Add(connection);
                    connection = new Connection();
                }
            }

            if (Connections.Count == 4) return Solve(bomb);
            else return "Not enought connections.";
        }

        public void SetCharacter(Bomb bomb)
        {
            var count1 = 0;
            var count2 = 0;
            var count3 = 0;
            var count4 = 0;
            var count5 = 0;
            var count6 = 0;
            var count7 = 0;
            var count8 = 0;

            foreach (var connection in Connections)
            {
                switch (connection.LeftSide)
                {
                    case "1": count1++; break;
                    case "2": count2++; break;
                    case "3": count3++; break;
                    case "4": count4++; break;
                    case "5": count5++; break;
                    case "6": count6++; break;
                    case "7": count7++; break;
                    case "8": count8++; break;
                }
                switch (connection.RightSide)
                {
                    case "1": count1++; break;
                    case "2": count2++; break;
                    case "3": count3++; break;
                    case "4": count4++; break;
                    case "5": count5++; break;
                    case "6": count6++; break;
                    case "7": count7++; break;
                    case "8": count8++; break;
                }
            }

            Charts = new Dictionary<string, Dictionary<string, string>>() { { "15BRO", _15BRO }, { "20DGT", _20DGT }, { "34XYZ", _34XYZ }, { "6WUF", _6WUF }, { "7HPJ", _7HPJ }, { "8CAKE", _8CAKE }, { "9QVN", _9QVN }, { "SLIM", _SLIM } };
            if (count1 <= 1 && count2 <= 1 && count3 <= 1 && count4 <= 1 && count5 <= 1 && count6 <= 1 && count7 <= 1 && count8 <= 1) { CharacterToCheck = bomb.GetSerialCharacterAtPosition(6); return; }
            if (count1 > 1) { CharacterToCheck = bomb.GetSerialCharacterAtPosition(1); return; }
            if (count7 > 1) { CharacterToCheck = bomb.GetSerialCharacterAtPosition(6); return; }
            if (count2 >= 3) { CharacterToCheck = bomb.GetSerialCharacterAtPosition(2); return; }
            if (count5 == 0) { CharacterToCheck = bomb.GetSerialCharacterAtPosition(5); return; }
            if (count8 == 2) { CharacterToCheck = bomb.GetSerialCharacterAtPosition(3); return; }
            if (bomb.HasManyBatteries(6) || !bomb.HasManyBatteries(1)) { CharacterToCheck = bomb.GetSerialCharacterAtPosition(6); return; }
            CharacterToCheck = bomb.GetSerialCharacterAtPosition(bomb.GetBatteries());
        }
    }

    public class Connection
    {
        public string LeftSide;
        public string RightSide;

        public bool IsComplete()
        {
            return !(string.IsNullOrWhiteSpace(LeftSide) && string.IsNullOrWhiteSpace(RightSide));
        }
    }
}
