using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Data;
using System.Diagnostics.Contracts;

public class TextSprite: ISprite
{
	SpriteFont Font;
	public TextSprite(SpriteFont font)
	{
		Font = font;
	}
	public void Update()
	{

	}
	public void Draw(SpriteBatch spriteBatch, int x, int y)
	{
		
		spriteBatch.Begin();
		if(Font !=null)
		spriteBatch.DrawString(Font, "Credits\nProgram Made By: Ryan Greene\nSprites From: https://www.mariouniverse.com/sprites-nes-smb/", new Vector2(x,y), Color.Black);
		spriteBatch.End();
	}
}
