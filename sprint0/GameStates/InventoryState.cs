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

    //Notes - Have to implement a list of inventory items and decide which ones to activate/deactivate based on inventory system
	public class InventoryState : StateManager, IState
	{

        IState DeathState;
        IState PauseState;
        IState PlayingState;

        private IState state;

        ILink player;
        List<IGameObject> CurrentUpdatables;
        public InventoryState()
		{
		}
        public void Update()
        {
            //Code for transition from inventory to play state 
        }
        public void EnemyUpdate()
        {
            this.state.EnemyDeactivate();
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
            this.state.LinkDeactivate();
        }

        public void RoomUpdate()
        {
            this.state.RoomDeactivate();
        }
    }
}

