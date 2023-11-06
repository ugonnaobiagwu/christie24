using System;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using sprint0.Commands;
using sprint0.Items.groundItems;
using System.Runtime.CompilerServices;
using sprint0.Controllers;
using sprint0.Blocks;
using sprint0.Link;
using System.Collections.Generic;
using sprint0.AnimatedSpriteFactory;

namespace sprint0.GameStates
{
	public class InventoryState : StateManager, IState
	{

        ILink player;
		public InventoryState()
		{
		}

        public void EnemyUpdate()
        {
            throw new NotImplementedException();
        }

        public bool GameResettable()
        {
            return false;
        }

        public string GetState()
        {
            return "Inventory";
        }

        public void LinkUpdate()
        {
            player.SetState("Dead");
            //Find a better way to change this var beyond adding a setter method?
            player.IsUpdateable = false;
        }

        public void RoomUpdate()
        {
            throw new NotImplementedException();
        }
    }
}

