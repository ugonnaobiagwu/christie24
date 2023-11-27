using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.AnimatedSpriteFactory;
using sprint0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static sprint0.Globals;

namespace sprint0.BoundariesDoorsAndRooms
{
    internal class Door : IDoor
    {
        SpriteFactory spriteFactory;
        ISprite doorSprite;
        int roomId;
        int toRoomId;
        Vector2 position;
        Globals.Direction sideOfRoom;
        IDoor.DoorState state;
        static Dictionary<IDoor.DoorState, string> stateSprites;
        public Door(int x, int y, SpriteFactory spriteFactory, Globals.Direction sideOfRoom)
        {
            position.X = x;
            position.Y = y;
            this.spriteFactory = spriteFactory;
            this.sideOfRoom = sideOfRoom;
            stateSprites = new Dictionary<IDoor.DoorState, string>();
            PopulateDoorStates();
        }
        private static void PopulateDoorStates()
        {
            stateSprites.Add(IDoor.DoorState.Open, "Open");
            stateSprites.Add(IDoor.DoorState.Closed, "Closed");
            stateSprites.Add(IDoor.DoorState.Locked, "Locked");
            stateSprites.Add(IDoor.DoorState.Bombable, "Bombable");
            stateSprites.Add(IDoor.DoorState.Exploded, "Exploded");
            stateSprites.Add(IDoor.DoorState.Wall, "Wall");
        }
        public int xPosition()
        {
            return (int)position.X;
        }
        public int yPosition()
        {
            return (int)position.Y;
        }
        public int width()
        {
            return doorSprite.GetWidth();
        }
        public int height()
        {
            return doorSprite.GetHeight();
        }
        public Direction getSideOfRoom()
        {
            return sideOfRoom;
        }
        public void setSideOfRoom(Globals.Direction side)
        {
            sideOfRoom = side;
        }
        public void SetState(IDoor.DoorState newState)
        {
            state = newState;
            doorSprite = spriteFactory.getAnimatedSprite(stateSprites[newState]);
        }
        public IDoor.DoorState GetState()
        {
            return state;
        }
        public bool isDrawable()
        {
            return true;
        }
        public bool isUpdateable()
        {
            //When we need to add exploding walls, we can make this into a variable
            return false;
        }
        public bool isInPlay()
        {
            return true;
        }
        public bool isDynamic()
        {
            //This will also need to be changed like IsUpdateable
            return false;
        }
        public void SetRoomId(int roomId)
        {
            this.roomId = roomId;
        }
        public int GetRoomId()
        {
            return roomId;
        }
        public int GetToRoomId()
        {
            return toRoomId;
        }
        public void SetToRoomId(int toRoomId)
        {
            this.toRoomId = toRoomId;
        }
        public void Update()
        {
            //Nothing to update but states would require it to be added
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            doorSprite.Draw(spriteBatch, xPosition(), yPosition(), 0);
        }
        public string type()
        {
            return "Door";
        }
    }
}
