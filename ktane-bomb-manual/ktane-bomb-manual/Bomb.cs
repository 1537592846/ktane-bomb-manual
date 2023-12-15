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
            PortPlates = 0;
            EmptyPortPlates = 0;
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
        public int EmptyPortPlates { get; set; }
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
            if (command.Contains("empty"))
            {
                foreach (var word in command.Split(' '))
                {
                    if (InternalFunctions.IsNumber(word))
                    {
                        EmptyPortPlates = InternalFunctions.GetNumber(word);
                    }
                }
                return "Empty port plates added.";
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

        public void AddStrike() => Strikes += 1;

        public Module GetModule(string module)
        {
            try
            {
                return Modules.Where(x => (char.IsNumber(module[0]) ? "_" : "" + x.ModuleName.ToLower()) == module && !x.Solved).First();
            }
            catch
            {
                ModulesAvaliable.TryGetValue(char.IsNumber(module[0]) ? "_" : "" + module, out Type type);
                Modules.Add((Module)Activator.CreateInstance(type));
                return GetModule(module);
            }
        }

        public Port GetPort(string port) => Ports.Where(x => x.Name == port.ToLower()).FirstOrDefault();

        public int GetPortsQuantity(string portName = "") => string.IsNullOrEmpty(portName)
                ? Ports.Sum(x => x.Quantity)
                : Ports.Where(x => x.Name == portName.ToLower()).Sum(x => x.Quantity);

        public int GetPortTypesQuantity() => Ports.Count;

        public int GetPortPlatesQuantity() => PortPlates;

        public Indicator GetIndicator(string tag) => Indicators.Where(x => x.Tag == tag.ToLower()).FirstOrDefault();

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

        public int GetBatteries() => BatteryAA + BatteryD;

        public int GetAABatteries() => BatteryAA;

        public int GetDBatteries() => BatteryD;

        public int GetBatteriesHolders() => BatteryD + BatteryAA / 2;

        public int GetIndicators() => Indicators.Count();

        public int GetLitIndicators() => Indicators.Count(x => x.LitIndicator);

        public int GetUnlitIndicators() => Indicators.Count(x => !x.LitIndicator);

        public int GetLitIndicatorsWithLetter(string letter) => Indicators.Count(x => x.Tag.Contains(letter.ToLower()) && x.LitIndicator);

        public int GetUnlitIndicatorsWithLetter(string letter) => Indicators.Count(x => x.Tag.Contains(letter.ToLower()) && !x.LitIndicator);

        public string GetSerialCharacterAtPosition(int position) => Serial[position - 1].ToString().ToLower();

        public List<int> GetSerialDigits() => Serial.Where(x => char.IsNumber(x)).Select(y => int.Parse(y.ToString())).ToList();

        public List<string> GetSerialCharacters() => Serial.Where(x => !char.IsNumber(x)).Select(y => y.ToString()).ToList();

        public int GetSerialVowelsQuantity() => GetSerialCharacters().Count(x => x == "a" || x == "e" || x == "i" || x == "o" || x == "u");

        public int GetSerialConsonantsQuantity() => GetSerialCharacters().Count() - GetSerialVowelsQuantity();

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

        public int GetSerialFirstNumberDigit() => GetSerialDigits().First();

        public int GetSerialLastNumberDigit() => GetSerialDigits().Last();

        public int GetManyDigitsInSerial() => GetSerialDigits().Count();

        public int GetManyCharactersInSerial() => 6 - GetSerialDigits().Count();

        public int GetSolvedModules() => Modules.Count(x => x.Solved);

        public bool HasEmptyPortPlate() => EmptyPortPlates != 0;

        public bool HasPort(string port, int quantity = 0) => quantity > 0 ? GetPortsQuantity(port) == quantity : GetPort(port.ToLower()) != null;

        public bool HasManyStrikes(int number) => Strikes >= number;

        public bool HasAnyDuplicatedPort()
        {
            foreach (var port in Ports)
            {
                if (port.Quantity >= 2)
                    return true;
            }
            return false;
        }

        public bool HasIndicatorWithLetter(string letter) => GetLitIndicatorsWithLetter(letter) + GetUnlitIndicatorsWithLetter(letter) != 0;

        public bool HasIndicatorWithLetterInWord(string word)
        {
            foreach (var letter in word)
            {
                if (HasIndicatorWithLetter(letter.ToString()))
                    return true;
            }
            return false;
        }

        public bool HasIndicator(string tag) => GetIndicator(tag.ToLower()) != null;

        public bool HasAnyLitIndicator() => GetLitIndicators() > 0;

        public bool HasLitIndicator(string tag) => HasIndicator(tag.ToLower()) && GetIndicator(tag.ToLower()).LitIndicator;

        public bool HasAnyUnlitIndicator() => GetUnlitIndicators() > 0;

        public bool HasUnlitIndicator(string tag) => HasIndicator(tag.ToLower()) && !GetIndicator(tag.ToLower()).LitIndicator;

        public bool HasAnySerialChar(string characters)
        {
            foreach (var character in characters)
            {
                if (HasSerialChar(character))
                    return true;
            }
            return false;
        }

        public bool HasSerialChar(char character) => Serial.Contains(character.ToString().ToUpper());

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

        public bool HasSerialVowel() => HasSerialChar('A') || HasSerialChar('E') || HasSerialChar('I') || HasSerialChar('O') || HasSerialChar('U');

        public bool HasSerialConsonant() => HasSerialChar('B') || HasSerialChar('C') || HasSerialChar('D') || HasSerialChar('F') || HasSerialChar('G') || HasSerialChar('H') || HasSerialChar('J') || HasSerialChar('K') || HasSerialChar('L') || HasSerialChar('M') || HasSerialChar('N') || HasSerialChar('P') || HasSerialChar('Q') || HasSerialChar('R') || HasSerialChar('S') || HasSerialChar('T') || HasSerialChar('V') || HasSerialChar('W') || HasSerialChar('X') || HasSerialChar('Y') || HasSerialChar('Z');

        public bool HasSerialEven() => HasSerialChar('2') || HasSerialChar('4') || HasSerialChar('6') || HasSerialChar('8') || HasSerialChar('0');

        public bool HasSerialOdd() => !HasSerialEven();

        public bool HasSerialLastDigitEven() => Serial.Last() == '2' || Serial.Last() == '4' || Serial.Last() == '6' || Serial.Last() == '8' || Serial.Last() == '0';

        public bool HasSerialLastDigitOdd() => !HasSerialLastDigitEven();

        public bool HasSerialNumbersLetters(int numbers, int letters) => GetSerialCharacters().Count == letters && GetSerialDigits().Count == numbers;

        public bool HasManyBatteries(int number) => BatteryAA + BatteryD >= number;

        public bool HasManyBatteriesHolders(int number) => GetBatteriesHolders() >= number;

        public bool HasExactlyBatteries(int number) => HasManyBatteries(number) && !HasManyBatteries(number + 1);

        public bool HasManyIndicators(int number) => Indicators.Count >= number;

        public bool HasManyPorts(int number) => Ports.Count >= number;

        public bool HasManyDigitsInSerial(int number) => GetManyDigitsInSerial() >= number;

        public bool HasManyCharactersInSerial(int number) => GetManyCharactersInSerial() >= number;

        public bool HasMoreModulesThanTime() => ModulesQuantity > Time;

        public bool CanDefuse() => Serial == "";
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
