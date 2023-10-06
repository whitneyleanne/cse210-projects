using System;

class Program
{
    static void Main(string[] args)
    {
        PromptGenerator promptGenerator = new PromptGenerator();
        Journal journal = new Journal();

        bool isRunning = true;

        while (isRunning)
        {
            Console.WriteLine("Main Menu:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display all entries");
            Console.WriteLine("3. Save entries to a file");
            Console.WriteLine("4. Load entries from a file");
            Console.WriteLine("5. Exit"); 

            Console.Write("Enter your choice (1-5): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                // generate and display random prompt
                    string randomPrompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine("Today's Journal Prompt:");
                    Console.WriteLine(randomPrompt);

                    Console.Write("Enter Your Response: ");
                    string userResponse = Console.ReadLine();

                    DateTime currentDate = DateTime.Now;
                    Entry journalEntry = new Entry(currentDate, randomPrompt, userResponse);

                    // add entry to the journal
                    journal.AddEntry(journalEntry);
                    break;

                case "2":
                    // display all entries
                    Console.WriteLine("All Entries: ");
                    journal.DisplayAllEntries();
                    break;

                case "3":
                    // save entries to a file
                    Console.Write("Enter a filename to save entries: ");
                    string saveFilename = Console.ReadLine();
                    journal.SaveToFile(saveFilename);
                    break;
                
                case "4":
                    // Load entries from a file
                    Console.Write("Enter a filename to load entries: ");
                    string loadFilename = Console.ReadLine();
                    journal.LoadFromFile(loadFilename);
                    break;

                case "5":
                    // exit program
                    isRunning = false;
                    break;

                default: 
                    Console.WriteLine("Invalid choice. Please enter a valid option.");
                    break;           

            }  
        }


    }
}
