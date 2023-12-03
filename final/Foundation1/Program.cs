using System;

class Program {
    static void Main(string[] args) {
        // Create a few videos
        var video1 = new Video("Video Title 1", "Author 1", 300);
        video1.AddComment(new Comment("John", "Great video!"));
        video1.AddComment(new Comment("Alice", "Very informative."));

        var video2 = new Video("Video Title 2", "Author 2", 450);
        video2.AddComment(new Comment("Dave", "Loved it!"));
        video2.AddComment(new Comment("Emma", "Thanks for this video."));

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