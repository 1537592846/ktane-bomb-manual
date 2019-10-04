using System.Collections.Generic;
using System.Linq;

namespace ktane_bomb_manual.Modules
{
    public class Passwords : Module
    {
        public Passwords()
        {
            Group1 = new List<string>() { " " };
            Group2 = new List<string>() { " " };
            Group3 = new List<string>() { " " };
            Group4 = new List<string>() { " " };
            Group5 = new List<string>() { " " };
        }

        public List<string> Group1;
        public List<string> Group2;
        public List<string> Group3;
        public List<string> Group4;
        public List<string> Group5;

        public override string Solve(Bomb bomb)
        {
            return GetWord();
        }

        public override string Command(Bomb bomb, string command)
        {
            if (command.Contains("solve"))
            {
                var solve = Solve(bomb);
                Solved = solve != "Can't solve it yet.";
                return solve;
            }
            if (command.Contains("reset"))
            {
                Reset();
                return "Module reseted";
            }
            AddLetters(command);

            var solveReturn = Solve(bomb);
            Solved = solveReturn != "Can't solve it yet.";

            return Solved ? solveReturn : "Letters added.";
        }

        public void Reset()
        {
            Group1 = new List<string>();
            Group2 = new List<string>();
            Group3 = new List<string>();
            Group4 = new List<string>();
            Group5 = new List<string>();
        }

        public void AddLetters(string input)
        {
            if (input.Contains("first"))
            {
                Group1.Clear();
                foreach (var phoneticLetter in input.Split(' '))
                {
                    var letter = InternalFunctions.GetLetterFromPhoneticLetter(phoneticLetter);
                    if (!string.IsNullOrEmpty(letter)) Group1.Add(letter);
                }

                Group2.Clear();
                Group3.Clear();
                Group4.Clear();
                Group5.Clear();

                Group2.Add(" ");
                Group3.Add(" ");
                Group4.Add(" ");
                Group5.Add(" ");

                return;
            }

            if (input.Contains("second"))
            {
                Group2.Clear();
                foreach (var phoneticLetter in input.Split(' '))
                {
                    var letter = InternalFunctions.GetLetterFromPhoneticLetter(phoneticLetter);
                    if (!string.IsNullOrEmpty(letter)) Group2.Add(letter);
                }

                Group3.Clear();
                Group4.Clear();
                Group5.Clear();

                Group3.Add(" ");
                Group4.Add(" ");
                Group5.Add(" ");

                return;
            }

            if (input.Contains("third"))
            {
                Group3.Clear();
                foreach (var phoneticLetter in input.Split(' '))
                {
                    var letter = InternalFunctions.GetLetterFromPhoneticLetter(phoneticLetter);
                    if (!string.IsNullOrEmpty(letter)) Group3.Add(letter);
                }

                Group4.Clear();
                Group5.Clear();

                Group4.Add(" ");
                Group5.Add(" ");

                return;
            }

            if (input.Contains("fourth"))
            {
                Group4.Clear();
                foreach (var phoneticLetter in input.Split(' '))
                {
                    var letter = InternalFunctions.GetLetterFromPhoneticLetter(phoneticLetter);
                    if (!string.IsNullOrEmpty(letter)) Group4.Add(letter);
                }

                Group5.Clear();

                Group5.Add(" ");

                return;
            }

            if (input.Contains("fifth") || input.Contains("last"))
            {
                Group5.Clear();
                foreach (var phoneticLetter in input.Split(' '))
                {
                    var letter = InternalFunctions.GetLetterFromPhoneticLetter(phoneticLetter);
                    if (!string.IsNullOrEmpty(letter)) Group5.Add(letter);
                }
                return;
            }
        }

        public string GetWord()
        {
            var wordList = new List<string>();

            foreach (var letter1 in Group1.OrderBy(x => x))
            {
                foreach (var letter2 in Group2.OrderBy(x => x))
                {
                    foreach (var letter3 in Group3.OrderBy(x => x))
                    {
                        foreach (var letter4 in Group4.OrderBy(x => x))
                        {
                            foreach (var letter5 in Group5.OrderBy(x => x))
                            {
                                wordList.AddRange(Word(letter1 + letter2 + letter3 + letter4 + letter5));
                            }
                        }
                    }
                }
            }
            if (wordList.Count == 1) return "The password is " + wordList[0] + ".";
            return "Can't solve it yet.";
        }

        public List<string> Word(string word)
        {
            word = word.Trim();
            if (string.IsNullOrWhiteSpace(word)) return new List<string>();
            var wordsReturn = "";
            if ("about".StartsWith(word)) wordsReturn += "about ";
            if ("after".StartsWith(word)) wordsReturn += "after ";
            if ("again".StartsWith(word)) wordsReturn += "again ";
            if ("below".StartsWith(word)) wordsReturn += "below ";
            if ("could".StartsWith(word)) wordsReturn += "could ";
            if ("every".StartsWith(word)) wordsReturn += "every ";
            if ("first".StartsWith(word)) wordsReturn += "first ";
            if ("found".StartsWith(word)) wordsReturn += "found ";
            if ("great".StartsWith(word)) wordsReturn += "great ";
            if ("house".StartsWith(word)) wordsReturn += "house ";
            if ("large".StartsWith(word)) wordsReturn += "large ";
            if ("learn".StartsWith(word)) wordsReturn += "learn ";
            if ("never".StartsWith(word)) wordsReturn += "never ";
            if ("other".StartsWith(word)) wordsReturn += "other ";
            if ("place".StartsWith(word)) wordsReturn += "place ";
            if ("plant".StartsWith(word)) wordsReturn += "plant ";
            if ("point".StartsWith(word)) wordsReturn += "point ";
            if ("right".StartsWith(word)) wordsReturn += "right ";
            if ("small".StartsWith(word)) wordsReturn += "small ";
            if ("sound".StartsWith(word)) wordsReturn += "sound ";
            if ("spell".StartsWith(word)) wordsReturn += "spell ";
            if ("still".StartsWith(word)) wordsReturn += "still ";
            if ("study".StartsWith(word)) wordsReturn += "study ";
            if ("their".StartsWith(word)) wordsReturn += "their ";
            if ("there".StartsWith(word)) wordsReturn += "there ";
            if ("these".StartsWith(word)) wordsReturn += "these ";
            if ("thing".StartsWith(word)) wordsReturn += "thing ";
            if ("think".StartsWith(word)) wordsReturn += "think ";
            if ("three".StartsWith(word)) wordsReturn += "three ";
            if ("water".StartsWith(word)) wordsReturn += "water ";
            if ("where".StartsWith(word)) wordsReturn += "where ";
            if ("which".StartsWith(word)) wordsReturn += "which ";
            if ("world".StartsWith(word)) wordsReturn += "world ";
            if ("would".StartsWith(word)) wordsReturn += "would ";
            if ("write".StartsWith(word)) wordsReturn += "write ";
            return wordsReturn.Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
        }
    }
}