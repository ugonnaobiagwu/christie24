using Microsoft.Xna.Framework.Graphics;
using sprint0;
using System;

public class MovingAnimatedCommand : ICommand
{
	Sprint0 Game;
	Texture2D Texture;	
	public MovingAnimatedCommand(Sprint0 gameObj, Texture2D texture)
	{
		Game = gameObj;
		Texture = texture;
	}

	public void execute() 
	{
		Game.SetSprite(new MovingAnimatedSprite(Texture,7,14));
	}
}
