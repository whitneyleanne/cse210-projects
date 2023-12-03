class Address {
    private string Street { get; }
    private string City { get; }
    private string StateOrProvince { get; }
    private string Country { get; }

    public Address(string street, string city, string stateOrProvince, string country) {
        Street = street;
        City = city;
        StateOrProvince = stateOrProvince;
        Country = country;
    }

    public bool IsInUSA() {
        return Country.Equals("USA", StringComparison.OrdinalIgnoreCase);
    }

    public override string ToString() {
        return $"{Street}\n{City}, {StateOrProvince}\n{Country}";
    }
}
