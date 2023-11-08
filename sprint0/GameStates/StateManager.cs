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
using sprint0.Boundaries___Doors;
using sprint0.Link;
using System.Collections.Generic;
using sprint0.AnimatedSpriteFactory;
using sprint0.Rooms;

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
        List<IGameObject> CurrentUpdatables;
		public StateManager()
		{
		}
         
        //Methods for activating and deactivating game objects - Will be inherited by state classes
        public void LinkActivate()
        {
            player.SetState("Default");
        }
        public void LinkDeactivate()
        {
            if (state.GetState() = "Dead")
            {
                this.player.SetState("Dead");
            }
            else
            {
                this.player.SetState("NotUpdatable");
            }
        }
        public IList<IGameObject> RoomActivate()
        {
            foreach (IGameObject roomObject in CurrentUpdatables)
            {
                //Gist of this is to activate all blocks and room objects - Maybe call foreach on room object instead of IGameObject list
                if (roomObject.GetType().Equals(IBlock) || roomObject.GetType().Equals(IRoom))
                {
                    //Calls for setting state to updatable
                }
            }
        }
        public IList<IGameObject> RoomDeactivate()
        {
            foreach (IGameObject roomObject in CurrentUpdatables)
            {
                //Gist of this is to activate all blocks and room objects - Maybe call foreach on room object instead of IGameObject list
                if (roomObject.GetType().Equals(IBlock) || roomObject.GetType().Equals(IRoom))
                {
                    //Calls for setting state to notUpdatable
                }
            }
        }
        public IList<IGameObject> EnemyActivate()
        {
            foreach (IGameObject enemyObject in CurrentUpdatables)
            {
                //Gist of this is to activate all enememy objects - Need to check for each individual enememy type since we dont have a unified IEnemy interface - look into
                if (enemyObject.GetType().Equals(IOctorok) )
                {
                    //Calls for setting state to notUpdatable
                }
            }
        }
        public IList<IGameObject> EnemyDeactivate()
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

