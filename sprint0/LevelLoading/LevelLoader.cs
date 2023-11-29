using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sprint0.AnimatedSpriteFactory;
using sprint0.Blocks;
using sprint0.BoundariesDoorsAndRooms;
using sprint0.Items.groundItems;
using sprint0.LinkObj;
using sprint0;

namespace sprint0.LevelLoading
{
    public class LevelLoader
    {
        public static void CreateRoom(int x, int y, int roomId, SpriteFactory spriteFactory)
        {

            IGameObject room = new Room(x, y, spriteFactory);
            room.SetRoomId(roomId);
            SendToGOM(room);
        }
        public static void CreateBlock(int x, int y, int roomId, string blockType, SpriteFactory spriteFactory, int toRoomId)
        {
            IBlock block;
            /*NOTE FOR REFACTORING: If we were to add methods to IBlock for altering its attributes, we wouldn't need multiple block
             concrete classes and could remove this block statement.  This would require new XmlNodes and edits to CreateBlock()*/
            switch (blockType)
            {
                case "DungeonBlueBlock":
                    block = new DungeonBlueBlock(x, y, spriteFactory);
                    block.SetRoomId(roomId);
                    SendToGOM(block);
                    break;
                case "BlueDragonBlock":
                    block = new BlueDragonBlock(x, y, spriteFactory);
                    block.SetRoomId(roomId);
                    SendToGOM(block);
                    break;
                case "BlueFishBlock":
                    block = new BlueFishBlock(x, y, spriteFactory);
                    block.SetRoomId(roomId);
                    SendToGOM(block);
                    break;
                case "DungeonPyramidBlock":
                    block = new DungeonPyramidBlock(x, y, spriteFactory);
                    block.SetRoomId(roomId);
                    SendToGOM(block);
                    break;
                case "WaterBlock":
                    block = new WaterBlock(x, y, spriteFactory);
                    block.SetRoomId(roomId);
                    SendToGOM(block);
                    break;
                case "StairBlock":
                    block = new StairBlock(x, y, spriteFactory);
                    block.SetRoomId(roomId);
                    block.SetToRoomId(toRoomId); ;
                    SendToGOM(block);
                    break;
                case "DungeonFishBlock":
                    block = new DungeonFishBlock(x, y, spriteFactory);
                    block.SetRoomId(roomId);
                    block.SetToRoomId(toRoomId); ;
                    SendToGOM(block);
                    break;
                case "DungeonDragonBlock":
                    block = new DungeonDragonBlock(x, y, spriteFactory);
                    block.SetRoomId(roomId);
                    block.SetToRoomId(toRoomId); ;
                    SendToGOM(block);
                    break;
                case "RedPyramidBlock":
                    block = new RedPyramidBlock(x, y, spriteFactory);
                    block.SetRoomId(roomId);
                    block.SetToRoomId(toRoomId); ;
                    SendToGOM(block);
                    break;
                default:
                    break;
            }
        }
        public static void CreateDoor(int x, int y, int roomId, int toRoomId, Globals.Direction sideOfRoom, SpriteFactory doorFactory, IDoor.DoorState state)
        {
            IDoor door = new Door(x, y, doorFactory, sideOfRoom);
            door.SetRoomId(roomId);
            door.SetToRoomId(toRoomId);
            door.SetState(state);
            SendToGOM(door);
        }
        public static void CreateBoundary(Rectangle boundaryObj, int roomId)
        {
            IGameObject boundary = new Boundary(boundaryObj);
            boundary.SetRoomId(roomId);
            SendToGOM(boundary);

        }
        public static void CreateLink(int x, int y, SpriteFactory spriteFactory)
        {
            ILink linkObj = new Link(x, y, spriteFactory);
            Globals.Link = linkObj;
           
            
        }
        public static void CreateProjectileEnemy(int x, int y, int roomId, string enemyType, SpriteFactory enemyFactory, SpriteFactory projectileFactory)
        {
            IGameObject enemy;
            /*NOTE FOR REFACTORING: If we were to add methods to IBlock for altering its attributes, we wouldn't need multiple block
             concrete classes and could remove this block statement.  This would require new XmlNodes and edits to CreateBlock()*/
            switch (enemyType)
            {
                case "Oktorok":
                    /* enemy = new DungeonBlueBlock(x, y, spriteFactory);
                       enemy.SetRoomId(roomId);
                       SendToGOM(enemy);*/
                    break;
                default:
                    break;
            }
        }
        public static void CreateFloor(int x, int y, int roomId, SpriteFactory floorFactory)
        {
            IGameObject floor = new Floor(x, y, floorFactory);
            floor.SetRoomId(roomId);
            SendToGOM(floor);
        }
        public static void CreateGroundItem(int x, int y, int roomId, string groundItemType, SpriteFactory spriteFactory)
        {
            IGameObject groundItem;
            switch (groundItemType)
            {
                case "GroundKey":
                    groundItem = new GroundKey(spriteFactory, x, y);
                    groundItem.SetRoomId(roomId);
                    SendToGOM(groundItem);
                    break;
                case "GroundRupee":
                    groundItem = new GroundRupee(spriteFactory, x, y);
                    groundItem.SetRoomId(roomId);
                    SendToGOM(groundItem);
                    break;
                case "GroundHeart":
                    groundItem = new GroundHeart(spriteFactory, x, y);
                    groundItem.SetRoomId(roomId);
                    SendToGOM(groundItem);
                    break;
                case "GroundCompass":
                    groundItem = new GroundCompass(spriteFactory, x, y);
                    groundItem.SetRoomId(roomId);
                    SendToGOM(groundItem);
                    break;
                case "GroundBlaze":
                    groundItem = new GroundBlaze(spriteFactory, x, y);
                    groundItem.SetRoomId(roomId);
                    SendToGOM(groundItem);
                    break;
                case "GroundBigHeart":
                    groundItem = new GroundBigHeart(spriteFactory, x, y);
                    groundItem.SetRoomId(roomId);
                    SendToGOM(groundItem);
                    break;

                case "GroundPage":
                    groundItem = new GroundPage(spriteFactory, x, y);
                    groundItem.SetRoomId(roomId);
                    SendToGOM(groundItem);
                    break;
                //No Ground Bomb Object :(
                // case "GroundBomb":
                // groundItem = new Bomb(spriteFactory, x, y);
                // groundItem.SetRoomId(roomId);
                //// SendToGOM(groundItem);
                // break;
                case "GroundTriforce":

                    groundItem = new GroundTriforce(spriteFactory, x, y);
                    groundItem.SetRoomId(roomId);
                    SendToGOM(groundItem);
                    break;
                default:
                    break;
            }
        }
        public static void CreateNPC(int x, int y, int roomId, SpriteFactory spriteFactory)
        {
            IGameObject NPC = new NPC(x, y, spriteFactory);
            NPC.SetRoomId(roomId);
            SendToGOM(NPC);
        }

        //BAD CODE: Magic numbers need to go away 
        public static void LoadItem(SpriteFactory[] factoryList, string itemName)
        {
            switch (itemName)
            {
                case "Bomb":
                    Globals.LinkItemSystem.LoadBomb(factoryList[0], factoryList[1]);
                    break;
                case "BetterBow":
                    Globals.LinkItemSystem.LoadBetterBow(factoryList[0], factoryList[1]);
                    break;
                case "Bow":
                    Globals.LinkItemSystem.LoadBow(factoryList[0], factoryList[1]);
                    break;
                case "Blaze":
                    Globals.LinkItemSystem.LoadBlaze(factoryList[0]);
                    break;
                case "Boomerang":
                    Globals.LinkItemSystem.LoadBoomerang(factoryList[0]);
                    break;
                case "BetterBoomerang":
                    Globals.LinkItemSystem.LoadBetterBoomerang(factoryList[0]);
                    break;
                case "Sword":
                    Globals.LinkItemSystem.LoadSword(factoryList[0], factoryList[1], factoryList[2]);
                    break;
                default:
                    break;
            }
        }
        private static void SendToGOM(IGameObject gameObject)
        {
            Globals.GameObjectManager.addObject(gameObject);
        }
    }
}
