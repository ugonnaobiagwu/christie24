using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using sprint0.Commands;
using sprint0;

namespace sprint0.ObjectManagers
{
    public class Object : IGameObjects
    {
        // five lists, one for drawables, one for updateables, and one for removeables, objects in a room, and dynamics.

        // blocks, items, link, enemies, etc.

        ListMap = new Dictionary<Level, List>();

    }
}
