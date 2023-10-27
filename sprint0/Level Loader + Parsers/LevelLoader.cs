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
       /* public static void CreateBlock(int x, int y, int roomId, string blockType, SpriteFactory spriteFactory)
        {
            IGameObject Block;
            /*NOTE: Make into typeof() later IF you can cast from Object to IGameObject, if you can't it is impossible to use many of the object's methods needed by the GOM*/
            /*NOTE: All of these will need parameters added once the block classes are cleaned up: Sprite Factory, x, y.
            switch (blockType)
            {
                case "DungeonBlueBlock":
                    Block = new DungenBlueBlock();
                    break;
                case "DungeonDragonBlock":
                    Block = new DungenDragonBlock();
                    break;
                case "DungeonFishBlock":
                    Block = new DungenFishBlock();
                    break;
                case "DungeonPyramidBlock":
                    Block = new DungenPyramidBlock();
                    break;
                default:
                    break;
            }
            /*CODE TO ASSIGN ROOMID*/
            /*CODE TO SEND TO GAME OBJECT MANAGER
        }*/
       /* public static void CreateEnemy(int x, int y, int roomId, string enemyType, SpriteFactory spriteFactory)
        {
            IGameObject Enemy;
            /*NOTE: Make into typeof() later IF you can cast from Object to IGameObject, if you can't it is impossible to use many of the object's methods needed by the GOM*/
            /*NOTE: All of these will need parameters added once the block classes are cleaned up: Sprite Factory, x, y.*/
            /*NOTE: I don't have the enemy classes yet so I'll need to see those before finishing
            switch (enemyType)
            {
                case "DungeonBlueBlock":
                    Enemy = new DungenBlueBlock();
                    break;
                case "DungeonDragonBlock":
                    Enemy = new DungenDragonBlock();
                    break;
                case "DungeonFishBlock":
                    Enemy = new DungenFishBlock();
                    break;
                case "DungeonPyramidBlock":
                    Enemy = new DungenPyramidBlock();
                    break;
                default:
                    break;
            }
        }*/
        public static void CreateBoundary(int x, int y, int roomId, int width, int height, SpriteFactory spriteFactory)
        {
            /*Creates the Boundary Object*/
            Rectangle BoundaryBox = new Rectangle(x, y, width, height);
            /*IGameObject Boundary = new Boundary(BoundaryBox,roomId,spriteFactory);*/
            /*CODE TO ASSIGN ROOMID*/
            /*CODE TO SEND TO GAME OBJECT MANAGER*/

        }
        public static void CreateDoor(int x, int y, int roomId, int width, int height, int toWhere, SpriteFactory spriteFactory)
        {
            Rectangle DoorBox = new Rectangle(x, y, width,height);
            /*IGameObject Door = new Door(DoorBox, roomId, toWhere, spriteFactory);*/
            /*CODE TO ASSIGN ROOMID*/
            /*CODE TO SEND TO GAME OBJECT MANAGER*/
        }
        public static void CreateItems()
        {
            /*TO BE FINISHED LATER*/
        }
    }
    //
}