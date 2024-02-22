//MMP1 - Template for Objects

using SFML.Graphics;
using SFML.Window;

public abstract class GameObject : Transformable
{
    ///<summary>
    ///5. GameObject-class
    ///template for gameobjects
    ///</summary>
    public abstract void Initialize();
    public abstract void Update(float deltaTime);
    public abstract void Draw(RenderWindow window);
}