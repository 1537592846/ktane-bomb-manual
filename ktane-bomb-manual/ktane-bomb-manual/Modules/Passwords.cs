﻿using System.Collections.Generic;

namespace ktane_bomb_manual.Modules
{
    public class Passwords : Module
    {
        public Passwords()
        {
            Group1 = new List<string>();
            Group2 = new List<string>();
            Group3 = new List<string>();
            Group4 = new List<string>();
            Group5 = new List<string>();
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
                var solveReturn = Solve(bomb);
                Solved = solveReturn != "Can't solve it yet.";
                return solveReturn;
            }
            if (command.Contains("reset"))
            {
                Reset();
                return "Module reseted";
            }
            AddLetters(command);
            if (Group1.Count > 0 && Group2.Count > 0 && Group3.Count > 0 && Group4.Count > 0 && Group5.Count > 0)
            {
                var solveReturn = Solve(bomb);
                Solved = solveReturn != "Can't solve it yet.";
                return solveReturn;
            }
            return "Letters added";
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
                Group1.Add("");
                foreach (var phoneticLetter in input.Split(' '))
                {
                    var letter = InternalFunctions.GetLetterFromPhoneticLetter(phoneticLetter);
                    if (!string.IsNullOrEmpty(letter)) Group1.Add(letter);
                }
                return;
            }

            if (input.Contains("second"))
            {
                Group2.Clear();
                Group2.Add("");
                foreach (var phoneticLetter in input.Split(' '))
                {
                    var letter = InternalFunctions.GetLetterFromPhoneticLetter(phoneticLetter);
                    if (!string.IsNullOrEmpty(letter)) Group2.Add(letter);
                }
                return;
            }

            if (input.Contains("third"))
            {
                Group3.Clear();
                Group3.Add("");
                foreach (var phoneticLetter in input.Split(' '))
                {
                    var letter = InternalFunctions.GetLetterFromPhoneticLetter(phoneticLetter);
                    if (!string.IsNullOrEmpty(letter)) Group3.Add(letter);
                }
                return;
            }

            if (input.Contains("fourth"))
            {
                Group4.Clear();
                Group4.Add("");
                foreach (var phoneticLetter in input.Split(' '))
                {
                    var letter = InternalFunctions.GetLetterFromPhoneticLetter(phoneticLetter);
                    if (!string.IsNullOrEmpty(letter)) Group4.Add(letter);
                }
                return;
            }

            if (input.Contains("fifth") || input.Contains("last"))
            {
                Group5.Clear();
                Group5.Add("");
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

            foreach (var letter1 in Group1)
            {
                foreach (var letter2 in Group2)
                {
                    foreach (var letter3 in Group3)
                    {
                        foreach (var letter4 in Group4)
                        {
                            foreach (var letter5 in Group5)
                            {
                                if (HasWordStartingWith(letter1 + letter2 + letter3 + letter4 + letter5))
                                {
                                    wordList.Add(Word(letter1 + letter2 + letter3 + letter4 + letter5).Trim());
                                }
                            }
                        }
                    }
                }
            }

            if (wordList.Count > 1) return "Can't solve it yet.";
            return "The password is "+wordList[0]+".";
        }

        public bool HasWordStartingWith(string word)
        {
            return !string.IsNullOrEmpty(Word(word));
        }

        public string Word(string word)
        {
            if ("about".StartsWith(word)) return "about";
            if ("after".StartsWith(word)) return "after";
            if ("again".StartsWith(word)) return "again";
            if ("below".StartsWith(word)) return "below";
            if ("could".StartsWith(word)) return "could";
            if ("every".StartsWith(word)) return "every";
            if ("first".StartsWith(word)) return "first";
            if ("found".StartsWith(word)) return "found";
            if ("great".StartsWith(word)) return "great";
            if ("house".StartsWith(word)) return "house";
            if ("large".StartsWith(word)) return "large";
            if ("learn".StartsWith(word)) return "learn";
            if ("never".StartsWith(word)) return "never";
            if ("other".StartsWith(word)) return "other";
            if ("place".StartsWith(word)) return "place";
            if ("plant".StartsWith(word)) return "plant";
            if ("point".StartsWith(word)) return "point";
            if ("right".StartsWith(word)) return "right";
            if ("small".StartsWith(word)) return "small";
            if ("sound".StartsWith(word)) return "sound";
            if ("spell".StartsWith(word)) return "spell";
            if ("still".StartsWith(word)) return "still";
            if ("study".StartsWith(word)) return "study";
            if ("their".StartsWith(word)) return "their";
            if ("there".StartsWith(word)) return "there";
            if ("these".StartsWith(word)) return "these";
            if ("thing".StartsWith(word)) return "thing";
            if ("think".StartsWith(word)) return "think";
            if ("three".StartsWith(word)) return "three";
            if ("water".StartsWith(word)) return "water";
            if ("where".StartsWith(word)) return "where";
            if ("which".StartsWith(word)) return "which";
            if ("world".StartsWith(word)) return "world";
            if ("would".StartsWith(word)) return "would";
            if ("write".StartsWith(word)) return "write";
            return "";
        }
    }
}