using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Data;


public class FixedSingleSprite: ISprite
{
	public Texture2D Texture { get; set; }
	public int Rows { get; set; } 
	public int Columns { get; set; }
	public FixedSingleSprite(Texture2D texture, int rows, int columns)
	{
		Texture = texture;
		Rows = rows;
		Columns = columns;
	}
	
	/*POTENTIAL BAD CODE:  This is needed in the main function's update loop because Luigi's animated sprites need updating.  Thus, ISprite needs an Update() for it to be callable*/
	public void Update()
	{
		
	}
    public void Draw(SpriteBatch spriteBatch, int x, int y)
	{
		/*Figures out where the sprite we want is*/
		int width = Texture.Width / Columns; 
		int height = Texture.Height / Rows;
		int xLoc = 1;
		int yLoc = 0;

        Rectangle sheetLocation = new Rectangle(width*xLoc, height*yLoc ,width, height);
		Rectangle destinationRectangle = new Rectangle(x, y, width, height);

		/*POTENTIAL BAD CODE: Dr. Kirby mentioned that Begin() and End() before and after each draw is sketchy*/
        spriteBatch.Begin();
        spriteBatch.Draw(Texture, destinationRectangle, sheetLocation, Color.White);
		spriteBatch.End();
	}
}

