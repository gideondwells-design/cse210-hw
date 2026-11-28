public class Activity
{
    private string _name;
    private string _description;
    protected int _duration;

    public Activity(string name, string description, int duration)
    {
        _name = name;
        _description = description;
        _duration = duration;
    }

    public void DisplayStartMessage()
    {
        System.Console.WriteLine($"Welcome to the {_name} activity.");
        System.Console.WriteLine($"{_description}");
        System.Console.WriteLine();
        System.Console.Write("How long, in seconds, would you like to try? ");
        while (!int.TryParse(System.Console.ReadLine(), out _duration) || _duration <= 0)
        {
            System.Console.Write("Please enter a positive number of seconds: ");
        }
        System.Console.WriteLine();
        System.Console.WriteLine("Get ready...");
        ShowSpinner("-", 3);
    }

    public void DisplayEndMessage()
    {
        System.Console.WriteLine();
        System.Console.WriteLine($"You have completed the {_name} activity.");
        System.Console.WriteLine($"Duration: {_duration} seconds");
        ShowSpinner("-", 3);
    }

    public virtual void Run()
    {
    }

    public void ShowSpinner(string spinner, int second)
    {
        string[] frames = { "|", "/", "-", "\\" };

        System.DateTime endTime = System.DateTime.Now.AddSeconds(second);
        int frameIndex = 0;

        while (System.DateTime.Now < endTime)
        {
            System.Console.Write(frames[frameIndex]);
            System.Threading.Thread.Sleep(250);
            System.Console.Write("\b");
            frameIndex = (frameIndex + 1) % frames.Length;
        }
        System.Console.WriteLine();
    }

    public void ShowCountdown(int second)
    {
        for (int i = second; i > 0; i--)
        {
            System.Console.Write(i + " ");
            System.Threading.Thread.Sleep(1000);
        }
        System.Console.WriteLine();
    }
}