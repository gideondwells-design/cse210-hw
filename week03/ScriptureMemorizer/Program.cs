using System;

class Program
{
    static void Main(string[] args)
    {
        string saveFile = Path.Combine(AppContext.BaseDirectory, "lastScripture.txt");
        Reference reference = null;
        string text = "";
        bool loadedSavedScripture = false;

        if (File.Exists(saveFile))
        {
            if (TryLoadScripture(saveFile, out Reference savedReference, out string savedText))
            {
                Console.WriteLine($"Last scripture: {savedReference.GetDisplayText()}");
                Console.WriteLine(savedText);
                Console.Write("Use this scripture? (y/n): ");
                string answer = Console.ReadLine() ?? "";

                if (answer.Equals("y", StringComparison.OrdinalIgnoreCase))
                {
                    reference = savedReference;
                    text = savedText;
                    loadedSavedScripture = true;
                }
            }
            else
            {
                Console.WriteLine("The saved scripture could not be read. Please enter it again.");
            }
        }

        if (!loadedSavedScripture)
        {
            Console.Write("Book: ");
            string book = Console.ReadLine() ?? "";

            int chapter = ReadPositiveNumber("Chapter: ");
            int startVerse = ReadPositiveNumber("Starting verse: ");

            int endVerse = 0;
            while (true)
            {
                Console.Write("Ending verse (or press Enter for a single verse): ");
                string endInput = Console.ReadLine() ?? "";

                if (string.IsNullOrWhiteSpace(endInput))
                {
                    break;
                }

                if (int.TryParse(endInput, out endVerse) && endVerse >= startVerse)
                {
                    Console.Clear();
                    break;
                }

                Console.WriteLine("Enter a valid verse number that is not before the starting verse.");
            }

            reference = endVerse == 0
                ? new Reference(book, chapter, startVerse)
                : new Reference(book, chapter, startVerse, endVerse);

            Console.WriteLine("Enter the scripture text on one line:");
            text = Console.ReadLine() ?? "";
            SaveScripture(saveFile, book, chapter, startVerse, endVerse, text);
        }

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

    static bool TryLoadScripture(string filePath, out Reference reference, out string text)
    {
        reference = null;
        text = "";

        string[] savedData = File.ReadAllLines(filePath);
        if (savedData.Length != 5
            || string.IsNullOrWhiteSpace(savedData[0])
            || !int.TryParse(savedData[1], out int chapter)
            || !int.TryParse(savedData[2], out int startVerse)
            || !int.TryParse(savedData[3], out int endVerse)
            || chapter <= 0
            || startVerse <= 0
            || endVerse < 0
            || (endVerse != 0 && endVerse < startVerse)
            || string.IsNullOrWhiteSpace(savedData[4]))
        {
            return false;
        }

        reference = endVerse == 0
            ? new Reference(savedData[0], chapter, startVerse)
            : new Reference(savedData[0], chapter, startVerse, endVerse);
        text = savedData[4];
        return true;
    }

    static void SaveScripture(string filePath, string book, int chapter, int startVerse, int endVerse, string text)
    {
        File.WriteAllLines(filePath, new[]
        {
            book,
            chapter.ToString(),
            startVerse.ToString(),
            endVerse.ToString(),
            text
        });
    }

    static int ReadPositiveNumber(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);

            if (int.TryParse(Console.ReadLine(), out int number) && number > 0)
            {
                return number;
            }

            Console.WriteLine("Enter a positive whole number.");
        }
    }
}