//MMP1 - Trap-Room


using SFML.Graphics;
using SFML.Window;
using SFML.System;

public class DeathRoom : Level
{
    ///<summary>
    ///3.4 DeathRoom-class
    ///handles death of player with collision
    ///</summary>
    List<CircleShape> trap = new List<CircleShape>();
    public bool movingUp;
    public CircleShape triangle = new();
    public FloatRect collisionRect;
    public Time time;
    public float deathTime = float.MaxValue;
    Game? game;

    public override void Draw(RenderWindow window)
    {
        foreach (CircleShape triangle in trap)
        {
            window.Draw(triangle);
        }
    }
    public override void Update(float deltaTime)
    {
        time = game.deatchClock.ElapsedTime;
        foreach (CircleShape triangle in trap)
        {
            if (triangle.Position.Y <= 220)
            {
                movingUp = false;
            }
            if (movingUp)
            {
                triangle.Position += new Vector2f(0, -1);
            }

            if (CollisionManager.CheckCollision(game.player, triangle) && deathTime == float.MaxValue)
            {
                deathTime = time.AsSeconds();
            }
        }
        if (deathTime < time.AsSeconds() - 1f)
        {
            deathTime = float.MaxValue;
            game.player.Kill();
        }
    }
    public override void LoadResources()
    {
        game = Program.game;
        for (int i = 0; i < 20; i++)
        {
            triangle = new CircleShape(20, 3);
            collisionRect = triangle.GetGlobalBounds();
            triangle.Position = new Vector2f(2200 + (i * 35), 250);
            triangle.FillColor = Color.White;
            trap.Add(triangle);
        }
    }
}