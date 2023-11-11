using Microsoft.Xna.Framework;
using sprint0.AnimatedSpriteFactory;
using sprint0.Blocks;
using sprint0.BoundariesDoorsAndRooms;
using sprint0.LinkObj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0.LevelLoading
{
    public  class LevelLoader
    {
        public static void CreateRoom(int x, int y, int roomId, SpriteFactory spriteFactory)
        {

            IGameObject room = new Room(x, y, roomId, spriteFactory);
           // room.SetRoomId(roomId);
            SendToGOM(room);
        }
        public static void CreateBlock(int x, int y, int roomId, string blockType, SpriteFactory spriteFactory)
        {
            IGameObject block;
            /*NOTE FOR REFACTORING: If we were to add methods to IBlock for altering its attributes, we wouldn't need multiple block
             concrete classes and could remove this block statement.  This would require new XmlNodes and edits to CreateBlock()*/
            switch (blockType)
            {
                case "DungeonBlueBlock":
                    block = new DungeonBlueBlock(x, y, roomId, spriteFactory);
                    //block.SetRoomId(roomId);
                    SendToGOM(block);
                    break;
                default:
                    break;
            }
        }
        public static void CreateDoor(int x, int y, int roomId, int toRoomId, Globals.Direction sideOfRoom, SpriteFactory doorFactory)
        {
            IGameObject door = new Door(x, y, toRoomId,doorFactory, sideOfRoom);
            door.SetRoomId(roomId);
            SendToGOM(door);
        }
        public static void CreateBoundary(Rectangle boundaryObj, int roomId)
        {
            IGameObject boundary = new Boundary(boundaryObj, roomId);
            //boundary.SetRoomId(roomId);
            SendToGOM(boundary);

        }
        public static void CreateLink(int x, int y, int roomId, SpriteFactory spriteFactory, Sprint0 game)
        {
            ILink linkObj = new Link(x, y, spriteFactory);
            linkObj.SetRoomId(roomId);
            //game.LinkObj = linkObj;
            Globals.Link = linkObj;
            SendToGOM(linkObj);

        }
        private static void SendToGOM(IGameObject gameObject)
        {
            Globals.GameObjectManager.addObject(gameObject);
        }
    }
}
