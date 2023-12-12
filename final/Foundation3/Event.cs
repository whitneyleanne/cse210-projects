abstract class Event {
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime EventDate { get; set; }
    public string Time { get; set; }
    protected Address EventAddress { get; set; }

    protected Event(string title, string description, DateTime eventDate, string time, Address eventAddress) {
        Title = title;
        Description = description;
        EventDate = eventDate;
        Time = time;
        EventAddress = eventAddress;
    }

    public string GetStandardDetails() {
        return $"{Title}\n{Description}\nDate: {EventDate.ToShortDateString()}, Time: {Time}\nLocation: {EventAddress}";
    }

    public abstract string GetFullDetails();

    public string GetShortDescription() {
        return $"{GetType().Name} - {Title} on {EventDate.ToShortDateString()}";
    }
}
