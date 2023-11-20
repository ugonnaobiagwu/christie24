using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0;

namespace sprint0.GameStates
{
	public class ScrollState:IGameState
	{
        public enum Direction { Left, Right, Up, Down }
        public Direction scrollDirection;

        public ScrollState(GameStateManager managers)
		{
		}

        public void Update(GameTime gameTime)
        {
            Globals.Camera.Update(gameTime);

            switch (scrollDirection)
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
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Globals.LinkItemSystem.Draw();

            List<IGameObject> Drawables = Globals.GameObjectManager.getList("drawables");
            foreach (IGameObject obj in Drawables)
            {
                obj.Draw(spriteBatch);
            }
        }

        public string GetState()
        {
            return "scroll";
        }

        public void TransitionState()
        {
            //Check to see if scroll is done
        }


    }
}

