using ktane_bomb_manual.Modules;
using System.Collections.Generic;
using System.Linq;

namespace ktane_bomb_manual
{
    public class Bomb
    {
        public Bomb()
        {
            Strikes = 0;
            Serial = "";
            BatteryD = 0;
            BatteryAA = 0;
            Ports = new List<Port>();
            Indicators = new List<Indicator>();
            Modules = new List<Module>();
            ModulesAvaliable = new Dictionary<string, Module>();

        }

        public Dictionary<string, Module> ModulesAvaliable { get; set; }
        public int Strikes { get; set; }
        public string Serial { get; set; }
        public int BatteryD { get; set; }
        public int BatteryAA { get; set; }
        public List<Port> Ports { get; set; }
        public List<Indicator> Indicators { get; set; }
        public List<Module> Modules { get; set; }

        public string Command(string command)
        {
            if (command.Contains("serial"))
            {
                foreach (var word in command.Split(' '))
                {
                    if (InternalFunctions.GetLetterFromPhoneticLetter(word) != "")
                    {
                        Serial += InternalFunctions.GetLetterFromPhoneticLetter(word).ToUpper();
                        continue;
                    }
                    if (InternalFunctions.GetMorseFromLetter(word) != "")
                    {
                        Serial += word;
                    }
                }
            }
            if (command.Contains("battery") || command.Contains("batteries"))
            {
                if (command.Contains(" d "))
                {
                    foreach (var letter in command)
                    {
                        if (char.IsDigit(letter))
                        {
                            BatteryD = int.Parse(letter.ToString());
                        }
                    }
                }
                if (command.Contains(" aa "))
                {
                    foreach (var letter in command)
                    {
                        if (char.IsDigit(letter))
                        {
                            BatteryAA = int.Parse(letter.ToString());
                        }
                    }
                }
            }
            if (command.Contains("add port"))
            {
                var info = command.Replace("add port ", "").Split(' ');
                Ports.Add(new Port(command[0].ToString(), int.Parse(command[1].ToString())));
            }

            return "";
        }

        public void AddStrike()
        {
            Strikes += 1;
        }

        public Module GetModule(string module)
        {
            try
            {
                return Modules.Where(x => x.ModuleName == module && !x.Solved).First();
            }
            catch
            {
                Modules.Add(new Wires());
                return GetModule(module);
            }
        }

        public Port GetPort(string port)
        {
            return Ports.Where(x => x.Name == port).FirstOrDefault();
        }

        public Indicator GetIndicator(string tag)
        {
            return Indicators.Where(x => x.Tag == tag).FirstOrDefault();
        }

        public int GetBatteries()
        {
            return BatteryAA + BatteryD;
        }

        public int GetLitIndicators()
        {
            return Indicators.Where(x => x.LitIndicator).Count();
        }

        public int GetUnlitIndicators()
        {
            return Indicators.Where(x => !x.LitIndicator).Count();
        }

        public int GetLitIndicatorsWithLetter(string letter)
        {
            return Indicators.Where(x => x.Tag.Contains(letter) && x.LitIndicator).Count();
        }

        public int GetUnlitIndicatorsWithLetter(string letter)
        {
            return Indicators.Where(x => x.Tag.Contains(letter) && !x.LitIndicator).Count();
        }

        public string GetSerialCharacterAtPosition(int position)
        {
            return Serial[position - 1].ToString().ToLower();
        }

        public List<int> GetSerialDigits()
        {
            var list = new List<int>();

            foreach (var digit in Serial.Where(x => char.IsDigit(x)))
            {
                list.Add(int.Parse(digit.ToString()));
            }

            return list;
        }

        public int GetBiggestSerialDigit()
        {
            try
            {
                return GetSerialDigits().OrderBy(x => x).Last();
            }
            catch
            {
                return -1;
            }
        }

        public int GetSmallestOddSerialDigit()
        {
            try
            {
                return GetSerialDigits().OrderBy(x => x).Where(x => x % 2 != 0).First();
            }
            catch
            {
                return -1;
            }
        }

        public int GetLastSerialDigit()
        {
            return GetSerialDigits().Last();
        }

        public int GetManyDigitsInSerial()
        {
            return GetSerialDigits().Count();
        }

        public bool HasPort(string port)
        {
            return GetPort(port) != null;
        }

        public bool HasIndicator(string tag)
        {
            return GetIndicator(tag) != null;
        }

        public bool HasLitIndicator(string tag)
        {
            return HasIndicator(tag) ? GetIndicator(tag).LitIndicator : false;
        }

        public bool HasUnlitIndicator(string tag)
        {
            return HasIndicator(tag) ? !GetIndicator(tag).LitIndicator : false;
        }

        public bool HasSerialChar(char character)
        {
            return Serial.Contains(character);
        }

        public bool HasSerialVowel()
        {
            return HasSerialChar('A') || HasSerialChar('E') || HasSerialChar('I') || HasSerialChar('O') || HasSerialChar('U');
        }

        public bool HasSerialConsonant()
        {
            return !HasSerialVowel();
        }

        public bool HasSerialEven()
        {
            return HasSerialChar('2') || HasSerialChar('4') || HasSerialChar('6') || HasSerialChar('8') || HasSerialChar('0');
        }

        public bool HasSerialOdd()
        {
            return !HasSerialEven();
        }

        public bool HasSerialLastDigitEven()
        {
            return Serial.Last() == '2' || Serial.Last() == '4' || Serial.Last() == '6' || Serial.Last() == '8' || Serial.Last() == '0';
        }

        public bool HasSerialLastDigitOdd()
        {
            return !HasSerialLastDigitEven();
        }

        public bool HasManyBatteries(int number)
        {
            return BatteryAA + BatteryD >= number;
        }

        public bool CanDefuse()
        {
            return Serial == "";
        }
    }

    public class Port
    {
        public Port(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }

        public string Name;
        public int Quantity;
    }

    public class Indicator
    {
        public Indicator(string tag, bool litIndicator)
        {
            Tag = tag;
            LitIndicator = litIndicator;
        }

        public string Tag;
        public bool LitIndicator;
    }
}
