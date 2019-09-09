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
        }

        public int Strikes { get; set; }
        public string Serial { get; set; }
        public int BatteryD { get; set; }
        public int BatteryAA { get; set; }
        public List<Port> Ports { get; set; }
        public List<Indicator> Indicators { get; set; }

        public Port GetPort(string port)
        {
            return Ports.Where(x => x.Name == port).FirstOrDefault();
        }

        public Indicator GetIndicator(string tag)
        {
            return Indicators.Where(x => x.Tag == tag).FirstOrDefault();
        }

        public bool HasPort(string port)
        {
            return GetPort(port) == null;
        }

        public bool HasIndicator(string tag)
        {
            return GetIndicator(tag) == null;
        }

        public bool HasLitIndicator(string tag)
        {
            return HasIndicator(tag) ? GetIndicator(tag).LitIndicator : false
;
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
            return BatteryAA + BatteryD > number;
        }

        public bool CanDefuse()
        {
            return Serial == "";
        }
    }

    public class Port
    {
        public string Name;
        public int Quantity;
    }

    public class Indicator
    {
        public string Tag;
        public bool LitIndicator;
    }

    public enum ExistingPorts
    {
        USB,
        DVI,
        Parallel,
        PS2,
        RJ45,
        Serial,
        Stereo
    }
}
