using System;

class Program
{
public static void Main()
{
    while (true)
    {
        Console.WriteLine("Choose an activity: \n1. Breathing \n2. Reflection \n3. Listing \n4. Exit");
        int choice = Convert.ToInt32(Console.ReadLine());

        ActivityBase activity = null;

        switch (choice)
        {
            case 1:
                activity = new BreathingActivity();
                break;
            case 2:
                activity = new ReflectionActivity();
                break;
            case 3:
                activity = new ListingActivity();
                break;
            case 4:
                return;
            default:
                Console.WriteLine("Invalid choice. Try again.");
                continue;
        }

        activity.StartActivity();
        activity.Execute();
        activity.EndActivity();
    }
}

}

public abstract class ActivityBase
{
    protected string name;
    protected string description;
    protected int duration;

    public ActivityBase(string name, string description)
    {
        this.name = name;
        this.description = description;
    }

    public void StartActivity()
    {
        Console.WriteLine($"Welcome to the {name} activity.");
        Console.WriteLine(description);
        Console.Write("Please set the duration of the activity in seconds: ");
        duration = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        ShowAnimation(3);  
    }

    public void EndActivity()
    {
        Console.WriteLine("\nGood Job!");
        ShowAnimation(3);
        Console.WriteLine($"You have completed the {name} activity for {duration} seconds.");
        ShowAnimation(3);
    }

    protected void ShowAnimation(int seconds)
    {
        char[] animationChars = new char[] { '|', '/', '-', '\\' };
        for (int i = 0; i < seconds; i++)
    {
            foreach (var animChar in animationChars)
        {
                Console.Write("\r" + animChar); 
                Thread.Sleep(250); 
        }
    }
        Console.WriteLine();  
    }

    public abstract void Execute();  
}

// THREE activities
// first one: breathe in and out, 5-6 seconds each, six times? 
public class BreathingActivity : ActivityBase
{
    public BreathingActivity() : base("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public override void Execute()
    {
        int cycles = duration / 6;  
        for (int i = 0; i < cycles; i++)
        {
            Console.WriteLine("Breathe in...");
            ShowAnimation(4);
            Console.WriteLine("Breathe out...");
            ShowAnimation(3);
        }
    }
}

// second one: pulls from menu, activity for reflection where prompts 

public class ReflectionActivity : ActivityBase
{
    private List<string> reflectionPrompts;
    private List<string> reflectionQuestions;
    private Random random;

    public ReflectionActivity() : base("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        reflectionPrompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        reflectionQuestions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        random = new Random();
    }

    public override void Execute()
    {
        var prompt = GetRandomPrompt();
        Console.WriteLine(prompt);

        int questionTime = duration / 3;
        for (int i = 0; i < 3; i++)
        {
            var question = GetRandomQuestion();
            Console.WriteLine(question);
            ShowAnimation(questionTime);
        }
    }

    private string GetRandomPrompt()
    {
        int index = random.Next(reflectionPrompts.Count);
        var prompt = reflectionPrompts[index];
        reflectionPrompts.RemoveAt(index); //This is to remove repetition :) 
        return prompt;
    }

    private string GetRandomQuestion()
    {
        int index = random.Next(reflectionQuestions.Count);
        var question = reflectionQuestions[index];
        reflectionQuestions.RemoveAt(index); 
        return question;
    }
}

// third: listing activity - list as many responses as you can to the following prompt

public class ListingActivity : ActivityBase
{
    private List<string> listingPrompts;
    private Random random;

    public ListingActivity() : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        listingPrompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        random = new Random();
    }

    public override void Execute()
    {
        var prompt = GetRandomPrompt();
        Console.WriteLine(prompt);

        Console.WriteLine("Press enter after listing each item.");
        int count = 0;

        DateTime endTime = DateTime.Now.AddSeconds(duration);
        while (DateTime.Now <= endTime)
        {
            string listItem = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(listItem))
            {
                count++;
            }
        }

        Console.WriteLine($"You listed {count} items.");
    }

    private string GetRandomPrompt()
    {
        int index = random.Next(listingPrompts.Count);
        var prompt = listingPrompts[index];
        listingPrompts.RemoveAt(index); 
        return prompt;
    }
}

// once any of the three activities are finished, bring user back to menu
