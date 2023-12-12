class Running : Activity {
    public double DistanceInKm { get; private set; } 
    public Running(DateTime date, int durationInMinutes, double distanceInKm)
        : base(date, durationInMinutes) {
        DistanceInKm = distanceInKm;
    }

    public override double GetDistance() => DistanceInKm;
    public override double GetSpeed() => (DistanceInKm / DurationInMinutes) * 60;
    public override double GetPace() => DurationInMinutes / DistanceInKm;

    public override string GetSummary() {
        return base.GetSummary() + $"Distance: {GetDistance()} km, Speed: {GetSpeed():F2} kph, Pace: {GetPace():F2} min per km";
    }
}
