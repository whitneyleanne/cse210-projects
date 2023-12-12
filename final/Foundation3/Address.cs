class Address {
    private string Street { get; }
    private string City { get; }
    private string State { get; }
    private string Country { get; }

    public Address(string street, string city, string state, string country) {
        Street = street;
        City = city;
        State = state;
        Country = country;
    }

    public override string ToString() {
        return $"{Street}, {City}, {State}, {Country}";
    }
}
