//MMP1 - Template for Levels

using SFML.Window;
using SFML.System;
using SFML.Graphics;

public abstract class Level
{
    ///<summary>
    ///5.2 Level-class
    ///template for level
    ///</summary>
    public abstract void LoadResources();
    public abstract void Update(float deltaTime);
    public abstract void Draw(RenderWindow window);
}