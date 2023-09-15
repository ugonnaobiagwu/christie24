using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

public class FixedAnimatedSprite : ISprite
{
    public Texture2D Texture { get; set; }
    public int Rows { get; set; }
    public int Columns { get; set; }
    private int CurrentFrame;
    private int TotalFrames;

   
    public FixedAnimatedSprite(Texture2D texture, int rows, int columns)
	{
        Texture = texture;
        Rows = rows;
        Columns = columns;
        CurrentFrame = 0;
        TotalFrames = 3;
	}

    public void Update()
    {
        
        CurrentFrame++;
        if (CurrentFrame == TotalFrames) 
            CurrentFrame = 0;
        
    }
    public void Draw(SpriteBatch spriteBatch, int x, int y)
    {
        
        int width = Texture.Width / Columns;
        int height = Texture.Height / Rows;
        int row = CurrentFrame / Columns;
        //Must add 3 in order to get the correct sprite index
        int column = (CurrentFrame % Columns) + 3;

        Rectangle sheetLocation = new Rectangle(width * column, height * row, width, height);
        Rectangle destinationRectangle = new Rectangle(x, y, width, height);

        spriteBatch.Begin();
        spriteBatch.Draw(Texture, destinationRectangle, sheetLocation, Color.White);
        spriteBatch.End() ; 
    }
}
