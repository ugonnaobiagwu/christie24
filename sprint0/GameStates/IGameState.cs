using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0.GameStates
{
    public interface IGameState
    {
        //Self explanatory
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch, SpriteBatch HudInventorySpriteBatch);

        //State methods
        String GetState();
        void TransitionState();
    }
}