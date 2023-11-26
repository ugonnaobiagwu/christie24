using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0.Blocks
{

    public interface IBlock : IGameObject
    {


        //add in Game central argument

        public void Explode();
        // public void NextBlock();
        // public void PreviousBlock();
        public int GetToRoomId();

        public void SetToRoomId(int toRoomId);


    }

}