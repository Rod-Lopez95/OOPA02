using System;
using System.Diagnostics;

public class Testing
{
    // Method to test the SevensOut game
    public void TestSevensOut()
    {
        // Create a new instance of the SevensOut game
        var game = new SevensOut();

        // Reset the game state before testing
        game.Reset();

        // Play the game
        game.Play();

        // Assert that the game stops with a total less than 7 when a 7 is rolled
        Debug.Assert(game.Total < 7, "Sevens Out game failed: Total should stop when a 7 is rolled");
    }

    // Method to test the ThreeOrMore game
    public void TestThreeOrMore()
    {
        // Create a new instance of the ThreeOrMore game
        var game = new ThreeOrMore();

        // Reset the game state before testing
        game.Reset();

        // Play the game
        game.Play();

        // Assert that the total score is non-negative
        Debug.Assert(game.Total >= 0, "Three Or More game failed: Total should be non-negative");
    }
}
