using System;
using Microsoft.Xna.Framework.Graphics;

namespace sprint0.Items.groundItems
{
    public interface IGroundItem : IGameObject
    {
        public void PickUp();
    }
}