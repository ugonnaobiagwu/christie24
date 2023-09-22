 using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0;
using System;

public class FixedSingleCommand: ICommand
{
	Sprint0 Game;
	Texture2D Texture;

	public FixedSingleCommand(Sprint0 GameObj, Texture2D texture)

	{
		Game = GameObj;

		Texture = texture;
	}

	public void execute()
	{
		Game.SetSprite(new FixedSingleSprite(Texture,7,14));

	}
}
