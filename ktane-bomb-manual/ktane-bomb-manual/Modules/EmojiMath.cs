namespace ktane_bomb_manual.Modules
{
    public class EmojiMath : Module
    {
        public string FirstNumber;
        public string SecondNumber;
        public string Operation;


        public override string Solve(Bomb bomb)
        {
            var message = "";
            switch (Operation)
            {
                case "+": message = "The result is " + (int.Parse(FirstNumber) + int.Parse(SecondNumber)) + "."; break;
                case "-": message = "The result is " + (int.Parse(FirstNumber) - int.Parse(SecondNumber)) + "."; break;
                case "/": message = "The result is " + (1.0 * int.Parse(FirstNumber) / int.Parse(SecondNumber)) + "."; break;
                case "*": message = "The result is " + (int.Parse(FirstNumber) * int.Parse(SecondNumber)) + "."; break;
                default: return "Could not calculate.";
            }

            Solved = true;
            return message;
        }

        public override string Command(Bomb bomb, string command)
        {
            command = command.Replace("emoji math ", "");
            command = command.Replace(" ", "");
            command = command.Replace(":)", "0");
            command = command.Replace("=(", "1");
            command = command.Replace("(:", "2");
            command = command.Replace(")=", "3");
            command = command.Replace(":(", "4");
            command = command.Replace("):", "5");
            command = command.Replace("=)", "6");
            command = command.Replace("(=", "7");
            command = command.Replace(":|", "8");
            command = command.Replace("|:", "9");

            foreach (string letter in command)
            {
                if (letter == '+' || letter == '-' || letter == '/' || letter == '*')
                {
                    Operation = letter.ToString();
                    continue;
                }

                if (string.IsNullOrWhiteSpace(Operation))
                {
                    FirstNumber += letter;
                }
                else
                {
                    SecondNumber += letter.ToString();
                }
            }

            return Solve(bomb);
        }
    }
}
