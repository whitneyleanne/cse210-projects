public class ChecklistGoal : BaseGoal
{
    public int TargetCount { get; private set; }
    public int CurrentCount { get; private set; }
    public int BonusPoints { get; private set; }

    public ChecklistGoal(string name, int points, int targetCount, int bonusPoints)
        : base(name, points)
    {
        TargetCount = targetCount;
        BonusPoints = bonusPoints;
        CurrentCount = 0;
    }

    public override void RecordEvent()
    {
        CurrentCount++;
        if (CurrentCount >= TargetCount)
        {
            IsComplete = true;
            Points += BonusPoints;
        }
    } 

    public void SetChecklistDetails(int currentCount, int targetCount, int bonusPoints)
{
    CurrentCount = currentCount;
    TargetCount = targetCount;
    BonusPoints = bonusPoints;
}


    public override string ToString()
    {
        return $"{base.ToString()} Completed {CurrentCount}/{TargetCount} times";
    }
}
 