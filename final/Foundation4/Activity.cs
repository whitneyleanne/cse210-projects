abstract class Activity {
    public DateTime Date { get; private set; }
    public int DurationInMinutes { get; private set; }

    protected Activity(DateTime date, int durationInMinutes) {
        Date = date;
        DurationInMinutes = durationInMinutes;
    }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public virtual string GetSummary() {
        return $"{Date.ToString("dd MMM yyyy")} ({GetType().Name} - {DurationInMinutes} min): ";
    }
}
