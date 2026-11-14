using System;

class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference("Proverbs", 3, 5, 6);
        string text = "Trust in the Lord with all your heart and lean not on your own understanding.";

        List<Word> words = text
            .Split(' ')
            .Select(word => new Word(word, false))
            .ToList();

        Scripture scripture = new Scripture(reference, words);


        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
        
            if (scripture.IsCompletelyHidden())
            {
                break;
            }
        
            Console.Write("Press Enter to hide words, or type 'quit' to stop: ");
            string input = Console.ReadLine() ?? "";
        
            if (input.Equals("quit", StringComparison.OrdinalIgnoreCase))
            {
                break;
            }
        
            scripture.HideRandomWords(3);
        }
    }
}