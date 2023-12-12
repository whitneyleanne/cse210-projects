class Lecture : Event {
    public string Speaker { get; set; }
    public int Capacity { get; set; }

    public Lecture(string title, string description, DateTime eventDate, string time, Address eventAddress, string speaker, int capacity)
        : base(title, description, eventDate, time, eventAddress) {
        Speaker = speaker;
        Capacity = capacity;
    }

    public override string GetFullDetails() {
        return $"{GetStandardDetails()}\nSpeaker: {Speaker}\nCapacity: {Capacity}";
    }
}
