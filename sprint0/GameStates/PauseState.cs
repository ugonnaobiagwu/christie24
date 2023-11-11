using System;
namespace sprint0.GameStates
{
	public class PauseState:StateManager, IState
	{
        IState PlayState;
     

        IState state;
        //Redundant? is there a pause in zelda 1 or is that just the inventory
        public PauseState()
		{
		}

        public new void EnemyUpdate()
        {
            this.state.EnemyActivate();
        }

        public new bool GameResettable()
        {
            return false;
        }

        public new string GetState()
        {
            return "Pause";
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

