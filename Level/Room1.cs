//MMP1 - Bonusroom with vases

using SFML.Graphics;
using SFML.Window;
using SFML.System;

public class Room1 : Level
{
    ///<summary>
    ///3.1 Room1-Class
    ///implements vase objects
    ///</summary>
    public RectangleShape doorback = new RectangleShape();

    public List<Vase> vases = new List<Vase>();

    public int floor = 1250;

    public override void Draw(RenderWindow window)
    {
        window.Draw(doorback);

        foreach (Vase va in vases)
        {
            va.Draw(window);
        }
    }
    public override void Update(float deltaTime)
    {
        doorback.Position = new Vector2f(-150 / 2, 1200 - 150);
        doorback.FillColor = Color.Black;
        foreach (Vase va in vases)
        {
            va.Update(deltaTime);
        }
    }
    public override void LoadResources()
    {
        doorback = new RectangleShape(new Vector2f(150, 200));

        Vase vase = new Vase(new Vector2f(550, floor), 3, 90f, null!);
        vases.Add(vase);

        Vase vase2 = new Vase(new Vector2f(650, floor), 2, 90f, null!);
        vases.Add(vase2);

        Vase vase3 = new Vase(new Vector2f(700, floor), 4, 90f, null!);
        vases.Add(vase3);

        Vase vase4 = new Vase(new Vector2f(735, floor), 2, 90f, null!);
        vases.Add(vase4);

        Vase vase5 = new Vase(new Vector2f(780, floor), 5, 90f, null!);
        vases.Add(vase5);

        Vase vase6 = new Vase(new Vector2f(850, floor), 3, 90f, null!);
        vases.Add(vase6);

        Vase vase7 = new Vase(new Vector2f(900, floor), 4, 90f, null!);
        vases.Add(vase7);

        Vase vase8 = new Vase(new Vector2f(950, floor), 2, 90f, null!);
        vases.Add(vase8);

        Torch torch = new Torch(new Vector2f(1130, floor), 1200f, 1250f);
        torch.Initialize();

        Vase vase9 = new Vase(new Vector2f(990, floor), 6, 90f, torch);
        vases.Add(vase9);


        Vase vase10 = new Vase(new Vector2f(1090, floor), 3, -90f, null!);
        vases.Add(vase10);

        Vase vase11 = new Vase(new Vector2f(1100, floor), 3, -90f, null!);
        vases.Add(vase11);

        Vase vase12 = new Vase(new Vector2f(1200, floor), 2, -90f, null!);
        vases.Add(vase12);

        Vase vase13 = new Vase(new Vector2f(1250, floor), 4, -90f, null!);
        vases.Add(vase13);

        Vase vase14 = new Vase(new Vector2f(1300, floor), 2, -90f, null!);
        vases.Add(vase14);

        Vase vase15 = new Vase(new Vector2f(1400, floor), 5, -90f, null!);
        vases.Add(vase15);

        Vase vase16 = new Vase(new Vector2f(1500, floor), 3, -90f, null!);
        vases.Add(vase16);

        Vase vase17 = new Vase(new Vector2f(1550, floor), 4, -90f, null!);
        vases.Add(vase17);

        Vase vase18 = new Vase(new Vector2f(1600, floor), 2, -90f, null!);
        vases.Add(vase18);

        Vase vase19 = new Vase(new Vector2f(1630, floor), 3, -90f, null!);
        vases.Add(vase19);

        Vase vase20 = new Vase(new Vector2f(1700, floor), 3, -90f, null!);
        vases.Add(vase20);

        Vase vase21 = new Vase(new Vector2f(1750, floor), 2, 90f, null!);
        vases.Add(vase21);

        Vase vase22 = new Vase(new Vector2f(1800, floor), 5, 90f, null!);
        vases.Add(vase22);

        Vase vase23 = new Vase(new Vector2f(1850, floor), 3, 90f, null!);
        vases.Add(vase23);

        Vase vase24 = new Vase(new Vector2f(1880, floor), 4, 90f, null!);
        vases.Add(vase24);

        Vase vase25 = new Vase(new Vector2f(1920, floor), 2, 90f, null!);
        vases.Add(vase25);

        Torch torch2 = new Torch(new Vector2f(2100, floor), 1200f, 1250f);
        torch2.Initialize();

        Vase vaseTorch2 = new Vase(new Vector2f(1990, floor), 5, 90f, torch2);
        vases.Add(vaseTorch2);

        foreach (Vase va in vases)
        {
            va.Initialize();
        }
    }


}