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

        private void Update()
        {
            if (player.GetState().Equals("Dead"))
            {
                state = DeathState;
            }
            //check for inventory

            //check for playing

            //check for pause 
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

