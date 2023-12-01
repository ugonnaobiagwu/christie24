using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
namespace sprint0.GameStates
{
	public class Cartographer
	{
		//To draw rooms we need Vector2's for all room draw positions
		//Use a list of Vector2's we add in the scroll transition
		private List<Vector2> KnownMapCoordinates;
		private Vector2 CurrentRoomCoordinate;
		private int xOffset = 30;
		private int yOffset = 30;
        Texture2D RoomTexture;

        public Cartographer(Texture2D roomTexture)
		{
			KnownMapCoordinates = new List<Vector2>();
			KnownMapCoordinates.Add(new Vector2(550,-100)); //This is adding the first room of the dungeon
			CurrentRoomCoordinate = new Vector2(550,-100);
            RoomTexture = roomTexture;
		}
        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle = new Rectangle(0,0,20,20);
            foreach(Vector2 roomPos in KnownMapCoordinates)
            {
                spriteBatch.Draw(RoomTexture,roomPos,sourceRectangle,Color.White);
            }
        }
		public void addLeftRoom() {
			CurrentRoomCoordinate.X -= xOffset;
			Vector2 newRoom = new Vector2(CurrentRoomCoordinate.X,CurrentRoomCoordinate.Y);
			KnownMapCoordinates.Add(newRoom);
		}
        public void addRightRoom()
        {
            CurrentRoomCoordinate.X += xOffset;
            Vector2 newRoom = new Vector2(CurrentRoomCoordinate.X, CurrentRoomCoordinate.Y);
            KnownMapCoordinates.Add(newRoom);
        }
        public void addTopRoom()
        {
            CurrentRoomCoordinate.Y -= yOffset;
            Vector2 newRoom = new Vector2(CurrentRoomCoordinate.X, CurrentRoomCoordinate.Y);
            KnownMapCoordinates.Add(newRoom);
        }
        public void addBottomRoom()
        {
            CurrentRoomCoordinate.Y -= yOffset;
            Vector2 newRoom = new Vector2(CurrentRoomCoordinate.X, CurrentRoomCoordinate.Y);
            KnownMapCoordinates.Add(newRoom);
        }
        public void CompleteMap()
        {
            List<Vector2> completedMap = new List<Vector2>();
            //Add all rooms to completedMap

            KnownMapCoordinates = completedMap;
        }
    }
}

