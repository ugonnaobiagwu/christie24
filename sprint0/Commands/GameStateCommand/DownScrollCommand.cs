using System;
namespace sprint0.Commands.GameStateCommand
{
	public class DownScrollCommand :ICommand
	{
        Sprint0 Game;
		public DownScrollCommand(Sprint0 game)
		{
            this.Game = game;
		}

        public void execute()
        {
            Globals.Camera.MoveCameraToBottomRoom();
        }
    }
}

