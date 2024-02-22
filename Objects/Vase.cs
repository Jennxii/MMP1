//MMP1 - Vase with some Logic for Torch

using SFML.Graphics;
using SFML.Window;
using SFML.System;

public class Vase : GameObject
{
    ///<summary>
    ///4.2 Vase-class
    ///logic for a vase, implements torch
    ///</summary>
    public Sprite vase = new Sprite();
    Vector2f vasePos = new Vector2f(0, 0);

    int scale;

    float vaRot;

    private Torch torch;
    Game? game;

    public Vase(Vector2f vasePos, int scale, float vaRot, Torch torch)
    {
        this.vasePos = vasePos;
        this.scale = scale;
        this.vaRot = vaRot;
        this.torch = torch;
    }

    public override void Draw(RenderWindow window)
    {
        window.Draw(vase);

        if (torch != null && torch.isVisible)
        {
            torch.Draw(window);
        }

    }

    public override void Initialize()
    {
        game = Program.game;
        AssetManager.Instance.LoadTexture("vase", "./Assets/vase.png");
        Texture textureVase = AssetManager.Instance.GetTexture("vase");
        vase = new Sprite(textureVase);

        vase.Origin = new Vector2f((vase.GetGlobalBounds().Width / 2), vase.GetGlobalBounds().Height);
        vase.Position = vasePos;
        vase.Scale *= scale;

    }

    public override void Update(float deltaTime)
    {
        torch?.Update(deltaTime);
        this.Position = vase.Position;
        vase.Position = this.Position;

        if (InputManager.Instance.GetKeyPressed(Keyboard.Key.E) && CollisionManager.CheckCollision(game.player, this.vase))
        {
            vase.Rotation = vaRot;
            if (torch != null)
            {
                torch.isVisible = true;
                if (torch.isVisible)
                {
                    torch.Update(deltaTime);
                }
                if (!torch.isVisible)
                {
                    torch = null!;
                }
            }
        }
    }
}