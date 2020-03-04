using System.Collections.Generic;
using System.Linq;

namespace ktane_bomb_manual.Modules
{
    public class Microcontrollers : Module
    {
        string Type = "";
        string Serial = "";
        int PinQuantity;
        int PinNumber;
        int PinsSolved = 0;
        List<string> VCC = new List<string> { "Yellow.", "Yellow.", "Red.", "Red.", "Green." };
        List<string> AIN = new List<string> { "Magenta.", "Red.", "Magenta.", "Blue.", "Red." };
        List<string> DIN = new List<string> { "Green.", "Magenta.", "Green.", "Yellow.", "Yellow." };
        List<string> PWM = new List<string> { "Blue.", "Green.", "Blue.", "Green.", "Blue." };
        List<string> RST = new List<string> { "Red.", "Blue.", "Yellow.", "Magenta.", "Magenta." };

        public override string Command(Bomb bomb, string command)
        {
            if (command.Contains("serial"))
            {
                foreach (var word in command.Split(' '))
                {
                    Serial += InternalFunctions.GetLetterFromPhoneticLetter(word).ToUpper();
                    Serial += InternalFunctions.GetNumber(word) == -1 ? "" : InternalFunctions.GetNumber(word).ToString();
                }
                return "Serial added.";
            }
            if (command.Contains("type"))
            {
                if (command.Contains("strk")) Type = "STRK";
                if (command.Contains("leds")) Type = "LEDS";
                if (command.Contains("cntd")) Type = "CNTD";
                if (command.Contains("expl")) Type = "EXPL";

                if (Type != "") return "Type added.";
            }
            foreach (var word in command.Split(' '))
            {
                if (InternalFunctions.IsNumber(word))
                {
                    if (command.Contains("pins"))
                    {
                        PinQuantity = InternalFunctions.GetNumber(word);
                        return "Pin quantity added.";
                    }
                    else
                    {
                        PinNumber = InternalFunctions.GetNumber(word);
                        return Solve(bomb);
                    }
                }
            }
            return "Cannot resolve, try again.";
        }

        public override string Solve(Bomb bomb)
        {
            PinsSolved++;

            if (PinsSolved == PinQuantity)
                Solved = true;

            switch (Type + PinQuantity)
            {
                case "STRK6":
                    {
                        switch (PinNumber)
                        {
                            case 1: return GetColor(bomb, "AIN");
                            case 2: return GetColor(bomb, "VCC");
                            case 3: return GetColor(bomb, "RST");
                            case 4: return GetColor(bomb, "DIN");
                            case 5: return GetColor(bomb, "PWN");
                            case 6: return GetColor(bomb, "GND");
                        }
                        break;
                    }
                case "STRK8":
                    {
                        switch (PinNumber)
                        {
                            case 1: return GetColor(bomb, "AIN");
                            case 2: return GetColor(bomb, "PWN");
                            case 3: return GetColor(bomb, "GND");
                            case 4: return GetColor(bomb, "DIN");
                            case 5: return GetColor(bomb, "VCC");
                            case 6: return GetColor(bomb, "GND");
                            case 7: return GetColor(bomb, "RST");
                            case 8: return GetColor(bomb, "GND");
                        }
                        break;
                    }
                case "STRK10":
                    {
                        switch (PinNumber)
                        {
                            case 1: return GetColor(bomb, "GND");
                            case 2: return GetColor(bomb, "GND");
                            case 3: return GetColor(bomb, "GND");
                            case 4: return GetColor(bomb, "GND");
                            case 5: return GetColor(bomb, "AIN");
                            case 6: return GetColor(bomb, "DIN");
                            case 7: return GetColor(bomb, "GND");
                            case 8: return GetColor(bomb, "VCC");
                            case 9: return GetColor(bomb, "RST");
                            case 10: return GetColor(bomb, "PWM");
                        }
                        break;
                    }
                case "LEDS6":
                    {
                        switch (PinNumber)
                        {
                            case 1: return GetColor(bomb, "PWN");
                            case 2: return GetColor(bomb, "RST");
                            case 3: return GetColor(bomb, "VCC");
                            case 4: return GetColor(bomb, "DIN");
                            case 5: return GetColor(bomb, "AIN");
                            case 6: return GetColor(bomb, "GND");
                        }
                        break;
                    }
                case "LEDS8":
                    {
                        switch (PinNumber)
                        {
                            case 1: return GetColor(bomb, "PWM");
                            case 2: return GetColor(bomb, "DIN");
                            case 3: return GetColor(bomb, "VCC");
                            case 4: return GetColor(bomb, "GND");
                            case 5: return GetColor(bomb, "AIN");
                            case 6: return GetColor(bomb, "GND");
                            case 7: return GetColor(bomb, "RST");
                            case 8: return GetColor(bomb, "GND");
                        }
                        break;
                    }
                case "LEDS10":
                    {
                        switch (PinNumber)
                        {
                            case 1: return GetColor(bomb, "PWM");
                            case 2: return GetColor(bomb, "AIN");
                            case 3: return GetColor(bomb, "DIN");
                            case 4: return GetColor(bomb, "GND");
                            case 5: return GetColor(bomb, "GND");
                            case 6: return GetColor(bomb, "GND");
                            case 7: return GetColor(bomb, "GND");
                            case 8: return GetColor(bomb, "RST");
                            case 9: return GetColor(bomb, "VCC");
                            case 10: return GetColor(bomb, "GND");
                        }
                        break;
                    }
                case "CNTD6":
                    {
                        switch (PinNumber)
                        {
                            case 1: return GetColor(bomb, "GND");
                            case 2: return GetColor(bomb, "AIN");
                            case 3: return GetColor(bomb, "PWM");
                            case 4: return GetColor(bomb, "VCC");
                            case 5: return GetColor(bomb, "DIN");
                            case 6: return GetColor(bomb, "RST");
                        }
                        break;
                    }
                case "CNTD8":
                    {
                        switch (PinNumber)
                        {
                            case 1: return GetColor(bomb, "PWM");
                            case 2: return GetColor(bomb, "GND");
                            case 3: return GetColor(bomb, "GND");
                            case 4: return GetColor(bomb, "VCC");
                            case 5: return GetColor(bomb, "AIN");
                            case 6: return GetColor(bomb, "GND");
                            case 7: return GetColor(bomb, "DIN");
                            case 8: return GetColor(bomb, "RST");
                        }
                        break;
                    }
                case "CNTD10":
                    {
                        switch (PinNumber)
                        {
                            case 1: return GetColor(bomb, "PWM");
                            case 2: return GetColor(bomb, "DIN");
                            case 3: return GetColor(bomb, "AIN");
                            case 4: return GetColor(bomb, "GND");
                            case 5: return GetColor(bomb, "GND");
                            case 6: return GetColor(bomb, "VCC");
                            case 7: return GetColor(bomb, "GND");
                            case 8: return GetColor(bomb, "GND");
                            case 9: return GetColor(bomb, "RST");
                            case 10: return GetColor(bomb, "GND");
                        }
                        break;
                    }
                case "EXPL6":
                    {
                        switch (PinNumber)
                        {
                            case 1: return GetColor(bomb, "PWM");
                            case 2: return GetColor(bomb, "VCC");
                            case 3: return GetColor(bomb, "RST");
                            case 4: return GetColor(bomb, "AIN");
                            case 5: return GetColor(bomb, "DIN");
                            case 6: return GetColor(bomb, "GND");
                        }
                        break;
                    }
                case "EXPL8":
                    {
                        switch (PinNumber)
                        {
                            case 1: return GetColor(bomb, "AIN");
                            case 2: return GetColor(bomb, "GND");
                            case 3: return GetColor(bomb, "RST");
                            case 4: return GetColor(bomb, "GND");
                            case 5: return GetColor(bomb, "VCC");
                            case 6: return GetColor(bomb, "GND");
                            case 7: return GetColor(bomb, "DIN");
                            case 8: return GetColor(bomb, "PWM");
                        }
                        break;
                    }
                case "EXPL10":
                    {
                        switch (PinNumber)
                        {
                            case 1: return GetColor(bomb, "RST");
                            case 2: return GetColor(bomb, "DIN");
                            case 3: return GetColor(bomb, "VCC");
                            case 4: return GetColor(bomb, "GND");
                            case 5: return GetColor(bomb, "GND");
                            case 6: return GetColor(bomb, "GND");
                            case 7: return GetColor(bomb, "AIN");
                            case 8: return GetColor(bomb, "GND");
                            case 9: return GetColor(bomb, "PWM");
                            case 10: return GetColor(bomb, "GND");
                        }
                        break;
                    }
            }

            return "Cannot resolve, try again.";
        }

        public string GetColor(Bomb bomb, string pinType)
        {
            var pinTypeColors = new List<string>();
            switch (pinType)
            {
                case "VCC": pinTypeColors = VCC; break;
                case "AIN": pinTypeColors = AIN; break;
                case "DIN": pinTypeColors = DIN; break;
                case "PWM": pinTypeColors = PWM; break;
                case "RST": pinTypeColors = RST; break;
                case "GND": return "White.";
            }

            if (Serial.Last() == '1' || Serial.Last() == '4') return pinTypeColors[0];
            if (bomb.HasLitIndicator("sig") || bomb.HasPort("rj")) return pinTypeColors[1];
            if (bomb.HasSerialChar("clrx18")) return pinTypeColors[2];
            if (bomb.GetSerialDigits()[1] == bomb.GetBatteries()) return pinTypeColors[3];
            return pinTypeColors[4];
        }
    }
}