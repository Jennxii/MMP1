//MMP1 - Leveldesign, with Statue

using SFML.Graphics;
using SFML.Window;
using SFML.System;

public class Level_Osiris : Level
{
    ///<summary>
    ///3. Level-Osiris-class
    ///handles Level-Design
    ///has logic for statue, many doors and walls, implements VasesInLevel-class, Head-class, EndScreen-, and DeathRoom-class
    ///</summary>
    public Room1 room1 = new();
    public BonusRoom2 bonusRoom2 = new BonusRoom2();

    public List<RectangleShape> walls = new List<RectangleShape>();
    public List<RectangleShape> doors = new List<RectangleShape>();
    public DeathRoom deathRoom = new DeathRoom();
    public bool gameWon = false;
    Game? game;
    Sprite osirisSprite = new Sprite();
    public bool osirisHasHead = false;
    private Texture osirisHasHeadTexture = new Texture(1, 1);
    VasesInLevel theVases = new();

    // head = new Head(new Vector2f(3900, 3160));
    public Head head = new();
    private Texture osirisWithHead = new Texture(1, 1);
    public Vector2i backgroundSize = new Vector2i(750, 400);

    public Floors floors = new();
    public Floors.Floor1 floor1 = new();
    public Floors.Floor2 floor2 = new();
    public Floors.Floor3 floor3 = new();

    public override void Draw(RenderWindow window)
    {
        //floor
        DrawStones(new Vector2f(-800, 250), new Vector2i(3500 / 80, 50), new Vector2i(80, 80));
        //ceiling
        DrawStones(new Vector2f(-800, -1100), new Vector2i(3500 / 80, 20), new Vector2i(80, 80));
        //left stones
        DrawStones(new Vector2f(-1880, -700), new Vector2i(16, 30), new Vector2i(80, 80));
        //right stones
        DrawStones(new Vector2f(2600, -700), new Vector2i(24, 100), new Vector2i(80, 80));
        //wall behind

        //startroom
        DrawWall(new Vector2f(-200, -850), new Vector2i(1, 1), backgroundSize);

        //deathroom 
        DrawWall(new Vector2f(2200, -150), new Vector2i(1, 1), backgroundSize);
        //vaseroom
        DrawWall(new Vector2f(-650, 850), new Vector2i(4, 1), backgroundSize);

        //bonusroom
        DrawWall(new Vector2f(2200, 2850), new Vector2i(1, 1), backgroundSize);

        //bonusroom2
        DrawWall(new Vector2f(3400, 2850), new Vector2i(1, 1), backgroundSize);
        //endroom
        DrawWall(new Vector2f(3500, 1850), new Vector2i(1, 1), backgroundSize);

        floors.Draw(window);
        floor1.Draw(window);
        floor2.Draw(window);
        floor3.Draw(window);

        // foreach (RectangleShape wall in walls)
        // {
        //     window.Draw(wall);
        // }
        foreach (RectangleShape door in doors)
        {
            window.Draw(door);
        }

        room1.Draw(window);

        if (osirisHasHead)
        {
            window.Draw(floors.endDoor);
        }

        bonusRoom2.Draw(window);

        window.Draw(osirisSprite);
        deathRoom.Draw(window);

        theVases.Draw(window);
        head.Draw(window);
    }
    public override void Update(float deltaTime)
    {
        room1.Update(deltaTime);
        deathRoom.Update(deltaTime);
        bonusRoom2.Update(deltaTime);
        theVases.Update(deltaTime);

        head.Update(deltaTime);

        floors.HandleDoors();

        if (game.player.playerHasHead && CollisionManager.CheckCollision(game.player, this.osirisSprite) && InputManager.Instance.GetKeyDown(Keyboard.Key.E))
        {
            osirisHasHead = true;
            game.player.playerHasHead = false;
            osirisSprite = new Sprite(osirisWithHead);
            osirisSprite.Position = new Vector2f(3800, 1950);
            osirisSprite.Scale *= 5;
        }

        if (osirisHasHead)
        {
            osirisSprite = new Sprite(osirisHasHeadTexture);
            osirisSprite.Position = new Vector2f(3800, 1950);
            osirisSprite.Scale *= 5;

            floors.endDoor = new RectangleShape(new Vector2f(150, 200));
            floors.endDoor.Position = new Vector2f(4000, 2050);
            floors.endDoor.FillColor = Color.White;

            if (CollisionManager.CheckCollision(game.player, floors.endDoor) && InputManager.Instance.GetKeyDown(Keyboard.Key.W))
            {
                gameWon = true;
            }
        }
    }
    public override void LoadResources()
    {
        game = Program.game;
        Texture osirisNoHeadTexture = new Texture("./Assets/OsirisNoHead.png");
        osirisWithHead = new Texture("./Assets/OsirisWithHead.png");
        osirisHasHeadTexture = new Texture("./Assets/OsirisWithHead.png");
        osirisSprite = new Sprite(osirisNoHeadTexture);
        osirisSprite.Position = new Vector2f(3800, 1950);
        osirisSprite.Scale *= 5;

        floors.LoadResources();
        floor1.LoadResources();
        floor2.LoadResources();
        floor3.LoadResources();

        head.Initialize();

        theVases = new VasesInLevel();
        theVases.LoadResources();

        Vector2f wallSize = new Vector2f(100, 450);

        RectangleShape wallLeft = new RectangleShape(wallSize);
        RectangleShape wallRight = new RectangleShape(wallSize);
        wallLeft.Position = new Vector2f(-300, -850);
        wallRight.Position = new Vector2f(550, -850);
        walls.Add(wallLeft);
        walls.Add(wallRight);

        RectangleShape wallLeft2 = new RectangleShape(wallSize);
        RectangleShape wallRight2 = new RectangleShape(wallSize);
        wallLeft2.Position = new Vector2f(-750, -150);
        wallRight2.Position = new Vector2f(1600, -150);
        walls.Add(wallLeft2);
        walls.Add(wallRight2);

        RectangleShape wallLeft3 = new RectangleShape(wallSize);
        RectangleShape wallRight3 = new RectangleShape(wallSize);
        wallLeft3.Position = new Vector2f(-750, 1850);
        wallRight3.Position = new Vector2f(1600, 1850);
        walls.Add(wallLeft3);
        walls.Add(wallRight3);

        RectangleShape wallLeft4 = new RectangleShape(wallSize);
        RectangleShape wallRight4 = new RectangleShape(wallSize);
        wallLeft4.Position = new Vector2f(2200, -150);
        wallRight4.Position = new Vector2f(2900, -150);
        walls.Add(wallLeft4);
        walls.Add(wallRight4);

        RectangleShape wallLeft5 = new RectangleShape(wallSize);
        RectangleShape wallRight5 = new RectangleShape(wallSize);
        wallLeft5.Position = new Vector2f(-780, 800);
        wallRight5.Position = new Vector2f(2380, 800);
        walls.Add(wallLeft5);
        walls.Add(wallRight5);

        RectangleShape wallLeft6 = new RectangleShape(wallSize);
        RectangleShape wallRight6 = new RectangleShape(wallSize);
        wallLeft6.Position = new Vector2f(-750, 2600);
        wallRight6.Position = new Vector2f(1600, 2600);
        walls.Add(wallLeft6);
        walls.Add(wallRight6);

        RectangleShape wallLeft7 = new RectangleShape(wallSize);
        RectangleShape wallRight7 = new RectangleShape(wallSize);
        wallLeft7.Position = new Vector2f(2100, 2850);
        wallRight7.Position = new Vector2f(2950, 2850);
        walls.Add(wallLeft7);
        walls.Add(wallRight7);

        RectangleShape wallLeft8 = new RectangleShape(wallSize);
        RectangleShape wallRight8 = new RectangleShape(wallSize);
        wallLeft8.Position = new Vector2f(3270, 2850);
        wallRight8.Position = new Vector2f(4200, 2850);
        walls.Add(wallLeft8);
        walls.Add(wallRight8);

        RectangleShape wallLeft9 = new RectangleShape(wallSize);
        RectangleShape wallRight9 = new RectangleShape(wallSize);
        wallLeft9.Position = new Vector2f(3350, 2150);
        wallRight9.Position = new Vector2f(4300, 2150);
        walls.Add(wallLeft9);
        walls.Add(wallRight9);

        room1 = new Room1();
        room1.LoadResources();
        bonusRoom2 = new BonusRoom2();
        bonusRoom2.LoadResources();

        AssetManager.Instance.LoadTexture("floor", "./Assets/floor.jpg");
        AssetManager.Instance.LoadTexture("wall", "./Assets/wallbackground.jpg");

        deathRoom = new DeathRoom();
        deathRoom.LoadResources();
    }

    private void DrawStones(Vector2f position, Vector2i tiles, Vector2i tileSize)
    {
        for (int y = 0; y < tiles.Y; y++)
        {
            for (int x = 0; x < tiles.X; x++)
            {
                Texture floorTex = AssetManager.Instance.GetTexture("floor");
                Vector2f tilePosition = position + new Vector2f(x * tileSize.X, y * tileSize.Y);
                DrawRectangle(tilePosition, tileSize.X, tileSize.Y, floorTex);
            }
        }
    }
    public void DrawWall(Vector2f position, Vector2i tiles, Vector2i tileSize)
    {
        for (int x = 0; x < tiles.X; x++)
        {
            Texture wallTex = AssetManager.Instance.GetTexture("wall");
            Vector2f tilePosition = position + new Vector2f(x * tileSize.X, 0);
            DrawRectangle(tilePosition, tileSize.X, tileSize.Y, wallTex);
        }
    }
    private void DrawRectangle(Vector2f position, int width, int height, Texture texture)
    {
        RectangleShape wallLeft = new RectangleShape(new Vector2f(width, height))
        {
            Position = position,

            Texture = texture
        };

        game.window.Draw(wallLeft);
    }
    public void DrawLine(Vector2f startPoint, Vector2f endPoint, Color color)
    {
        VertexArray line = new VertexArray(PrimitiveType.Lines, 2);

        line[0] = new Vertex(startPoint, color);
        line[1] = new Vertex(endPoint, color);

        game.window.Draw(line);
    }
}