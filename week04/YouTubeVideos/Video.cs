public class Video
{
    public string _title;
    public string _author;
    public string _description;
    public int _lengthInSeconds;
    public List<Comment> _comments = new List<Comment>();

    public Video(string title, string author, string description, int length)
    {
        _title = title;
        _author = author;
        _description = description;
        _lengthInSeconds = length;
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public int GetCommentCount()
    {
        return _comments.Count;
    }

    public void Display()
    {
        Console.WriteLine($"Title: {_title}\nAuthor: {_author}\nDescription: {_description}\nLength: {_lengthInSeconds} seconds");
    }
}