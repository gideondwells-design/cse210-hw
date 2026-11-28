public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base(
            "Breathing",
            "This activity will help you relax by walking you through breathing in and out slowly.",
            0)
    {
    }

    public override void Run()
    {
        DisplayStartMessage();

        System.DateTime endTime = System.DateTime.Now.AddSeconds(_duration);
        while (System.DateTime.Now < endTime)
        {
            System.Console.WriteLine("Breathe in");
            ShowCountdown(3);


            System.Console.WriteLine("Breathe out");
            ShowCountdown(3);
        }

        DisplayEndMessage();
    }
}