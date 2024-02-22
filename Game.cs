//MMP1 - Game with Shader controls


using SFML.Graphics;
using SFML.System;
using SFML.Window;
using SFML.Audio;

public class Game
{
    ///<summary>
    /// 2. Game-Class 
    ///includes Shader and Shader-variables
    ///implement Hud, Clocks, EndScreen, Level-Class
    ///</summary>
    public RenderWindow window = new(new VideoMode(800, 600), "MMP1");
    public Shader shader;
    public RenderStates renderStates;
    private float gameTime = 0;
    public Player player = new Player();
    public View view = new View(new FloatRect(0f, 0f, 0, 0));

    public float time;

    public Level_Osiris level = new Level_Osiris();
    // private static Game instance = null;
    public float lightTime;
    float coneScale;
    private Clock clock;
    public Clock deatchClock;
    public bool lostGame;
    public Hud hud;
    EndScreen theEnd;


    public Game()
    {
        window.Closed += OnWindowClose;

        window.Resized += (sender, args) =>
        {
            Vector2u windowSize = window.Size;

            float aspectRatio = (float)windowSize.X / windowSize.Y;

            float viewWidth = 800f;
            float viewHeight = viewWidth / aspectRatio;

            view.Size = new Vector2f(viewWidth, viewHeight);
            view.Center = new Vector2f(viewWidth / 2, viewHeight / 2);
        };


        window.Resized += OnWindowResized;

        //DebugDraw.ActiveWindow = window;
    }

    private void OnWindowResized(object? sender, SizeEventArgs e)
    {
        view.Size = new Vector2f(e.Width, e.Height);
        // view.Move(player.Position);

        window.SetView(view);
    }

    private void OnWindowClose(object? sender, EventArgs e)
    {
        window.Close();
    }

    public void Run()
    {
        Initialize();

        while (window.IsOpen)
        {

            float deltaTime = clock.Restart().AsSeconds();

            HandleEvents();

            Update(deltaTime);

            Draw();
        }
    }

    private void Draw()
    {
        window.Clear(Color.Black);
        window.SetView(view);
        FloatRect playerBounds = player.playerSprite.GetGlobalBounds();

        level.Draw(window);
        player.Draw(window);

        //Shader
        DrawLight((uint)view.Size.X, (uint)view.Size.Y + 400);

        hud.Draw(window);
        window.Display();
    }

    private void Update(float deltaTime)
    {
        level.Update(deltaTime);
        player.Update(deltaTime);
        view.Center = player.Position - new Vector2f(0, 200);
        //Logic for Shader 
        if (lightTime >= 1f)
        {
            lightTime -= deltaTime;
            coneScale -= 0.005f * deltaTime;
            if (coneScale <= 0f)
            {
                coneScale = 0f;
            }
        }
        else
        {
            // No light at 0 seconds
            coneScale = 0f;
            lostGame = true;
        }
        if (lostGame || level.gameWon)
        {
            theEnd.Initialize();
            theEnd.Draw(window);
        }

        hud.Update(deltaTime);
    }
    public void ResetLight()
    {
        lightTime = 60f;
        coneScale = 0.3f;
    }
    private void HandleEvents()
    {
        window.DispatchEvents();
    }
    public void Initialize()
    {
        time = 0f;
        lightTime = 60f;
        coneScale = 0.3f;
        clock = new Clock();
        deatchClock = new Clock();
        lostGame = false;

        AssetManager.Instance.LoadMusic("bg-music", "./Assets/desert-song.ogg");
        AssetManager.Instance.PlayMusic("bg-music");

        InputManager.Instance.Initialize(window);
        player.Initialize();

        level.LoadResources();
        level.gameWon = false;

        player.Position = new Vector2f(100, -500);
        player.playerSprite.Position = player.Position;

        Vector2u initialWindowSize = window.Size;
        float initialAspectRatio = (float)initialWindowSize.X / initialWindowSize.Y;
        float initialViewWidth = 1440f;
        float initialViewHeight = initialViewWidth / initialAspectRatio;
        view = new View(new FloatRect(0f, 0f, initialViewWidth, initialViewHeight));

        //Shader settings
        AssetManager.Instance.LoadTexture("LightTexture", "./Assets/LightTexture.png");
        shader = new Shader(null, null, @"./Assets/LightShader.frag");

        window.SetView(view);

        hud = new Hud();
        hud.Initialize();

        AssetManager.Instance.LoadMusic("background-music", "./Assets/desert-song.ogg");
        theEnd = new EndScreen();

        level.osirisHasHead = false;
    }

    //implement Shader
    public void DrawLight(uint screenWidth, uint screenHeight)
    {
        renderStates = new RenderStates(shader);

        var rectangle = new RectangleShape(new Vector2f(screenWidth, screenHeight));

        rectangle.Texture = AssetManager.Instance.GetTexture("LightTexture");
        Vector2f playerScreenPos = player.Position;
        renderStates.Shader.SetUniform("PlayerScreenPos", new Vector2f(0.5f, 0.5f));
        time += 0.004f;
        renderStates.Shader.SetUniform("coneScale", coneScale);

        renderStates.Shader.SetUniform("time", time);
        rectangle.Position = new Vector2f(player.Position.X - screenWidth / 2, player.Position.Y - screenHeight / 2);
        window.Draw(rectangle, renderStates);
    }

}
