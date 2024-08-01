using System;
using System.Linq;

public class SevensOut : Game
{
    // Array of Die objects to represent the dice used in the game
    private Die[] _dice;
    // Field to store the total score of the game
    private int _total;

    // Property to get the total score of the game
    public override int Total => _total;

    // Constructor to initialize the dice array
    public SevensOut()
    {
        _dice = new Die[2];
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
            while (true)
            {
                // Roll all dice and calculate the total of the roll
                int[] rollResults = RollAllDice();
                int rollTotal = rollResults.Sum();

                // Display the results of the roll
                Console.WriteLine($"Roll: [{string.Join(", ", rollResults)}] (Total={rollTotal})");

                // Check if the roll total is 7 and stop the game if it is
                if (rollTotal == 7)
                {
                    Console.WriteLine("Total is 7. Stopping the game.");
                    break;
                }

                // If both dice show the same value, double the roll total and add to the game total
                if (rollResults[0] == rollResults[1])
                {
                    _total += rollTotal * 2; // Double the score if dice are the same
                }
                else
                {
                    // Otherwise, just add the roll total to the game total
                    _total += rollTotal;
                }

                // Display the current total score
                Console.WriteLine($"Current Total: {_total}");
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

    // Method to reset the game state
    public override void Reset()
    {
        _total = 0; // Reset the total score to zero
    }
}
