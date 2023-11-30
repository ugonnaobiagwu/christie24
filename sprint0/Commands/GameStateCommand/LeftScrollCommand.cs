using System;
namespace sprint0.Commands.GameStateCommand
{
	public class LeftScrollCommand : ICommand
	{
        Sprint0 Game;
        public LeftScrollCommand(Sprint0 game)
		{
            this.Game = game;
        }
        public void execute()
        {
            Globals.startScrolling = true;
            //Globals.Camera.MoveCameraToLeftRoom();
            Console.WriteLine("Left scroll command");
        }
    }
}

