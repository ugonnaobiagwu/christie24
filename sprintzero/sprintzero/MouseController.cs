using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static sprintzero.Game1;

namespace sprintzero
{
    public class MouseController : IController
    {
        private MouseState currentState;
        private Point mousePos;
        public int processInput()
        {
            int input = -1;
            currentState = Mouse.GetState();
            ButtonState leftClick = currentState.LeftButton;
            ButtonState rightClick = currentState.RightButton;
            mousePos = currentState.Position;
            if (leftClick == ButtonState.Pressed)
            {
                if (mousePos.X > 400 && mousePos.Y > 200) //top-right, nonMovingAnimatedSprite
                {
                    input = 2;
                }
                else if (mousePos.X > 400 && mousePos.Y < 200) //bottom-right, movingAnimatedSprite
                {
                    input = 4;
                }
                else if (mousePos.X < 400 && mousePos.Y > 200) //top-left, nonMovingNonAnimatedSprite
                {
                    input = 3;
                }
                else if (mousePos.X < 400 && mousePos.Y < 200) //bottom-left, movingNonAnimatedSprite
                {
                    input = 1;
                }
            }
            if (rightClick == ButtonState.Pressed)
            {
                input = 0;
            }

            return input;
        }
    }
}

