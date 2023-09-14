using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Data.Common;

public class UpAndDownSprite: ISprite
{
	Texture2D Texture;
	int Rows;
	int Columns;

	int SpriteHeight = 0;
	int SpriteMaxHeight = 10;
	int SpriteMinHeight = -10;
	Boolean GoingUp = true;
	public UpAndDownSprite(Texture2D texture, int rows, int columns)
	{
		Texture = texture;
		Rows = rows;
		Columns = columns;
	}
	public void Update()
	{
	
		if (GoingUp)
			SpriteHeight++;
		else
			SpriteHeight--;

		if (SpriteHeight == SpriteMaxHeight)
		{
			GoingUp = false;
		}else if(SpriteHeight == SpriteMinHeight)
		{
			GoingUp = true;
			
		}
	}

	public void Draw(SpriteBatch spriteBatch, int x, int y)
	{
		int width = Texture.Width / Columns;
		int height = Texture.Height / Rows;
		
		//POTENTIAL BAD CODE: Hard Coded Numbers
        Rectangle sheetLocation = new Rectangle(0,1, width, height);
        Rectangle destinationRectangle = new Rectangle(x, y + SpriteHeight, width, height);

		spriteBatch.Begin();
		spriteBatch.Draw(Texture, destinationRectangle, sheetLocation, Color.White);
		spriteBatch.End();
    }
}
