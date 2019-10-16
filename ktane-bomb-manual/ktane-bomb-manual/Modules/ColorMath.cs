using System.Collections.Generic;

namespace ktane_bomb_manual.Modules
{
    public class ColorMath : Module
    {
        public ColorMath()
        {
            RightSideColors = new List<string>();
            LeftSideColors = new List<string>();
        }

        public List<string> RightSideColors;
        public List<string> LeftSideColors;
        public string OperationType;
        public string OperationColor;

        public override string Solve(Bomb bomb)
        {
            int leftSide = 0;
            switch (LeftSideColors[0])
            {
                case "magenta": break;
                case "green": leftSide += 1000; break;
                case "purple": leftSide += 2000; break;
                case "grey":
                case "gray": leftSide += 3000; break;
                case "yellow": leftSide += 4000; break;
                case "orange": leftSide += 5000; break;
                case "blue": leftSide += 6000; break;
                case "black": leftSide += 7000; break;
                case "red": leftSide += 8000; break;
                case "white": leftSide += 9000; break;
            }
            switch (LeftSideColors[1])
            {
                case "red": break;
                case "green": leftSide += 100; break;
                case "black": leftSide += 200; break;
                case "white": leftSide += 300; break;
                case "yellow": leftSide += 400; break;
                case "orange": leftSide += 500; break;
                case "magenta": leftSide += 600; break;
                case "grey":
                case "gray": leftSide += 700; break;
                case "blue": leftSide += 800; break;
                case "purple": leftSide += 900; break;
            }
            switch (LeftSideColors[2])
            {
                case "white": break;
                case "green": leftSide += 10; break;
                case "magenta": leftSide += 20; break;
                case "orange": leftSide += 30; break;
                case "blue": leftSide += 40; break;
                case "red": leftSide += 50; break;
                case "black": leftSide += 60; break;
                case "yellow": leftSide += 70; break;
                case "gray":
                case "grey": leftSide += 80; break;
                case "purple": leftSide += 90; break;
            }
            switch (LeftSideColors[3])
            {
                case "gray":
                case "grey": break;
                case "red": leftSide += 1; break;
                case "black": leftSide += 2; break;
                case "orange": leftSide += 3; break;
                case "white": leftSide += 4; break;
                case "yellow": leftSide += 5; break;
                case "blue": leftSide += 6; break;
                case "purple": leftSide += 7; break;
                case "green": leftSide += 8; break;
                case "magenta": leftSide += 9; break;
            }

            if (OperationColor == "green")
            {
                int rightSide = 0;
                switch (RightSideColors[0])
                {
                    case "blue": break;
                    case "grey":
                    case "gray": rightSide += 1000; break;
                    case "black": rightSide += 2000; break;
                    case "white": rightSide += 3000; break;
                    case "yellow": rightSide += 4000; break;
                    case "purple": rightSide += 5000; break;
                    case "green": rightSide += 6000; break;
                    case "magenta": rightSide += 7000; break;
                    case "orange": rightSide += 8000; break;
                    case "red": rightSide += 9000; break;
                }
                switch (RightSideColors[1])
                {
                    case "yellow": break;
                    case "grey":
                    case "gray": rightSide += 100; break;
                    case "blue": rightSide += 200; break;
                    case "magenta": rightSide += 300; break;
                    case "red": rightSide += 400; break;
                    case "white": rightSide += 500; break;
                    case "black": rightSide += 600; break;
                    case "orange": rightSide += 700; break;
                    case "purple": rightSide += 800; break;
                    case "green": rightSide += 900; break;
                }
                switch (RightSideColors[2])
                {
                    case "green": break;
                    case "black": rightSide += 10; break;
                    case "white": rightSide += 20; break;
                    case "orange": rightSide += 30; break;
                    case "yellow": rightSide += 40; break;
                    case "blue": rightSide += 50; break;
                    case "purplw": rightSide += 60; break;
                    case "magenta": rightSide += 70; break;
                    case "gray":
                    case "grey": rightSide += 80; break;
                    case "red": rightSide += 90; break;
                }
                switch (RightSideColors[3])
                {
                    case "black": break;
                    case "orange": rightSide += 1; break;
                    case "purple": rightSide += 2; break;
                    case "gray":
                    case "grey": rightSide += 3; break;
                    case "green": rightSide += 4; break;
                    case "blue": rightSide += 5; break;
                    case "magenta": rightSide += 6; break;
                    case "red": rightSide += 7; break;
                    case "white": rightSide += 8; break;
                    case "yellow": rightSide += 9; break;
                }
                Solved = true;
                return Operation(leftSide, rightSide);
            }
            else
            {
                int asmdNumber = 0;
                switch (bomb.GetBatteries())
                {
                    case 0:
                    case 1:
                        {
                            asmdNumber += bomb.GetSerialFirstNumberDigit();
                            asmdNumber *= 10;
                            asmdNumber += bomb.GetUnlitIndicators();
                            asmdNumber *= 10;
                            asmdNumber += 9;
                            asmdNumber *= 10;
                            asmdNumber += bomb.GetPortsQuantity("rj");
                            break;
                        }
                    case 2:
                    case 3:
                        {
                            asmdNumber += bomb.GetPortsQuantity("ps2");
                            asmdNumber *= 10;
                            asmdNumber += bomb.GetManyCharactersInSerial();
                            asmdNumber *= 10;
                            asmdNumber += bomb.GetSerialLastNumberDigit();
                            break;
                        }
                    case 4:
                    case 5:
                        {
                            asmdNumber += bomb.GetSerialVowelsQuantity();
                            asmdNumber *= 10;
                            asmdNumber += bomb.GetBatteriesHolders();
                            asmdNumber *= 10;
                            asmdNumber += bomb.GetPortsQuantity("serial");
                            asmdNumber *= 10;
                            asmdNumber += 4;
                            break;
                        }
                    default:
                        {
                            asmdNumber += bomb.GetPortsQuantity("dvi");
                            asmdNumber *= 10;
                            asmdNumber += 5;
                            asmdNumber *= 10;
                            asmdNumber += bomb.GetSerialConsonantsQuantity();
                            asmdNumber *= 10;
                            asmdNumber += bomb.GetLitIndicators();
                            break;
                        }
                }
                Solved = true;
                return Operation(leftSide, asmdNumber);
            }
        }

        public override string Command(Bomb bomb, string command)
        {
            command = command.Replace("color math", "").Trim();
            foreach (var word in command.Split(' '))
            {
                if (LeftSideColors .Count != 4) { LeftSideColors .Add(word); continue; }
                if (string.IsNullOrWhiteSpace(OperationColor) || string.IsNullOrWhiteSpace(OperationType))
                {
                    if (word == "addiction" || word == "subtraction" || word == "multiplication" || word == "division") OperationType = word;
                    else OperationColor = word;
                    continue;
                }
                RightSideColors.Add(word);
            }

            return Solve(bomb);
        }

        public string Operation(int left, int right)
        {
            string message = "The order is ";

            uint endResult = 0;
            switch (OperationType)
            {
                case "addiction": endResult = (uint)(left + right) % 10000; break;
                case "subtraction": endResult = (uint)(left - right); break;
                case "multiplication": endResult = (uint)(left * right) % 10000; break;
                case "division": endResult = (uint)(left / right); break;
            }

            var textEndResult = "000" + endResult;
            textEndResult = textEndResult.Remove(0, textEndResult.Length - 4);

            switch (textEndResult[0])
            {
                case '0': message += "gray, "; break;
                case '1': message += "green, "; break;
                case '2': message += "orange, "; break;
                case '3': message += "white, "; break;
                case '4': message += "purple, "; break;
                case '5': message += "blue, "; break;
                case '6': message += "magenta, "; break;
                case '7': message += "black, "; break;
                case '8': message += "yellow, "; break;
                case '9': message += "red, "; break;
            }
            switch (textEndResult[1])
            {
                case '0': message += "blue, "; break;
                case '1': message += "green, "; break;
                case '2': message += "black, "; break;
                case '3': message += "purple, "; break;
                case '4': message += "magenta, "; break;
                case '5': message += "red, "; break;
                case '6': message += "gray, "; break;
                case '7': message += "yellow, "; break;
                case '8': message += "orange, "; break;
                case '9': message += "white, "; break;
            }
            switch (textEndResult[2])
            {
                case '0': message += "magenta, "; break;
                case '1': message += "yellow, "; break;
                case '2': message += "blue, "; break;
                case '3': message += "gray, "; break;
                case '4': message += "red, "; break;
                case '5': message += "black, "; break;
                case '6': message += "green, "; break;
                case '7': message += "purple, "; break;
                case '8': message += "orange, "; break;
                case '9': message += "white, "; break;
            }
            switch (textEndResult[3])
            {
                case '0': message += "gray."; break;
                case '1': message += "blue."; break;
                case '2': message += "purple."; break;
                case '3': message += "red."; break;
                case '4': message += "yellow."; break;
                case '5': message += "magenta."; break;
                case '6': message += "black."; break;
                case '7': message += "orange."; break;
                case '8': message += "green."; break;
                case '9': message += "white."; break;
            }

            return message;
        }
    }
}