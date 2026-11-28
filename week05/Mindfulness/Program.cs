using System;

class Program
{
    static void Main(string[] args)
    {
        bool keepGoing = true;

        while (keepGoing)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Clear();
                Activity activity = new BreathingActivity();
                activity.Run();
            }
            else if (choice == "2")
            {
                Console.Clear();
                Activity activity = new ReflectingActivity();
                activity.Run();
            }
            else if (choice == "3")
            {
                Console.Clear();
                Activity activity = new ListingActivity();
                activity.Run();
            }
            else if (choice == "4")
            {
                Console.WriteLine("Thank you for using the Mindfulness program!");
                Console.WriteLine("I hope you have a great day!");
                Console.WriteLine("Press Enter to exit.");
                Console.ReadLine();
                keepGoing = false;
            }
            else
            {
                Console.WriteLine("Please choose 1, 2, 3, or 4.");
            }

            if (keepGoing)
            {
                Console.WriteLine();
                Console.WriteLine("Press Enter to return to the menu.");
                Console.ReadLine();
            }
        }
    }
}