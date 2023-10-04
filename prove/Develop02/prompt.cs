using System;
using System.Collections.Generic;

public class PromptGenerator
{
    private List<string> PromptList;

    public PromptGenerator()
    {
        
        PromptList = new List<string>
        {
            "Who was the most interesting person you interacted with today, and why?",
            "What was the most challenging decision you made today?",
            "Identify a moment today where you felt in 'flow'. Describe the activity and your feelings.",
            "What's one skill you used today that you want to improve?",
            "Name a moment today that you would like to remember five years from now."
        };
    }

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int randomIndex = random.Next(0, PromptList.Count);
        return PromptList[randomIndex];
    }
}