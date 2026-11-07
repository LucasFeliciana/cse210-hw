/*I added a Mood Tracker feature that allows users to record
how they are feeling when writing a journal entry.*/

using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        int choice = 0;

        while (choice != 5)
        {
            Console.WriteLine("Welcome to the Journal Program!");
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");

            Console.Write("What would you like to do? ");

            string input = Console.ReadLine() ?? "";

            if (!int.TryParse(input, out choice))
            {
                Console.WriteLine("Please enter a valid number.");
                Console.WriteLine();
                continue;
            }

            if (choice == 1)
            {
                string prompt = promptGenerator.GetRandomPrompt();

                Console.WriteLine(prompt);
                Console.Write("> ");

               
                string response = Console.ReadLine() ?? "";

                Console.WriteLine("How are you feeling today?");
                Console.WriteLine("1. Happy");
                Console.WriteLine("2. Normal");
                Console.WriteLine("3. Stressed");
                Console.WriteLine("4. Sad");
                Console.WriteLine("5. Excited");

                Console.Write("Choose your mood (1-5): ");
                string moodChoice = Console.ReadLine() ?? "";

                string mood = moodChoice switch
                {
                    "1" => "Happy",
                    "2" => "Normal",
                    "3" => "Stressed",
                    "4" => "Sad",
                    "5" => "Excited",
                    _ => "Not specified"
                };

                Entry entry = new Entry();

                entry._date = DateTime.Now.ToShortDateString();
                entry._promptText = prompt;
                entry._entryText = response;
                entry._mood = mood;

                journal.AddEntry(entry);

                Console.WriteLine("Entry saved in the journal.");
            }
            else if (choice == 2)
            {
                journal.DisplayAll();
            }
            else if (choice == 3)
            {
                Console.Write("What is the filename? ");
                string filename = Console.ReadLine() ?? "";

                try
                {
                    journal.LoadFromFile(filename);
                    Console.WriteLine("Journal loaded successfully.");
                }
                catch (Exception)
                {
                    Console.WriteLine("Unable to load the file.");
                }
            }
            else if (choice == 4)
            {
                Console.Write("What is the filename? ");
                string filename = Console.ReadLine() ?? "";

                try
                {
                    journal.SaveToFile(filename);
                    Console.WriteLine("Journal saved successfully.");
                }
                catch (Exception)
                {
                    Console.WriteLine("Unable to save the file.");
                }
            }
            else if (choice == 5)
            {
                Console.WriteLine("Goodbye!");
            }
            else
            {
                Console.WriteLine("Invalid option. Please try again.");
            }

            Console.WriteLine();
        }
    }
}
