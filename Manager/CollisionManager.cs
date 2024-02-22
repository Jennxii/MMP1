//MMP1 - Collision-Management


using SFML.Graphics;
using SFML.System;
using SFML.Window;

public static class CollisionManager
{
    ///<summary>
    ///6.2 CollisionManager-class
    ///Collision-Handling
    ///</summary>
    public static bool CheckCollision(Player player, RectangleShape rect)
    {
        FloatRect playerBounds = player.playerSprite.GetGlobalBounds();
        FloatRect rectBounds = rect.GetGlobalBounds();

        return playerBounds.Intersects(rectBounds) ? true : false;
    }

    public static bool CheckCollision(Player player, Sprite sprite)
    {
        FloatRect playerBounds = player.playerSprite.GetGlobalBounds();
        FloatRect rectBounds = sprite.GetGlobalBounds();

        return playerBounds.Intersects(rectBounds) ? true : false;
    }

    public static bool CheckCollision(IntRect player, IntRect sprite)
    {
        return player.Intersects(sprite) ? true : false;
    }

    public static bool CheckCollision(Player player, CircleShape rect)
    {
        FloatRect playerBounds = player.playerSprite.GetGlobalBounds();
        FloatRect rectBounds = rect.GetGlobalBounds();

        return playerBounds.Intersects(rectBounds) ? true : false;
    }

}
