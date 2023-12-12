class Cycling : Activity {
    public double SpeedInKph { get; private set; } // Speed in kilometers per hour

    public Cycling(DateTime date, int durationInMinutes, double speedInKph)
        : base(date, durationInMinutes) {
        SpeedInKph = speedInKph;
    }

    public override double GetDistance() => (SpeedInKph / 60) * DurationInMinutes;
    public override double GetSpeed() => SpeedInKph;
    public override double GetPace() => 60 / SpeedInKph;

    public override string GetSummary() {
        return base.GetSummary() + $"Distance: {GetDistance():F2} km, Speed: {SpeedInKph} kph, Pace: {GetPace():F2} min per km";
    }
}
