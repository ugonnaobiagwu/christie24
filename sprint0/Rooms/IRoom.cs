using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace sprint0.Rooms
{

    public interface IRoom
    {
        public void NextRoom();
        public void PreviousRoom();

    }
}