using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ktane_bomb_manual.Modules
{
    public class CheapCheckout : Module
    {
        public CheapCheckout()
        {
            ItemsBought = new List<Item>();
        }

        public double ValuePaid;
        public string Day;
        public List<Item> PossibleItems = new List<Item>()
        {
            new Item(){ Name="bananas",OneUnitPrice=0.87,Category="fruit",BuyPerPound=true},
            new Item(){ Name="grapefruit",OneUnitPrice=1.08,Category="fruit",BuyPerPound=true},
            new Item(){ Name="lemons",OneUnitPrice=1.74,Category="fruit",BuyPerPound=true},
            new Item(){ Name="oranges",OneUnitPrice=0.80,Category="fruit",BuyPerPound=true},
            new Item(){ Name="tomatoes",OneUnitPrice=1.8,Category="fruit",BuyPerPound=true},

            new Item(){ Name="broccoli",OneUnitPrice=1.39,Category="vegetable",BuyPerPound=true},
            new Item(){ Name="lettuce",OneUnitPrice=1.10,Category="vegetable",BuyPerPound=true},
            new Item(){ Name="pasta sauce",OneUnitPrice=2.30,Category="vegetable"},
            new Item(){ Name="potatoes",OneUnitPrice=0.68,Category="vegetable",BuyPerPound=true},

            new Item(){ Name="candy canes",OneUnitPrice=3.51,Category="sweet"},
            new Item(){ Name="chocolate bar",OneUnitPrice=2.10,Category="sweet"},
            new Item(){ Name="cookies",OneUnitPrice=2.00,Category="sweet"},
            new Item(){ Name="fruit punch",OneUnitPrice=2.08,Category="sweet"},
            new Item(){ Name="grape jelly",OneUnitPrice=2.98,Category="sweet"},
            new Item(){ Name="gum",OneUnitPrice=1.12,Category="sweet"},
            new Item(){ Name="honey",OneUnitPrice=8.25,Category="sweet"},
            new Item(){ Name="lollipops",OneUnitPrice=2.61,Category="sweet"},
            new Item(){ Name="mints",OneUnitPrice=6.39,Category="sweet"},
            new Item(){ Name="soda",OneUnitPrice=2.05,Category="sweet"},
            new Item(){ Name="sugar",OneUnitPrice=2.08,Category="sweet"},

            new Item(){ Name="canola oil",OneUnitPrice=2.28,Category="oil"},
            new Item(){ Name="mayonnaise",OneUnitPrice=3.99,Category="oil"},
            new Item(){ Name="potato chips",OneUnitPrice=3.25f,Category="oil"},

            new Item(){ Name="cereal",OneUnitPrice=4.19,Category="grain"},
            new Item(){ Name="spaghetti",OneUnitPrice=2.92,Category="grain"},
            new Item(){ Name="white bread",OneUnitPrice=2.43,Category="grain"},

            new Item(){ Name="cheese",OneUnitPrice=4.49,Category="dairy"},
            new Item(){ Name="chocolate milk",OneUnitPrice=2.10,Category="dairy"},
            new Item(){ Name="white milk",OneUnitPrice=3.62,Category="dairy"},

            new Item(){ Name="chicken",OneUnitPrice=1.99,Category="protein",BuyPerPound=true},
            new Item(){ Name="peanut butter",OneUnitPrice=5.00,Category="protein"},
            new Item(){ Name="pork",OneUnitPrice=4.14,Category="protein",BuyPerPound=true},
            new Item(){ Name="steak",OneUnitPrice=4.97,Category="protein",BuyPerPound=true},
            new Item(){ Name="turkey",OneUnitPrice=2.98,Category="protein",BuyPerPound=true},

            new Item(){ Name="coffee beans",OneUnitPrice=7.85,Category="other"},
            new Item(){ Name="ketchup",OneUnitPrice=3.59,Category="other"},
            new Item(){ Name="mustard",OneUnitPrice=2.36,Category="other"},
            new Item(){ Name="socks",OneUnitPrice=6.97,Category="other"},

            new Item(){ Name="deodorant",OneUnitPrice=3.97,Category="care product"},
            new Item(){ Name="lotion",OneUnitPrice=7.97,Category="care product"},
            new Item(){ Name="paper towel",OneUnitPrice=9.46,Category="care product"},
            new Item(){ Name="shampoo",OneUnitPrice=4.98,Category="care product"},
            new Item(){ Name="tissues",OneUnitPrice=3.94,Category="care product"},
            new Item(){ Name="thoothpaste",OneUnitPrice=2.50,Category="care product"},

            new Item(){ Name="tea",OneUnitPrice=2.35,Category="water"},
            new Item(){ Name="water bottles",OneUnitPrice=9.37,Category="water"},
        };
        public List<Item> ItemsBought;

        public override string Solve(Bomb bomb)
        {
            var totalAmount = 0.0;
            foreach (var item in ItemsBought)
            {
                switch (Day)
                {
                    case "sunday":
                        {
                            if (item.BuyPerPound) totalAmount += Math.Round(item.OneUnitPrice * item.Quantity, 2);
                            else if (item.Name.Contains('s')) totalAmount += Math.Round(item.OneUnitPrice * item.Quantity, 2) + 2.15;
                            break;
                        }
                    case "monday":
                        {
                            if (ItemsBought.FindIndex(x => x == item) == 0 || ItemsBought.FindIndex(x => x == item) == 2 || ItemsBought.FindIndex(x => x == item) == 5) totalAmount += Math.Round(item.OneUnitPrice * item.Quantity * 0.85, 2);
                            else totalAmount += Math.Round(item.OneUnitPrice * item.Quantity, 2);
                            break;
                        }
                    case "tuesday":
                        {
                            if (item.BuyPerPound) totalAmount += totalAmount += Math.Round(item.OneUnitPrice * item.Quantity, 2);
                            totalAmount += Math.Round(item.OneUnitPrice * item.Quantity, 2) + InternalFunctions.DigitalRoot(item.OneUnitPrice);
                            break;
                        }
                    case "wednesday":
                        {
                            var largestDigit = item.OneUnitPrice.ToString().Replace(".", "").AsEnumerable().ToList().OrderBy(x => x).First();
                            var smallestDigit = item.OneUnitPrice.ToString().Replace(".", "").AsEnumerable().ToList().OrderBy(x => x).Last();
                            item.OneUnitPrice = double.Parse(item.OneUnitPrice.ToString().Replace(largestDigit, smallestDigit), CultureInfo.InvariantCulture);
                            totalAmount += Math.Round(item.OneUnitPrice * item.Quantity, 2);
                            break;
                        }
                    case "thursday":
                        {
                            if (ItemsBought.FindIndex(x => x == item) % 2 == 0) totalAmount += Math.Round(item.OneUnitPrice * item.Quantity * 0.5, 2);
                            else totalAmount += Math.Round(item.OneUnitPrice * item.Quantity, 2);
                            break;
                        }
                    case "friday":
                        {
                            if (item.Category == "fruit") totalAmount += Math.Round(item.OneUnitPrice * item.Quantity * 1.25, 2);
                            else totalAmount += Math.Round(item.OneUnitPrice * item.Quantity, 2);
                            break;
                        }
                    case "saturday":
                        {
                            if (item.Category == "sweet") totalAmount += Math.Round(item.OneUnitPrice * item.Quantity * 0.65, 2);
                            else totalAmount += Math.Round(item.OneUnitPrice * item.Quantity, 2);
                            break;
                        }
                    default: break;
                }
            }
            Solved = true;

            if (totalAmount > ValuePaid)
            {
                var message = "The amount of the cart is ";
                var dollars = totalAmount.ToString().Split(',')[0];
                message += dollars == "1" ? dollars + " dollar" : dollars + " dollars";
                var cents = totalAmount.ToString().Split(',')[1];
                if (cents == "0") return message + ".";
                message += " and ";
                message += cents == "01" ? "1 cent." : (int.Parse(cents) + " cents.");
                return message;
            }
            else
            {
                totalAmount = Math.Round(ValuePaid - totalAmount, 2);
                var message = "Return ";
                var dollars = totalAmount.ToString().Split(',')[0];
                message += dollars == "1" ? dollars + " dollar" : dollars + " dollars";
                var cents = totalAmount.ToString().Split(',')[1];
                if (cents == "00") return message + ".";
                message += " and ";
                message += cents == "01" ? "1 cent." : (int.Parse(cents) + " cents.");
                return message;
            }
        }

        public override string Command(Bomb bomb, string command)
        {
            bool? NumberInTheFront = null;
            var splitCommand = command.Split(' ').ToList();

            foreach (var word in command.Split(' '))
            {
                if (word.Contains("dollar"))
                {
                    var itemIndex = splitCommand.FindIndex(x => x == word);
                    ValuePaid = double.Parse(splitCommand[itemIndex - 1], CultureInfo.InvariantCulture);
                    continue;
                }
                if (word == "sunday" || word == "monday" || word == "tuesday" || word == "wednesday" || word == "thursday" || word == "friday" || word == "saturday")
                {
                    Day = word;
                    continue;
                }
                if (!PossibleItems.Select(x => x.Name).Contains(word)) continue;
                ItemsBought.Add(PossibleItems.Where(x => x.Name == word).First());
                if (ItemsBought.Last().BuyPerPound)
                {
                    var itemIndex = splitCommand.FindIndex(x => x == ItemsBought.Last().Name);
                    switch (NumberInTheFront)
                    {
                        case true: { ItemsBought.Last().Quantity = double.Parse(splitCommand[itemIndex - 1], CultureInfo.InvariantCulture); break; }
                        case false: { ItemsBought.Last().Quantity = double.Parse(splitCommand[itemIndex + 1], CultureInfo.InvariantCulture); break; }
                        default:
                            {
                                NumberInTheFront = InternalFunctions.IsNumber(splitCommand[itemIndex - 1]);
                                if (NumberInTheFront.Value) ItemsBought.Last().Quantity = double.Parse(splitCommand[itemIndex - 1], CultureInfo.InvariantCulture);
                                else ItemsBought.Last().Quantity = double.Parse(splitCommand[itemIndex + 1], CultureInfo.InvariantCulture);
                                break;
                            }
                    }
                }
                else
                {
                    ItemsBought.Last().Quantity = 1;
                }
            }

            return Solve(bomb);
        }
    }

    public class Item
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public double OneUnitPrice { get; set; }
        public string Category { get; set; }
        public bool BuyPerPound { get; set; }
    }
}
