﻿using System.Collections.Generic;
using System.Linq;

namespace ktane_bomb_manual.Modules
{
    public class Cryptography : Module
    {
        List<int> Numbers;
        List<string> Letters;
        List<string> Text = new List<string>(){
            "scrooge",
            "knew",
            "he",
            "was",
            "dead",
            "of",
            "course",
            "he",
            "did",
            "how",
            "could",
            "it",
            "be",
            "otherwise",
            "scrooge",
            "and",
            "he",
            "were",
            "partners",
            "for",
            "i",
            "dont",
            "know",
            "how",
            "many",
            "years",
            "scrooge",
            "was",
            "his",
            "sole",
            "executor",
            "his",
            "sole",
            "administrator",
            "his",
            "sole",
            "assign",
            "his",
            "sole",
            "residuary",
            "legatee",
            "his",
            "sole",
            "friend",
            "and",
            "sole",
            "mourner",
            "and",
            "even",
            "scrooge",
            "was",
            "not",
            "so",
            "dreadfully",
            "cut",
            "up",
            "by",
            "the",
            "sad",
            "event",
            "but",
            "that",
            "he",
            "was",
            "an",
            "excellent",
            "man",
            "of",
            "business",
            "on",
            "the",
            "very",
            "day",
            "of",
            "the",
            "funeral",
            "and",
            "solemnised",
            "it",
            "with",
            "an",
            "undoubted",
            "bargain",
            "the",
            "mention",
            "of",
            "marleys",
            "funeral",
            "brings",
            "me",
            "back",
            "to",
            "the",
            "point",
            "i",
            "started",
            "from",
            "there",
            "is",
            "no",
            "doubt",
            "that",
            "marley",
            "was",
            "dead",
            "this",
            "must",
            "be",
            "distinctly",
            "understood",
            "or",
            "nothing",
            "wonderful",
            "can",
            "come",
            "of",
            "the",
            "story",
            "i",
            "am",
            "going",
            "to",
            "relate",
            "if",
            "we",
            "were",
            "not",
            "perfectly",
            "convinced",
            "that",
            "hamlets",
            "father",
            "died",
            "before",
            "the",
            "play",
            "began",
            "there",
            "would",
            "be",
            "nothing",
            "more",
            "remarkable",
            "in",
            "his",
            "taking",
            "a",
            "stroll",
            "at",
            "night",
            "in",
            "an",
            "easterly",
            "wind",
            "upon",
            "his",
            "own",
            "ramparts",
            "than",
            "there",
            "would",
            "be",
            "in",
            "any",
            "other",
            "middle",
            "aged",
            "gentleman",
            "rashly",
            "turning",
            "out",
            "after",
            "dark",
            "in",
            "a",
            "breezy",
            "spot",
            "say",
            "saint",
            "pauls",
            "churchyard",
            "for",
            "instance",
            "literally",
            "to",
            "astonish",
            "his",
            "sons",
            "weak",
            "mind",
            "scrooge",
            "never",
            "painted",
            "out",
            "old",
            "marleys",
            "name",
            "there",
            "it",
            "stood",
            "years",
            "afterwards",
            "above",
            "the",
            "warehouse",
            "door",
            "scrooge",
            "and",
            "marley",
            "the",
            "firm",
            "was",
            "known",
            "as",
            "scrooge",
            "and",
            "marley",
            "sometimes",
            "people",
            "new",
            "to",
            "the",
            "business",
            "called",
            "scrooge",
            "scrooge",
            "and",
            "sometimes",
            "marley",
            "but",
            "he",
            "answered",
            "to",
            "both",
            "names",
            "it",
            "was",
            "all",
            "the",
            "same",
            "to",
            "him",
            "oh",
            "but",
            "he",
            "was",
            "a",
            "tight",
            "fisted",
            "hand",
            "at",
            "the",
            "grind",
            "stone",
            "scrooge",
            "a",
            "squeezing",
            "wrenching",
            "grasping",
            "scraping",
            "clutching",
            "covetous",
            "old",
            "sinner",
            "hard",
            "and",
            "sharp",
            "as",
            "flint",
            "from",
            "which",
            "no",
            "steel",
            "had",
            "ever",
            "struck",
            "out",
            "generous",
            "fire",
            "secret",
            "and",
            "self",
            "contained",
            "and",
            "solitary",
            "as",
            "an",
            "oyster",
            "the",
            "cold",
            "within",
            "him",
            "froze",
            "his",
            "old",
            "features",
            "nipped",
            "his",
            "pointed",
            "nose",
            "shrivelled",
            "his",
            "cheek",
            "stiffened",
            "his",
            "gait",
            "made",
            "his",
            "eyes",
            "red",
            "his",
            "thin",
            "lips",
            "blue",
            "and",
            "spoke",
            "out",
            "shrewdly",
            "in",
            "his",
            "grating",
            "voice",
            "a",
            "frosty",
            "rime",
            "was",
            "on",
            "his",
            "head",
            "and",
            "on",
            "his",
            "eyebrows",
            "and",
            "his",
            "wiry",
            "chin",
            "he",
            "carried",
            "his",
            "own",
            "low",
            "temperature",
            "always",
            "about",
            "with",
            "him",
            "he",
            "iced",
            "his",
            "office",
            "in",
            "the",
            "dogdays",
            "and",
            "didnt",
            "thaw",
            "it",
            "one",
            "degree",
            "at",
            "christmas",
            "external",
            "heat",
            "and",
            "cold",
            "had",
            "little",
            "influence",
            "on",
            "scrooge",
            "no",
            "warmth",
            "could",
            "warm",
            "no",
            "wintry",
            "weather",
            "chill",
            "him",
            "no",
            "wind",
            "that",
            "blew",
            "was",
            "bitterer",
            "than",
            "he",
            "no",
            "falling",
            "snow",
            "was",
            "more",
            "intent",
            "upon",
            "its",
            "purpose",
            "no",
            "pelting",
            "rain",
            "less",
            "open",
            "to",
            "entreaty",
            "foul",
            "weather",
            "didnt",
            "know",
            "where",
            "to",
            "have",
            "him",
            "the",
            "heaviest",
            "rain",
            "and",
            "snow",
            "and",
            "hail",
            "and",
            "sleet",
            "could",
            "boast",
            "of",
            "the",
            "advantage",
            "over",
            "him",
            "in",
            "only",
            "one",
            "respect",
            "they",
            "often",
            "came",
            "down",
            "handsomely",
            "and",
            "scrooge",
            "never",
            "did",
            "nobody",
            "ever",
            "stopped",
            "him",
            "in",
            "the",
            "street",
            "to",
            "say",
            "with",
            "gladsome",
            "looks",
            "my",
            "dear",
            "scrooge",
            "how",
            "are",
            "you",
            "When",
            "will",
            "you",
            "come",
            "to",
            "see",
            "me",
            "no",
            "beggars",
            "implored",
            "him",
            "to",
            "bestow",
            "a",
            "trifle",
            "no",
            "children",
            "asked",
            "him",
            "what",
            "it",
            "was",
            "oclock",
            "no",
            "man",
            "or",
            "woman",
            "ever",
            "once",
            "in",
            "all",
            "his",
            "life",
            "inquired",
            "the",
            "way",
            "to",
            "such",
            "and",
            "such",
            "a",
            "place",
            "of",
            "scrooge",
            "even",
            "the",
            "blind",
            "mens",
            "dogs",
            "appeared",
            "to",
            "know",
            "him",
            "and",
            "when",
            "they",
            "saw",
            "him",
            "coming",
            "on",
            "would",
            "tug",
            "their",
            "owners",
            "into",
            "doorways",
            "and",
            "up",
            "courts",
            "and",
            "then",
            "would",
            "wag",
            "their",
            "tails",
            "as",
            "though",
            "they",
            "said",
            "no",
            "eye",
            "at",
            "all",
            "is",
            "better",
            "than",
            "an",
            "evil",
            "eye",
            "dark",
            "master",
            "but",
            "what",
            "did",
            "scrooge",
            "care",
            "it",
            "was",
            "the",
            "very",
            "thing",
            "he",
            "liked",
            "to",
            "edge",
            "his",
            "way",
            "along",
            "the",
            "crowded",
            "paths",
            "of",
            "life",
            "warning",
            "all",
            "human",
            "sympathy",
            "to",
            "keep",
            "its",
            "distance",
            "was",
            "what",
            "the",
            "knowing",
            "ones",
            "call",
            "nuts",
            "to",
            "scrooge" };

        public Cryptography()
        {
            Numbers = new List<int>();
            Letters = new List<string>();
        }

        public override string Command(Bomb bomb, string command)
        {
            foreach (var word in command.Split(' '))
            {
                if (InternalFunctions.IsNumber(word)) Numbers.Add(InternalFunctions.GetNumber(word));
                if (InternalFunctions.IsPhoneticLetter(word)) Letters.Add(InternalFunctions.GetLetterFromPhoneticLetter(word));
            }

            if (Letters.Count != 5) return "Not enought phonetic letters.";

            return Solve(bomb);
        }

        public override string Solve(Bomb bomb)
        {
            for (int i = 0; i < Text.Count; i++)
            {
                var equal = true;

                for (int j = 0; j < Numbers.Count; j++)
                {
                    if (Text[i + j].Length != Numbers[j]) { equal = false; break; }
                }

                if (equal) return TextToLetters(i);
            }

            return "Could not find the text.";
        }

        public string TextToLetters(int start)
        {
            string TextToInform = "";
            foreach (var word in Text.GetRange(start, Numbers.Count))
            {
                TextToInform += word;
            }

            var result = "Order is ";
            List<int> indexList = new List<int>() {
                TextToInform.IndexOf(Letters[0]),
                TextToInform.IndexOf(Letters[1]),
                TextToInform.IndexOf(Letters[2]),
                TextToInform.IndexOf(Letters[3]),
                TextToInform.IndexOf(Letters[4])
            };

            indexList.Sort();

            foreach (var index in indexList)
            {
                result += InternalFunctions.GetPhoneticLetterFromLetter(TextToInform[index]) + ", ";
            }

            Solved = true;

            return result.Substring(0, result.Length - 2) + ".";
        }
    }
}
