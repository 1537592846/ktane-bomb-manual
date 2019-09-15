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
            bomb = new Bomb();
            while (true)
            {
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
                if (command.Contains("solved") || command.Contains("defused")) return;

                if (command.Contains("bomb"))
                {
                    bomb.Command(command);
                }

                if (command.Contains("wires"))
                {
                    var commandReturn = bomb.GetModule("Wires").Command(bomb, command);
                    Console.Write(commandReturn);
                }
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

        // Handle the SpeechRecognized event.  
        static void recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            var command = e.Result.Text;

            if (command.Contains("wires"))
            {
                Console.WriteLine("Identified Wires command: " + command);
                Console.WriteLine("Resulting response: " + bomb.GetModule("Wires").Command(bomb, command));
            }
        }
    }
}