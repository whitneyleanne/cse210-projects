class Program
{
    static void Main()
    {
        var manager = new GoalManager();

        // Add some goals
        manager.AddGoal(new SimpleGoal("Run a marathon", 1000));
        manager.AddGoal(new EternalGoal("Read scriptures", 100));
        manager.AddGoal(new ChecklistGoal("Attend the temple", 50, 10, 500));

        // Record some events
        manager.RecordGoalEvent("Run a marathon");
        manager.RecordGoalEvent("Read scriptures");

        // Display goals and score
        manager.DisplayGoals();
        manager.DisplayScore();

        // Save to file
        FileHandler.SaveToFile("goals.json", manager);

        // Load from file
        var loadedManager = FileHandler.LoadFromFile("goals.json");
        loadedManager.DisplayGoals();
        loadedManager.DisplayScore();
    }
}
