using System;

class Program {
    static void Main(string[] args) {
        // Youtube videos
        var video1 = new Video("Youtube Video #1", "Author #1", 142);
        video1.AddComment(new Comment("John", "I learned a lot from this!"));
        video1.AddComment(new Comment("Alice", "I like how simple you made this seem!"));
        video1.AddComment(new Comment("Sophie", "Love this!!"));

        var video2 = new Video("Youtube Video #2", "Author #2", 640);
        video2.AddComment(new Comment("Dave", "Fast and Efficient! Great tutorial"));
        video2.AddComment(new Comment("Emma", "Thanks for this video."));
        video2.AddComment(new Comment("Alex", "Very informative. Thank you."));

        var video3 = new Video("Youtube Video #3", "Author #3", 220);
        video3.AddComment(new Comment("Erik", "Does this work differently in the heat?"));
        video3.AddComment(new Comment("Kathy", "I am in awe."));
        video3.AddComment(new Comment("Holly", "I want to try this!"));

        var video4 = new Video("Youtube Video #4", "Author #4", 190);
        video4.AddComment(new Comment("Leo", "I didn't know half of these facts!"));
        video4.AddComment(new Comment("Beth", "Are all of these real? Wow!"));
        video4.AddComment(new Comment("Allison", "My whole reality is changed..."));

        // Add videos to a list
        var videos = new List<Video> { video1, video2 };

        // Iterate through the list and display details
        foreach (var video in videos) {
            Console.WriteLine($"Title: {video.Title}, Author: {video.Author}, Length: {video.LengthInSeconds} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            foreach (var comment in video.Comments) {
                Console.WriteLine($"Comment by {comment.CommenterName}: {comment.Text}");
            }
            Console.WriteLine(); 
        }
    }
}