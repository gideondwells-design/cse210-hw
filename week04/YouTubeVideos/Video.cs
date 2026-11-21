public class Video
{
    public string _title;
    public string _description;
    public int _lengthInSeconds;
    public List<Comment> _comments = new List<Comment>();

    public Video(string title, string description, int length)
    {
        _title = title;
        _description = description;
        _lengthInSeconds = length;
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public void Display()
    {
        Console.WriteLine($"Title: {_title}\nDescription: {_description}\nLength: {_lengthInSeconds} seconds");
    }
}