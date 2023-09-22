using Microsoft.Xna.Framework.Graphics;
using sprint0;
using System;

public class FixedAnimatedCommand : ICommand
{
	Sprint0 Game;
	
	Texture2D Texture;
	
    public FixedAnimatedCommand(Sprint0 gameObj, Texture2D texture)
	{
		Game = gameObj;
		Texture = texture;
		
	}

	public void execute()
	{
		Game.SetSprite(new FixedAnimatedSprite(Texture, 7, 14));
	}
}
