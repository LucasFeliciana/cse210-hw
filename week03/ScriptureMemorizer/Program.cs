// EXCEEDING REQUIREMENTS:
// I added a restart feature that allows users to practice memorizing the same scripture multiple times without restarting the program.
// When all words are hidden, the user can press Enter to show all words again and start a new memorization session.
// I improved the word hiding logic so the program only selects words that are still visible. This prevents the user from pressing Enter multiple times without seeing progress.
using System;
class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference("Doctrine and Covenants", 1, 37, 38);

        string text = "Search these commandments, for they are true and faithful, and the prophecies and promises which are in them shall all be fulfilled. " +
                      "What I the Lord have spoken, I have spoken, and I excuse not myself; and though the heavens and the earth pass away, my word shall not pass away, but shall all be fulfilled, whether by mine own voice or by the voice of my servants, it is the same.";

        Scripture scripture = new Scripture(reference, text);

        while (true)
        {
            Console.Clear();

            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();

            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("Congratulations! You completed the scripture!");
                Console.Write("Press Enter to restart or type 'quit' to exit: ");

                string restartInput = Console.ReadLine();

                if (restartInput == "quit")
                {
                    break;
                }

                scripture.Restart();
            }
            else
            {
                Console.Write("Press Enter to continue or type 'quit' to finish: ");

                string userInput = Console.ReadLine();

                if (userInput == "quit")
                {
                    break;
                }

                scripture.HideRandomWords(3);
            }
        }
    }
}