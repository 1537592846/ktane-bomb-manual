using System.Collections.Generic;

namespace ktane_bomb_manual.Modules
{
    public class Astrology : Module
    {
        public Astrology()
        {
            Symbols = new List<string>();
        }

        int OmenValue;
        public List<string> Symbols;

        public override string Solve(Bomb bomb)
        {
            if (Symbols.Count != 3) return "Not enough symbols.";

            OmenValue += CalculateOmen(Symbols[0], Symbols[1]);
            OmenValue += CalculateOmen(Symbols[0], Symbols[2]);
            OmenValue += CalculateOmen(Symbols[1], Symbols[2]);

            foreach (var symbol in Symbols)
            {
                var hasInCommon = false;

                foreach (var letter in symbol)
                {
                    if (bomb.HasSerialChar(letter))
                    {
                        hasInCommon = true;
                        break;
                    }
                }

                OmenValue += hasInCommon ? 1 : -1;
            }

            Solved = true;

            if (OmenValue > 0)
                return "Good omen when the timer has a " + OmenValue + ".";
            else if (OmenValue < 0)
                return "Poor omen when the timer has a " + (OmenValue * -1) + ".";
            else
                return "No omen anywhere.";
        }

        public override string Command(Bomb bomb, string command)
        {
            foreach (var word in command.Replace("astrology", "").Trim().Split(' '))
            {
                Symbols.Add(word);
            }

            return Solve(bomb);
        }

        public int CalculateOmen(string symbol1, string symbol2)
        {
            switch (symbol1)
            {
                case "air":
                    {
                        switch (symbol2)
                        {
                            case "sun": return -1;
                            case "moon": return 2;
                            case "mercury": return -1;
                            case "venus": return 0;
                            case "mars": return -2;
                            case "jupiter": return -1;
                            case "saturn": return 0;
                            case "uranus": return 2;
                            case "neptune": return -2;
                            case "pluto": return 2;

                            case "aries": return 1;
                            case "taurus": return 1;
                            case "gemini": return -2;
                            case "cancer": return -2;
                            case "leo": return 2;
                            case "virgo": return 0;
                            case "libra": return -1;
                            case "scorpio": return 1;
                            case "sagittarius": return 0;
                            case "capricorn": return 0;
                            case "aquarius": return -1;
                            case "pisces": return -1;
                        }
                        break;
                    }
                case "fire":
                    {
                        switch (symbol2)
                        {
                            case "sun": return 0;
                            case "moon": return 0;
                            case "mercury": return 1;
                            case "venus": return -1;
                            case "mars": return 0;
                            case "jupiter": return 1;
                            case "saturn": return -2;
                            case "uranus": return 2;
                            case "neptune": return 0;
                            case "pluto": return -1;

                            case "aries": return 1;
                            case "taurus": return 0;
                            case "gemini": return -1;
                            case "cancer": return 0;
                            case "leo": return 0;
                            case "virgo": return 2;
                            case "libra": return 2;
                            case "scorpio": return 0;
                            case "sagittarius": return 1;
                            case "capricorn": return 0;
                            case "aquarius": return 1;
                            case "pisces": return 0;
                        }
                        break;
                    }
                case "water":
                    {
                        switch (symbol2)
                        {
                            case "sun": return -2;
                            case "moon": return 0;
                            case "mercury": return -1;
                            case "venus": return 0;
                            case "mars": return 2;
                            case "jupiter": return 0;
                            case "saturn": return -2;
                            case "uranus": return 2;
                            case "neptune": return 0;
                            case "pluto": return 1;

                            case "aries": return 2;
                            case "taurus": return 2;
                            case "gemini": return -1;
                            case "cancer": return 2;
                            case "leo": return -1;
                            case "virgo": return -1;
                            case "libra": return -2;
                            case "scorpio": return 1;
                            case "sagittarius": return 2;
                            case "capricorn": return 0;
                            case "aquarius": return 0;
                            case "pisces": return 2;
                        }
                        break;
                    }
                case "earth":
                    {
                        switch (symbol2)
                        {
                            case "sun": return -1;
                            case "moon": return -1;
                            case "mercury": return 0;
                            case "venus": return -1;
                            case "mars": return 1;
                            case "jupiter": return 2;
                            case "saturn": return 0;
                            case "uranus": return 2;
                            case "neptune": return 1;
                            case "pluto": return -2;

                            case "aries": return -2;
                            case "taurus": return -1;
                            case "gemini": return 0;
                            case "cancer": return 0;
                            case "leo": return 1;
                            case "virgo": return 0;
                            case "libra": return 1;
                            case "scorpio": return 2;
                            case "sagittarius": return -1;
                            case "capricorn": return -2;
                            case "aquarius": return 1;
                            case "pisces": return 1;
                        }
                        break;
                    }

                case "sun":
                    {
                        switch (symbol2)
                        {
                            case "air": return -1;
                            case "fire": return 0;
                            case "water": return -2;
                            case "earth": return -1;

                            case "aries": return -1;
                            case "taurus": return -1;
                            case "gemini": return 2;
                            case "cancer": return 0;
                            case "leo": return -1;
                            case "virgo": return 0;
                            case "libra": return -1;
                            case "scorpio": return 1;
                            case "sagittarius": return 0;
                            case "capricorn": return 0;
                            case "aquarius": return -2;
                            case "pisces": return -2;
                        }
                        break;
                    }
                case "moon":
                    {
                        switch (symbol2)
                        {
                            case "air": return 2;
                            case "fire": return 0;
                            case "water": return 0;
                            case "earth": return -1;

                            case "aries": return -2;
                            case "taurus": return 0;
                            case "gemini": return 1;
                            case "cancer": return 0;
                            case "leo": return 2;
                            case "virgo": return 0;
                            case "libra": return -1;
                            case "scorpio": return 1;
                            case "sagittarius": return 2;
                            case "capricorn": return 0;
                            case "aquarius": return 1;
                            case "pisces": return 0;
                        }
                        break;
                    }
                case "mercury":
                    {
                        switch (symbol2)
                        {
                            case "air": return -1;
                            case "fire": return 1;
                            case "water": return -1;
                            case "earth": return 0;

                            case "aries": return -2;
                            case "taurus": return -2;
                            case "gemini": return -1;
                            case "cancer": return -1;
                            case "leo": return 1;
                            case "virgo": return -1;
                            case "libra": return 0;
                            case "scorpio": return -2;
                            case "sagittarius": return 0;
                            case "capricorn": return 0;
                            case "aquarius": return -1;
                            case "pisces": return 1;
                        }
                        break;
                    }
                case "venus":
                    {
                        switch (symbol2)
                        {
                            case "air": return 0;
                            case "fire": return -1;
                            case "water": return 0;
                            case "earth": return -1;

                            case "aries": return -2;
                            case "taurus": return 2;
                            case "gemini": return -2;
                            case "cancer": return 0;
                            case "leo": return 0;
                            case "virgo": return 1;
                            case "libra": return -1;
                            case "scorpio": return 0;
                            case "sagittarius": return 2;
                            case "capricorn": return -0;
                            case "aquarius": return -1;
                            case "pisces": return 1;
                        }
                        break;
                    }
                case "mars":
                    {
                        switch (symbol2)
                        {
                            case "air": return -2;
                            case "fire": return 0;
                            case "water": return 2;
                            case "earth": return 1;

                            case "aries": return -2;
                            case "taurus": return 0;
                            case "gemini": return -1;
                            case "cancer": return -2;
                            case "leo": return -2;
                            case "virgo": return -2;
                            case "libra": return -1;
                            case "scorpio": return 1;
                            case "sagittarius": return 1;
                            case "capricorn": return 1;
                            case "aquarius": return 0;
                            case "pisces": return -1;
                        }
                        break;
                    }
                case "jupiter":
                    {
                        switch (symbol2)
                        {
                            case "air": return -1;
                            case "fire": return 1;
                            case "water": return 0;
                            case "earth": return 2;

                            case "aries": return -1;
                            case "taurus": return -2;
                            case "gemini": return 1;
                            case "cancer": return -1;
                            case "leo": return 0;
                            case "virgo": return 0;
                            case "libra": return 0;
                            case "scorpio": return 1;
                            case "sagittarius": return 0;
                            case "capricorn": return -1;
                            case "aquarius": return 2;
                            case "pisces": return 0;
                        }
                        break;
                    }
                case "saturn":
                    {
                        switch (symbol2)
                        {
                            case "air": return 0;
                            case "fire": return -2;
                            case "water": return -2;
                            case "earth": return 0;

                            case "aries": return -1;
                            case "taurus": return -1;
                            case "gemini": return 0;
                            case "cancer": return 0;
                            case "leo": return 1;
                            case "virgo": return 1;
                            case "libra": return 0;
                            case "scorpio": return 0;
                            case "sagittarius": return 0;
                            case "capricorn": return 0;
                            case "aquarius": return -1;
                            case "pisces": return -1;
                        }
                        break;
                    }
                case "uranus":
                    {
                        switch (symbol2)
                        {
                            case "air": return 2;
                            case "fire": return 2;
                            case "water": return 2;
                            case "earth": return 2;

                            case "aries": return -1;
                            case "taurus": return 2;
                            case "gemini": return 0;
                            case "cancer": return 0;
                            case "leo": return 1;
                            case "virgo": return -2;
                            case "libra": return 1;
                            case "scorpio": return 0;
                            case "sagittarius": return 2;
                            case "capricorn": return -1;
                            case "aquarius": return 1;
                            case "pisces": return -0;
                        }
                        break;
                    }
                case "neptune":
                    {
                        switch (symbol2)
                        {
                            case "air": return -2;
                            case "fire": return 0;
                            case "water": return 0;
                            case "earth": return 1;

                            case "aries": return 1;
                            case "taurus": return 0;
                            case "gemini": return 2;
                            case "cancer": return 1;
                            case "leo": return -1;
                            case "virgo": return 1;
                            case "libra": return 1;
                            case "scorpio": return 1;
                            case "sagittarius": return 0;
                            case "capricorn": return -2;
                            case "aquarius": return 2;
                            case "pisces": return 0;
                        }
                        break;
                    }
                case "pluto":
                    {
                        switch (symbol2)
                        {
                            case "air": return 2;
                            case "fire": return -1;
                            case "water": return 1;
                            case "earth": return -2;

                            case "aries": return -1;
                            case "taurus": return 0;
                            case "gemini": return 0;
                            case "cancer": return -1;
                            case "leo": return -2;
                            case "virgo": return 1;
                            case "libra": return 2;
                            case "scorpio": return 1;
                            case "sagittarius": return 1;
                            case "capricorn": return 0;
                            case "aquarius": return 0;
                            case "pisces": return -1;
                        }
                        break;
                    }

                case "aries":
                    {
                        switch (symbol2)
                        {
                            case "air": return 1;
                            case "fire": return 1;
                            case "water": return 2;
                            case "earth": return -2;

                            case "sun": return -1;
                            case "moon": return -2;
                            case "mercury": return -2;
                            case "venus": return -2;
                            case "mars": return -2;
                            case "jupiter": return -1;
                            case "saturn": return -1;
                            case "uranus": return -1;
                            case "neptune": return 1;
                            case "pluto": return -1;
                        }
                        break;
                    }
                case "taurus":
                    {
                        switch (symbol2)
                        {
                            case "air": return 1;
                            case "fire": return 0;
                            case "water": return 2;
                            case "earth": return -1;

                            case "sun": return -1;
                            case "moon": return 0;
                            case "mercury": return -2;
                            case "venus": return 2;
                            case "mars": return 0;
                            case "jupiter": return -2;
                            case "saturn": return -1;
                            case "uranus": return 2;
                            case "neptune": return 0;
                            case "pluto": return 0;
                        }
                        break;
                    }
                case "gemini":
                    {
                        switch (symbol2)
                        {
                            case "air": return -2;
                            case "fire": return -1;
                            case "water": return -1;
                            case "earth": return 0;

                            case "sun": return 2;
                            case "moon": return 1;
                            case "mercury": return -1;
                            case "venus": return -2;
                            case "mars": return -1;
                            case "jupiter": return 1;
                            case "saturn": return 0;
                            case "uranus": return 0;
                            case "neptune": return 2;
                            case "pluto": return 0;
                        }
                        break;
                    }
                case "cancer":
                    {
                        switch (symbol2)
                        {
                            case "air": return -2;
                            case "fire": return 0;
                            case "water": return 2;
                            case "earth": return 0;

                            case "sun": return 0;
                            case "moon": return 0;
                            case "mercury": return -1;
                            case "venus": return 0;
                            case "mars": return -2;
                            case "jupiter": return -1;
                            case "saturn": return 0;
                            case "uranus": return 0;
                            case "neptune": return 1;
                            case "pluto": return -1;
                        }
                        break;
                    }
                case "leo":
                    {
                        switch (symbol2)
                        {
                            case "air": return 2;
                            case "fire": return 0;
                            case "water": return -1;
                            case "earth": return 1;

                            case "sun": return -1;
                            case "moon": return 2;
                            case "mercury": return 1;
                            case "venus": return 0;
                            case "mars": return -2;
                            case "jupiter": return 0;
                            case "saturn": return 1;
                            case "uranus": return 1;
                            case "neptune": return -1;
                            case "pluto": return -2;
                        }
                        break;
                    }
                case "virgo":
                    {
                        switch (symbol2)
                        {
                            case "air": return 0;
                            case "fire": return 2;
                            case "water": return -1;
                            case "earth": return 0;

                            case "sun": return 0;
                            case "moon": return 0;
                            case "mercury": return -1;
                            case "venus": return 1;
                            case "mars": return -2;
                            case "jupiter": return 0;
                            case "saturn": return 1;
                            case "uranus": return -2;
                            case "neptune": return 1;
                            case "pluto": return 1;
                        }
                        break;
                    }
                case "libra":
                    {
                        switch (symbol2)
                        {
                            case "air": return -1;
                            case "fire": return 2;
                            case "water": return -2;
                            case "earth": return 1;

                            case "sun": return -1;
                            case "moon": return -1;
                            case "mercury": return 0;
                            case "venus": return -1;
                            case "mars": return -1;
                            case "jupiter": return 0;
                            case "saturn": return 0;
                            case "uranus": return 1;
                            case "neptune": return 1;
                            case "pluto": return 2;
                        }
                        break;
                    }
                case "scorpio":
                    {
                        switch (symbol2)
                        {
                            case "air": return 1;
                            case "fire": return 0;
                            case "water": return 1;
                            case "earth": return 2;

                            case "sun": return 1;
                            case "moon": return 1;
                            case "mercury": return -2;
                            case "venus": return 0;
                            case "mars": return 1;
                            case "jupiter": return 1;
                            case "saturn": return 0;
                            case "uranus": return 0;
                            case "neptune": return 1;
                            case "pluto": return 1;
                        }
                        break;
                    }
                case "sagittarius":
                    {
                        switch (symbol2)
                        {
                            case "air": return 0;
                            case "fire": return 1;
                            case "water": return 2;
                            case "earth": return -1;

                            case "sun": return 0;
                            case "moon": return 2;
                            case "mercury": return 0;
                            case "venus": return 2;
                            case "mars": return 1;
                            case "jupiter": return 0;
                            case "saturn": return 0;
                            case "uranus": return 2;
                            case "neptune": return 0;
                            case "pluto": return 1;
                        }
                        break;
                    }
                case "capricorn":
                    {
                        switch (symbol2)
                        {
                            case "air": return 0;
                            case "fire": return 0;
                            case "water": return 0;
                            case "earth": return -2;

                            case "sun": return 0;
                            case "moon": return 0;
                            case "mercury": return 0;
                            case "venus": return -2;
                            case "mars": return 1;
                            case "jupiter": return -1;
                            case "saturn": return 0;
                            case "uranus": return -1;
                            case "neptune": return 2;
                            case "pluto": return 0;
                        }
                        break;
                    }
                case "aquarius":
                    {
                        switch (symbol2)
                        {
                            case "air": return -1;
                            case "fire": return 1;
                            case "water": return 0;
                            case "earth": return 1;

                            case "sun": return -2;
                            case "moon": return 1;
                            case "mercury": return -1;
                            case "venus": return -1;
                            case "mars": return 0;
                            case "jupiter": return 2;
                            case "saturn": return -1;
                            case "uranus": return 1;
                            case "neptune": return 2;
                            case "pluto": return 0;
                        }
                        break;
                    }
                case "pisces":
                    {
                        switch (symbol2)
                        {
                            case "air": return -1;
                            case "fire": return 0;
                            case "water": return 2;
                            case "earth": return 1;

                            case "sun": return -2;
                            case "moon": return 0;
                            case "mercury": return 1;
                            case "venus": return 1;
                            case "mars": return -1;
                            case "jupiter": return 0;
                            case "saturn": return -1;
                            case "uranus": return 0;
                            case "neptune": return 0;
                            case "pluto": return -1;
                        }
                        break;
                    }
            }
            return 0;
        }
    }
}
