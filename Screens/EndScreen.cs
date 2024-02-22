//MMP1 - Lose or Winscreen

using SFML.Graphics;
using SFML.System;
using SFML.Window;

class EndScreen : GameObject
{
    ///<summary>
    ///3.5 EndScreen-Class
    ///creating an simple Endscreen
    ///</summary>

    // private RenderWindow window = new RenderWindow();
    private Text messageText = new();
    private Text messageTextLost = new();
    private Text replayText = new();
    private Text exitText = new();
    private bool replaySelected;

    Game? game;

    public override void Update(float deltaTime)
    {
        replaySelected = Keyboard.IsKeyPressed(Keyboard.Key.W) ? true : (Keyboard.IsKeyPressed(Keyboard.Key.S) ? false : replaySelected);

        if (Keyboard.IsKeyPressed(Keyboard.Key.Enter))
        {
            if (replaySelected)
            {
                Program.Restart();
            }
            else
            {
                game.window.Close();
            }
        }

    }

    public override void Initialize()
    {
        game = Program.game;
        AssetManager.Instance.LoadFont("text", "./Assets/SHPinscher-Regular.otf");

        CreateText(out messageText, "You win!", 70, new Vector2f(260, 100));
        CreateText(out messageTextLost, "You loose!", 70, new Vector2f(260, 100));
        CreateText(out replayText, "Restart", 70, new Vector2f(290, 250));
        CreateText(out exitText, "Quit", 70, new Vector2f(300, 400));

        replaySelected = true;
    }

    private void CreateText(out Text text, string content, uint size, Vector2f position)
    {
        text = new Text(content, AssetManager.Instance.GetFont("text"), size);
        text.Position = position;
    }

    public override void Draw(RenderWindow window)
    {
        window.Clear(Color.Black);
        Text currentMessageText = game.lostGame ? messageTextLost : messageText;
        window.Draw(currentMessageText);

        replayText.FillColor = replaySelected ? Color.Yellow : Color.White;
        exitText.FillColor = replaySelected ? Color.White : Color.Yellow;


        window.Draw(replayText);
        window.Draw(exitText);

        window.Display();
    }
}
