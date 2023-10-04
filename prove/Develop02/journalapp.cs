using System;

class JournalApp
{
    static void Main(string[] args)
    {
        PromptGenerator promptGenerator = new PromptGenerator();
        Journal journal = new Journal();

        string randomPrompt = promptGenerator.GetRandomPrompt();
        Console.WriteLine("Today's Journal Prompt:");
        Console.WriteLine(randomPrompt);

        Console.Write("Enter Your Response: ");
        string userResponse = Console.ReadLine();

        DateTime currentDate = DateTime.Now;
        Entry journalEntry = new Entry(currentDate, randomPrompt, userResponse);

        // add entry to the journal
        journal.AddEntry(journalEntry);

        // display all entries
        Console.WriteLine("All Entries: ");
        journal.DisplayAllEntries();

        // Save entries to a file
        Console.Write("Enter a filename to save entries: ");
        string saveFilename = Console.ReadLine();
        journal.SaveToFile(saveFilename);

        // Load entries from a file
        Console.Write("Enter a filename to load entries: ");
        string loadFilename = Console.ReadLine();
        journal.LoadFromFile(loadFilename);

        // Display all entries after loading
        Console.WriteLine("All Entries After Loading:");
        journal.DisplayAllEntries();


    }
}
