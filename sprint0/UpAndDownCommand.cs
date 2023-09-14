using Microsoft.Xna.Framework.Graphics;
using sprint0;
using System;

public class UpAndDownCommand : ICommand
{
	Sprint0 Game;
	Texture2D Texture;
	public UpAndDownCommand(Sprint0 gameObj, Texture2D texture)
	{
		Game = gameObj;
		Texture = texture;
	}

	public void execute() 
	{
		Game.SetSprite(new UpAndDownSprite(Texture, 7, 14));
	}
}
