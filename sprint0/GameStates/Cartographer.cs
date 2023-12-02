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
        private List<Vector2> KnownRoomHorizontalConnectors;
        private List<Vector2> KnownRoomVerticalConnectors;
        private Vector2 CurrentRoomCoordinate;
		private int xOffset = 30;
		private int yOffset = 30;
        Texture2D RoomTexture;

        public Cartographer(Texture2D roomTexture)
		{
			KnownMapCoordinates = new List<Vector2>();
			KnownMapCoordinates.Add(new Vector2(550,-100)); //This is adding the first room of the dungeon
			CurrentRoomCoordinate = new Vector2(550,-100);
            KnownRoomHorizontalConnectors = new List<Vector2>();
            KnownRoomVerticalConnectors = new List<Vector2>();
            RoomTexture = roomTexture;
           
		}
        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle = new Rectangle(0,0,20,20);
            foreach(Vector2 roomPos in KnownMapCoordinates)
            {
                spriteBatch.Draw(RoomTexture,roomPos,sourceRectangle,Color.White);
            }
            Rectangle sourceRectangleConnector = new Rectangle(0,0,xOffset,yOffset/4);
            foreach(Vector2 connectorPost in KnownRoomHorizontalConnectors)
            {
                spriteBatch.Draw(RoomTexture, connectorPost, sourceRectangleConnector, Color.White);
            }
            sourceRectangleConnector = new Rectangle(0, 0, xOffset/4, yOffset);
            foreach (Vector2 vertConnector in KnownRoomVerticalConnectors)
            {
                spriteBatch.Draw(RoomTexture, vertConnector,sourceRectangleConnector,Color.White);
            }
        }
		public void addLeftRoom() {
			CurrentRoomCoordinate.X -= xOffset;
			Vector2 newRoom = new Vector2(CurrentRoomCoordinate.X,CurrentRoomCoordinate.Y);
			KnownMapCoordinates.Add(newRoom);
            Vector2 newRoomConnector = new Vector2(CurrentRoomCoordinate.X + xOffset/2, CurrentRoomCoordinate.Y + yOffset/4);
            KnownRoomHorizontalConnectors.Add(newRoomConnector);
        }
        public void addRightRoom()
        {
            CurrentRoomCoordinate.X += xOffset;
            Vector2 newRoom = new Vector2(CurrentRoomCoordinate.X, CurrentRoomCoordinate.Y);
            KnownMapCoordinates.Add(newRoom);
            Vector2 newRoomConnector = new Vector2(CurrentRoomCoordinate.X - xOffset / 2, CurrentRoomCoordinate.Y + yOffset/4);
            KnownRoomHorizontalConnectors.Add(newRoomConnector);
        }
        public void addTopRoom()
        {
            CurrentRoomCoordinate.Y -= yOffset;
            Vector2 newRoom = new Vector2(CurrentRoomCoordinate.X, CurrentRoomCoordinate.Y);
            KnownMapCoordinates.Add(newRoom);
            Vector2 newRoomConnector = new Vector2(CurrentRoomCoordinate.X + xOffset/4, CurrentRoomCoordinate.Y + yOffset/2 );
            KnownRoomVerticalConnectors.Add(newRoomConnector);
        }
        public void addBottomRoom()
        {
            CurrentRoomCoordinate.Y -= yOffset;
            Vector2 newRoom = new Vector2(CurrentRoomCoordinate.X, CurrentRoomCoordinate.Y);
            KnownMapCoordinates.Add(newRoom);
            Vector2 newRoomConnector = new Vector2(CurrentRoomCoordinate.X + xOffset / 4, CurrentRoomCoordinate.Y - yOffset / 2 );
            KnownRoomVerticalConnectors.Add(newRoomConnector);
        }
        public void CompleteMap()
        {
            //Make a completed map
            //Basically just resetting the Vector list and mimiking exploring the whole map
            KnownMapCoordinates = new List<Vector2>();
            KnownMapCoordinates.Add(new Vector2(550, -100)); //This is adding the first room of the dungeon
            CurrentRoomCoordinate = new Vector2(550, -100);
            KnownRoomHorizontalConnectors = new List<Vector2>();

            //Exploring the map woo
            this.addLeftRoom();
            this.addRightRoom();
            this.addRightRoom();
            this.addLeftRoom();
            this.addTopRoom();
            this.addTopRoom();
            this.addLeftRoom();
            this.addTopRoom();
            this.addRightRoom();
            this.addTopRoom();
            this.addTopRoom();
            this.addLeftRoom();
            this.addRightRoom();
            this.addBottomRoom();
            this.addBottomRoom();
            this.addBottomRoom();
            this.addRightRoom();
            this.addTopRoom();
            this.addLeftRoom();
            this.addRightRoom();
            this.addRightRoom();
            this.addTopRoom();
            this.addRightRoom();

        }
    }
}

