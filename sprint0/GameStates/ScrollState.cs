using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0;
using sprint0.BoundariesDoorsAndRooms;
using static sprint0.Globals;
using sprint0.HUDs;
namespace sprint0.GameStates
{
    public class ScrollState : IGameState
    {
        
        //public Direction ScrollDirection;
        private Door EnteredDoor { get; set; }
        Direction SideOfRoomDirection;
        private int NewRoomId;
        private float ScrollTime = 1.5f;
        GameStateManager GameStateManager;
        HUD GameHud;
        public ScrollState(GameStateManager manager, int toRoomId, Direction sideOfRoom, HUD newHud)
        {
            GameStateManager = manager;
            NewRoomId = toRoomId;
            SideOfRoomDirection = sideOfRoom;
            GameHud = newHud;
        }

        public void Update(GameTime gameTime)
        {
            Globals.Camera.Update(gameTime);

            switch (Globals.scrollFromThisDirection)
            {
                case (Direction.Left):
                    Globals.Camera.MoveCameraToLeftRoom();
                    break;
                case (Direction.Right):
                    Globals.Camera.MoveCameraToRightRoom();
                    break;
                case (Direction.Up):
                    Globals.Camera.MoveCameraToTopRoom();
                    break;
                case (Direction.Down):
                    Globals.Camera.MoveCameraToBottomRoom();
                    break;
            }

            Globals.Update(gameTime);

            this.TransitionState();
        }

        public void Draw(SpriteBatch spriteBatch, SpriteBatch HudInvSpriteBatch)
        {
            Globals.LinkItemSystem.Draw();
            
            List<IGameObject> Drawables = Globals.GameObjectManager.drawablesInRoom();
            foreach (IGameObject obj in Drawables)
            {
                obj.Draw(spriteBatch);
            }
            GameHud.Draw();
        }

        public string GetState()
        {
            return "scroll";
        }

        public void TransitionState()
        {
            //Check to see if scroll is done
            ScrollTime -= Globals.TotalSeconds;
            if (ScrollTime <= 0)
            {
                ScrollTime += 1.5f;
                Globals.startScrolling = false;
                GameStateManager.ChangeState("play");
            }
        }

    }
}