public class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>()
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless.",
        "Think of a time when you overcame a fear."
    };
    private List<string> _questions = new List<string>()
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };
    public ReflectingActivity()
        : base(
            "Reflecting",
            "This activity will help you reflect on times in your life when you have shown strength and resilience.",
            0)
    {
    }

    public override void Run()
    {
        DisplayStartMessage();

        System.Console.WriteLine("Consider the following prompt:");
        GetRandomPrompt();
        System.Console.WriteLine();
        System.Console.WriteLine("When you have something in mind, press Enter.");
        System.Console.ReadLine();
        System.Console.WriteLine("Now ponder on each of the following questions:");
        ShowCountdown(5);

        System.Random random = new System.Random();
        System.DateTime endTime = System.DateTime.Now.AddSeconds(_duration);
        while (System.DateTime.Now < endTime)
        {
            string question = _questions[random.Next(_questions.Count)];
            System.Console.WriteLine(question);
            ShowSpinner("-", 5);
        }

        DisplayEndMessage();
    }
    public string GetRandomPrompt()
    {
        System.Random random = new System.Random();
        int randomIndex = random.Next(_prompts.Count);
        System.Console.WriteLine(_prompts[randomIndex]);
        return _prompts[randomIndex];
    }
    public string GetRandomQuestion()
    {
        System.Random random = new System.Random();
        int randomIndex = random.Next(_questions.Count);
        System.Console.WriteLine(_questions[randomIndex]);
        return _questions[randomIndex];
    }
    public void DisplayQuestions()
    {
        foreach (var question in _questions)
        {
            System.Console.WriteLine(question);
            System.Threading.Thread.Sleep(2000);
        }
    }
    public void DisplayPrompts()
    {
        foreach (var prompt in _prompts)
        {
            System.Console.WriteLine(prompt);
            System.Threading.Thread.Sleep(2000);
        }
    }
}
