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
            var classList = System.Reflection.Assembly.GetAssembly(typeof(Program)).ExportedTypes
                 .Where(t => t.Namespace == "ktane_bomb_manual.Modules")
                 .ToList();

            foreach (var classType in classList)
            {
                if (!ModulesAvaliable.ContainsKey(classType.Name.ToLower()))
                    ModulesAvaliable.Add(classType.Name.ToLower(), classType);
            }
        }

        public int Strikes { get; set; }
        public string Serial { get; set; }
        public int BatteryD { get; set; }
        public int BatteryAA { get; set; }
        public int Time { get; set; }
        public int ModulesQuantity { get; set; }
        public int PortPlates { get; set; }
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
            if (command.Contains("plate"))
            {
                foreach (var word in command.Split(' '))
                {
                    if (InternalFunctions.IsNumber(word))
                    {
                        PortPlates = InternalFunctions.GetNumber(word);
                    }
                }
                return "Port plates added.";
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
            if (command.Contains("time") || command.Contains("minute"))
            {
                foreach (var word in command.Split(' '))
                {
                    if (InternalFunctions.IsNumber(word))
                    {
                        Time = int.Parse(word);
                        return "Time added.";
                    }
                }

                return "Can't find time.";
            }
            if (command.Contains("module"))
            {
                foreach (var word in command.Split(' '))
                {
                    if (InternalFunctions.IsNumber(word))
                    {
                        ModulesQuantity = int.Parse(word);
                        return "Modules quantity added.";
                    }
                }

                return "Can't find modules quantity.";
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
                return Modules.Where(x => (char.IsNumber(module[0]) ? "_" : "" + x.ModuleName.ToLower()) == module && !x.Solved).First();
            }
            catch
            {
                Type type;
                ModulesAvaliable.TryGetValue(char.IsNumber(module[0]) ? "_" : "" + module, out type);
                Modules.Add((Module)Activator.CreateInstance(type));
                return GetModule(module);
            }
        }

        public Port GetPort(string port)
        {
            return Ports.Where(x => x.Name == port.ToLower()).FirstOrDefault();
        }

        public int GetPortsQuantity(string portName = "")
        {
            if (string.IsNullOrEmpty(portName))
                return Ports.Sum(x => x.Quantity);
            else
                return Ports.Where(x => x.Name == portName.ToLower()).Sum(x => x.Quantity);
        }

        public int GetPortTypesQuantity()
        {
            return Ports.Count;
        }

        public int GetPortPlatesQuantity()
        {
            return PortPlates;
        }

        public Indicator GetIndicator(string tag)
        {
            return Indicators.Where(x => x.Tag == tag.ToLower()).FirstOrDefault();
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

        public int GetAABatteries()
        {
            return BatteryAA;
        }

        public int GetDBatteries()
        {
            return BatteryD;
        }

        public int GetBatteriesHolders()
        {
            return BatteryD + BatteryAA / 2;
        }

        public int GetIndicators()
        {
            return Indicators.Count();
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
            return Indicators.Where(x => x.Tag.Contains(letter.ToLower()) && x.LitIndicator).Count();
        }

        public int GetUnlitIndicatorsWithLetter(string letter)
        {
            return Indicators.Where(x => x.Tag.Contains(letter.ToLower()) && !x.LitIndicator).Count();
        }

        public string GetSerialCharacterAtPosition(int position)
        {
            return Serial[position - 1].ToString().ToLower();
        }

        public List<int> GetSerialDigits()
        {
            return Serial.Where(x => char.IsNumber(x)).Select(y => int.Parse(y.ToString())).ToList();
        }

        public List<string> GetSerialCharacters()
        {
            return Serial.Where(x => !char.IsNumber(x)).Select(y => y.ToString()).ToList();
        }

        public int GetSerialVowelsQuantity()
        {
            return GetSerialCharacters().Where(x => x == "a" || x == "e" || x == "i" || x == "o" || x == "u").Count();
        }

        public int GetSerialConsonantsQuantity()
        {
            return GetSerialCharacters().Count() - GetSerialVowelsQuantity();
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

        public int GetSerialFirstNumberDigit()
        {
            return GetSerialDigits().First();
        }

        public int GetSerialLastNumberDigit()
        {
            return GetSerialDigits().Last();
        }

        public int GetManyDigitsInSerial()
        {
            return GetSerialDigits().Count();
        }

        public int GetManyCharactersInSerial()
        {
            return 6 - GetSerialDigits().Count();
        }

        public int GetSolvedModules()
        {
            return Modules.Where(x => x.Solved).Count();
        }

        public bool HasPort(string port, int quantity = 0)
        {
            if (quantity > 0)
                return GetPortsQuantity(port) == quantity;
            return GetPort(port.ToLower()) != null;
        }

        public bool HasManyStrikes(int number)
        {
            return Strikes >= number;
        }

        public bool HasAnyDuplicatedPort()
        {
            foreach (var port in Ports)
            {
                if (port.Quantity >= 2)
                    return true;
            }
            return false;
        }

        public bool HasIndicatorWithLetter(string letter)
        {
            return GetLitIndicatorsWithLetter(letter) + GetUnlitIndicatorsWithLetter(letter) != 0;
        }

        public bool HasIndicatorWithLetterInWord(string word)
        {
            foreach (var letter in word)
            {
                if (HasIndicatorWithLetter(letter.ToString()))
                    return true;
            }
            return false;
        }

        public bool HasIndicator(string tag)
        {
            return GetIndicator(tag.ToLower()) != null;
        }

        public bool HasAnyLitIndicator()
        {
            return GetLitIndicators() > 0;
        }

        public bool HasLitIndicator(string tag)
        {
            return HasIndicator(tag.ToLower()) ? GetIndicator(tag.ToLower()).LitIndicator : false;
        }

        public bool HasAnyUnlitIndicator()
        {
            return GetUnlitIndicators() > 0;
        }

        public bool HasUnlitIndicator(string tag)
        {
            return HasIndicator(tag.ToLower()) ? !GetIndicator(tag.ToLower()).LitIndicator : false;
        }

        public bool HasAnySerialChar(string characters)
        {
            foreach (var character in characters)
            {
                if (HasSerialChar(character))
                    return true;
            }
            return false;
        }

        public bool HasSerialChar(char character)
        {
            return Serial.Contains(character.ToString().ToUpper());
        }

        public bool HasSerialChar(string characters)
        {
            foreach (var c in characters)
            {
                if (HasSerialChar(c))
                    return true;
            }
            return false;
        }

        public bool HasAnyDuplicatedSerialChar()
        {
            foreach (var letter in Serial)
            {
                if (Serial.Where(x => x == letter).Count() >= 2)
                    return true;
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

        public bool HasSerialNumbersLetters(int numbers, int letters)
        {
            return GetSerialCharacters().Count == letters && GetSerialDigits().Count == numbers;
        }

        public bool HasManyBatteries(int number)
        {
            return BatteryAA + BatteryD >= number;
        }

        public bool HasManyBatteriesHolders(int number)
        {
            return GetBatteriesHolders() >= number;
        }

        public bool HasExactlyBatteries(int number)
        {
            return HasManyBatteries(number) && !HasManyBatteries(number + 1);
        }

        public bool HasManyIndicators(int number)
        {
            return Indicators.Count >= number;
        }

        public bool HasManyPorts(int number)
        {
            return Ports.Count >= number;
        }

        public bool HasManyDigitsInSerial(int number)
        {
            return GetManyDigitsInSerial() >= number;
        }

        public bool HasManyCharactersInSerial(int number)
        {
            return GetManyCharactersInSerial() >= number;
        }

        public bool HasMoreModulesThanTime()
        {
            return ModulesQuantity > Time;
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
            Name = name.ToLower();
            Quantity = quantity;
        }

        public string Name;
        public int Quantity;
    }

    public class Indicator
    {
        public Indicator(string tag, bool litIndicator)
        {
            Tag = tag.ToLower();
            LitIndicator = litIndicator;
        }

        public string Tag;
        public bool LitIndicator;
    }
}
