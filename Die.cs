using System;

public class Die
{
    // Static Random instance to ensure randomness across all Die instances
    private static Random _random = new Random();

    // Property to hold the current value of the die
    public int CurrentValue { get; private set; }

    // Method to roll the die, generating a random number between 1 and 6
    public int Roll()
    {
        // Generate a random number between 1 and 6 (inclusive) and set it as the current value
        CurrentValue = _random.Next(1, 7);
        // Return the current value
        return CurrentValue;
    }
}
