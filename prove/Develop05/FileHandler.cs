using System;
using System.Collections.Generic;
using System.IO;

public class FileHandler
{
    public static void SaveToFile(string filename, GoalManager manager)
    {
        using (StreamWriter file = new StreamWriter(filename))
        {
            file.WriteLine(manager.TotalScore);
            foreach (var goal in manager.Goals)
            {
                file.WriteLine($"{goal.GetType().Name},{goal.Name},{goal.Points},{goal.IsComplete}");
                if (goal is ChecklistGoal checklistGoal)
                {
                    file.WriteLine($"{checklistGoal.CurrentCount},{checklistGoal.TargetCount},{checklistGoal.BonusPoints}");
                }

    if (int.TryParse(file.ReadLine(), out int totalScore))
    {
        manager.SetTotalScore(totalScore);
    }
            }
        }
    }

    public static GoalManager LoadFromFile(string filename)
    {
        var manager = new GoalManager();

        using (StreamReader file = new StreamReader(filename))
        {
            if (int.TryParse(file.ReadLine(), out int totalScore))
            {
                manager.TotalScore = totalScore;
            }

            string line;
            while ((line = file.ReadLine()) != null)
            {
                var parts = line.Split(',');

                if (parts.Length >= 4)
                {
                    string type = parts[0];
                    string name = parts[1];
                    int.TryParse(parts[2], out int points);
                    bool.TryParse(parts[3], out bool isComplete);

                    BaseGoal goal = type switch
                    {
                        "SimpleGoal" => new SimpleGoal(name, points),
                        "EternalGoal" => new EternalGoal(name, points),
                        "ChecklistGoal" => new ChecklistGoal(name, points, 0, 0),
                        _ => null
                    };

                    if (goal != null)
                    {
                        goal.IsComplete = isComplete;
                        manager.AddGoal(goal);

                        if (goal is ChecklistGoal checklistGoal && (line = file.ReadLine()) != null)
                        {
                            var checklistParts = line.Split(',');
                            if (checklistParts.Length >= 3)
                            {
                                int.TryParse(checklistParts[0], out int currentCount);
                                int.TryParse(checklistParts[1], out int targetCount);
                                int.TryParse(checklistParts[2], out int bonusPoints);

                                checklistGoal.SetChecklistDetails(currentCount, targetCount, bonusPoints);
                            }
                        }
                    }
                }
            }
        }

        return manager;
    }
}
