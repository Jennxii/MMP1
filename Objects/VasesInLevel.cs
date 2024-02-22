//MMP1 - for random vases in the level

using SFML.Graphics;
using SFML.Window;
using SFML.System;

public class VasesInLevel : Level
{
    ///<summary>
    ///3.3 VasesInLevel-class
    ///handles vases randomly implemented in the level
    ///</summary>
    List<Vase> vases = new List<Vase>();

    public int firstfloor = 250;
    public int secondfloor = 2250;
    private float thirdfloor = 3000;

    public override void Draw(RenderWindow window)
    {
        foreach (Vase va in vases)
        {
            va.Draw(window);
        }
    }
    public override void Update(float deltaTime)
    {
        foreach (Vase va in vases)
        {
            va.Update(deltaTime);
        }
    }
    public override void LoadResources()
    {


        Torch torch = new(new Vector2f(800, firstfloor), 190f, 220f);
        torch.Initialize();
        Torch torch2 = new(new Vector2f(350, thirdfloor), 2970f, thirdfloor);
        torch2.Initialize();
        Torch torch3 = new(new Vector2f(2800, 3250), 3200f, 3250f);
        torch3.Initialize();

        Vase vaseRandom1 = new(new Vector2f(600, firstfloor), 3, 90f, null!);
        vases.Add(vaseRandom1);
        Vase vaseRandom2 = new(new Vector2f(1300, firstfloor), 2, -90f, null!);
        vases.Add(vaseRandom2);

        Vase vaseRandom3 = new(new Vector2f(200, secondfloor), 3, 90f, null!);
        vases.Add(vaseRandom3);
        Vase vaseRandom4 = new(new Vector2f(600, secondfloor), 2, 90f, null!);
        vases.Add(vaseRandom4);
        Vase vaseRandom5 = new(new Vector2f(1300, secondfloor), 5, 90f, null!);
        vases.Add(vaseRandom5);

        Vase vaseRandom6 = new(new Vector2f(200, thirdfloor), 3, 90f, torch2);
        vases.Add(vaseRandom6);

        Vase vaseRandom7 = new(new Vector2f(400, thirdfloor), 4, 90f, null!);
        vases.Add(vaseRandom7);
        Vase vaseRandom8 = new(new Vector2f(1100, thirdfloor), 2, -90f, null!);
        vases.Add(vaseRandom8);
        Vase vaseRandom9 = new(new Vector2f(1400, thirdfloor), 5, -90f, null!);
        vases.Add(vaseRandom9);

        Vase vaseBonus = new(new Vector2f(2600, 3250), 5, 90f, torch3);
        vases.Add(vaseBonus);

        foreach (Vase va in vases)
        {
            va.Initialize();
        }
    }


}