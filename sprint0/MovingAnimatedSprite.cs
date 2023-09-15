using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

public class MovingAnimatedSprite: ISprite
{
	//POTENTIAL BAD PROGRAMING: Hardcoded numbers
	//Instantiating
	Texture2D Texture;
	int Rows;
	int Columns;
	//Animation Variables
	int CurrentFrame = 0;
	int TotalFrames = 3;
	//Moving
	int SpriteX = 0;
	int SpriteMaxX = 400;
	int SpriteMinX = -400;
	Boolean FacingLeft = true;

	public MovingAnimatedSprite(Texture2D texture, int rows, int columns)
	{
		Texture = texture;
		Rows = rows;
		Columns = columns;
		
	}

	public void Update()
	{
		CurrentFrame++;
		if(CurrentFrame == TotalFrames)
			CurrentFrame = 0;

		if (FacingLeft)
		{
			SpriteX++;
		}
		else
		{
			SpriteX--;
		}

		if(SpriteX == SpriteMaxX)
		{
			FacingLeft = false;
		}else if(SpriteX == SpriteMinX)
		{
			FacingLeft = true;
		}
	}

	public void Draw(SpriteBatch spriteBatch, int x, int y)
	{
        int width = Texture.Width / Columns;
        int height = Texture.Height / Rows;
        
        int row = CurrentFrame / Columns;
		//Must add 3 in order to get the correct sprite index
		int column;
		Rectangle sheetLocation = new Rectangle();
		Rectangle destinationRectangle = new Rectangle();
		//POTENTIAL BAD CODE: This if-else should likely be exported to a function, also the cases should be swapped for neatness
        if (!FacingLeft) {
			column = (CurrentFrame % Columns) + 3;

			sheetLocation = new Rectangle(width * column, height * row, width, height);
			destinationRectangle = new Rectangle(x + SpriteX, y, width, height);
		}
		else
		{
            column = (CurrentFrame % Columns) + 7;
			//POTENTIAL BAD CODE: Adding 10 to adjust errors on the sprite sheet
            sheetLocation = new Rectangle(width * column + 10, height * row, width, height);
            destinationRectangle = new Rectangle(x + SpriteX, y, width, height);
        }
        spriteBatch.Begin();
        spriteBatch.Draw(Texture, destinationRectangle, sheetLocation, Color.White);
        spriteBatch.End();
    }

}
