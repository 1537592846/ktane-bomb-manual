using System.Collections.Generic;

namespace ktane_bomb_manual.Modules
{
    public class Chess : Module
    {
        public Chess()
        {
            Chessboard = new Tile[6, 6]
            {
                {
                    new Tile(0,0),
                    new Tile(0,1),
                    new Tile(0,2),
                    new Tile(0,3),
                    new Tile(0,4),
                    new Tile(0,5),
                },
                {
                    new Tile(1,0),
                    new Tile(1,1),
                    new Tile(1,2),
                    new Tile(1,3),
                    new Tile(1,4),
                    new Tile(1,5),
                },
                {
                    new Tile(2,0),
                    new Tile(2,1),
                    new Tile(2,2),
                    new Tile(2,3),
                    new Tile(2,4),
                    new Tile(2,5),
                },
                {
                    new Tile(3,0),
                    new Tile(3,1),
                    new Tile(3,2),
                    new Tile(3,3),
                    new Tile(3,4),
                    new Tile(3,5),
                },
                {
                    new Tile(4,0),
                    new Tile(4,1),
                    new Tile(4,2),
                    new Tile(4,3),
                    new Tile(4,4),
                    new Tile(4,5),
                },
                {
                    new Tile(5,0),
                    new Tile(5,1),
                    new Tile(5,2),
                    new Tile(5,3),
                    new Tile(5,4),
                    new Tile(5,5),
                },
            };
            Positions = new List<string>();
        }

        public Tile[,] Chessboard;
        public List<string> Positions;

        public override string Solve(Bomb bomb)
        {
            DefinePosition4();
            DefinePosition5();
            DefinePosition2(bomb.HasSerialLastDigitOdd());
            DefinePosition1();
            DefinePosition3();
            DefinePosition6();

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (!Chessboard[i, j].UnderAttack)
                    {
                        Solved = true;
                        return "The position is " + InternalFunctions.GetPhoneticLetterFromLetter(InternalFunctions.GetLetterFromNumber(i + 1)) + " " + (j + 1) + ".";
                    }
                }
            }

            return "";
        }

        public override string Command(Bomb bomb, string command)
        {
            var row = -1;
            var column = -1;

            foreach (var word in command.Split(' '))
            {
                if (InternalFunctions.GetLetterFromPhoneticLetter(word) != "") column = InternalFunctions.GetNumberFromLetter(InternalFunctions.GetLetterFromPhoneticLetter(word)) - 1;
                if (InternalFunctions.IsNumber(word)) row = int.Parse(word) - 1;
                if (row != -1 && column != -1)
                {
                    Positions.Add(InternalFunctions.GetPhoneticLetterFromLetter(InternalFunctions.GetLetterFromNumber(column + 1)) + '-' + (row + 1));
                    row = -1;
                    column = -1;
                }
            }

            return Solve(bomb);
        }

        public void DefinePosition1()
        {
            int column = InternalFunctions.GetNumberFromLetter(InternalFunctions.GetLetterFromPhoneticLetter(Positions[0].Split('-')[0])) - 1;
            int row = int.Parse(Positions[0].Split('-')[1]) - 1;
            int column5 = InternalFunctions.GetNumberFromLetter(InternalFunctions.GetLetterFromPhoneticLetter(Positions[4].Split('-')[0])) - 1;
            int row5 = int.Parse(Positions[4].Split('-')[1]) - 1;

            if (Chessboard[row5, column5].Piece == "queen") Chessboard[row, column].Piece = "king";
            else Chessboard[row, column].Piece = "bishop";

            ChangeOtherTiles(row, column, Chessboard[row, column].Piece);
        }

        public void DefinePosition2(bool bombSerialIsOdd)
        {
            int column = InternalFunctions.GetNumberFromLetter(InternalFunctions.GetLetterFromPhoneticLetter(Positions[1].Split('-')[0])) - 1;
            int row = int.Parse(Positions[1].Split('-')[1]) - 1;

            if (bombSerialIsOdd) Chessboard[row, column].Piece = "rook";
            else Chessboard[row, column].Piece = "knight";

            ChangeOtherTiles(row, column, Chessboard[row, column].Piece);
        }

        public void DefinePosition3()
        {
            int column = InternalFunctions.GetNumberFromLetter(InternalFunctions.GetLetterFromPhoneticLetter(Positions[2].Split('-')[0])) - 1;
            int row = int.Parse(Positions[2].Split('-')[1]) - 1;

            int count = 0;

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (Chessboard[i, j].Piece == "rook") count++;
                }
            }

            if (count < 2) Chessboard[row, column].Piece = "queen";
            else Chessboard[row, column].Piece = "king";

            ChangeOtherTiles(row, column, Chessboard[row, column].Piece);
        }

        public void DefinePosition4()
        {
            int column = InternalFunctions.GetNumberFromLetter(InternalFunctions.GetLetterFromPhoneticLetter(Positions[3].Split('-')[0])) - 1;
            int row = int.Parse(Positions[3].Split('-')[1]) - 1;

            Chessboard[row, column].Piece = "rook";

            ChangeOtherTiles(row, column, Chessboard[row, column].Piece);
        }

        public void DefinePosition5()
        {
            int column = InternalFunctions.GetNumberFromLetter(InternalFunctions.GetLetterFromPhoneticLetter(Positions[4].Split('-')[0])) - 1;
            int row = int.Parse(Positions[4].Split('-')[1]) - 1;

            if (Chessboard[row, column].WhiteSpace) Chessboard[row, column].Piece = "queen";
            else Chessboard[row, column].Piece = "rook";

            ChangeOtherTiles(row, column, Chessboard[row, column].Piece);
        }

        public void DefinePosition6()
        {
            int column = InternalFunctions.GetNumberFromLetter(InternalFunctions.GetLetterFromPhoneticLetter(Positions[5].Split('-')[0])) - 1;
            int row = int.Parse(Positions[5].Split('-')[1]) - 1;
            int queenCount = 0;
            int knightCount = 0;

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (Chessboard[i, j].Piece == "queen") queenCount++;
                    if (Chessboard[i, j].Piece == "knight") knightCount++;
                }
            }

            if (queenCount == 0) Chessboard[row, column].Piece = "queen";
            else if (knightCount == 0) Chessboard[row, column].Piece = "knight";
            else Chessboard[row, column].Piece = "bishop";

            ChangeOtherTiles(row, column, Chessboard[row, column].Piece);
        }

        public void ChangeOtherTiles(int row, int column, string piece)
        {
            switch (piece)
            {
                case "king":
                    {
                        Chessboard[row - 1, column - 1].UnderAttack = true;
                        Chessboard[row - 1, column].UnderAttack = true;
                        Chessboard[row - 1, column + 2].UnderAttack = true;
                        Chessboard[row, column - 1].UnderAttack = true;
                        Chessboard[row, column].UnderAttack = true;
                        Chessboard[row, column + 1].UnderAttack = true;
                        Chessboard[row + 1, column - 1].UnderAttack = true;
                        Chessboard[row + 1, column].UnderAttack = true;
                        Chessboard[row + 1, column + 1].UnderAttack = true;
                        break;
                    }
                case "queen":
                    {
                        ChangeOtherTiles(row, column, "rook");
                        ChangeOtherTiles(row, column, "bishop");
                        break;
                    }
                case "rook":
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            for (int j = 0; j < 6; j++)
                            {
                                if (i == row || j == column) Chessboard[i, j].UnderAttack = true; ;
                            }
                        }
                        break;
                    }
                case "bishop":
                    {
                        for (int i = 0; i < 6; i++)
                        {
                            for (int j = 0; j < 6; j++)
                            {
                                if (i == row && j == column) Chessboard[i, j].UnderAttack = true; ;
                                if (i - row == j - column) Chessboard[i, j].UnderAttack = true;
                                if (i + j == row + column) Chessboard[i, j].UnderAttack = true;
                            }
                        }
                        break;
                    }
                case "knight":
                    {
                        try { Chessboard[row, column].UnderAttack = true; } catch { }
                        try { Chessboard[row - 2, column - 1].UnderAttack = true; } catch { }
                        try { Chessboard[row - 2, column + 1].UnderAttack = true; } catch { }
                        try { Chessboard[row - 1, column - 2].UnderAttack = true; } catch { }
                        try { Chessboard[row - 1, column + 2].UnderAttack = true; } catch { }
                        try { Chessboard[row + 1, column - 2].UnderAttack = true; } catch { }
                        try { Chessboard[row + 1, column + 2].UnderAttack = true; } catch { }
                        try { Chessboard[row + 2, column - 1].UnderAttack = true; } catch { }
                        try { Chessboard[row + 2, column + 1].UnderAttack = true; } catch { }
                        break;
                    }
            }
        }
    }

    public class Tile
    {
        public Tile(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public int Row { get; set; }
        public int Column { get; set; }
        public string Piece { get; set; }
        public bool WhiteSpace { get { return Row % 2 == 0 ^ Column % 2 == 0; } }
        public bool BlackSpace { get { return !WhiteSpace; } }
        public bool UnderAttack { get; set; }
    }
}
