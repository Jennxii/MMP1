//MMP1 - Logic for Head of Statue

using SFML.Graphics;
using SFML.Window;
using SFML.System;

public class Head : GameObject
{
    ///<summary>
    ///4.3 Head-class
    ///logic for the head
    ///</summary>
    public Sprite headSprite = new ();
    //public bool playerHasHead = false;
    private float fadeSpeed = 250f;
    private float opacity;
    Game? game;

    public override void Draw(RenderWindow window)
    {
        window.Draw(headSprite);
    }

    public override void Initialize()
    {
        game = Program.game;
        Texture headText = new Texture("./Assets/OsirisHead.png");
        headSprite = new Sprite(headText);
        headSprite.Position = new Vector2f(3900, 3160);
        headSprite.Scale *= 2;
    }

    public override void Update(float deltaTime)
    {
        if (game.player.playerHasHead)
        {
            opacity -= fadeSpeed * deltaTime;
            opacity = Math.Max(opacity, 0);
            opacity = Math.Min(opacity, 255);
            headSprite.Color = new Color(255, 255, 255, (byte)opacity);
        }
    }
}