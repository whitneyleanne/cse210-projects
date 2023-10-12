using System;
using System.Collections.Generic;
using System.Linq;

public class Word
{
    public string Text { get; set; }
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

public class Scripture
{
    private List<Word> words;
    private int currentIndex;
    private Random random;

    public Scripture(string text)
    {
        words = text.Split(' ').Select(word => new Word(word)).ToList();
        currentIndex = 0;
        random = new Random();
    }

    public bool HasWordsToDisplay()
    {
        return currentIndex < words.Count;
    }

    public List<Word> GetNextWords(int count)
    {
        var wordsToDisplay = new List<Word>();
        for (int i = 0; i < count && currentIndex < words.Count; i++)
        {
            wordsToDisplay.Add(words[currentIndex]);
            currentIndex++;
        }
        return wordsToDisplay;
    }

    public void HideRandomWords(int count)
    {
        var hiddenWords = new List<Word>();
        for (int i = 0; i < count; i++)
        {
            if (currentIndex >= words.Count)
                break;

            int randomIndex = random.Next(currentIndex, words.Count);
            if (!words[randomIndex].IsHidden)
            {
                words[randomIndex].IsHidden = true;
                hiddenWords.Add(words[randomIndex]);
            }
        }

        Console.Clear();
        Console.WriteLine(string.Join(" ", words.Select(word => word.ToString())));
        Console.WriteLine("Press Enter to continue or type 'quit' to end the program.");
        Console.WriteLine("Hidden Words: " + string.Join(", ", hiddenWords.Select(word => word.Text)));
    }
}

public class Reference
{
    public static void DisplayScripture(Scripture scripture)
    {
        while (scripture.HasWordsToDisplay())
        {
            Console.Clear();
            Console.WriteLine(string.Join(" ", scripture.GetNextWords(3)));
            Console.WriteLine("Press Enter to continue or type 'quit' to end the program: ");
            string input = Console.ReadLine();
            if (input == "quit")
                break;

            scripture.HideRandomWords(3);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        string scriptureText = "Your scripture text goes here."; // Replace with your scripture text.
        Scripture scripture = new Scripture(scriptureText);

        Console.WriteLine("Welcome to the Scripture Display Program!");
        Console.WriteLine("Press Enter to begin displaying the scripture.");
        Console.ReadLine();

        Reference.DisplayScripture(scripture);

        Console.WriteLine("Program ended. Press any key to exit.");
        Console.ReadKey();
    }
}
