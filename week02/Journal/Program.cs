using System;

class Program
{
    static void Main(string[] args)
    {
        Journal theJournal = new Journal();
        int choice = 0;
    string fileName = "journal.txt";
        do
        {
            

        Console.WriteLine("");
        Console.WriteLine("Please select one of the following choices:");
        Console.WriteLine("1. Write a new entry");
        Console.WriteLine("2. Display the journal");
        Console.WriteLine("3. Load the journal");
        Console.WriteLine("4. Save the journal");
        Console.WriteLine("5. Quit");
        Console.WriteLine("");
        Console.WriteLine("Enter your choice:");
        choice = int.Parse(Console.ReadLine());
        switch (choice)
        {
            case 1:
                // Write a new entry
                PromptGenerator generator = new PromptGenerator();
                string prompt = generator.GetRandomPrompt();
                Console.WriteLine(prompt);
                
                string response = Console.ReadLine();
                Entry anEntry = new Entry();
                
                anEntry._date = DateTime.Now.ToShortDateString();
                anEntry._promptText = prompt;
                anEntry._entryText = response;
                
                theJournal.AddEntry(anEntry);
                break;
            case 2:
                // Display the journal
                theJournal.DisplayAll();
                break;
            case 3:
                // Load the journal

                theJournal.LoadFormFile(fileName);
                {
                    Console.WriteLine("Journal loaded successfully.");
                }
                break;
            case 4:
                // Save the journal
                theJournal.SaveToFile(fileName);
                {
                    Console.WriteLine("Journal saved successfully.");
                }
                break;
            case 5:
                // Quit
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
        } while (choice != 5);
    }
}