using System;

using System;

class Program {
    static void Main(string[] args) {
        var address = new Address("123 Main St", "Anytown", "State", "Country");

        var lecture = new Lecture("Science Talk", "A talk on the latest in science", new DateTime(2023, 12, 1), "18:00", address, "Dr. Jane Doe", 100);
        var reception = new Reception("Wedding Reception", "Celebration of marriage", new DateTime(2023, 12, 15), "19:00", address, "rsvp@example.com");
        var outdoorGathering = new OutdoorGathering("Beach Party", "Fun at the beach", new DateTime(2023, 12, 20), "12:00", address, "Sunny with mild winds");

        Console.WriteLine(lecture.GetStandardDetails());
        Console.WriteLine(lecture.GetFullDetails());
        Console.WriteLine(lecture.GetShortDescription());

        Console.WriteLine(reception.GetStandardDetails());
        Console.WriteLine(reception.GetFullDetails());
        Console.WriteLine(reception.GetShortDescription());

        Console.WriteLine(outdoorGathering.GetStandardDetails());
        Console.WriteLine(outdoorGathering.GetFullDetails());
        Console.WriteLine(outdoorGathering.GetShortDescription());
    }
}
