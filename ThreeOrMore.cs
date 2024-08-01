using System;
using System.Collections.Generic;
using System.Linq;

public class ThreeOrMore : Game
{
    // Array of Die objects to represent the dice used in the game
    private Die[] _dice;
    // Field to store the total score of the game
    private int _total;
    // Constant for the winning score
    private const int WinningScore = 20;

    // Property to get the total score of the game
    public override int Total => _total;

    // Constructor to initialize the dice array
    public ThreeOrMore()
    {
        _dice = new Die[5];
        for (int i = 0; i < _dice.Length; i++)
        {
            _dice[i] = new Die();
        }
    }

    // Method to play the game
    public override void Play()
    {
        // Reset the game state before starting
        Reset();

        try
        {
            int rollCount = 0;

            while (rollCount < 2)
            {
                // Display the results of the roll
                Console.WriteLine($"Roll {rollCount + 1}: [{string.Join(", ", RollAllDice())}]");

                // Group dice values by their frequency and find groups with 2 or more of the same value
                var groups = _dice.Select(die => die.CurrentValue)
                                  .GroupBy(v => v)
                                  .Where(g => g.Count() >= 2)
                                  .OrderByDescending(g => g.Count())
                                  .ToList();

                if (groups.Count > 0)
                {
                    // Display the highest frequency group found
                    Console.WriteLine($"Found {groups[0].Count()}-of-a-kind with value {groups[0].Key}");

                    // If there is a 3-of-a-kind or better, calculate and add points to the total
                    if (groups[0].Count() >= 3)
                    {
                        int points = CalculatePoints(groups[0].Count());
                        _total += points;
                        Console.WriteLine($"{groups[0].Count()}-of-a-kind: {points} points");
                    }

                    // On the first roll, allow the player to choose to re-roll all or some dice
                    if (rollCount == 0)
                    {
                        Console.Write("Do you want to re-roll all dice or some dice? (a for all / s for some): ");
                        string choice = Console.ReadLine().Trim().ToLower();
                        if (choice == "a")
                        {
                            RollAllDice();
                        }
                        else if (choice == "s")
                        {
                            Console.Write("Enter the indices (0-4) of dice to re-roll, separated by spaces: ");
                            var indices = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
                            RollSelectedDice(indices);
                        }
                        else
                        {
                            Console.WriteLine("Invalid choice. Rolling all dice.");
                            RollAllDice();
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No 2-of-a-kind or better found.");
                }

                rollCount++;
                // Display the current total score
                Console.WriteLine($"Current Total: {_total}");

                // Check if the player has reached the winning score
                if (_total >= WinningScore)
                {
                    Console.WriteLine("Congratulations! You've reached the winning score of 20.");
                    break;
                }
            }
        }
        catch (Exception ex)
        {
            // Handle any exceptions that occur during the game
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    // Method to roll all dice and return the results as an array of integers
    private int[] RollAllDice()
    {
        return _dice.Select(die => die.Roll()).ToArray();
    }

    // Method to roll selected dice based on their indices
    private void RollSelectedDice(List<int> indices)
    {
        foreach (var index in indices)
        {
            if (index >= 0 && index < _dice.Length)
            {
                _dice[index].Roll();
            }
        }
    }

    // Method to calculate points based on the count of same-value dice
    private int CalculatePoints(int count)
    {
        switch (count)
        {
            case 3:
                return 3;
            case 4:
                return 6;
            case 5:
                return 12;
            default:
                return 0;
        }
    }

    // Method to reset the game state
    public override void Reset()
    {
        _total = 0; // Reset the total score to zero
    }
}
