using Microsoft.Xna.Framework;
using sprint0.Blocks;
using sprint0.Link;
using sprint0.Boundaries___Doors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using sprint0.AnimatedSpriteFactory;
using sprint0.Rooms;
using sprint0.Enemies;

namespace sprint0.Level_Loading___Parsers
{
    internal static class LevelLoader
    {

        public static void CreateLink(int x, int y, int roomId, SpriteFactory spriteFactory)
        {

            //IGameObject Link = new sprint0.Link.Link(x,y, roomId,spriteFactory);
            /*CODE TO ASSIGN ROOMID*/
            /*CODE TO SEND TO GAME OBJECT MANAGER*/
        }
        public static void CreateBlock(int x, int y, int roomId, string blockType, SpriteFactory spriteFactory)
        {
            IGameObject Block;
            /*NOTE: Make into typeof() later IF you can cast from Object to IGameObject, if you can't it is impossible to use many of the object's methods needed by the GOM*/
            /*NOTE: All of these will need parameters added once the block classes are cleaned up: Sprite Factory, x, y.*/
            switch (blockType)
            {
                case "DungeonBlueBlock":
                    Block = new DungeonBlueBlock(x,y,roomId,spriteFactory);
                    break;
                case "DungeonDragonBlock":
                    Block = new DungeonDragonBlock(x, y, roomId, spriteFactory);
                    break;
                case "DungeonFishBlock":
                    Block = new DungeonFishBlock(x, y, roomId, spriteFactory);
                    break;
                case "DungeonPyramidBlock":
                    Block = new DungeonPyramidBlock(x, y, roomId, spriteFactory);
                    break;
                case "BlackBlock":
                    Block = new BlackBlock(x, y, roomId, spriteFactory);
                    break;
                case "GrassBlock":
                    Block = new GrassBlock(x, y, roomId, spriteFactory);
                    break;
                case "StairBlock":
                    Block = new StairBlock(x, y, roomId, spriteFactory);
                    break;
                case "WaterBlock":
                    Block = new WaterBlock(x, y, roomId, spriteFactory);
                    break;
                case "RedPyramidBlock":
                    Block = new RedPyramidBlock(x, y, roomId, spriteFactory);
                    break;
                case "BlueFishBlock":
                    Block = new BlueFishBlock(x, y, roomId, spriteFactory);
                    break;
                case "BlueDragonBlock":
                    Block = new BlueDragonBlock(x, y, roomId, spriteFactory);
                    break;
                default:
                    break;
            }
            /*CODE TO ASSIGN ROOMID*/
            /*CODE TO SEND TO GAME OBJECT MANAGER*/
        }
       public static void CreateEnemy(int x, int y, int roomId, string enemyType, SpriteFactory spriteFactory, SpriteFactory projectileFactory)
        {
            IGameObject Enemy;
            /*NOTE: Make into typeof() later IF you can cast from Object to IGameObject, if you can't it is impossible to use many of the object's methods needed by the GOM*/
            /*NOTE: All of these will need parameters added once the block classes are cleaned up: Sprite Factory, x, y.*/
            /*NOTE: I don't have the enemy classes yet so I'll need to see those before finishing*/
            switch (enemyType)
            {
                case "Bokoblin":
                    Enemy = new Bokoblin(x, y, roomId, spriteFactory, projectileFactory);
                    break;
                case "Oktorok":
                    Enemy = new Oktorok(x, y, roomId, spriteFactory, projectileFactory);
                    break;
                case "Skeleton":
                    Enemy = new Skeleton(x, y, roomId, spriteFactory);
                    break;
                default:
                    break;
            }
        }
        public static void CreateBoundary(int x, int y, int roomId, int width, int height, SpriteFactory spriteFactory)
        {
            /*Creates the Boundary Object*/
            Rectangle BoundaryBox = new Rectangle(x, y, width, height);
            //IGameObject Boundary = new Boundary(BoundaryBox,roomId,spriteFactory);
            /*CODE TO ASSIGN ROOMID*/
            /*CODE TO SEND TO GAME OBJECT MANAGER*/

        }
        /*NEED TO ADD PARAMETERS FOR DOORLOCATION IN LevelParser.cs*/
        public static void CreateDoor(int x, int y, int roomId, int width, int height, int toWhere, SpriteFactory spriteFactory, int SideOfRoom)
        {
            Rectangle DoorBox = new Rectangle(x, y, width,height);
            //IGameObject Door = new Door(DoorBox, roomId, toWhere, spriteFactory, SideOfRoom);
            /*CODE TO ASSIGN ROOMID*/
            /*CODE TO SEND TO GAME OBJECT MANAGER*/
        }
        public static void CreateItems()
        {
            /*TO BE FINISHED LATER*/
        }
        public static void CreateRoom(int x, int y, int roomId, SpriteFactory spriteFactory)
        {
            IGameObject Room = new Room(x, y, roomId, spriteFactory);
            /*NEEDS TO GET ROOM OBJECT CONSTRUCTOR*/
        } 
    }
}