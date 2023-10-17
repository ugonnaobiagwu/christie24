using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using sprint0.Commands;
using sprint0;

namespace sprint0
{
    public class Object : IGameObjects
    {
        // five lists, one for drawables, one for updateables, and one for removeables, objects in a room, and dynamics.

        // blocks, items, link, enemies, etc.


        // returns X pos of object
        public int xPosition() { 
            int x = 0;

            return x;
        }

        // returns Y pos of object
        public int yPosition() {
            int y = 0;

            return y;
        }

        // (i.e.) "how big are you?"
        public int width() { 
            int width = 0;

            return width;
        }

        // (i.e.) "how big are you?"
        public int height() { 
            int height = 0;

            return height;
        }

        // does this object move? 
        public bool isDynamic() {
            bool isDynamic = true;

            return isDynamic;
        }


    }
}
