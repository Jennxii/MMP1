//MMP1 - the floors in first Program.game.level

using SFML.Graphics;
using SFML.Window;
using SFML.System;

public class Floors
{
    public bool w_down = false;
    //special doors
    public RectangleShape startDoor = new RectangleShape(new Vector2f(150, 200));
    public RectangleShape door3back = new RectangleShape(new Vector2f(150, 200));
    public RectangleShape doorBonusroom3Back = new RectangleShape(new Vector2f(150, 200));
    public RectangleShape doorEndBack = new RectangleShape(new Vector2f(150, 200));

    public RectangleShape endDoor = new RectangleShape(new Vector2f(150, 200));
    public void LoadResources()
    {
        //doors
        startDoor.Position = new Vector2f(300, -640);
        startDoor.FillColor = Color.Black;


        door3back.Position = new Vector2f(2400, 50);
        door3back.FillColor = Color.Black;



        doorBonusroom3Back.Position = new Vector2f(3550, 3050);
        doorBonusroom3Back.FillColor = Color.Black;
        doorEndBack.Position = new Vector2f(3550, 2050);
        doorEndBack.FillColor = Color.Black;
    }
    public void Draw(RenderWindow window)
    {
        window.Draw(startDoor);
        window.Draw(door3back);
        window.Draw(doorBonusroom3Back);
        window.Draw(doorEndBack);
    }
    public class Floor1
    {
        //firstfloor
        public RectangleShape door = new RectangleShape(new Vector2f(150, 200));
        public RectangleShape door2 = new RectangleShape(new Vector2f(150, 200));
        //deathdoor
        public RectangleShape door3 = new RectangleShape(new Vector2f(150, 200));
        public RectangleShape startDoorBack = new RectangleShape(new Vector2f(150, 200));

        public void Draw(RenderWindow window)
        {
            //firstfloor
            Program.game.level.DrawWall(new Vector2f(-650, -150), new Vector2i(3, 1), Program.game.level.backgroundSize);
            window.Draw(door);
            window.Draw(door2);
            window.Draw(door3);
            window.Draw(startDoorBack);


        }

        public void LoadResources()
        {
            //firstfloor
            door.Position = new Vector2f(400, 50);
            door.FillColor = Color.Black;
            door2.Position = new Vector2f(900, 50);
            door2.FillColor = Color.Black;

            door3.Position = new Vector2f(1400, 50);
            door3.FillColor = Color.Black;
            startDoorBack.Position = new Vector2f(-100, 50);
            startDoorBack.FillColor = Color.Black;
        }
    }
    public class Floor2
    {
        //secondfloor
        //deathdoor
        public RectangleShape door4 = new RectangleShape(new Vector2f(150, 200));
        //bonusroom2
        public RectangleShape door5 = new RectangleShape(new Vector2f(150, 200));
        //rightway
        public RectangleShape door6 = new RectangleShape(new Vector2f(150, 200));
        public RectangleShape door2back = new RectangleShape(new Vector2f(150, 200));


        public void Draw(RenderWindow window)
        {
            //secondfloor
            Program.game.level.DrawWall(new Vector2f(-650, 1850), new Vector2i(3, 1), Program.game.level.backgroundSize);

            window.Draw(door4);
            window.Draw(door5);
            window.Draw(door6);
            window.Draw(door2back);
        }

        public void LoadResources()
        {
            //secondfloor
            door4.Position = new Vector2f(400, 2050);
            door4.FillColor = Color.Black;
            door5.Position = new Vector2f(900, 2050);
            door5.FillColor = Color.Black;
            door6.Position = new Vector2f(1400, 2050);
            door6.FillColor = Color.Black;
            door2back.Position = new Vector2f(-150 / 2, 2050);
            door2back.FillColor = Color.Black;
        }
    }
    public class Floor3
    {
        //deathdoor
        public RectangleShape door7 = new RectangleShape(new Vector2f(150, 200));
        //bonusroom2
        public RectangleShape door8 = new RectangleShape(new Vector2f(150, 200));
        //rightway
        public RectangleShape door9 = new RectangleShape(new Vector2f(150, 200));
        public RectangleShape door10 = new RectangleShape(new Vector2f(150, 200));
        public RectangleShape door6back = new RectangleShape(new Vector2f(150, 200));

        public void Draw(RenderWindow window)
        {
            //thirdfloor
            Program.game.level.DrawWall(new Vector2f(-650, 2600), new Vector2i(3, 1), Program.game.level.backgroundSize);

            window.Draw(door7);
            window.Draw(door8);
            window.Draw(door9);
            window.Draw(door10);
            window.Draw(door6back);

        }
        public void LoadResources()
        {
            door7.Position = new Vector2f(0, 2800);
            door7.FillColor = Color.Black;
            door8.Position = new Vector2f(400, 2800);
            door8.FillColor = Color.Black;
            door9.Position = new Vector2f(800, 2800);
            door9.FillColor = Color.Black;
            door10.Position = new Vector2f(1200, 2800);
            door10.FillColor = Color.Black;
            door6back.Position = new Vector2f(-400, 2800);
            door6back.FillColor = Color.Black;
        }
    }
    public void HandleDoors()
    {
        if (w_down)
        {
            Vector2f deathRoom = new Vector2f(2500, 200);
            if (CollisionManager.CheckCollision(Program.game.player, startDoor))
            {
                Program.game.player.Position = new Vector2f(-80, 200);
                Program.game.player.playerSprite.Position = Program.game.player.Position;
                w_down = false;
            }
            else if (CollisionManager.CheckCollision(Program.game.player, Program.game.level.floor1.startDoorBack))
            {
                Program.game.player.Position = new Vector2f(300 + 70, -500);
                Program.game.player.playerSprite.Position = Program.game.player.Position;
                w_down = false;
            }
            else if (CollisionManager.CheckCollision(Program.game.player, Program.game.level.floor1.door))
            {
                Program.game.player.Position = new Vector2f(0, 1200);
                Program.game.player.playerSprite.Position = Program.game.player.Position;
                w_down = false;

            }
            else if (CollisionManager.CheckCollision(Program.game.player, Program.game.level.room1.doorback))
            {
                Program.game.player.Position = new Vector2f(450, 210);
                Program.game.player.playerSprite.Position = Program.game.player.Position;
                w_down = false;
            }
            else if (CollisionManager.CheckCollision(Program.game.player, Program.game.level.floor1.door2))
            {
                Program.game.player.Position = new Vector2f(0, 2190);
                Program.game.player.playerSprite.Position = Program.game.player.Position;
                w_down = false;
            }
            else if (CollisionManager.CheckCollision(Program.game.player, Program.game.level.floor2.door2back))
            {
                Program.game.player.Position = new Vector2f(1000, 210);
                Program.game.player.playerSprite.Position = Program.game.player.Position;
                w_down = false;
            }
            else if (CollisionManager.CheckCollision(Program.game.player, Program.game.level.floor1.door3) ||
                    CollisionManager.CheckCollision(Program.game.player, Program.game.level.floor2.door4) ||
                    CollisionManager.CheckCollision(Program.game.player, Program.game.level.floor3.door7) ||
                    CollisionManager.CheckCollision(Program.game.player, Program.game.level.floor3.door8))
            {
                Program.game.player.Position = deathRoom;
                Program.game.player.playerSprite.Position = Program.game.player.Position;
                Program.game.level.deathRoom.movingUp = true;
                w_down = false;
            }
            else if (CollisionManager.CheckCollision(Program.game.player, Program.game.level.floor2.door5))
            {
                Program.game.player.Position = new Vector2f(2400, 3200);
                Program.game.player.playerSprite.Position = Program.game.player.Position;
                w_down = false;
            }
            else if (CollisionManager.CheckCollision(Program.game.player, Program.game.level.floor2.door6))
            {
                Program.game.player.Position = new Vector2f(-350, 2950);
                Program.game.player.playerSprite.Position = Program.game.player.Position;
                w_down = false;
            }
            else if (CollisionManager.CheckCollision(Program.game.player, Program.game.level.bonusRoom2.doorback2))
            {
                Program.game.player.Position = new Vector2f(950, 2190);
                Program.game.player.playerSprite.Position = Program.game.player.Position;
                w_down = false;
            }
            else if (CollisionManager.CheckCollision(Program.game.player, Program.game.level.floor3.door6back))
            {
                Program.game.player.Position = new Vector2f(1450, 2190);
                Program.game.player.playerSprite.Position = Program.game.player.Position;
                w_down = false;
            }
            else if (CollisionManager.CheckCollision(Program.game.player, Program.game.level.floor3.door9))
            {
                Program.game.player.Position = new Vector2f(3600, 2190);
                Program.game.player.playerSprite.Position = Program.game.player.Position;
                w_down = false;
            }
            else if (CollisionManager.CheckCollision(Program.game.player, Program.game.level.floor3.door10))
            {
                Program.game.player.Position = new Vector2f(3600, 3200);
                Program.game.player.playerSprite.Position = Program.game.player.Position;
                w_down = false;
            }
            else if (CollisionManager.CheckCollision(Program.game.player, doorBonusroom3Back))
            {
                Program.game.player.Position = new Vector2f(1250, 2950);
                Program.game.player.playerSprite.Position = Program.game.player.Position;
                w_down = false;
            }
            else if (CollisionManager.CheckCollision(Program.game.player, doorEndBack))
            {
                Program.game.player.Position = new Vector2f(850, 2950);
                Program.game.player.playerSprite.Position = Program.game.player.Position;
                w_down = false;
            }
        }
    }
}