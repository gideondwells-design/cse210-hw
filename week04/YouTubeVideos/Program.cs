using System;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("Learning C#", "Gideon Wells", "An introduction to C# programming.", 720);
        video1.AddComment(new Comment("Alex", "This was easy to follow."));
        video1.AddComment(new Comment("Jordan", "The examples were really helpful."));
        video1.AddComment(new Comment("Taylor", "Looking forward to the next lesson."));
        videos.Add(video1);

        Video video2 = new Video("Building with Classes", "Gideon Wells", "Understanding classes and objects.", 540);
        video2.AddComment(new Comment("Morgan", "Great explanation of constructors."));
        video2.AddComment(new Comment("Casey", "The object example made sense."));
        video2.AddComment(new Comment("Riley", "I learned a lot from this video."));
        videos.Add(video2);

        Video video3 = new Video("Working with Lists", "Gideon Wells", "Storing and using collections in C#.", 660);
        video3.AddComment(new Comment("Jamie", "Lists are very useful."));
        video3.AddComment(new Comment("Avery", "Could you make another video on collections?"));
        video3.AddComment(new Comment("Drew", "Thanks for the clear walkthrough."));
        videos.Add(video3);

        foreach (Video video in videos)
        {
            video.Display();
            Console.WriteLine($"Comments ({video.GetCommentCount()}):");
            foreach (Comment comment in video._comments)
            {
                Console.WriteLine(comment.GetDisplayText());
            }

            Console.WriteLine();
        }
    }
}