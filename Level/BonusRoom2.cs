//MMP1 - second Bonus room with one vase


using SFML.Graphics;
using SFML.Window;
using SFML.System;

public class BonusRoom2 : Level
{
    ///<summary>
    ///3.2 BonusRoom2-Class
    ///implements door
    ///</summary>
    public RectangleShape doorback2 = new RectangleShape();
    public override void Draw(RenderWindow window)
    {
        window.Draw(doorback2);
    }
    public override void Update(float deltaTime)
    {
        doorback2.Position = new Vector2f(2350, 3050);
        doorback2.FillColor = Color.Black;
    }
    public override void LoadResources()
    {
        doorback2 = new RectangleShape(new Vector2f(150, 200));
    }
}