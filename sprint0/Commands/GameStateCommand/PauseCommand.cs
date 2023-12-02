using System;
using sprint0.GameStates;
namespace sprint0.Commands.GameStateCommand
{
	public class PauseCommand :ICommand
	{
        Sprint0 Game;
        IGameState GameState;
        public PauseCommand(Sprint0 game)
		{
            this.Game = game;
           //this.GameState = gameState;
        }

        public void execute()
        {
            //Globals.isPaused = !Globals.isPaused;
        }
    }
}

