using ktane_bomb_manual.Modules;
using System;
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
            ModulesAvaliable = new Dictionary<string, Type>();
            var classList = System.Reflection.Assembly.GetExecutingAssembly().GetTypes()
                 .Where(t => t.Namespace == "ktane_bomb_manual.Modules")
                 .ToList();

            foreach (var classType in classList)
            {
                if (!ModulesAvaliable.ContainsKey(classType.Name.ToLower())) ModulesAvaliable.Add(classType.Name.ToLower(), classType);
            }
        }

        public int Strikes { get; set; }
        public string Serial { get; set; }
        public int BatteryD { get; set; }
        public int BatteryAA { get; set; }
        public List<Port> Ports { get; set; }
        public List<Indicator> Indicators { get; set; }
        public List<Module> Modules { get; set; }
        public Dictionary<string, Type> ModulesAvaliable { get; set; }

        public string Command(string command)
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
            if (command.Contains("battery") || command.Contains("batteries"))
            {
                if (command.Contains(" d "))
                {
                    foreach (var letter in command)
                    {
                        if (char.IsDigit(letter))
                        {
                            BatteryD = int.Parse(letter.ToString());
                            return "D batteries added.";
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
                            return "AA batteries added.";
                        }
                    }
                }
            }
            if (command.Contains("port"))
            {
                var info = command.Replace("bomb", "").Replace("has", "").Replace("ports", "").Replace("port", "").Trim().Split(' ');
                if (Ports.Where(x => x.Name == info[1]).Count() == 1)
                    Ports.Where(x => x.Name == info[1]).First().Quantity += InternalFunctions.GetNumber(info[0]);
                else
                    Ports.Add(new Port(info[1], InternalFunctions.GetNumber(info[0])));
                return info[1][0].ToString().ToUpper() + info[1].Substring(1).ToLower() + " port added.";
            }
            if (command.Contains("indicator"))
            {
                var info = command.Replace("bomb", "").Replace("has", "").Replace("indicator", "").Trim().Split(' ');
                var light = !info.Contains("unlit");
                info = info.Where(x => !x.Contains("lit")).ToArray();
                var text = InternalFunctions.GetLetterFromPhoneticLetter(info[0]) + InternalFunctions.GetLetterFromPhoneticLetter(info[1]) + InternalFunctions.GetLetterFromPhoneticLetter(info[2]);
                Indicators.Add(new Indicator(text, light));
                return (light ? "Lit " : "Unlit ") + text.ToUpper() + " indicator added.";
            }
            if (command.Contains("strike"))
            {
                AddStrike();
                return "Strike added.";
            }

            return "Command not found.";
        }

        public void AddStrike()
        {
            Strikes += 1;
        }

        public Module GetModule(string module)
        {
            try
            {
                return Modules.Where(x => x.ModuleName.ToLower() == module && !x.Solved).First();
            }
            catch
            {
                Type type;
                ModulesAvaliable.TryGetValue(module, out type);
                Modules.Add((Module)Activator.CreateInstance(type));
                return GetModule(module);
            }
        }

        public Port GetPort(string port)
        {
            return Ports.Where(x => x.Name == port).FirstOrDefault();
        }

        public int GetPortsQuantity(string portName = "")
        {
            var count = 0;
            if (string.IsNullOrEmpty(portName))
                foreach (var port in Ports)
                {
                    count += port.Quantity;
                }
            else
                count = Ports.Where(x => x.Name == portName).First().Quantity;
            return count;
        }

        public Indicator GetIndicator(string tag)
        {
            return Indicators.Where(x => x.Tag == tag).FirstOrDefault();
        }

        public int GetLitIndicatorsInSerialQuantity()
        {
            int count = 0;

            foreach (var indicator in Indicators.Where(x => x.LitIndicator))
            {
                count += HasSerialChar(indicator.Tag[0]) || HasSerialChar(indicator.Tag[1]) || HasSerialChar(indicator.Tag[2]) ? 1 : 0;
            }

            return count;
        }

        public int GetUnlitIndicatorsInSerialQuantity()
        {
            int count = 0;

            foreach (var indicator in Indicators.Where(x => !x.LitIndicator))
            {
                count += HasSerialChar(indicator.Tag[0]) || HasSerialChar(indicator.Tag[1]) || HasSerialChar(indicator.Tag[2]) ? 1 : 0;
            }

            return count;
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

        public bool HasAnyDuplicatedPort()
        {
            foreach (var port in Ports)
            {
                if (port.Quantity >= 2) return true;
            }
            return false;
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
            return Serial.Contains(character.ToString().ToUpper());
        }

        public bool HasAnyDuplicatedSerialChar()
        {
            foreach (var letter in Serial)
            {
                if (Serial.Where(x => x == letter).Count() >= 2) return true;
            }
            return false;
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
