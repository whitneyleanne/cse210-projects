using System;
using System.Collections.Generic;

public class GoalManager
{
    private List<BaseGoal> goals = new List<BaseGoal>();
    private int totalScore;

    public IReadOnlyList<BaseGoal> Goals => goals.AsReadOnly();
    public int TotalScore => totalScore;

    public void AddGoal(BaseGoal goal)
    {
        goals.Add(goal);
    }

    public void RecordGoalEvent(string goalName)
    {
        var goal = goals.Find(g => g.Name == goalName);
        if (goal != null)
        {
            goal.RecordEvent();
            AddToTotalScore(goal.Points);
        }
    }

    public void DisplayGoals()
    {
        foreach (var goal in goals)
        {
            Console.WriteLine(goal);
        }
    }

    public void DisplayScore()
    {
        Console.WriteLine($"Total Score: {TotalScore}");
    }

    // New method to update the total score
    public void SetTotalScore(int score)
    {
        totalScore = score;
    }

    // Private method to add points to the total score
    private void AddToTotalScore(int points)
    {
        totalScore += points;
    }
}
