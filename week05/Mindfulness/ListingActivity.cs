public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts = new List<string>()
    {
        "What are you grateful for today?",
        "What is a challenge you are facing?",
        "What is a goal you want to achieve?",
        "What is something that makes you happy?",
        "What is something you want to improve?",
        "When have you felt the holy ghost this month?"
    };
    public ListingActivity()
        : base(
            "Listing",
            "This activity will help you reflect on the good things in your life by having you list as many things as you can.",
            0)
    {
    }

    public override void Run()
    {
        DisplayStartMessage();

        GetRandomPrompt();
        System.Console.WriteLine("You may begin in:");
        ShowCountdown(5);

        System.DateTime endTime = System.DateTime.Now.AddSeconds(_duration);
        List<string> items = GetListFromUser(endTime);
        _count = items.Count;
        System.Console.WriteLine($"You listed {_count} items.");

        DisplayEndMessage();
    }
    public void GetRandomPrompt()
    {
        System.Random random = new System.Random();
        int randomIndex = random.Next(_prompts.Count);
        System.Console.WriteLine(_prompts[randomIndex]);
    }
    public List<string> GetListFromUser(System.DateTime endTime)
    {
        List<string> list = new List<string>();
        System.Console.WriteLine("Please enter your list of items:");
        string item;
        while (System.DateTime.Now < endTime &&
               (item = System.Console.ReadLine()) != null &&
               item != "")
        {
            list.Add(item);
        }
        return list;
    }
}