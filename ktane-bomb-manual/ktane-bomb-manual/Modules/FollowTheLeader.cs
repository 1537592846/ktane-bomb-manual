using System;
using System.Collections.Generic;

namespace ktane_bomb_manual.Modules
{
    public class FollowTheLeader : Module
    {
        public Wire StartPosition;
        public bool ReversedOrder;

        public override string Command(Bomb bomb, string command)
        {
            StartPosition = new Wire();
            var positionList = new List<int>() { };
            var colorList = new List<string>();

            foreach (var word in command.Split(' '))
            {
                if (InternalFunctions.IsNumber(word)) positionList.Add(InternalFunctions.GetNumber(word));
                if (InternalFunctions.IsColor(word)) colorList.Add(word);
            }

            if (positionList.Count != colorList.Count || positionList.Count == 0 || colorList.Count == 0)
                return "Different number of colors and positions.";

            var originalStart = StartPosition;

            for (int i = 0; i < positionList.Count - 1; i++)
            {
                StartPosition.Start = positionList[i];
                StartPosition.End = positionList[i + 1 % positionList.Count];
                StartPosition.Color = colorList[i];
                StartPosition.Next = new Wire();
                StartPosition.Next.Previous = StartPosition;
                StartPosition = StartPosition.Next;
            }

            StartPosition.Start = positionList[positionList.Count - 1];
            StartPosition.End = positionList[0];
            StartPosition.Color = colorList[colorList.Count - 1];
            StartPosition.Next = originalStart;
            StartPosition.Next.Previous = StartPosition;
            StartPosition = StartPosition.Next;

            return Solve(bomb);
        }

        public override string Solve(Bomb bomb)
        {
            SetInitialPosition(bomb);

            if (StartPosition == null) return "Cut all the wires on descending numeral order.";

            var result = "Cut wires ";
            var letter = bomb.GetSerialCharacters()[0];

            while (!StartPosition.Resolved)
            {
                if (!StartPosition.Previous.Resolved || (ReversedOrder && !StartPosition.Next.Resolved))
                {
                    result += StartPosition.Start + "-" + StartPosition.End + ", ";
                    StartPosition.Resolved = true;
                    StartPosition.ShouldBeCut = true;
                    if (ReversedOrder)
                    {
                        StartPosition = StartPosition.Previous;
                    }
                    else
                    {
                        StartPosition = StartPosition.Next;
                    }
                    continue;
                }

                switch (letter.ToUpper())
                {
                    case "A":
                    case "N":
                        {
                            if (StartPosition.Previous.Color != "yellow" && StartPosition.Previous.Color != "blue" && StartPosition.Previous.Color != "green")
                            {
                                StartPosition.ShouldBeCut = true;
                                result += StartPosition.Start + "-" + StartPosition.End + ", ";
                            }
                            if (ReversedOrder)
                            {
                                StartPosition = StartPosition.Previous;
                                var number = InternalFunctions.GetNumberFromLetter(letter) - 1;
                                if (number == -1) number = 26;
                                letter = InternalFunctions.GetLetterFromNumber(number);
                            }
                            else
                            {
                                StartPosition = StartPosition.Next;
                                var number = InternalFunctions.GetNumberFromLetter(letter) + 1;
                                if (number == 27) number = 1;
                                letter = InternalFunctions.GetLetterFromNumber(number);
                            }
                            break;
                        }
                    case "B":
                    case "O":
                        {
                            if (StartPosition.Start % 2 == 0)
                            {
                                result += StartPosition.Start + "-" + StartPosition.End + ", ";
                                StartPosition.ShouldBeCut = true;
                            }
                            if (ReversedOrder)
                            {
                                StartPosition = StartPosition.Previous;
                                var number = InternalFunctions.GetNumberFromLetter(letter) - 1;
                                if (number == -1) number = 26;
                                letter = InternalFunctions.GetLetterFromNumber(number);
                            }
                            else
                            {
                                StartPosition = StartPosition.Next;
                                var number = InternalFunctions.GetNumberFromLetter(letter) + 1;
                                if (number == 27) number = 1;
                                letter = InternalFunctions.GetLetterFromNumber(number);
                            }
                            break;
                        }
                    case "C":
                    case "P":
                        {
                            if (StartPosition.Previous.ShouldBeCut)
                            {
                                result += StartPosition.Start + "-" + StartPosition.End + ", ";
                                StartPosition.ShouldBeCut = true;
                            }
                            if (ReversedOrder)
                            {
                                StartPosition = StartPosition.Previous;
                                var number = InternalFunctions.GetNumberFromLetter(letter) - 1;
                                if (number == -1) number = 26;
                                letter = InternalFunctions.GetLetterFromNumber(number);
                            }
                            else
                            {
                                StartPosition = StartPosition.Next;
                                var number = InternalFunctions.GetNumberFromLetter(letter) + 1;
                                if (number == 27) number = 1;
                                letter = InternalFunctions.GetLetterFromNumber(number);
                            }
                            break;
                        }
                    case "D":
                    case "Q":
                        {
                            if (StartPosition.Previous.Color == "red" || StartPosition.Previous.Color == "blue" || StartPosition.Previous.Color == "black")
                            {
                                result += StartPosition.Start + "-" + StartPosition.End + ", ";
                                StartPosition.ShouldBeCut = true;
                            }
                            if (ReversedOrder)
                            {
                                StartPosition = StartPosition.Previous;
                                var number = InternalFunctions.GetNumberFromLetter(letter) - 1;
                                if (number == -1) number = 26;
                                letter = InternalFunctions.GetLetterFromNumber(number);
                            }
                            else
                            {
                                StartPosition = StartPosition.Next;
                                var number = InternalFunctions.GetNumberFromLetter(letter) + 1;
                                if (number == 27) number = 1;
                                letter = InternalFunctions.GetLetterFromNumber(number);
                            }
                            break;
                        }
                    case "E":
                    case "R":
                        {
                            var list = new List<string>();
                            if (!list.Exists(x => x == StartPosition.Previous.Previous.Previous.Color)) list.Add(StartPosition.Previous.Previous.Previous.Color);
                            if (!list.Exists(x => x == StartPosition.Previous.Previous.Color)) list.Add(StartPosition.Previous.Previous.Color);
                            if (!list.Exists(x => x == StartPosition.Previous.Color)) list.Add(StartPosition.Previous.Color);
                            if (list.Count == 2)
                            {
                                result += StartPosition.Start + "-" + StartPosition.End + ", ";
                                StartPosition.ShouldBeCut = true;
                            }
                            if (ReversedOrder)
                            {
                                StartPosition = StartPosition.Previous;
                                var number = InternalFunctions.GetNumberFromLetter(letter) - 1;
                                if (number == -1) number = 26;
                                letter = InternalFunctions.GetLetterFromNumber(number);
                            }
                            else
                            {
                                StartPosition = StartPosition.Next;
                                var number = InternalFunctions.GetNumberFromLetter(letter) + 1;
                                if (number == 27) number = 1;
                                letter = InternalFunctions.GetLetterFromNumber(number);
                            }
                            break;
                        }
                    case "F":
                    case "S":
                        {
                            if ((StartPosition.Previous.Previous.Color == StartPosition.Color && StartPosition.Previous.Color != StartPosition.Color) || (StartPosition.Previous.Color == StartPosition.Color && StartPosition.Previous.Previous.Color != StartPosition.Color))
                            {
                                result += StartPosition.Start + "-" + StartPosition.End + ", ";
                                StartPosition.ShouldBeCut = true;
                            }
                            if (ReversedOrder)
                            {
                                StartPosition = StartPosition.Previous;
                                var number = InternalFunctions.GetNumberFromLetter(letter) - 1;
                                if (number == -1) number = 26;
                                letter = InternalFunctions.GetLetterFromNumber(number);
                            }
                            else
                            {
                                StartPosition = StartPosition.Next;
                                var number = InternalFunctions.GetNumberFromLetter(letter) + 1;
                                if (number == 27) number = 1;
                                letter = InternalFunctions.GetLetterFromNumber(number);
                            }
                            break;
                        }
                    case "G":
                    case "T":
                        {
                            if (StartPosition.Previous.Color == "yellow" || StartPosition.Previous.Color == "white" || StartPosition.Previous.Color == "green")
                            {
                                result += StartPosition.Start + "-" + StartPosition.End + ", ";
                                StartPosition.ShouldBeCut = true;
                            }
                            if (ReversedOrder)
                            {
                                StartPosition = StartPosition.Previous;
                                var number = InternalFunctions.GetNumberFromLetter(letter) - 1;
                                if (number == -1) number = 26;
                                letter = InternalFunctions.GetLetterFromNumber(number);
                            }
                            else
                            {
                                StartPosition = StartPosition.Next;
                                var number = InternalFunctions.GetNumberFromLetter(letter) + 1;
                                if (number == 27) number = 1;
                                letter = InternalFunctions.GetLetterFromNumber(number);
                            }
                            break;
                        }
                    case "H":
                    case "U":
                        {
                            if (!StartPosition.Previous.ShouldBeCut)
                            {
                                result += StartPosition.Start + "-" + StartPosition.End + ", ";
                                StartPosition.ShouldBeCut = true;
                            }
                            if (ReversedOrder)
                            {
                                StartPosition = StartPosition.Previous;
                                var number = InternalFunctions.GetNumberFromLetter(letter) - 1;
                                if (number == -1) number = 26;
                                letter = InternalFunctions.GetLetterFromNumber(number);
                            }
                            else
                            {
                                StartPosition = StartPosition.Next;
                                var number = InternalFunctions.GetNumberFromLetter(letter) + 1;
                                if (number == 27) number = 1;
                                letter = InternalFunctions.GetLetterFromNumber(number);
                            }
                            break;
                        }
                    case "I":
                    case "V":
                        {
                            if (StartPosition.Previous.Start + 1 != StartPosition.Start)
                            {
                                result += StartPosition.Start + "-" + StartPosition.End + ", ";
                                StartPosition.ShouldBeCut = true;
                            }
                            if (ReversedOrder)
                            {
                                StartPosition = StartPosition.Previous;
                                var number = InternalFunctions.GetNumberFromLetter(letter) - 1;
                                if (number == -1) number = 26;
                                letter = InternalFunctions.GetLetterFromNumber(number);
                            }
                            else
                            {
                                StartPosition = StartPosition.Next;
                                var number = InternalFunctions.GetNumberFromLetter(letter) + 1;
                                if (number == 27) number = 1;
                                letter = InternalFunctions.GetLetterFromNumber(number);
                            }
                            break;
                        }
                    case "J":
                    case "W":
                        {
                            if (StartPosition.Previous.Color != "white" || StartPosition.Previous.Color != "black" || StartPosition.Previous.Color != "red")
                            {
                                result += StartPosition.Start + "-" + StartPosition.End + ", ";
                                StartPosition.ShouldBeCut = true;
                            }
                            if (ReversedOrder)
                            {
                                StartPosition = StartPosition.Previous;
                                var number = InternalFunctions.GetNumberFromLetter(letter) - 1;
                                if (number == -1) number = 26;
                                letter = InternalFunctions.GetLetterFromNumber(number);
                            }
                            else
                            {
                                StartPosition = StartPosition.Next;
                                var number = InternalFunctions.GetNumberFromLetter(letter) + 1;
                                if (number == 27) number = 1;
                                letter = InternalFunctions.GetLetterFromNumber(number);
                            }
                            break;
                        }
                    case "K":
                    case "X":
                        {
                            if (StartPosition.Previous.Previous.Color != StartPosition.Previous.Color)
                            {
                                result += StartPosition.Start + "-" + StartPosition.End + ", ";
                                StartPosition.ShouldBeCut = true;
                            }
                            if (ReversedOrder)
                            {
                                StartPosition = StartPosition.Previous;
                                var number = InternalFunctions.GetNumberFromLetter(letter) - 1;
                                if (number == -1) number = 26;
                                letter = InternalFunctions.GetLetterFromNumber(number);
                            }
                            else
                            {
                                StartPosition = StartPosition.Next;
                                var number = InternalFunctions.GetNumberFromLetter(letter) + 1;
                                if (number == 27) number = 1;
                                letter = InternalFunctions.GetLetterFromNumber(number);
                            }
                            break;
                        }
                    case "L":
                    case "Y":
                        {
                            if (!(StartPosition.Previous.End <= 6))
                            {
                                result += StartPosition.Start + "-" + StartPosition.End + ", ";
                                StartPosition.ShouldBeCut = true;
                            }
                            if (ReversedOrder)
                            {
                                StartPosition = StartPosition.Previous;
                                var number = InternalFunctions.GetNumberFromLetter(letter) - 1;
                                if (number == -1) number = 26;
                                letter = InternalFunctions.GetLetterFromNumber(number);
                            }
                            else
                            {
                                StartPosition = StartPosition.Next;
                                var number = InternalFunctions.GetNumberFromLetter(letter) + 1;
                                if (number == 27) number = 1;
                                letter = InternalFunctions.GetLetterFromNumber(number);
                            }
                            break;
                        }
                    case "M":
                    case "Z":
                        {
                            var list = new List<string> { "white", "black" };
                            if (!list.Contains(StartPosition.Previous.Previous.Color) || !list.Contains(StartPosition.Previous.Color))
                            {
                                result += StartPosition.Start + "-" + StartPosition.End + ", ";
                                StartPosition.ShouldBeCut = true;
                            }
                            if (ReversedOrder)
                            {
                                StartPosition = StartPosition.Previous;
                                var number = InternalFunctions.GetNumberFromLetter(letter) - 1;
                                if (number == -1) number = 26;
                                letter = InternalFunctions.GetLetterFromNumber(number);
                            }
                            else
                            {
                                StartPosition = StartPosition.Next;
                                var number = InternalFunctions.GetNumberFromLetter(letter) + 1;
                                if (number == 27) number = 1;
                                letter = InternalFunctions.GetLetterFromNumber(number);
                            }
                            break;
                        }
                }

                StartPosition.Previous.Resolved = true;
            }
            Solved = true;
            return result.Substring(0, result.Length - 2) + ".";
        }

        public void SetInitialPosition(Bomb bomb)
        {
            var position = StartPosition;
            if (bomb.HasPort("rj"))
            {
                while (position.Start != 4) position = position.Next;
                if (position.End == 5)
                {
                    while (StartPosition.Start != 4) StartPosition = StartPosition.Next;
                    return;
                }
            }

            position = StartPosition;
            while (position.Start != bomb.GetBatteries() && position.End != 1) position = position.Next;
            if (position.End != 1)
            {
                while (StartPosition.Start != bomb.GetBatteries()) StartPosition = StartPosition.Next;
                return;
            }

            position = StartPosition;
            var bombNumber = bomb.GetSerialFirstNumberDigit();
            while (position.Start != bombNumber && position.End != 1) position = position.Next;
            if (position.End != 1)
            {
                while (StartPosition.Start != bomb.GetBatteries()) StartPosition = StartPosition.Next;
                return;
            }

            if (bomb.HasLitIndicator("clr"))
            {
                StartPosition = null;
                return;
            }

            while (StartPosition.Previous.Start < StartPosition.Start) StartPosition = StartPosition.Previous;
            ReversedOrder = true;
        }
    }

    public class Wire
    {
        public string Color;
        public int Start;
        public int End;
        public bool Resolved;
        public bool ShouldBeCut;
        public Wire Next;
        public Wire Previous;
    }
}
