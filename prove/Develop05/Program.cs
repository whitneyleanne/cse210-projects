class Program
{
    static void Main()
    {
        var manager = new GoalManager();
        bool exit = false;

        while (!exit)
        {
            Console.Clear();
            Console.WriteLine($"You have {manager.TotalScore} points.\n");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice from the menu: ");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    var newGoal = CreateNewGoal();
                    if (newGoal != null)
                    {
                        manager.AddGoal(newGoal);
                    }
                    break;

                case "2":
                    manager.DisplayGoals();
                    break;
                case "3":
                    SaveGoals(manager);
                    break;
                case "4":
                    LoadGoals(manager);
                    break;
                case "5":
                    RecordEvent(manager);
                    break;
                case "6":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }

            if (!exit)
            {
                Console.WriteLine("\nPress any key to return to the menu...");
                Console.ReadKey();
            }
        }
    }

    private static BaseGoal CreateNewGoal()
{
    Console.WriteLine("Select Goal Type:");
    Console.WriteLine("1. Simple Goal");
    Console.WriteLine("2. Eternal Goal");
    Console.WriteLine("3. Checklist Goal");
    Console.WriteLine("4. Negative Goal");
    Console.Write("Enter choice: ");

    string goalType = Console.ReadLine();
    Console.Write("Enter goal name: ");
    string name = Console.ReadLine();

    switch (goalType)
    {
        case "1":
            Console.Write("Enter point value: ");
            int points = int.Parse(Console.ReadLine());
            return new SimpleGoal(name, points);
        case "2":
            Console.Write("Enter point value: ");
            points = int.Parse(Console.ReadLine());
            return new EternalGoal(name, points);
        case "3":
            Console.Write("Enter point value: ");
            points = int.Parse(Console.ReadLine());
            Console.Write("Enter target count: ");
            int targetCount = int.Parse(Console.ReadLine());
            Console.Write("Enter bonus points: ");
            int bonusPoints = int.Parse(Console.ReadLine());
            return new ChecklistGoal(name, points, targetCount, bonusPoints);
        case "4":
            Console.Write("Enter penalty points: ");
            int penaltyPoints = int.Parse(Console.ReadLine());
            return new NegativeGoal(name, penaltyPoints);
        default:
            Console.WriteLine("Invalid choice. Goal not created.");
            return null;
    }
}

private static void SaveGoals(GoalManager manager)
{
    Console.Write("Enter filename to save goals: ");
    string filename = Console.ReadLine();
    FileHandler.SaveToFile(filename, manager);
    Console.WriteLine("Goals saved successfully.");
}

private static void LoadGoals(GoalManager manager)
{
    Console.Write("Enter filename to load goals from: ");
    string filename = Console.ReadLine();
    var loadedManager = FileHandler.LoadFromFile(filename);
    Console.WriteLine("Goals loaded successfully.");
    
}

private static void RecordEvent(GoalManager manager)
{
    Console.Write("Enter the name of the goal to record an event for: ");
    string goalName = Console.ReadLine();
    manager.RecordGoalEvent(goalName);
    Console.WriteLine("Event recorded successfully.");
}

}
