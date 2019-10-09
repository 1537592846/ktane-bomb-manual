using System.Collections.Generic;
using System.Linq;

namespace ktane_bomb_manual.Modules
{
    public class Alphabet : Module
    {
        public Alphabet()
        {
            Letters = new List<string>();
        }

        public List<string> PossibleWords = new List<string>() { "jqxz", "qew", "ac", "zny", "tjl", "okbv", "dfw", "ykq", "lxe", "gs", "vsi", "pqjs", "vcn", "jr", "irnm", "op", "qydx", "hdu", "pkd", "argf", };
        public List<string> Letters;

        public override string Solve(Bomb bomb)
        {
            if (Letters.Count != 4) { Letters.Clear(); return "Not enough letters to solve."; }

            var message = "Press ";

            foreach (var letter in BiggestWordPossible())
            {
                message += InternalFunctions.GetPhoneticLetterFromLetter(letter) + ", ";
            }

            return message.Substring(0, message.Length - 2) + ".";
        }

        public override string Command(Bomb bomb, string command)
        {
            foreach (var word in command.Split(' '))
            {
                if (InternalFunctions.GetLetterFromPhoneticLetter(word) != "")
                {
                    Letters.Add(InternalFunctions.GetLetterFromPhoneticLetter(word));
                }
            }

            return Solve(bomb);
        }

        public string BiggestWordPossible()
        {
            var wordList = new List<string>();

            wordList.AddRange(PossibleWords.Where(x => WordHasLetters(x, 4)).OrderBy(x => x));
            wordList.AddRange(PossibleWords.Where(x => WordHasLetters(x, 3)).OrderBy(x => x));
            wordList.AddRange(PossibleWords.Where(x => WordHasLetters(x, 2)).OrderBy(x => x));
            wordList.AddRange(PossibleWords.Where(x => WordHasLetters(x, 1)).OrderBy(x => x));

            var wordToReturn = wordList.First();

            if (wordToReturn.Length == 2)
            {
                wordList.Clear();
                wordList.AddRange(PossibleWords.Where(x => WordHasLetters(x, 2) && x != wordToReturn).OrderBy(x => x));
                wordList.AddRange(PossibleWords.Where(x => WordHasLetters(x, 1) && x != wordToReturn).OrderBy(x => x));
                wordToReturn += wordList.First();
            }
            else
            {
                foreach (var letter in Letters.Where(x => !wordToReturn.Contains(x)).OrderBy(x => x))
                {
                    wordToReturn += letter;
                }
            }

            return wordToReturn;
        }

        public bool WordHasLetters(string word, int quantityToHave)
        {
            int count = 0;

            foreach (var letter in Letters)
            {
                if (word.Contains(letter)) count++;
            }
            return count == quantityToHave;
        }
    }
}
