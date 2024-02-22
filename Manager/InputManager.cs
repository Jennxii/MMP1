//MMP1 - InputManager

using SFML.Graphics;
using SFML.Window;
using SFML.System;


public class InputManager
{
    ///<summary>
    ///6.3 InputManager-class
    ///Managing Input-Handling
    ///</summary>
    private static InputManager instance;

    public static InputManager Instance
    {
        get
        {
            if (instance == null)
                instance = new InputManager();

            return instance;
        }
    }

    private Dictionary<Keyboard.Key, bool> isKeyPressed = new Dictionary<Keyboard.Key, bool>();
    private Dictionary<Keyboard.Key, bool> isKeyDown = new Dictionary<Keyboard.Key, bool>();
    private Dictionary<Keyboard.Key, bool> isKeyUp = new Dictionary<Keyboard.Key, bool>();
    private bool isMouseClicked;
    private bool isMousePressed;
    private bool isMouseReleased;
    private Vector2i mousePosition;
    private InputManager() { }
    public void Initialize(Window window)
    {
        window.KeyPressed += OnKeyPressed;
        window.KeyReleased += OnKeyReleased;

        window.MouseButtonPressed += OnMouseButtonPressed;
        window.MouseButtonReleased += OnMouseButtonReleased;
        window.MouseMoved += OnMouseMoved;


        isKeyPressed[Keyboard.Key.W] = false;
        isKeyPressed[Keyboard.Key.A] = false;
        isKeyPressed[Keyboard.Key.E] = false;
        isKeyPressed[Keyboard.Key.D] = false;
        isKeyPressed[Keyboard.Key.Num1] = false;
        isKeyPressed[Keyboard.Key.Num2] = false;
        isKeyPressed[Keyboard.Key.Space] = false;

        foreach (var key in isKeyPressed.Keys)
        {
            isKeyDown[key] = false;
            isKeyUp[key] = false;
        }

        isMouseClicked = false;
        isMousePressed = false;
        isMouseReleased = false;
        mousePosition = new Vector2i();
    }
    public void Update(float deltaTime)
    {
        foreach (var keyState in isKeyUp)
        {
            isKeyUp[keyState.Key] = false;
        }
        foreach (var keyState in isKeyDown)
        {
            isKeyDown[keyState.Key] = false;
        }

        isMouseClicked = false;
        isMousePressed = false;
        isMouseReleased = false;
    }

    public bool GetKeyPressed(Keyboard.Key key)
    {
        bool value;
        isKeyPressed.TryGetValue(key, out value);
        return value;
    }
    public bool GetKeyDown(Keyboard.Key key)
    {
        bool value;
        isKeyDown.TryGetValue(key, out value);
        return value;
    }
    public bool GetKeyUp(Keyboard.Key key)
    {
        bool value;
        isKeyUp.TryGetValue(key, out value);
        return value;
    }
    private void OnKeyReleased(object? sender, KeyEventArgs e)
    {
        if (isKeyPressed.ContainsKey(e.Code))
        {
            if (isKeyPressed[e.Code])
            {
                isKeyUp[e.Code] = true;
                isKeyPressed[e.Code] = false;
            }
        }
    }

    private void OnKeyPressed(object? sender, KeyEventArgs e)
    {
        if (isKeyPressed.ContainsKey(e.Code))
        {
            if (!isKeyPressed[e.Code])
            {
                isKeyDown[e.Code] = true;
                isKeyPressed[e.Code] = true;
            }
        }
    }

    public bool GetMouseClicked()
    {
        return isMouseClicked;
    }

    public bool GetMousePressed()
    {
        return isMousePressed;
    }

    public bool GetMouseReleased()
    {
        return isMouseReleased;
    }

    public Vector2i GetMousePosition()
    {
        return mousePosition;
    }

    private void OnMouseButtonPressed(object? sender, MouseButtonEventArgs e)
    {
        if (e.Button == Mouse.Button.Left)
        {
            isMousePressed = true;
            isMouseClicked = true;
        }
    }

    private void OnMouseButtonReleased(object? sender, MouseButtonEventArgs e)
    {
        if (e.Button == Mouse.Button.Left)
        {
            isMouseReleased = true;
        }
    }

    private void OnMouseMoved(object? sender, MouseMoveEventArgs e)
    {
        mousePosition = new Vector2i(e.X, e.Y);
    }
}
