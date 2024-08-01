using System;
using System.Collections.Generic;

public class Statistics
{
    // Dictionary to hold statistics data for different games.
    // The key is the game name, and the value is a tuple containing the number of plays and the high score.
    private Dictionary<string, (int plays, int highScore)> _data = new Dictionary<string, (int, int)>
    {
        { "SevensOut", (0, 0) },
        { "ThreeOrMore", (0, 0) }
    };

    // Method to update the statistics for a specific game.
    public void UpdateStatistics(string gameName, int score)
    {
        // Retrieve the current statistics for the specified game.
        var stats = _data[gameName];

        // Increment the number of plays.
        stats.plays++;

        // Update the high score if the current score is higher.
        if (score > stats.highScore)
        {
            stats.highScore = score;
        }

        // Store the updated statistics back in the dictionary.
        _data[gameName] = stats;
    }

    // Method to display the statistics for all games.
    public void DisplayStatistics()
    {
        // Loop through each game in the dictionary and print its statistics.
        foreach (var game in _data)
        {
            Console.WriteLine($"{game.Key} - Plays: {game.Value.plays}, High Score: {game.Value.highScore}");
        }
    }
}
