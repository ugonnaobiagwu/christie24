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
	public class StateManager
	{
		IState InventoryState;
		IState DeathState;
		IState PauseState;
		IState PlayingState;
        IState ScrollState;

		IState state;

        public enum GameState { Inventory, Death, Pause, Playing,Scroll}
        public GameState currentState = GameState.Playing;
        public ILink player { get; set; }
        public List<IGameObject> CurrentUpdatables;
		public StateManager()
		{


            //Instantiate states
           /// InventoryState = new InventoryState();
           // DeathState = new DeathState();
            PlayingState = new PlayingState();
            //ScrollState = new ScrollState();
		}
        //Method for transitioning state, called by state classes - may use, may not use
        //public void StateTransition(String newState)
        //{
        //    switch (newState)
        //    {
        //        case "Inventory":
        //            this.state = InventoryState;
        //            break;
        //        case "Dead":
        //            this.state = DeathState;
        //            break;
        //        case "Playing":
        //            this.state = PlayingState;
        //            break;
        //        case "Scroll":
        //            this.state = ScrollState;
        //            break;

        //    }

        //}

        //Methods for activating and deactivating game objects - Will be inherited by state classes
        public void LinkActivate()
        {
            player.SetState(Link.State.Default);
        }
        public void LinkDeactivate()
        {
            //if (state.GetState() = GameState.Death)
            //{
            //    this.player.SetState(Link.State.Dead);
            //}
            //else
            //{
            //  //  this.player.SetState("NotUpdatable");
            //}
        }
        public IList<IGameObject> RoomActivate()
        {
            //foreach (IGameObject roomObject in CurrentUpdatables)
            //{
            //    //Gist of this is to activate all blocks and room objects - Maybe call foreach on room object instead of IGameObject list
            //    if (roomObject.GetType().Equals(IBlock) || roomObject.GetType().Equals(IRoom))
            //    {
            //        //Calls for setting state to updatable
            //    }
            //}
            return CurrentUpdatables;
        }
        public IList<IGameObject> RoomDeactivate()
        {
            //foreach (IGameObject roomObject in CurrentUpdatables)
            //{
            //    //Gist of this is to activate all blocks and room objects - Maybe call foreach on room object instead of IGameObject list
            //    if (roomObject.GetType().Equals(IBlock) || roomObject.GetType().Equals(IRoom))
            //    {
            //        //Calls for setting state to notUpdatable
            //    }
                return CurrentUpdatables;
            
        }
        public IList<IGameObject> EnemyActivate()
        {
            //foreach (IGameObject enemyObject in CurrentUpdatables)
            //{
            //    //Gist of this is to activate all enememy objects - Need to check for each individual enememy type since we dont have a unified IEnemy interface - look into
            //    if (enemyObject.GetType().Equals(IOctorok) )
            //    {
            //        //Calls for setting state to notUpdatable
                    
            //    }
            //}
            return CurrentUpdatables;
        }
        public IList<IGameObject> EnemyDeactivate()
        {
            return CurrentUpdatables;
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
        public GameState GetState()
        {
           return currentState;
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

