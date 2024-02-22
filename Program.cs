//MMP1 - The Main Program with Restart-Method

using SFML.Graphics;
using SFML.System;
using SFML.Window;

public static class Program
{
    ///<summary>
    ///1. Main Program (for creating a game)
    ///</summary>

    public static Game game = null!;
    private static void Main()
    {
        game = new Game();
        game.Run();
    }

    public static void Restart()
    {
        game.Initialize();
        game.Run();
    }
}