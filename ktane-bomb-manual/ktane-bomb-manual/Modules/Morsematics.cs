namespace ktane_bomb_manual.Modules
{
    public class Morsematics : Module
    {
        public int RecievedCharacterValue1;
        public int RecievedCharacterValue2;
        public int RecievedCharacterValue3;
        public int PairCharacterValue1;
        public int PairCharacterValue2;

        public string RecievedCharacter1;
        public string RecievedCharacter2;
        public string RecievedCharacter3;

        public override string Solve(Bomb bomb)
        {
            if (string.IsNullOrEmpty(bomb.Serial) || string.IsNullOrEmpty(RecievedCharacter1) || string.IsNullOrEmpty(RecievedCharacter2) || string.IsNullOrEmpty(RecievedCharacter3)) return "Can't solve it yet.";
            return "Send " + Solution(bomb) + " done.";
        }

        public override string Command(Bomb bomb, string command)
        {
            if (command.Contains("solve"))
            {
                return Solve(bomb);
            }
            AddCharacter(command);
            return "";
        }

        public void AddCharacter(string input)
        {
            var splittedInput = input.Split(' ');
            var morse = "";
            foreach (var splitInput in splittedInput)
            {
                if (splitInput == "dash" || splitInput == "dot" || splitInput == "next")
                {
                    morse += splitInput + " ";
                }
            }

            morse = morse.Trim();

            if (input.Contains("first"))
            {
                RecievedCharacter1 = InternalFunctions.GetLetterFromMorse(morse);
                RecievedCharacterValue1 = InternalFunctions.GetNumberFromLetter(RecievedCharacter1);
                return;
            }
            if (input.Contains("second"))
            {
                RecievedCharacter2 = InternalFunctions.GetLetterFromMorse(morse);
                RecievedCharacterValue2 = InternalFunctions.GetNumberFromLetter(RecievedCharacter2);
                return;
            }
            if (input.Contains("third"))
            {
                RecievedCharacter3 = InternalFunctions.GetLetterFromMorse(morse);
                RecievedCharacterValue3 = InternalFunctions.GetNumberFromLetter(RecievedCharacter3);
                return;
            }
        }

        public string Solution(Bomb bomb)
        {
            PairCharacterValue1 = InternalFunctions.GetNumberFromLetter(bomb.GetSerialCharacterAtPosition(4));
            PairCharacterValue2 = InternalFunctions.GetNumberFromLetter(bomb.GetSerialCharacterAtPosition(5));

            ChangeCharacterValue(bomb.GetLitIndicatorsWithLetter(RecievedCharacter1), 1);
            ChangeCharacterValue(bomb.GetLitIndicatorsWithLetter(RecievedCharacter2), 1);
            ChangeCharacterValue(bomb.GetLitIndicatorsWithLetter(RecievedCharacter3), 1);
            ChangeCharacterValue(bomb.GetUnlitIndicatorsWithLetter(RecievedCharacter1), 2);
            ChangeCharacterValue(bomb.GetUnlitIndicatorsWithLetter(RecievedCharacter2), 2);
            ChangeCharacterValue(bomb.GetUnlitIndicatorsWithLetter(RecievedCharacter3), 2);

            if (InternalFunctions.IsSquare(PairCharacterValue1 + PairCharacterValue2))
                ChangeCharacterValue(4, 1);
            else
                ChangeCharacterValue(-4, 2);

            if (RecievedCharacterValue1 > RecievedCharacterValue2)
                if (RecievedCharacterValue1 > RecievedCharacterValue3)
                    ChangeCharacterValue(RecievedCharacterValue1, 1);
                else
                    ChangeCharacterValue(RecievedCharacterValue3, 1);
            else
                if (RecievedCharacterValue2 > RecievedCharacterValue3)
                ChangeCharacterValue(RecievedCharacterValue2, 1);
            else
                ChangeCharacterValue(RecievedCharacterValue3, 1);

            if (InternalFunctions.IsPrime(RecievedCharacterValue1)) ChangeCharacterValue(-RecievedCharacterValue1, 1);
            if (InternalFunctions.IsPrime(RecievedCharacterValue2)) ChangeCharacterValue(-RecievedCharacterValue2, 1);
            if (InternalFunctions.IsPrime(RecievedCharacterValue3)) ChangeCharacterValue(-RecievedCharacterValue3, 1);

            if (InternalFunctions.IsSquare(RecievedCharacterValue1)) ChangeCharacterValue(-RecievedCharacterValue1, 2);
            if (InternalFunctions.IsSquare(RecievedCharacterValue2)) ChangeCharacterValue(-RecievedCharacterValue2, 2);
            if (InternalFunctions.IsSquare(RecievedCharacterValue3)) ChangeCharacterValue(-RecievedCharacterValue3, 2);

            if (bomb.HasManyBatteries(1))
            {
                if (RecievedCharacterValue1 % bomb.GetBatteries() == 0) { ChangeCharacterValue(-RecievedCharacterValue1, 1); ChangeCharacterValue(-RecievedCharacterValue1, 2); }
                if (RecievedCharacterValue2 % bomb.GetBatteries() == 0) { ChangeCharacterValue(-RecievedCharacterValue2, 1); ChangeCharacterValue(-RecievedCharacterValue2, 2); }
                if (RecievedCharacterValue3 % bomb.GetBatteries() == 0) { ChangeCharacterValue(-RecievedCharacterValue3, 1); ChangeCharacterValue(-RecievedCharacterValue3, 2); }
            }

            if (PairCharacterValue1 == PairCharacterValue2)
                return InternalFunctions.GetMorseFromLetter(InternalFunctions.GetLetterFromNumber(PairCharacterValue1));
            else
                if (PairCharacterValue1 > PairCharacterValue2)
                return InternalFunctions.GetMorseFromLetter(InternalFunctions.GetLetterFromNumber(PairCharacterValue1 - PairCharacterValue2));
            else
                return InternalFunctions.GetMorseFromLetter(InternalFunctions.GetLetterFromNumber(PairCharacterValue1 + PairCharacterValue2));
        }

        public void ChangeCharacterValue(int value, int numberPair)
        {
            switch (numberPair)
            {
                case 1:
                    {
                        PairCharacterValue1 += value;
                        if (PairCharacterValue1 > 26 || PairCharacterValue1 < 1)
                        {
                            PairCharacterValue1 += 52;
                            PairCharacterValue1 = PairCharacterValue1 % 26;
                            if (PairCharacterValue1 == 0) PairCharacterValue1 = 26;
                        }
                        break;
                    }
                case 2:
                    {
                        PairCharacterValue2 += value;
                        if (PairCharacterValue2 > 26 || PairCharacterValue2 < 1)
                        {
                            PairCharacterValue2 += 52;
                            PairCharacterValue2 = PairCharacterValue2 % 26;
                            if (PairCharacterValue2 == 0) PairCharacterValue2 = 26;
                        }
                        break;
                    }
            }
        }
    }
}
