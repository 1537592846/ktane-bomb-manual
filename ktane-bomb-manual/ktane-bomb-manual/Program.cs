using ktane_bomb_manual;
using System;
using System.Globalization;
using System.Linq;
using System.Speech.Recognition;
using System.Speech.Synthesis;

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
                Console.WriteLine(Command(command));
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

        public static string Command(string command)
        {
            var commandReturn = "";
            try
            {
                if (command.Contains("new bomb"))
                {
                    bomb = bomb = new Bomb();
                    return "Bomb reseted.";
                }
                if (command.Contains("bomb"))
                {
                    bomb.Command(command);
                    return "Command executed.";
                }
                if (command.Contains("solve"))
                {
                    commandReturn = bomb.GetModule(command.Replace("solve", "").Trim()).Solve(bomb);
                    if (commandReturn == "")
                    {
                        commandReturn = "Command computed.";
                    }
                    return commandReturn;
                }
                try
                {
                    commandReturn = bomb.GetModule(command.Split(' ')[0] + command.Split(' ')[1] + command.Split(' ')[2]).Command(bomb, command);
                }
                catch
                {
                    try
                    {
                        commandReturn = bomb.GetModule(command.Split(' ')[0] + command.Split(' ')[1]).Command(bomb, command);
                    }
                    catch
                    {
                        try
                        {
                            commandReturn = bomb.GetModule(command.Split(' ')[0]).Command(bomb, command);
                        }
                        catch { commandReturn = "Module not found."; }
                    }
                }
                if (string.IsNullOrEmpty(commandReturn)) commandReturn = "Module added";
            }
            catch
            {
                commandReturn = "Command not executed";
            }

            return commandReturn;
        }

        // Handle the SpeechRecognized event.  
        static void recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            var command = e.Result.Text;

            Console.WriteLine(command);
            synthesizer_SpeechSynthesize(Command(command));
        }

        static void synthesizer_SpeechSynthesize(string message)
        {
            SpeechSynthesizer synth = new SpeechSynthesizer();

            // Configure the speech voice
            synth.SelectVoice("Microsoft Zira Desktop");

            // Configure the audio output.   
            synth.SetOutputToDefaultAudioDevice();

            // Speak a string.  
            synth.Speak(message);
        }
    }
}