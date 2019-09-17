using System.Collections.Generic;

namespace ktane_bomb_manual.Modules
{
    public class SafetySafe : Module
    {
        public Dictionary<string, int> Dial1 = new Dictionary<string, int>() { { "a", 8 }, { "b", 10 }, { "c", 2 }, { "d", 11 }, { "e", 0 }, { "f", 4 }, { "g", 7 }, { "h", 8 }, { "i", 0 }, { "j", 2 }, { "k", 5 }, { "l", 1 }, { "m", 1 }, { "n", 9 }, { "o", 5 }, { "p", 3 }, { "q", 4 }, { "r", 8 }, { "s", 9 }, { "t", 7 }, { "u", 11 }, { "v", 11 }, { "w", 6 }, { "x", 4 }, { "y", 10 }, { "z", 3 }, { "0", 7 }, { "1", 9 }, { "2", 2 }, { "3", 10 }, { "4", 6 }, { "5", 6 }, { "6", 1 }, { "7", 0 }, { "8", 5 }, { "9", 3 } };
        public Dictionary<string, int> Dial2 = new Dictionary<string, int>() { { "a", 3 }, { "b", 1 }, { "c", 1 }, { "d", 6 }, { "e", 5 }, { "f", 2 }, { "g", 4 }, { "h", 3 }, { "i", 11 }, { "j", 11 }, { "k", 2 }, { "l", 9 }, { "m", 7 }, { "n", 5 }, { "o", 9 }, { "p", 10 }, { "q", 10 }, { "r", 0 }, { "s", 4 }, { "t", 6 }, { "u", 9 }, { "v", 11 }, { "w", 0 }, { "x", 2 }, { "y", 7 }, { "z", 7 }, { "0", 0 }, { "1", 10 }, { "2", 5 }, { "3", 8 }, { "4", 8 }, { "5", 3 }, { "6", 1 }, { "7", 6 }, { "8", 4 }, { "9", 8 } };
        public Dictionary<string, int> Dial3 = new Dictionary<string, int>() { { "a", 4 }, { "b", 3 }, { "c", 1 }, { "d", 11 }, { "e", 5 }, { "f", 7 }, { "g", 4 }, { "h", 6 }, { "i", 0 }, { "j", 8 }, { "k", 5 }, { "l", 8 }, { "m", 9 }, { "n", 1 }, { "o", 8 }, { "p", 9 }, { "q", 6 }, { "r", 4 }, { "s", 0 }, { "t", 7 }, { "u", 6 }, { "v", 2 }, { "w", 11 }, { "x", 7 }, { "y", 10 }, { "z", 1 }, { "0", 3 }, { "1", 10 }, { "2", 11 }, { "3", 10 }, { "4", 0 }, { "5", 3 }, { "6", 5 }, { "7", 2 }, { "8", 9 }, { "9", 2 } };
        public Dictionary<string, int> Dial4 = new Dictionary<string, int>() { { "a", 8 }, { "b", 7 }, { "c", 5 }, { "d", 11 }, { "e", 8 }, { "f", 7 }, { "g", 2 }, { "h", 6 }, { "i", 0 }, { "j", 0 }, { "k", 1 }, { "l", 11 }, { "m", 5 }, { "n", 4 }, { "o", 10 }, { "p", 1 }, { "q", 1 }, { "r", 0 }, { "s", 6 }, { "t", 11 }, { "u", 3 }, { "v", 8 }, { "w", 6 }, { "x", 2 }, { "y", 10 }, { "z", 10 }, { "0", 5 }, { "1", 9 }, { "2", 7 }, { "3", 4 }, { "4", 3 }, { "5", 3 }, { "6", 2 }, { "7", 4 }, { "8", 9 }, { "9", 9 } };
        public Dictionary<string, int> Dial5 = new Dictionary<string, int>() { { "a", 9 }, { "b", 3 }, { "c", 3 }, { "d", 7 }, { "e", 2 }, { "f", 1 }, { "g", 10 }, { "h", 6 }, { "i", 9 }, { "j", 5 }, { "k", 0 }, { "l", 11 }, { "m", 6 }, { "n", 4 }, { "o", 2 }, { "p", 9 }, { "q", 9 }, { "r", 6 }, { "s", 3 }, { "t", 5 }, { "u", 11 }, { "v", 1 }, { "w", 11 }, { "x", 8 }, { "y", 8 }, { "z", 0 }, { "0", 8 }, { "1", 1 }, { "2", 7 }, { "3", 10 }, { "4", 5 }, { "5", 0 }, { "6", 7 }, { "7", 2 }, { "8", 10 }, { "9", 4 } };
        public Dictionary<string, int> Dial6 = new Dictionary<string, int>() { { "a", 0 }, { "b", 8 }, { "c", 6 }, { "d", 7 }, { "e", 1 }, { "f", 5 }, { "g", 5 }, { "h", 5 }, { "i", 10 }, { "j", 6 }, { "k", 4 }, { "l", 11 }, { "m", 2 }, { "n", 9 }, { "o", 8 }, { "p", 7 }, { "q", 7 }, { "r", 11 }, { "s", 10 }, { "t", 3 }, { "u", 1 }, { "v", 0 }, { "w", 62 }, { "x", 10 }, { "y", 9 }, { "z", 4 }, { "0", 6 }, { "1", 2 }, { "2", 3 }, { "3", 4 }, { "4", 0 }, { "5", 11 }, { "6", 3 }, { "7", 1 }, { "8", 7 }, { "9", 9 } };

        public SafetySafe()
        {
            Dials = new List<int>();
        }

        public List<int> Dials { get; set; }

        public override string Solve(Bomb bomb)
        {
            int PortTypeQuantity = bomb.Ports.Count * 7;
            int LitIndicatorsInSerial = bomb.GetLitIndicatorsInSerialQuantity() * 5;
            int UnlitIndicatorsInSerial = bomb.GetUnlitIndicatorsInSerialQuantity();

            int Dial1 = (PortTypeQuantity + LitIndicatorsInSerial + UnlitIndicatorsInSerial + GetNumberForDial(bomb, 1)) % 12;
            int Dial2 = (PortTypeQuantity + LitIndicatorsInSerial + UnlitIndicatorsInSerial + GetNumberForDial(bomb, 2)) % 12;
            int Dial3 = (PortTypeQuantity + LitIndicatorsInSerial + UnlitIndicatorsInSerial + GetNumberForDial(bomb, 3)) % 12;
            int Dial4 = (PortTypeQuantity + LitIndicatorsInSerial + UnlitIndicatorsInSerial + GetNumberForDial(bomb, 4)) % 12;
            int Dial5 = (PortTypeQuantity + LitIndicatorsInSerial + UnlitIndicatorsInSerial + GetNumberForDial(bomb, 5)) % 12;
            int Dial6 = (PortTypeQuantity + LitIndicatorsInSerial + UnlitIndicatorsInSerial + GetNumberForDial(bomb, 6)) % 12;
            Solved = true;

            return "First dial: " + Dial1 + " turns. Second dial: " + Dial2 + " turns. Third dial: " + Dial3 + " turns. Fourth dial: " + Dial4 + " turns. Fifth dial: " + Dial5 + " turns. Sixth dial: " + Dial6 + " turns.";
        }

        public override string Command(Bomb bomb, string command)
        {
            Dials.Clear();

            foreach (var word in command.Split(' '))
            {
                if (InternalFunctions.GetNumber(word) != -1)
                {
                    Dials.Add(InternalFunctions.GetNumber(word));
                }
            }
            if (Dials.Count != 6) return "Not enought dials.";
            return Solve(bomb);
        }

        public int GetNumberForDial(Bomb bomb, int dial)
        {
            int numberToReturn = 0;
            int number;
            switch (dial)
            {
                case 1:
                    {
                        Dial1.TryGetValue(bomb.GetSerialCharacterAtPosition(dial), out numberToReturn);
                        break;
                    }
                case 2:
                    {
                        Dial2.TryGetValue(bomb.GetSerialCharacterAtPosition(dial), out numberToReturn);
                        break;
                    }
                case 3:
                    {
                        Dial3.TryGetValue(bomb.GetSerialCharacterAtPosition(dial), out numberToReturn);
                        break;
                    }
                case 4:
                    {
                        Dial4.TryGetValue(bomb.GetSerialCharacterAtPosition(dial), out numberToReturn);
                        break;
                    }
                case 5:
                    {
                        Dial5.TryGetValue(bomb.GetSerialCharacterAtPosition(dial), out numberToReturn);
                        break;
                    }
                case 6:
                    {
                        foreach (var character in bomb.Serial)
                        {
                            Dial6.TryGetValue(character.ToString().ToLower(), out number);
                            numberToReturn += number;
                        }
                        break;
                    }
                default: return 0;
            }
            return numberToReturn;
        }
    }
}
