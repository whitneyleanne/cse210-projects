public abstract class BaseGoal
{
    public string Name { get; set; }
    public int Points { get; set; }
    public bool IsComplete { get; set; }

    protected BaseGoal(string name, int points)
    {
        Name = name;
        Points = points;
        IsComplete = false;
    }

    public abstract void RecordEvent();

    public override string ToString()
    {
        return $"[{(IsComplete ? "X" : " ")}] {Name}";
    }
}
