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
            UpdateTotalScore(goal);
        }
    }

    private void UpdateTotalScore(BaseGoal goal)
    {
        totalScore += goal.Points;
        goal.Points = 0; // Reset goal points after they have been added to the total
    }

    public void DisplayGoals()
    {
        foreach (var goal in goals)
        {
            Console.WriteLine(goal);
        }
    }

    public void SetTotalScore(int score)
    {
        totalScore = score;
    }

    public void DisplayScore()
    {
        Console.WriteLine($"Total Score: {TotalScore}");
    }
}
