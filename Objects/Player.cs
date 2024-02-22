//MMP1 - Player with InputHandling and Animation

using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;

public class Player : GameObject
{
    ///<summary>
    ///2.2 Player-class
    ///logic for the player, Inputhandling and Animation
    ///</summary>
    public Sprite playerSprite = new Sprite();

    private const int PLAYER_TILING_X = 5;
    private const int PLAYER_TILING_Y = 4;

    private Dictionary<AnimationType, int> animationFrameCounts = new Dictionary<AnimationType, int>();

    private float animationTime = 0;

    private float playerSpeed = 300f;

    public Vector2f playerPosition;
    Vector2f previousPosition;
    private Game? game;
    public bool playerHasHead = false;
    public int torchAmount = 0;

    public IntRect collisionRect { get; private set; }
    public enum AnimationType
    {
        IdleRight = 0,
        IdleLeft = 1,
        RunRight = 2,
        RunLeft = 3,
    }
    public override void Draw(RenderWindow window)
    {
        window.Draw(playerSprite);
        // DrawRectOutline(collisionRect, Color.White);
    }

    public override void Initialize()
    {
        game = Program.game;
        animationFrameCounts = new Dictionary<AnimationType, int>
        {
            { AnimationType.IdleRight, 5 },
            { AnimationType.IdleLeft, 5 },
            { AnimationType.RunRight, 4 },
            { AnimationType.RunLeft, 4 },
        };

        Texture playerTexture = new Texture("./Assets/playerSpriteSheet2.png");
        playerSprite = new Sprite(playerTexture);
        playerSprite.TextureRect = new IntRect(
                0,
                0,
            (int)(playerTexture.Size.X / PLAYER_TILING_X),
                (int)(playerTexture.Size.Y / PLAYER_TILING_Y)
            );
        playerSprite.Scale *= 5f;
        playerSprite.Position = this.Position;
        playerSprite.Origin = new Vector2f(playerSprite.TextureRect.Width / 2, playerSprite.TextureRect.Height / 2);
    }

    public override void Update(float deltaTime)
    {
        AnimationType currentAnimation = AnimationType.IdleRight;
        float animationSpeed = 10;
        float gameTime = 0;

        gameTime += deltaTime;
        animationTime += deltaTime * animationSpeed;
        Vector2f playerMovement = new Vector2f();

        //inputhandling

        if (InputManager.Instance.GetKeyPressed(Keyboard.Key.A))
        {
            currentAnimation = AnimationType.RunLeft;
            playerMovement += new Vector2f(-1, 0);
        }
        else if (InputManager.Instance.GetKeyUp(Keyboard.Key.A))
        {
            currentAnimation = AnimationType.IdleLeft;
        }
        else if (InputManager.Instance.GetKeyPressed(Keyboard.Key.D))
        {
            currentAnimation = AnimationType.RunRight;
            playerMovement += new Vector2f(1, 0);
        }
        else if (InputManager.Instance.GetKeyUp(Keyboard.Key.D))
        {
            currentAnimation = AnimationType.IdleRight;
        }
        else if (InputManager.Instance.GetKeyDown(Keyboard.Key.W))
        {
            game.level.floors.w_down = true;
        }
        else if (InputManager.Instance.GetKeyDown(Keyboard.Key.Space) && torchAmount > 0)
        {
            torchAmount -= 1;
            game.ResetLight();
        }

        int animationFrame = (int)(animationTime % animationFrameCounts[currentAnimation]);

        int spriteXOffset = animationFrame * playerSprite.TextureRect.Width;
        int spriteYOffset = (int)currentAnimation * playerSprite.TextureRect.Height;

        playerSprite.TextureRect = new IntRect(
            spriteXOffset,
            spriteYOffset,
            playerSprite.TextureRect.Width,
            playerSprite.TextureRect.Height
        );

        //positioning
        previousPosition = playerSprite.Position;
        playerPosition = playerSprite.Position;
        playerPosition += playerMovement * playerSpeed * deltaTime;

        playerSprite.Position = playerPosition;
        foreach (RectangleShape wall in game.level.walls)
        {
            if (CollisionManager.CheckCollision(this, wall))
            {
                playerSprite.Position = previousPosition;
            }
            this.Position = playerPosition;
        }

        if (InputManager.Instance.GetKeyDown(Keyboard.Key.E) && CollisionManager.CheckCollision(game.player, game.level.head.headSprite))
        {
            playerHasHead = true;
        }
        InputManager.Instance.Update(deltaTime);
    }
    public void Kill()
    {
        this.Position = new Vector2f(100, -500);
        this.playerSprite.Position = this.Position;
    }
}