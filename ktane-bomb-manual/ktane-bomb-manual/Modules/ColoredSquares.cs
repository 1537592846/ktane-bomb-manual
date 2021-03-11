using System.Collections.Generic;

namespace ktane_bomb_manual.Modules
{
    public class ColoredSquares :Module
    {
        private string Color;
        private int Quantity;
        private List<string> Red = new List<string> { "blue", "topmost row", "yellow", "blue", "yellow", "magenta", "green", "magenta", "leftmost column", "green", "red", "leftmost column", "topmost row", "red", "leftmost column" };
        private List<string> Blue = new List<string> { "leftmost column", "green", "magenta", "green", "topmost row", "red", "topmost row", "red", "yellow", "leftmost column", "yellow", "blue", "magenta", "blue", "topmost row"};
        private List<string> Green= new List<string> { "red", "blue", "green", "yellow", "blue", "yellow", "leftmost column", "green", "red", "topmost row", "topmost row", "magenta", "leftmost column", "magenta", "leftmost column" };
        private List<string> Yellow = new List<string> { "yellow", "magenta", "topmost row", "leftmost column", "magenta", "green", "blue", "blue", "green", "red", "leftmost column", "red", "yellow", "topmost row", "topmost row" };
        private List<string> Magenta = new List<string> { "topmost row", "red", "blue", "red", "leftmost column", "leftmost column", "magenta", "yellow", "topmost row", "magenta", "green", "yellow", "blue", "green", "leftmost column" };
        private List<string> Row = new List<string> { "green", "leftmost column", "red", "topmost row", "red", "blue", "yellow", "leftmost column", "magenta", "blue", "magenta", "topmost row", "green", "yellow", "topmost row" };
        private List<string> Column = new List<string> { "magenta", "yellow", "leftmost column", "magenta", "green", "topmost row", "red", "topmost row", "blue", "yellow", "blue", "green", "red", "leftmost column", "leftmost column" };

        public override string Command(Bomb bomb, string command)
        {
            foreach (var word in command.Split(' '))
            {
                if (InternalFunctions.IsNumber(word))
                    Quantity = InternalFunctions.GetNumber(word);
                if (InternalFunctions.IsColor(word))
                    Color = word;
            }
            if (Quantity == 0 || string.IsNullOrEmpty(Color))
                return "Cannot find quantity and color";

            return Solve(bomb);
        }

        public override string Solve(Bomb bomb)
        {
            if (Quantity == 16)
            {
                Solved = true;
                return "Module solved.";
            }
            Color = GetLastClicked()[Quantity-1];
            return "Press " + Color +".";
        }

        public List<string> GetLastClicked()
        {
            switch (Color)
            {
                case "red":return Red;
                case "blue":return Blue;
                case "green":return Green;
                case "yellow":return Yellow;
                case "magenta":return Magenta;
                case "topmost row":return Row;
            }
            return Column;
        }
    }
}