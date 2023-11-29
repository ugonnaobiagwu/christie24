using System;
namespace sprint0.Commands.GameStateCommand
{
	public class UpScrollCommand :ICommand
	{
        Sprint0 Game;
		public UpScrollCommand(Sprint0 game)
		{
            this.Game = game;
		}

        public void execute()
        {
            Globals.Camera.MoveCameraToTopRoom();
        }
    }
}

