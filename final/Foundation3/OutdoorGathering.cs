class OutdoorGathering : Event {
    public string WeatherForecast { get; set; }

    public OutdoorGathering(string title, string description, DateTime eventDate, string time, Address eventAddress, string weatherForecast)
        : base(title, description, eventDate, time, eventAddress) {
        WeatherForecast = weatherForecast;
    }

    public override string GetFullDetails() {
        return $"{GetStandardDetails()}\nWeather Forecast: {WeatherForecast}";
    }
}
