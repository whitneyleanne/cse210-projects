class Reception : Event {
    public string RSVP_Email { get; set; }

    public Reception(string title, string description, DateTime eventDate, string time, Address eventAddress, string rsvpEmail)
        : base(title, description, eventDate, time, eventAddress) {
        RSVP_Email = rsvpEmail;
    }

    public override string GetFullDetails() {
        return $"{GetStandardDetails()}\nRSVP at: {RSVP_Email}";
    }
}
