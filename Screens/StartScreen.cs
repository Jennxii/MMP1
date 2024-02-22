//MMP1 - Lose or Winscreen

using SFML.Graphics;
using SFML.System;
using SFML.Window;


class StartScreen
{
    ///<summary>
    ///3.5 EndScreen-Class
    ///creating an simple Endscreen
    ///</summary>
    private RenderWindow window;
    //private Font font;
    private Text messageText;

    private Text startText;
    private Text exitText;
    private bool startSelected;

    public StartScreen(RenderWindow window)
    {
        this.window = window;
        AssetManager.Instance.LoadFont("text", "./Assets/SHPinscher-Regular.otf");

        messageText = new Text("Lost in the Pyramid", AssetManager.Instance.GetFont("text"), 70);
        messageText.Position = new Vector2f(260, 100);

        startText = new Text("Start", AssetManager.Instance.GetFont("text"), 70);
        startText.Position = new Vector2f(290, 250);

        exitText = new Text("Quit", AssetManager.Instance.GetFont("text"), 70);
        exitText.Position = new Vector2f(300, 400);

        startSelected = true;
    }

    public void HandleInput()
    {
        if (Keyboard.IsKeyPressed(Keyboard.Key.W))
            startSelected = true;
        else if (Keyboard.IsKeyPressed(Keyboard.Key.S))
            startSelected = false;

        if (Keyboard.IsKeyPressed(Keyboard.Key.Enter))
        {
            if (startSelected)
            {
                Program.Restart();
            }
            else
            {
                window.Close();
            }
        }
    }

    public void Draw()
    {
        window.Clear(Color.Black);

        window.Draw(messageText);

        if (startSelected)
        {
            startText.FillColor = Color.Yellow;
            exitText.FillColor = Color.White;
        }
        else
        {
            startText.FillColor = Color.White;
            exitText.FillColor = Color.Yellow;
        }

        window.Draw(startText);
        window.Draw(exitText);

        window.Display();
    }
}
