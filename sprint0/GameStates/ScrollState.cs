using System;
using sprint0.Link;
using System.Collections.Generic;

namespace sprint0.GameStates
{
	public class ScrollState: StateManager, IState
	{
        IState DeathState;
        IState PauseState;
        IState PlayingState;

        private IState state;

        ILink player;
        List<IGameObject> CurrentUpdatables;
        public ScrollState()
		{
		}

        public void Update()
        {
            //Code for transition from scroll => playing 
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
            return "Scroll";
        }

        public void LinkUpdate()
        {
            this.state.LinkDeactivate();
        }

        public void RoomUpdate()
        {
            this.state.RoomActivate();
        }
    }
}

