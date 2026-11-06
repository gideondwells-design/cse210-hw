public class PromptGenerator
{
    public List<string> _prompts = new List<string>
    {
        "What was the best part of your day?",
        "Who did you help today?",
        "What is something new you learned?",
        "What made you smile today?",
        "Were you able to accomplish any of your goals today?",
        "What are you grateful for today?",
        "What challenges did you face today?",
        "What could you have done better today?",
        "Did you do anything to improve yourself today?",
        "What are your plans for tomorrow?",
        "Did you do anything to help others today?"
    };

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(0, _prompts.Count);

        return _prompts[index];
    }
}
