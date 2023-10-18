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
        // UNFINISHED!!!


        // five lists, one for drawables, one for updateables, and one for removeables, objects in a room, and dynamics.
        private List<Object> drawables;
        private List<Object> updateables;
        private List<Object> removeables;
        private List<Object> dynamics;

        // makes a dictionary for the levels and objects
        // I will need to do something with this
        private Dictionary<int, List<Objects>> ObjectMap;
        private List<Object> room1;
        private List<Object> room2;
        private List<Object> room3;
        private List<Object> room4;
        private List<Object> room5;
        private List<Object> room6;
        private List<Object> room7;
        private List<Object> room8;
        private List<Object> room9;
        private List<Object> room10;

        // blocks, items, link, enemies, etc.

        public Object() { 
            drawables = new List<Object>();
            updateables = new List<Object>();
            removeables = new List<Object>();
            dynamics = new List<Object>();
            room1 = new List<Object>();
            room2 = new List<Object>();
            room3 = new List<Object>();
            room4 = new List<Object>();
            room5 = new List<Object>();
            room6 = new List<Object>();
            room7 = new List<Object>();
            room8 = new List<Object>();
            room9 = new List<Object>();
            room10 = new List<Object>();

            // map to hold all the objects in each room
            ObjectMap = new Dictionary<int, List<Objects>>();
            ObjectMap.Add(1, room1);
            ObjectMap.Add(2, room2);
            ObjectMap.Add(3, room3);
            ObjectMap.Add(4, room4);
            ObjectMap.Add(5, room5);
            ObjectMap.Add(6, room6);
            ObjectMap.Add(7, room7);
            ObjectMap.Add(8, room8);
            ObjectMap.Add(9, room9);
            ObjectMap.Add(10, room10);

        }

        public void addToList(int room) {
            // get the list of objects for the given level
            List<Objects> objects = KeyMap[room];
            // WORKING ON IT
            objects.Add(this);
            KeyMap[room] = objects;

            // check the type of the object and add it to the corresponding list
            if (this is IBlock)
            {
                drawables.Add(this); // blocks are only drawable
            }
            else if (this is IItem)
            {
                drawables.Add(this); // items are only drawable
                dynamics.Add(this); // items are also dynamic (can be picked up or used)
                updateables.Add(this); // items are updateable
                removeables.Add(this); // when you use it, it is removed
            }
            else if (this is ILink)
            {
                drawables.Add(this); // link is drawable
                updateables.Add(this); // link is updateable (can move and interact)
                dynamics.Add(this); // link is dynamic (can be affected by collisions or commands)
            }
            else if (this is IEnemy)
            {
                drawables.Add(this); // enemies are drawable
                updateables.Add(this); // enemies are updateable (can move and attack)
                dynamics.Add(this); // enemies are dynamic (can be damaged or killed)
                removeables.Add(this); // enemies are removeable (can be removed from the game when killed)
            }
        }

        // returns X pos of object
        public int xPosition()
        {
            // still working on it
            return this.xPosition;
        }

        // returns Y pos of object
        public int yPosition()
        {
            // still working on it
            return this.yPosition;
        }

        // (i.e.) "how big are you?"
        public int width()
        {
            // still working on it
            int width = 0;

            return width;
        }

        // (i.e.) "how big are you?"
        public int height()
        {
            // still working on it
            int height = 0;

            return height;
        }

        // does this object move? 
        public bool isDynamic()
        {
            // returns true if list has the object
            return dynamics.Contains(this);
        }


    }
}
