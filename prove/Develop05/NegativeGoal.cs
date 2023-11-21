public class NegativeGoal : BaseGoal
{
    public int PenaltyPoints { get; set; }

    public NegativeGoal(string name, int penaltyPoints) 
        : base(name, 0) 
    {
        PenaltyPoints = penaltyPoints;
    }

    public override void RecordEvent()
    {
        if (!IsComplete)
        {
            Points -= PenaltyPoints;
        }
    }

    public override string ToString()
    {
        return $"{base.ToString()} [Penalty: {PenaltyPoints} points]";
    }
}
