using System;
using static sprint0.Link.Link;
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
	public class StateManager: IState
	{
		IState InventoryState;
		IState DeathState;
		IState PauseState;
		IState PlayingState;

		private IState state;

        ILink player;

		public StateManager()
		{
		}
         
        //Methods for activating and deactivating game objects - Will be inherited by state classes
        private void LinkActivate()
        {
            player.SetState("Default");
        }
        private void LinkDeactivate()
        {
            if (state.GetState() = "Dead")
            {
                player.SetState("Dead");
            }
            else
            {
                player.SetState("NotUpdatable");
            }
        }
        private IList RoomActivate()
        {

        }
        private IList RoomDeactivate()
        {

        }
        private IList EnemyActivate()
        {

        }
        private IList EnemyDeactivate()
        {

        }
        //Calls to state specific methods below
        public void Update()
        {
            state.Update();
        }

        //Updates if ememies are updatable
        public void EnemyUpdate()
        {
            state.EnemyUpdate();
        }
        //Updates if game is resettable
        public bool GameResettable()
        {
            return state.GameResettable();
        }
        //Returns current state
        public string GetState()
        {
           return state.GetState();
        }
        //Sets if link is updatable
        public void LinkUpdate()
        {
            state.LinkUpdate();
        }
        //Sets if rooms are updatable
        public void RoomUpdate()
        {
            state.RoomUpdate();
        }

	}
}

