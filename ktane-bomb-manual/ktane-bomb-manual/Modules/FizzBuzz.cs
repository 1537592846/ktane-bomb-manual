using System.Collections.Generic;

namespace ktane_bomb_manual.Modules
{
    public class FizzBuzz : Module
    {
        public Dictionary<string, string> Numbers;

        public FizzBuzz()
        {
            Numbers = new Dictionary<string, string>();
        }

        public override string Command(Bomb bomb, string command)
        {
            var color = "";
            var number = "";
            foreach (var word in command.Split(' '))
            {
                if (InternalFunctions.IsNumber(word)) number = word;
                if (InternalFunctions.IsColor(word)) color = word;
                if (!string.IsNullOrWhiteSpace(number) && !string.IsNullOrWhiteSpace(word))
                {
                    Numbers.Add(color, number);
                    color = "";
                    number = "";
                }
            }

            if (Numbers.Count != 3) return "Could not find enought numbers.";

            return Solve(bomb);
        }

        public override string Solve(Bomb bomb)
        {
            var result = "";
            foreach (var number in Numbers)
            {
                int count = CountForNumber(bomb, number);
                var numberText = "";
                foreach (var num in number.Value)
                {
                    numberText += "" + ((int.Parse(num.ToString()) + count) % 10);
                }

                var endNumber = int.Parse(numberText);
                result += endNumber % 3 == 0 && endNumber % 5 == 0 ? "FizzBuzz, " : endNumber % 3 == 0 ? "Fizz, " : endNumber % 5 == 0 ? "Buzz, " : "Number, ";
            }

            Solved = true;
            return result.Substring(0, result.Length - 2) + ".";
        }

        public int CountForNumber(Bomb bomb, KeyValuePair<string, string> number)
        {
            int count = 0;

            switch (number.Key)
            {
                case "red":
                    {
                        if (bomb.HasManyBatteriesHolders(3)) count += 7;
                        if (bomb.HasPort("serial")) count += 3;
                        if (bomb.HasSerialNumbersLetters(3, 3)) count += 4;
                        if (bomb.HasPort("dvi") && bomb.HasPort("stereo")) count += 2;
                        if (bomb.HasManyStrikes(2)) count += 6;
                        if (bomb.HasManyBatteries(5)) count += 1;
                        if (count == 0) count += 3;
                        break;
                    }
                case "green":
                    {
                        if (bomb.HasManyBatteriesHolders(3)) count += 3;
                        if (bomb.HasPort("serial")) count += 4;
                        if (bomb.HasSerialNumbersLetters(3, 3)) count += 5;
                        if (bomb.HasPort("dvi") && bomb.HasPort("stereo")) count += 3;
                        if (bomb.HasManyStrikes(2)) count += 6;
                        if (bomb.HasManyBatteries(5)) count += 2;
                        if (count == 0) count += 1;
                        break;
                    }
                case "blue":
                    {
                        if (bomb.HasManyBatteriesHolders(3)) count += 2;
                        if (bomb.HasPort("serial")) count += 9;
                        if (bomb.HasSerialNumbersLetters(3, 3)) count += 8;
                        if (bomb.HasPort("dvi") && bomb.HasPort("stereo")) count += 7;
                        if (bomb.HasManyStrikes(2)) count += 1;
                        if (bomb.HasManyBatteries(5)) count += 2;
                        if (count == 0) count += 8;
                        break;
                    }
                case "yellow":
                    {
                        if (bomb.HasManyBatteriesHolders(3)) count += 4;
                        if (bomb.HasPort("serial")) count += 2;
                        if (bomb.HasSerialNumbersLetters(3, 3)) count += 8;
                        if (bomb.HasPort("dvi") && bomb.HasPort("stereo")) count += 9;
                        if (bomb.HasManyStrikes(2)) count += 2;
                        if (bomb.HasManyBatteries(5)) count += 5;
                        if (count == 0) count += 3;
                        break;
                    }
                case "white":
                    {
                        if (bomb.HasManyBatteriesHolders(3)) count += 5;
                        if (bomb.HasPort("serial")) count += 8;
                        if (bomb.HasSerialNumbersLetters(3, 3)) count += 2;
                        if (bomb.HasPort("dvi") && bomb.HasPort("stereo")) count += 1;
                        if (bomb.HasManyStrikes(2)) count += 8;
                        if (bomb.HasManyBatteries(5)) count += 3;
                        if (count == 0) count += 4;
                        break;
                    }
                default: return -1;
            }

            return count;
        }
    }
}
