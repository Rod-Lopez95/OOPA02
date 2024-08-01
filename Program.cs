using System;

class Program
{
    static void Main(string[] args)
    {
        // Initialize statistics object to keep track of game statistics
        var statistics = new Statistics();

        // Enter an infinite loop to display the menu and process user input
        while (true)
        {
            try
            {
                // Display the menu options to the user
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Play Sevens Out");
                Console.WriteLine("2. Play Three Or More");
                Console.WriteLine("3. View Statistics");
                Console.WriteLine("4. Run Tests");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");

                // Read user input
                var choice = Console.ReadLine();

                // Process user input based on the menu choice
                switch (choice)
                {
                    case "1":
                        // Create an instance of SevensOut game and play it
                        var sevensOut = new SevensOut();
                        sevensOut.Play();
                        // Update statistics with the result of SevensOut game
                        statistics.UpdateStatistics("SevensOut", sevensOut.Total);
                        break;
                    case "2":
                        // Create an instance of ThreeOrMore game and play it
                        var threeOrMore = new ThreeOrMore();
                        threeOrMore.Play();
                        // Update statistics with the result of ThreeOrMore game
                        statistics.UpdateStatistics("ThreeOrMore", threeOrMore.Total);
                        break;
                    case "3":
                        // Display the current statistics
                        statistics.DisplayStatistics();
                        break;
                    case "4":
                        // Create an instance of Testing and run tests for both games
                        var testing = new Testing();
                        testing.TestSevensOut();
                        testing.TestThreeOrMore();
                        break;
                    case "5":
                        // Exit the program
                        return;
                    default:
                        // Handle invalid input
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur and display an error message
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
