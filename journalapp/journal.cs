using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> EntriesList;

    public Journal()
    {
        EntriesList = new List<Entry>();
    }

    public void AddEntry(Entry entry)
    {
        EntriesList.Add(entry);
    }

    public void DisplayAllEntries()
    {
        foreach (Entry entry in EntriesList)
        {
            entry.DisplayEntry();
            Console.WriteLine();
        }
    }

    public void SaveToFile(string filename)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (Entry entry in EntriesList)
                {
                    writer.WriteLine($"{entry.Date}");
                    writer.WriteLine($"{entry.Prompt}");
                    writer.WriteLine($"{entry.Response}");
                    writer.WriteLine(); // Add a blank line between entries
                }
            }

            Console.WriteLine($"Entries saved to {filename}");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Error saving entries to {filename}: {ex.Message}");
        }
    }

    public void LoadFromFile(string filename)
    {
        EntriesList.Clear(); // Clear existing entries before loading

        try
        {
            using (StreamReader reader = new StreamReader(filename))
            {
                DateTime date = DateTime.MinValue;
                string prompt = "";
                string response = "";

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    if (string.IsNullOrWhiteSpace(line))
                    {
                        // Blank line indicates the end of an entry
                        AddEntry(new Entry(date, prompt, response));
                        date = DateTime.MinValue;
                        prompt = "";
                        response = "";
                    }
                    else
                    {
                        if (date == DateTime.MinValue)
                            date = DateTime.Parse(line);
                        else if (string.IsNullOrWhiteSpace(prompt))
                            prompt = line;
                        else if (string.IsNullOrWhiteSpace(response))
                            response = line;
                    }
                }
            }

            Console.WriteLine($"Entries loaded from {filename}");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Error loading entries from {filename}: {ex.Message}");
        }
    }
}
