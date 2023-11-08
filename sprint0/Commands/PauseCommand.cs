using System;
using sprint0.GameStates;
namespace sprint0.Commands
{
	public class PauseCommand : ICommand
	{
        //Initiate state machine
        Sprint0 Game;
        InventoryState PauseState;
		public PauseCommand(Sprint0 game, InventoryState pauseState)
		{
			PauseState = pauseState;
		}
		public void execute()
		{
			PauseState.UpdatePause();
			PauseState.Update();
		}
	}
}

