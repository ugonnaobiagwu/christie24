using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using sprint0.Commands;
using sprint0.Blocks;
using sprint0.Items;
using sprint0.Link;
using sprint0;

namespace sprint0
{
    public class Object : IGameObjects
    {
        // UNFINISHED!!!
        // just in charge of lists 

        // five lists, one for drawables, one for updateables, and one for removeables, objects in a room, and dynamics.
        private List<Object> drawables;
        private List<Object> updateables;
        private List<Object> removeables;
        private List<Object> dynamics;

        // makes a dictionary for the rooms and objects
        // I will need to do something with this
        // need a constructor
        private Dictionary<int, List<Objects>> ObjectMap;

        // blocks, items, link, enemies, etc.

        public Object() { 
            drawables = new List<Object>();
            updateables = new List<Object>();
            removeables = new List<Object>();
            dynamics = new List<Object>();

            // map to hold all the objects in each room
            ObjectMap = new Dictionary<int, List<Objects>>();

        }

        // more paramenters
        // find calls and add into lists?
        public void addToList(int room, Object obj) {
            // get the list of objects for the given level
            List<Objects> objects = KeyMap[room];
            // WORKING ON IT
            objects.Add(obj);
            KeyMap[room] = objects;

            // check the type of the object and add it to the corresponding list
            // interrogate the object to see if it has .update, .draw, etc
            // use reflection
            if (obj is IBlock)
            {
                drawables.Add(obj); // blocks are only drawable
            }
            else if (obj is IItem)
            {
                drawables.Add(obj); // items are only drawable
                dynamics.Add(obj); // items are also dynamic (can be picked up or used)
                updateables.Add(obj); // items are updateable
                removeables.Add(obj); // when you use it, it is removed
            }
            else if (obj is ILink)
            {
                drawables.Add(obj); // link is drawable
                updateables.Add(obj); // link is updateable (can move and interact)
                dynamics.Add(obj); // link is dynamic (can be affected by collisions or commands)
            }
            else if (obj is IEnemy)
            {
                drawables.Add(obj); // enemies are drawable
                updateables.Add(obj); // enemies are updateable (can move and attack)
                dynamics.Add(obj); // enemies are dynamic (can be damaged or killed)
                removeables.Add(obj); // enemies are removeable (can be removed from the game when killed)
            }
        }

        // queue it up and remove it later
        public void removeFromList(int room, Object obj)
        {
            // work on this :(

        }


    }
}
