class Swimming : Activity {
    public int Laps { get; private set; }

    public Swimming(DateTime date, int durationInMinutes, int laps)
        : base(date, durationInMinutes) {
        Laps = laps;
    }

    public override double GetDistance() => Laps * 50 / 1000.0; // Each lap is 50 meters
    public override double GetSpeed() => GetDistance() / (DurationInMinutes / 60.0);
    public override double GetPace() => DurationInMinutes / GetDistance();

    public override string GetSummary() {
        return base.GetSummary() + $"Distance: {GetDistance():F2} km, Speed: {GetSpeed():F2} kph, Pace: {GetPace():F2} min per km";
    }
}
