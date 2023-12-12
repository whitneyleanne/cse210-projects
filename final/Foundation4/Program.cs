using System;

class Program {
    static void Main(string[] args) {
        var activities = new List<Activity> {
            new Running(new DateTime(2022, 11, 03), 30, 4.8),
            new Cycling(new DateTime(2022, 11, 04), 40, 20),
            new Swimming(new DateTime(2022, 11, 05), 30, 20)
        };

        foreach (var activity in activities) {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
