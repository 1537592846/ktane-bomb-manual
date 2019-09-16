using ktane_bomb_manual;
using System;
using System.Globalization;
using System.Linq;
using System.Speech.Recognition;

namespace SpeechRecognitionApp
{
    class Program
    {
        public static Bomb bomb;

        public static void Main()
        {
            while (true)
            {
                bomb = new Bomb();
                MainText();
                Console.Write("Input mode: ");
                var op = Console.ReadLine();
                if (op.Contains("text"))
                    MainText();
                else
                    MainVoice();
            }
        }

        public static void MainText()
        {
            while (true)
            {
                Console.Write("Command:");
                var command = Console.ReadLine();
                Command(command);
                Console.WriteLine();
            }
        }

        public static void MainVoice()
        {
            SpeechRecognitionEngine.InstalledRecognizers();

            // Create an in-process speech recognizer for the en-US locale.  
            using (
            SpeechRecognitionEngine recognizer =
              new SpeechRecognitionEngine(
                new CultureInfo("en-US")))
            {

                // Create and load a dictation grammar.  
                recognizer.LoadGrammar(new DictationGrammar());

                // Add a handler for the speech recognized event.  
                recognizer.SpeechRecognized +=
                  new EventHandler<SpeechRecognizedEventArgs>(recognizer_SpeechRecognized);

                // Configure input to the speech recognizer.  
                recognizer.SetInputToDefaultAudioDevice();

                // Start asynchronous, continuous speech recognition.
                recognizer.RecognizeAsync(RecognizeMode.Multiple);

                // Keep the console window open.  
                while (true)
                {
                    Console.ReadLine();
                }
            }
        }

        public static void Command(string command)
        {
            if (command.Contains("new bomb"))
            {
                bomb = bomb = new Bomb();
                Console.WriteLine("Command computed.");
                return;
            }
            if (command.Contains("bomb"))
            {
                bomb.Command(command);
                Console.WriteLine("Command computed.");
                return;
            }
            if (command.Contains("solve"))
            {
                var commandReturn = bomb.GetModule(command.Split(' ')[1]).Solve(bomb);
                if (commandReturn == "")
                {
                    Console.WriteLine("Command computed.");
                }
                else
                {
                    Console.WriteLine(commandReturn);
                }
                return;
            }
            bomb.GetModule(command.Split(' ')[0]).Command(bomb, command);
            Console.WriteLine("Module added");
        }

        // Handle the SpeechRecognized event.  
        static void recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            var command = e.Result.Text;

            Command(command);
            Console.WriteLine();
        }
    }
}