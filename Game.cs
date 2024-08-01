public abstract class Game
{
    // Abstract method to play the game. This must be implemented by any derived class.
    public abstract void Play();

    // Abstract method to reset the game state. This must be implemented by any derived class.
    public abstract void Reset();

    // Abstract property to get the total score or result of the game. This must be implemented by any derived class.
    public abstract int Total { get; }
}
