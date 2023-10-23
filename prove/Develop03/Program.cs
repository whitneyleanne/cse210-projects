
using System;
using System.Collections.Generic;
using System.Linq;

// This class manages the random class throughout the application
// It manages consistency!
public static class Utils
{
    public static readonly Random Random = new Random();
}

//This class extends the functionality of generic lists and provides a method to shuffle the elements within the list in a random order.
//ChatGPT and my brother helped me figure this out.
public static class Extensions
{
    public static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = Utils.Random.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}

//this is a manager for the scripture objects, allowing scriptures to be added to an internal list and then be selected at random from the collection
public class ScriptureLibrary
{
    private List<Scripture> scriptures;

    public ScriptureLibrary()
    {
        scriptures = new List<Scripture>();
    }

    public void AddScripture(Reference reference, string text)
    {
        scriptures.Add(new Scripture(reference, text));
    }

    public Scripture GetRandomScripture()
    {
        if (!scriptures.Any())
        {
            Console.WriteLine("The library is empty.");
            return null;
        }
        int index = Utils.Random.Next(scriptures.Count);
        return scriptures[index];
    }
}

//This class represents the individual words in a scripture
public class Word
{
    public string Text { get; private set; }
    public bool IsHidden { get; set; }

    public Word(string text)
    {
        Text = text;
        IsHidden = false;
    }

    public override string ToString()
    {
        return IsHidden ? "___" : Text;
    }
}

//Represents a complete scripture and holds a reference
public class Scripture
{
    public Reference Reference { get; }
    private List<Word> words;

    public Scripture(Reference reference, string text)
    {
        Reference = reference;
        words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public string GetScriptureText()
    {
        return string.Join(" ", words);
    }

    public void HideRandomWords(int count)
    {
        var wordsToHide = words.Where(w => !w.IsHidden).ToList();

        if (!wordsToHide.Any())
        {
            Console.WriteLine("No more words to hide! Press any key to continue.");
            Console.ReadKey();
            return;
        }

        wordsToHide.Shuffle();
        for (int i = 0; i < Math.Min(count, wordsToHide.Count); i++)
        {
            wordsToHide[i].IsHidden = true;
        }
    }

    public bool WordsLeftToHide()
    {
        return words.Any(w => !w.IsHidden);
    }
}

//This holds the detailed reference information and makes sure the data is grouped logically.
public class Reference
{
    public string Book { get; }
    public int Chapter { get; }
    public int Verse { get; }

    public Reference(string book, int chapter, int verse)
    {
        Book = book;
        Chapter = chapter;
        Verse = verse;
    }

    public override string ToString()
    {
        return $"{Book} {Chapter}:{Verse}";
    }
}

//This begins the scripture memorization session, allowing the user to interact to hide words.
public class ScriptureMemorization
{
    public static void StartMemorizationSession(Scripture scripture)
    {
        Console.Clear();
        Console.WriteLine(scripture.Reference);
        Console.WriteLine(scripture.GetScriptureText());

        while (scripture.WordsLeftToHide())
        {
            Console.WriteLine("\nPress Enter to hide words or type 'quit' to stop.");
            string input = Console.ReadLine()?.Trim().ToLower();

            if (string.IsNullOrEmpty(input))
            {
                scripture.HideRandomWords(3); // Hiding three words at a time
                Console.Clear();
                Console.WriteLine(scripture.Reference);
                Console.WriteLine(scripture.GetScriptureText());
            }
            else if (input == "quit")
            {
                Console.WriteLine("\nEnd of session.");  // Moved here so the user sees it before the session ends
                break;
            }
        }
    }
}

//This class initializes the data, handles the main loop of user interactions, and triggers memorization commands based on the user interactions.
class Program
{
    static void Main(string[] args)
    {
        ScriptureLibrary library = new ScriptureLibrary();

        // Adding scriptures to the library
            library.AddScripture(new Reference("Nephi", 2, 27), "Wherefore, men are free according to the flesh; and all things are given them which are expedient unto man. And they are free to choose liberty and eternal life, through the great Mediator of all men, or to choose captivity and death, according to the captivity and power of the devil; for he seeketh that all men might be miserable like unto himself.");
            library.AddScripture(new Reference("Nephi", 2, 16), "Wherefore, the Lord God gave unto man that he should act for himself. Wherefore, man could not act for himself save it should be that he was enticed by the one or the other.");
            library.AddScripture(new Reference("Moroni", 10, 5), "And by the power of the Holy Ghost ye may know the truth of all things.");

        Console.WriteLine("Welcome to the Scripture Memorization Helper!");

        while (true)
        {
            Console.WriteLine("Press Enter to display a new scripture or type 'quit' to exit.");
            string command = Console.ReadLine();

            if (command.Equals("quit", StringComparison.OrdinalIgnoreCase))
            {
                break;
            }

            var scripture = library.GetRandomScripture();
            if (scripture != null)
            {
                ScriptureMemorization.StartMemorizationSession(scripture);
            }
        }

        Console.WriteLine("Thank you for using the Scripture Memorization Helper. Goodbye!");
    }
}
