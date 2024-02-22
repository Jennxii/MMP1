//MMP1 - HUD Elements

using SFML.Graphics;
using SFML.System;
using SFML.Window;

public class Hud : GameObject
{
    ///<summary>
    ///5. Hud-class
    ///logic for hud-elements
    ///</summary>
    Game? game;
    public View hudView = new();
    // private Text limit;
    private string torchString = "";
    Text xTorch = new();
    public Text floorText = new();
    public string floorString = "x";
    public Sprite torchSprite = new Sprite();
    private const int TORCH_TILING_X = 7;
    private const int TORCH_TILING_Y = 1;
    private float animationTime = 0;
    Torch torchHud = new Torch(new Vector2f(0, 0), 0, 0);
    private Vector2f torchPos = new();
    private Sprite headHud = new();

    public override void Initialize()
    {
        game = Program.game;
        Vector2f topLeft = game.window.MapPixelToCoords(new Vector2i(0, 0), hudView);

        hudView = new View(new FloatRect(0, 0, game.window.Size.X, game.window.Size.Y));
        hudView.Viewport = new FloatRect(0, 0, 1, 1);
        hudView.Zoom(1f);

        torchString = "x";
        AssetManager.Instance.LoadFont("hud", "./Assets/SHPinscher-Regular.otf");
        xTorch = new Text(torchString, AssetManager.Instance.GetFont("hud"), 70);
        xTorch.FillColor = Color.White;
        xTorch.Position = new Vector2f(topLeft.X + 90, topLeft.Y + 50);

        AssetManager.Instance.LoadFont("hud", "./Assets/SHPinscher-Regular.otf");
        floorText = new Text(floorString, AssetManager.Instance.GetFont("hud"), 70);
        floorText.FillColor = Color.White;
        floorText.Position = new Vector2f(topLeft.X + 500, topLeft.Y + 50);

        torchHud = new Torch(new Vector2f(topLeft.X + 20, topLeft.Y + 80), topLeft.Y, topLeft.Y);

        Texture headTexture = new Texture("./Assets/OsirisHead.png");
        headHud = new Sprite(headTexture);
        headHud.Position = new Vector2f(topLeft.X + 680, topLeft.Y + 30);
        headHud.Scale *= 2;

        Texture torchTexture = new Texture("./Assets/torch.png");
        torchSprite = new Sprite(torchTexture);
        torchSprite.TextureRect = new IntRect(
                0,
                0,
            (int)(torchTexture.Size.X / TORCH_TILING_X),
                (int)(torchTexture.Size.Y / TORCH_TILING_Y)
            );
        torchSprite.Scale *= 8f;
        torchPos = new Vector2f(topLeft.X + 50, topLeft.Y + 140);
        torchSprite.Position = torchPos;
        torchSprite.Origin = new Vector2f(torchSprite.TextureRect.Width / 2, torchSprite.TextureRect.Height);

    }
    public override void Update(float deltaTime)
    {
        //xTorch.DisplayedString = "x" + torchString;

        torchHud.Update(deltaTime);

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

        torchSprite.Position = torchPos;
        floorHudChange();

        InputManager.Instance.Update(deltaTime);
    }
    public override void Draw(RenderWindow window)
    {
        window.SetView(hudView);
        torchHud.Draw(window);
        window.Draw(torchSprite);
        xTorch.DisplayedString = "x" + game.player.torchAmount + "";
        window.Draw(xTorch);
        window.SetView(window.DefaultView);
        floorText.DisplayedString = floorString;
        window.Draw(floorText);

        if (game.player.playerHasHead)
        {
            window.Draw(headHud);
        }
    }
    private void floorHudChange()
    {
        switch (Program.game.player.Position.Y)
        {
            case -500f:
                {
                    floorString = "Start";
                    break;
                }
            case 200f:
                {
                    floorString = "First Floor";
                    break;
                }
            case 2190f:
                {
                    floorString = "Second Floor";
                    break;
                }
            case 2950f:
                {
                    floorString = "Third Floor";
                    break;
                }
        }
    }
}