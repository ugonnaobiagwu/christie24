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
using sprint0.LinkObj;
using System.Collections.Generic;
using sprint0.AnimatedSpriteFactory;

namespace sprint0.GameStates
{

    //Notes - Have to implement a list of inventory items and decide which ones to activate/deactivate based on inventory system
	public class InventoryState : StateManager, IState
	{

        IState PlayingState;

        private IState state;

        ILink player;
        bool PauseCommand;
        List<IGameObject> CurrentUpdatables;
        public InventoryState(IState playingState)
		{
            //Define transition states
            PlayingState = playingState;

            //Set conditions for state
            this.state.EnemyUpdate();
            this.state.GameResettable();
            this.state.LinkUpdate();
            this.state.RoomUpdate();

            //Set pause command
            PauseCommand = false;
        }
        public new void Update()
        {
            //Code for transition from inventory to play state
            if (PauseCommand) {
                this.state = PlayingState;
            } 
        }

        //Method to update pause bool based on commands
        public void UpdatePause()
        {
            PauseCommand = true;
        }

        public new void EnemyUpdate()
        {
            this.state.EnemyDeactivate();
        }

        public new bool GameResettable()
        {
            return false;
        }

        public new string GetState()
        {
            return "Inventory";
        }

        public new void LinkUpdate()
        {
            this.state.LinkDeactivate();
        }

        public new void RoomUpdate()
        {
            this.state.RoomDeactivate();
        }
    }
}

