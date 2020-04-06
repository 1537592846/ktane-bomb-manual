using ktane_bomb_manual;
using NUnit.Framework;
using System.Linq;

namespace Tests
{
    public class TheCenturionTest
    {
        public Program program;

        [SetUp]
        public void Setup()
        {
            //Instanciando a classe do programa
            program = new Program();
        }

        [Test]
        public void TheCenturion_Test()
        {
            //Bomb settings
            AssertCommand("Serial added.", ValidateCommand("bomb serial is tango hotel 8 zulu kilo 9"), "Serial configuration");
            AssertCommand("AA batteries added.", ValidateCommand("bomb has 4 aa batteries"), "AA batteries configuration");
            AssertCommand("D batteries added.", ValidateCommand("bomb has 1 d battery"), "D batteries configuration");
            AssertCommand("Lit MSA indicator added.", ValidateCommand("bomb has indicator mike sierra alpha lit"), "Indicator configuration");
            AssertCommand("Parallel port added.", ValidateCommand("bomb has 1 parallel port"), "Port configuration");
            AssertCommand("Port plates added.", ValidateCommand("bomb has 1 port plate"), "Port configuration");
            AssertCommand("Time added.", ValidateCommand("bomb has 100 minutes"), "Port configuration");
            AssertCommand("Modules quantity added.", ValidateCommand("bomb has 101 modules"), "Port configuration");

            //Adjacent letters
            AssertCommand("Press: November. Yankee. Charlie. Foxtrot.", ValidateCommand("adjacent letters romeo november quebec lima uniform yankee sierra hotel charlie tango foxtrot victor"), "Adjacent Letters");

            //Adventure Games
            AssertCommand("Use symbol, then caber.", ValidateCommand("adventure games golem 6 8 3 5'3 41C 9.0m/s 107kpa broadsword caber grimoire lamp throphy symbol"), "Adventure Games");

            //Alphabet
            AssertCommand("Press zulu, november, yankee, lima.", ValidateCommand("alphabet zulu yankee november lima"), "Alphabet");

            //Astrology
            AssertCommand("Poor omen when the timer has a 1.", ValidateCommand("astrology fire uranus aries"), "Astrology");


            //Binary LEDs
            AssertCommand("Cut the green one on 1-2-5.", ValidateCommand("binary leds 1,3 2,3,4,5 5 1,2,5 2 1,2,5 5"), "Binary LEDs");

            //Bitmaps
            AssertCommand("First quadrant added.", ValidateCommand("bitmaps 3 1,3 3,4"), "Bitmaps");
            AssertCommand("Second quadrant added.", ValidateCommand("bitmaps 1,2,3,4 1,2,4 1,2,3,4 1"), "Bitmaps");
            AssertCommand("Third quadrant added.", ValidateCommand("bitmaps 2 1,3,4 2,4 3,4"), "Bitmaps");
            AssertCommand("Press 4.", ValidateCommand("bitmaps 1,2,3 3 2,3,4 1"), "Bitmaps");

            //Bitwise
            AssertCommand("The answer is 0, 0, 0, 0, 0, 0, 0, 1.", ValidateCommand("bitwise and"), "Bitwise");

            //Bulb
            AssertCommand("First unscrew, then press I, then press I, then press I, then screw, then you're done.", ValidateCommand("bulb blue off opaque"), "Bulb");

            //Cheap Checkout
            AssertCommand("Return 1 dollar and 1 cent.", ValidateCommand("cheap checkout 22 dollars saturday honey deodorant mustard socks 1 potatoes 1.5 lettuce"), "Cheap Checkout");

            //Chess
            AssertCommand("The position is echo 5.", ValidateCommand("chess echo 1 bravo 1 bravo 5 alpha 6 delta 4 delta 3"), "Chess");

            //Clock
            AssertCommand("Set the hours to the 5 o'clock position.", ValidateCommand("clock hours gold matches no number"), "Clock");
            AssertCommand("Set the minutes to 23.", ValidateCommand("clock minutes spades gold black am present"), "Clock");

            //Color math
            AssertCommand("The order is magenta, black, magenta, gray.", ValidateCommand("color math black white yellow magenta green addiction orange purple white orange"), "Color Math");

            //Complicate wires
            AssertCommand("Leave it.", ValidateCommand("complicated wires red blue led"), "Complicated wires");
            AssertCommand("Leave it.", ValidateCommand("complicated wires red"), "Complicated wires");
            AssertCommand("Leave it.", ValidateCommand("complicated wires red blue star led"), "Complicated wires");
            AssertCommand("Cut it.", ValidateCommand("complicated wires blue led"), "Complicated wires");
            AssertCommand("Cut it.", ValidateCommand("complicated wires red star"), "Complicated wires");
            AssertCommand("Cut it.", ValidateCommand("complicated wires white"), "Complicated wires");

            //Connection Check
            AssertCommand("Connection 1 is not connected. Connection 2 is not connected. Connection 3 is not connected. Connection 4 is not connected.", ValidateCommand("connection check 51 38 17 25"), "Connection Check");

            //Cryptography            
            AssertCommand("Order is india, romeo, november, oscar, whiskey.", ValidateCommand("cryptography 4 3 4 3 3 4 4 4 3 5 3 8 2 3 7 5 november india romeo oscar whiskey"), "Cryptography");

            //Emoji Math
            AssertCommand("The result is -54.", ValidateCommand("emoji math )= :) - :| :("), "Emoji Math");

            //Fast Math
            AssertCommand("97.", ValidateCommand("fast math alpha november"), "Fast Math");
            AssertCommand("19.", ValidateCommand("fast math bravo delta"), "Fast Math");
            AssertCommand("03.", ValidateCommand("fast math golf charlie"), "Fast Math");
            AssertCommand("65.", ValidateCommand("fast math november delta"), "Fast Math");

            //FizzBuzz
            AssertCommand("Buzz, Number, Number.", ValidateCommand("fizz buzz white 0820717 red 0395544 blue 5764108"), "FizzBuzz");

            //Follow the Leader
            AssertCommand("Cut wires 5-6, 6-7, 9-10, 10-11, 11-12, 12-1, 4-5.", ValidateCommand("follow the leader 1 blue 3 white 4 white 5 yellow 6 red 7 black 9 blue 10 white 11 black 12 black"), "Follow the Leader");

            //LED Encryption
            AssertCommand("Press papa.", ValidateCommand("led encryption orange foxtrot papa bravo delta"), "LED Encryption");
            AssertCommand("Press india.", ValidateCommand("led encryption blue xray golf india yankee"), "LED Encryption");
            AssertCommand("Press sierra.", ValidateCommand("led encryption yellow mike tango oscar sierra"), "LED Encryption");
            AssertCommand("Press sierra.", ValidateCommand("led encryption blue uniform tango alpha sierra"), "LED Encryption");

            //Microcontrollers
            AssertCommand("Type added.", ValidateCommand("microcontrollers type is leds"), "Microcontrollers");
            AssertCommand("Serial added.", ValidateCommand("microcontrollers serial is foxtrot november xray 7 5 3 7 0 7 5 9"), "Microcontrollers");
            AssertCommand("Pin quantity added.", ValidateCommand("microcontrollers 10 pins"), "Microcontrollers");
            AssertCommand("White.", ValidateCommand("microcontrollers at 5"), "Microcontrollers");
            AssertCommand("Magenta.", ValidateCommand("microcontrollers at 2"), "Microcontrollers");
            AssertCommand("Red.", ValidateCommand("microcontrollers at 9"), "Microcontrollers");
            AssertCommand("White.", ValidateCommand("microcontrollers at 7"), "Microcontrollers");
            AssertCommand("Blue.", ValidateCommand("microcontrollers at 1"), "Microcontrollers");
            AssertCommand("White.", ValidateCommand("microcontrollers at 6"), "Microcontrollers");
            AssertCommand("White.", ValidateCommand("microcontrollers at 10"), "Microcontrollers");
            AssertCommand("Green.", ValidateCommand("microcontrollers at 3"), "Microcontrollers");
            AssertCommand("Yellow.", ValidateCommand("microcontrollers at 8"), "Microcontrollers");
            AssertCommand("White.", ValidateCommand("microcontrollers at 4"), "Microcontrollers");

            //Morsematics
            AssertCommand("Character added.", ValidateCommand("morsematics first dot dot dash dot next"), "Morsematics");
            AssertCommand("Character added.", ValidateCommand("morsematics second dash dot dash dot next"), "Morsematics");
            AssertCommand("Send dot dash dash dot done.", ValidateCommand("morsematics third dash dot dash next"), "Morsematics");

            //Murder
            AssertCommand("Scarlett, with Dagger, in Library.", ValidateCommand("murder peacock green white scarlet rope spanner candle dagger hall"), "Murder");

            //Passwords
            AssertCommand("Letters added.", ValidateCommand("passwords first golf bravo quebec yankee oscar charlie"), "Passwords");
            AssertCommand("Letters added.", ValidateCommand("passwords second whisley oscar sierra tango xray alpha"), "Passwords");
            AssertCommand("The password is could.", ValidateCommand("passwords third delta whiskey uniform india lima"), "Passwords");

            //Plumbing
            AssertCommand("Input: blue. Output: blue.", ValidateCommand("plumbing solve"), "Plumbing");

            //Round keypads
            AssertCommand("Press this ones: Aesc. Lambda. Little Yus. Lunate Sigma. Omega.", ValidateCommand("round keypads big yus yat little yus sigma omega question mark aesc lambda"), "Round keypads");

            //Safety safe
            AssertCommand("First dial: 2 turns. Second dial: 10 turns. Third dial: 4 turns. Fourth dial: 5 turns. Fifth dial: 7 turns. Sixth dial: 3 turns.", ValidateCommand("safety safe 6 3 4 6 10 1"), "Safety safe");

            //Screw
            AssertCommand("First color red, press alpha. Second color yellow, press second. Third color red, press alpha.", ValidateCommand("screw bravo charlie alpha delta white magenta blue yellow red green"), "Screw");

            //Simon screams
            AssertCommand("Sequence saved.", ValidateCommand("simon screams colors yellow orange red blue purple green"), "Simon screams");
            AssertCommand("Press green, then red, then blue.", ValidateCommand("simon screams yellow purple red"), "Simon screams");
            AssertCommand("Press blue, then purple, then red.", ValidateCommand("simon screams yellow purple red green"), "Simon screams");
            AssertCommand("Press green, then red, then blue.", ValidateCommand("simon screams yellow purple red green purple"), "Simon screams");

            //Simon states
            AssertCommand("Top left color added.", ValidateCommand("simon states top left blue"), "Simon states");
            AssertCommand("Press yellow.", ValidateCommand("simon states yellow"), "Simon states");
            AssertCommand("Press yellow blue.", ValidateCommand("simon states red green"), "Simon states");
            AssertCommand("Press yellow blue yellow.", ValidateCommand("simon states red yellow"), "Simon states");
            AssertCommand("Press yellow blue yellow red.", ValidateCommand("simon states all"), "Simon states");
            AssertCommand("Module defused.", ValidateCommand("simon states solved"), "Simon states");

            //Square button
            AssertCommand("Hold the button. What is the LED color?", ValidateCommand("square button blue run"), "Square button");
            AssertCommand("Release when the seconds are a multiple of seven.", ValidateCommand("square button led flick cyan"), "Square button");

            //Bomb final validations
            var modulesNotSolved = "";
            program.mockBomb.Modules.Where(x => !x.Solved).Select(x => x.ModuleName).ToList().ForEach(x => { modulesNotSolved += x + ", "; });
            Assert.AreEqual(program.mockBomb.Modules.Count(), program.mockBomb.Modules.Where(x => x.Solved).Count(), "Not enough modules solved. Modules not solved: " + modulesNotSolved, null);
        }

        public string ValidateCommand(string command)
        {
            return program.MockCommand(command);
        }

        public void AssertCommand(string expected, string obtained, string message)
        {
            Assert.AreEqual(expected, obtained, message, null);
        }
    }
}