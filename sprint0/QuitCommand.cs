using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

public class QuitCommand : ICommand
{
	private Game Game;
	public QuitCommand(Game game)
	{
		Game = game; 
	}
	public void execute()
	{
		Game.Exit();
	}
}
