using System.Collections.Generic;
using System.Linq;

namespace ktane_bomb_manual.Modules
{
    public class ForgetMeNot : Module
    {
        public ForgetMeNot()
        {
            EndNumbers = new List<string>();
        }

        public List<string> EndNumbers;

        public override string Solve(Bomb bomb)
        {
            var message = "Listing the number, pay attention. ";

            for (int i = 0; i < EndNumbers.Count; i++)
            {
                message += EndNumbers[i];
                message += i % 3 == 2 ? " next. " : ", ";
            }
            while (!char.IsDigit(message.Last())) { message = message.Substring(0, message.Count() - 1); }

            Solved = true;

            return message+" done.";
        }

        public void AddNumber(Bomb bomb, string number)
        {
            if (EndNumbers.Count == 0)
            {
                if (bomb.HasUnlitIndicator("car")) { EndNumbers.Add((2 + int.Parse(number)).ToString().Last().ToString()); return; }
                if (bomb.GetUnlitIndicators() > bomb.GetLitIndicators()) { EndNumbers.Add((7 + int.Parse(number)).ToString().Last().ToString()); return; }
                if (bomb.GetUnlitIndicators() == 0) { EndNumbers.Add((bomb.GetLitIndicators() + int.Parse(number)).ToString().Last().ToString()); return; }
                EndNumbers.Add((bomb.GetLastSerialDigit() + int.Parse(number)).ToString().Last().ToString());
                return;
            }

            if (EndNumbers.Count == 1)
            {
                if (bomb.HasPort("serial") && bomb.GetManyDigitsInSerial() >= 3) { EndNumbers.Add((3 + int.Parse(number)).ToString().Last().ToString()); return; }
                if (int.Parse(EndNumbers[0]) % 2 == 0) { EndNumbers.Add((int.Parse(EndNumbers[0]) + 1 + int.Parse(number)).ToString().Last().ToString()); return; }
                EndNumbers.Add((int.Parse(EndNumbers[0]) - 1 + int.Parse(number)).ToString().Last().ToString());
                return;
            }

            if (EndNumbers[EndNumbers.Count - 1] == "0" || EndNumbers[EndNumbers.Count - 2] == "0") { EndNumbers.Add((bomb.GetBiggestSerialDigit() + int.Parse(number)).ToString().Last().ToString()); return; }
            if (int.Parse(EndNumbers[EndNumbers.Count - 1]) % 2 == 0 && int.Parse(EndNumbers[EndNumbers.Count - 2]) % 2 == 0) { EndNumbers.Add(bomb.GetSmallestOddSerialDigit() != -1 ? (bomb.GetSmallestOddSerialDigit() + int.Parse(number)).ToString().Last().ToString() : (9 + int.Parse(number)).ToString().Last().ToString()); return; }
            EndNumbers.Add((int.Parse((int.Parse(EndNumbers[EndNumbers.Count - 1]) + int.Parse(EndNumbers[EndNumbers.Count - 2])).ToString().Substring(0, 1)) + int.Parse(number)).ToString().Last().ToString());
        }
    }
}
