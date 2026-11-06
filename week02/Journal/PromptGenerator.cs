public class PromptGenerator
{
    public List<string> _prompts;

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(0, _prompts.Count);
        
        return _prompts[index];


    }
}
