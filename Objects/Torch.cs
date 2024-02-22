//MMP1 - Torch with Animation

using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;

public class Torch : GameObject
{
    ///<summary>
    ///4.1 Torch-class
    ///logic for torch, has animation
    ///</summary>
    public Sprite torchSprite = new Sprite();

    public IntRect torchRect { get; private set; }
    private const int TORCH_TILING_X = 7;
    private const int TORCH_TILING_Y = 1;
    private float animationTime = 0;
    private bool movingUp = true;
    private float moveSpeed = 30f;

    private Vector2f torchPos;
    private float opacity;
    private float fadeSpeed = 250f;
    private float upperBound;
    private float underBound;

    public bool isVisible = false;
    Game? game;
    public Torch(Vector2f torchPos, float upperBound, float underBound)
    {
        this.torchPos = torchPos;
        this.upperBound = upperBound;
        this.underBound = underBound;
    }
    public override void Draw(RenderWindow window)
    {
        window.Draw(torchSprite);
    }

    public override void Initialize()
    {
        game = Program.game;
        Texture torchTexture = new Texture("./Assets/torch.png");
        torchSprite = new Sprite(torchTexture);
        torchSprite.TextureRect = new IntRect(
                0,
                0,
            (int)(torchTexture.Size.X / TORCH_TILING_X),
                (int)(torchTexture.Size.Y / TORCH_TILING_Y)
            );
        torchSprite.Scale *= 8f;
        torchSprite.Position = torchPos;
        this.Position = torchSprite.Position;
        torchSprite.Origin = new Vector2f(torchSprite.TextureRect.Width / 2, torchSprite.TextureRect.Height);
        // torchRect = new IntRect((Vector2i)torchSprite.Position, new Vector2i(50,50));
        opacity = 255f;
    }
    public override void Update(float deltaTime)
    {

        float animationSpeed = 1;

        animationTime += deltaTime * animationSpeed;

        int animationFrame = (int)(animationTime % 7);

        int spriteXOffset = animationFrame * torchSprite.TextureRect.Width;
        int spriteYOffset = 0;

        torchSprite.TextureRect = new IntRect(
            spriteXOffset,
            spriteYOffset,
            torchSprite.TextureRect.Width,
            torchSprite.TextureRect.Height
        );
        float verticalMovement = moveSpeed * deltaTime;
        if (movingUp)
        {
            torchPos.Y -= verticalMovement;
            if (torchPos.Y <= upperBound)
            {
                movingUp = false;
            }
        }
        else
        {
            torchPos.Y += verticalMovement;

            if (torchPos.Y >= underBound)
            {
                movingUp = true;
            }
        }

        this.Position = torchPos;
        torchSprite.Position = torchPos;

        if (CollisionManager.CheckCollision(Program.game.player, this.torchSprite) && this.isVisible)
        {
            Fading(deltaTime);
            game.player.torchAmount += 1;
            Console.Write(game.player.torchAmount);
            this.isVisible = false;
        }
        // InputManager.Instance.Update(deltaTime);
    }
    public void Fading(float deltaTime)
    {
        opacity -= fadeSpeed * deltaTime;

        opacity = Math.Max(opacity, 0);
        opacity = Math.Min(opacity, 255);
        torchSprite.Color = new Color(255, 255, 255, (byte)opacity);
    }
}