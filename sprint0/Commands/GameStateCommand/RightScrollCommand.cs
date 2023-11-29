using System;
namespace sprint0.Commands.GameStateCommand
{
	public class RightScrollCommand:ICommand
	{
        Sprint0 Game;
		public RightScrollCommand(Sprint0 game)
		{
            this.Game = game;
		}

        public void execute()
        {
            Globals.Camera.MoveCameraToRightRoom();
        }
    }
}

