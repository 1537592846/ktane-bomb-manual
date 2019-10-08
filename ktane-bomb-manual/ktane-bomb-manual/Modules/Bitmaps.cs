using System;
using System.Linq;

namespace ktane_bomb_manual.Modules
{
    public class Bitmaps : Module
    {
        public Bitmaps()
        {
            FirstQuadrant = new bool[4, 4];
            SecondQuadrant = new bool[4, 4];
            ThirdQuadrant = new bool[4, 4];
            FourthQuadrant = new bool[4, 4];
        }

        public bool[,] FirstQuadrant;
        public bool[,] SecondQuadrant;
        public bool[,] ThirdQuadrant;
        public bool[,] FourthQuadrant;

        public override string Solve(Bomb bomb)
        {
            var numberToReturn = 0;
            try
            {
                //Rule 0
                if (QuadrantSum(FirstQuadrant) <= 5) { numberToReturn = QuadrantSum(SecondQuadrant) + QuadrantSum(ThirdQuadrant) + QuadrantSum(FourthQuadrant); throw new Exception(); }
                if (QuadrantSum(SecondQuadrant) <= 5) { numberToReturn = QuadrantSum(FirstQuadrant) + QuadrantSum(ThirdQuadrant) + QuadrantSum(FourthQuadrant); throw new Exception(); }
                if (QuadrantSum(ThirdQuadrant) <= 5) { numberToReturn = QuadrantSum(SecondQuadrant) + QuadrantSum(FirstQuadrant) + QuadrantSum(FourthQuadrant); throw new Exception(); }
                if (QuadrantSum(FourthQuadrant) <= 5) { numberToReturn = QuadrantSum(SecondQuadrant) + QuadrantSum(ThirdQuadrant) + QuadrantSum(FirstQuadrant); throw new Exception(); }

                //Rule 1
                if (bomb.GetLitIndicators() == (QuadrantSum(FirstQuadrant) > 8 ? 1 : 0) + (QuadrantSum(SecondQuadrant) > 8 ? 1 : 0) + (QuadrantSum(ThirdQuadrant) > 8 ? 1 : 0) + (QuadrantSum(FourthQuadrant) > 8 ? 1 : 0)) { numberToReturn = bomb.GetBatteries(); throw new Exception(); }

                //Rule 2
                if ((HasLitRow(FirstQuadrant) ? 1 : 0) + (HasLitColumn(FirstQuadrant) ? 1 : 0) + (HasUnlitRow(FirstQuadrant) ? 1 : 0) + (HasUnlitColumn(FirstQuadrant) ? 1 : 0) +
                    (HasLitRow(SecondQuadrant) ? 1 : 0) + (HasLitColumn(SecondQuadrant) ? 1 : 0) + (HasUnlitRow(SecondQuadrant) ? 1 : 0) + (HasUnlitColumn(SecondQuadrant) ? 1 : 0) +
                    (HasLitRow(ThirdQuadrant) ? 1 : 0) + (HasLitColumn(ThirdQuadrant) ? 1 : 0) + (HasUnlitRow(ThirdQuadrant) ? 1 : 0) + (HasUnlitColumn(ThirdQuadrant) ? 1 : 0) +
                    (HasLitRow(FourthQuadrant) ? 1 : 0) + (HasLitColumn(FourthQuadrant) ? 1 : 0) + (HasUnlitRow(FourthQuadrant) ? 1 : 0) + (HasUnlitColumn(FourthQuadrant) ? 1 : 0) == 1)
                {
                    numberToReturn = GetLitUnlitRowColumn(FirstQuadrant);
                    if (numberToReturn == 0) GetLitUnlitRowColumn(SecondQuadrant);
                    if (numberToReturn == 0) GetLitUnlitRowColumn(ThirdQuadrant);
                    if (numberToReturn == 0) GetLitUnlitRowColumn(FourthQuadrant);
                }

                //Rule 3
                if ((QuadrantSum(FirstQuadrant) > 8 ? 1 : -1) + (QuadrantSum(FirstQuadrant) > 8 ? 1 : -1) + (QuadrantSum(FirstQuadrant) > 8 ? 1 : -1) + (QuadrantSum(FirstQuadrant) > 8 ? 1 : -1) < 0) { numberToReturn = ((QuadrantSum(FirstQuadrant) > 8 ? 1 : -1) + (QuadrantSum(FirstQuadrant) > 8 ? 1 : -1) + (QuadrantSum(FirstQuadrant) > 8 ? 1 : -1) + (QuadrantSum(FirstQuadrant) > 8 ? 1 : -1)) * -1; throw new Exception(); }

                //Rule 4
                if (QuadrantSum(FirstQuadrant) + QuadrantSum(SecondQuadrant) + QuadrantSum(ThirdQuadrant) + QuadrantSum(FourthQuadrant) >= 36) { numberToReturn = QuadrantSum(FirstQuadrant) + QuadrantSum(SecondQuadrant) + QuadrantSum(ThirdQuadrant) + QuadrantSum(FourthQuadrant); throw new Exception(); }

                //Rule 5
                if ((QuadrantSum(FirstQuadrant) > 8 ? 1 : -1) + (QuadrantSum(FirstQuadrant) > 8 ? 1 : -1) + (QuadrantSum(FirstQuadrant) > 8 ? 1 : -1) + (QuadrantSum(FirstQuadrant) > 8 ? 1 : -1) > 0)
                {
                    var min = 16 - QuadrantSum(FirstQuadrant);
                    numberToReturn = min;
                    min = 16 - QuadrantSum(SecondQuadrant);
                    numberToReturn = min < numberToReturn ? min : numberToReturn;
                    min = 16 - QuadrantSum(ThirdQuadrant);
                    numberToReturn = min < numberToReturn ? min : numberToReturn;
                    min = 16 - QuadrantSum(FourthQuadrant);
                    numberToReturn = min < numberToReturn ? min : numberToReturn;
                    throw new Exception();
                }

                //Rule 6
                if (16 - QuadrantSum(FirstQuadrant) <= 5) { numberToReturn = 48 - QuadrantSum(SecondQuadrant) + QuadrantSum(ThirdQuadrant) + QuadrantSum(FourthQuadrant); throw new Exception(); }
                if (16 - QuadrantSum(SecondQuadrant) <= 5) { numberToReturn = 48 - QuadrantSum(FirstQuadrant) + QuadrantSum(ThirdQuadrant) + QuadrantSum(FourthQuadrant); throw new Exception(); }
                if (16 - QuadrantSum(ThirdQuadrant) <= 5) { numberToReturn = 48 - QuadrantSum(SecondQuadrant) + QuadrantSum(FirstQuadrant) + QuadrantSum(FourthQuadrant); throw new Exception(); }
                if (16 - QuadrantSum(FourthQuadrant) <= 5) { numberToReturn = 48 - QuadrantSum(SecondQuadrant) + QuadrantSum(ThirdQuadrant) + QuadrantSum(FirstQuadrant); throw new Exception(); }

                //Rule 7
                if (bomb.GetUnlitIndicators() == (QuadrantSum(FirstQuadrant) < 8 ? 1 : 0) + (QuadrantSum(SecondQuadrant) < 8 ? 1 : 0) + (QuadrantSum(ThirdQuadrant) < 8 ? 1 : 0) + (QuadrantSum(FourthQuadrant) < 8 ? 1 : 0)) { numberToReturn = bomb.GetPortsQuantity(); throw new Exception(); }

                //Rule 8
                if (HasLitUnlitSquare(FirstQuadrant)) { numberToReturn = GetSquareCenter(FirstQuadrant); throw new Exception(); }
                if (HasLitUnlitSquare(SecondQuadrant)) { numberToReturn = GetSquareCenter(SecondQuadrant); throw new Exception(); }
                if (HasLitUnlitSquare(ThirdQuadrant)) { numberToReturn = GetSquareCenter(ThirdQuadrant); throw new Exception(); }
                if (HasLitUnlitSquare(FourthQuadrant)) { numberToReturn = GetSquareCenter(FourthQuadrant); throw new Exception(); }

                //Rule 9
                if ((QuadrantSum(FirstQuadrant) > 8 ? 1 : -1) + (QuadrantSum(FirstQuadrant) > 8 ? 1 : -1) + (QuadrantSum(FirstQuadrant) > 8 ? 1 : -1) + (QuadrantSum(FirstQuadrant) > 8 ? 1 : -1) == 0) { numberToReturn = bomb.GetSerialFirstNumberDigit(); throw new Exception(); }
            }
            catch { }

            if (numberToReturn == 0)
            {
                return "Can't solve it.";
            }
            else
            {
                Solved = true;
                return "Press " + ((numberToReturn - 1) % 4 + 1) + ".";
            }
        }

        public override string Command(Bomb bomb, string command)
        {
            command = command.Replace("bitmaps ", "");
            if (QuadrantSum(FirstQuadrant) == 0)
            {
                foreach (var word in command.Split(' '))
                {
                    FirstQuadrant[command.Split(' ').ToList().FindIndex(x => x == word), 0] = word.Contains("1");
                    FirstQuadrant[command.Split(' ').ToList().FindIndex(x => x == word), 1] = word.Contains("2");
                    FirstQuadrant[command.Split(' ').ToList().FindIndex(x => x == word), 2] = word.Contains("3");
                    FirstQuadrant[command.Split(' ').ToList().FindIndex(x => x == word), 3] = word.Contains("4");
                }
                return "First quadrant added.";
            }

            if (QuadrantSum(SecondQuadrant) == 0)
            {
                foreach (var word in command.Split(' '))
                {
                    SecondQuadrant[command.Split(' ').ToList().FindIndex(x => x == word), 0] = word.Contains("1");
                    SecondQuadrant[command.Split(' ').ToList().FindIndex(x => x == word), 1] = word.Contains("2");
                    SecondQuadrant[command.Split(' ').ToList().FindIndex(x => x == word), 2] = word.Contains("3");
                    SecondQuadrant[command.Split(' ').ToList().FindIndex(x => x == word), 3] = word.Contains("4");
                }
                return "Second quadrant added.";
            }

            if (QuadrantSum(ThirdQuadrant) == 0)
            {
                foreach (var word in command.Split(' '))
                {
                    ThirdQuadrant[command.Split(' ').ToList().FindIndex(x => x == word), 0] = word.Contains("1");
                    ThirdQuadrant[command.Split(' ').ToList().FindIndex(x => x == word), 1] = word.Contains("2");
                    ThirdQuadrant[command.Split(' ').ToList().FindIndex(x => x == word), 2] = word.Contains("3");
                    ThirdQuadrant[command.Split(' ').ToList().FindIndex(x => x == word), 3] = word.Contains("4");
                }
                return "Third quadrant added.";
            }

            if (QuadrantSum(FourthQuadrant) == 0)
            {
                foreach (var word in command.Split(' '))
                {
                    FourthQuadrant[command.Split(' ').ToList().FindIndex(x => x == word), 0] = word.Contains("1");
                    FourthQuadrant[command.Split(' ').ToList().FindIndex(x => x == word), 1] = word.Contains("2");
                    FourthQuadrant[command.Split(' ').ToList().FindIndex(x => x == word), 2] = word.Contains("3");
                    FourthQuadrant[command.Split(' ').ToList().FindIndex(x => x == word), 3] = word.Contains("4");
                }
            }

            return Solve(bomb);
        }

        public int QuadrantSum(bool[,] quadrant)
        {
            int count = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    count += quadrant[i, j] ? 1 : 0;
                }
            }
            return count;
        }

        public bool HasLitColumn(bool[,] quadrant)
        {
            for (int i = 0; i < 4; i++)
            {
                if (quadrant[0, i] && quadrant[1, i] && quadrant[2, i] && quadrant[3, i]) return true;
            }
            return false;
        }

        public bool HasLitRow(bool[,] quadrant)
        {
            for (int i = 0; i < 4; i++)
            {
                if (quadrant[i, 0] && quadrant[i, 1] && quadrant[i, 2] && quadrant[i, 3]) return true;
            }
            return false;
        }
        public bool HasUnlitColumn(bool[,] quadrant)
        {
            for (int i = 0; i < 4; i++)
            {
                if (!(quadrant[0, i] && quadrant[1, i] && quadrant[2, i] && quadrant[3, i])) return true;
            }
            return false;
        }

        public bool HasUnlitRow(bool[,] quadrant)
        {
            for (int i = 0; i < 4; i++)
            {
                if (!(quadrant[i, 0] && quadrant[i, 1] && quadrant[i, 2] && quadrant[i, 3])) return true;
            }
            return false;
        }

        public bool HasLitUnlitSquare(bool[,] quadrant)
        {
            var litSquare = true;
            var unlitSquare = true;

            for (int rowThrough = 0; rowThrough < 2; rowThrough++)
            {
                for (int columnThrough = 0; columnThrough < 2; columnThrough++)
                {
                    for (int row = 0; row < 3; row++)
                    {
                        for (int column = 0; column < 3; column++)
                        {
                            if (quadrant[rowThrough + row, columnThrough + column]) unlitSquare = false;
                            else litSquare = true;

                            if (!litSquare && !!unlitSquare) break;
                        }
                        if (!litSquare && !!unlitSquare) break;
                    }
                }
            }

            return litSquare || unlitSquare;
        }

        public int GetLitUnlitRowColumn(bool[,] quadrant)
        {

            for (int i = 0; i < 4; i++)
            {
                if (quadrant[i, 0] && quadrant[i, 1] && quadrant[i, 2] && quadrant[i, 3]) return i + 1;
            }

            for (int i = 0; i < 4; i++)
            {
                if (quadrant[0, i] && quadrant[1, i] && quadrant[2, i] && quadrant[3, i]) return i + 1;
            }
            for (int i = 0; i < 4; i++)
            {
                if (!(quadrant[i, 0] && quadrant[i, 1] && quadrant[i, 2] && quadrant[i, 3])) return i + 1;
            }

            for (int i = 0; i < 4; i++)
            {
                if (!(quadrant[0, i] && quadrant[1, i] && quadrant[2, i] && quadrant[3, i])) return i + 1;
            }
            return 0;
        }

        public int GetSquareCenter(bool[,] quadrant)
        {
            var litSquare = true;
            var unlitSquare = true;

            for (int rowThrough = 0; rowThrough < 2; rowThrough++)
            {
                for (int columnThrough = 0; columnThrough < 2; columnThrough++)
                {
                    for (int row = 0; row < 3; row++)
                    {
                        for (int column = 0; column < 3; column++)
                        {
                            if (quadrant[rowThrough + row, columnThrough + column]) unlitSquare = false;
                            else litSquare = true;

                            if (!litSquare && !!unlitSquare) break;
                        }
                        if (!litSquare && !!unlitSquare) break;
                    }

                    if (litSquare || unlitSquare) return columnThrough + 2;
                }
            }

            return 0;
        }
    }
}
