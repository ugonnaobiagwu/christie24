using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

/*POTENTIAL BAD CODE: A lot of these functions should probably get squished into function calls*/
internal class FacingLeftLinkState : ISprite
    {
        
        Texture2D Texture;
        int Rows, Cols;
        int CurrentFrame = 0;
        int TotalFrames = 2;
        public FacingLeftLinkState(Texture2D texture, int rows, int cols) 
        {
            Texture = texture;
            Rows = rows;
            Cols = cols;
           
        }
        public void Update()
        {
           
            CurrentFrame++;
            if(CurrentFrame == TotalFrames)
                CurrentFrame = 0;
        }
        public void Draw(SpriteBatch spriteBatch, int x, int y)
        { 
            int width = Texture.Width / Cols;
            int height = Texture.Height / Rows;
            int row = CurrentFrame;
            int column = 1; 
        
            Rectangle SourceRec = new Rectangle(width * column, height * row, width, height);
            Rectangle DestinationRec = new Rectangle(x,y, width,height);

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, DestinationRec, SourceRec, Color.White);
            spriteBatch.End();
        }
    }

internal class FacingRightLinkState : ISprite
{
    Texture2D Texture;
    int Rows, Cols;
    int CurrentFrame = 0;
    int TotalFrames = 2;
    public FacingRightLinkState(Texture2D texture, int rows, int cols)
    {
        Texture = texture;
        Rows = rows;
        Cols = cols;

    }
    public void Update()
    {
        CurrentFrame++;
        if (CurrentFrame == TotalFrames)
            CurrentFrame = 0;
    }
    public void Draw(SpriteBatch spriteBatch, int x, int y)
    {
        int width = Texture.Width / Cols;
        int height = Texture.Height / Rows;
        int row = CurrentFrame;
        int column = 3;

        Rectangle SourceRec = new Rectangle(width * column, height * row, width, height);
        Rectangle DestinationRec = new Rectangle(x, y, width, height);

        spriteBatch.Begin();
        spriteBatch.Draw(Texture, DestinationRec, SourceRec, Color.White);
        spriteBatch.End();
    }
}
internal class FacingUpLinkState : ISprite
{
    Texture2D Texture;
    int Rows, Cols;
    int CurrentFrame = 0;
    int TotalFrames = 2;
    public FacingUpLinkState(Texture2D texture, int rows, int cols)
    {
        Texture = texture;
        Rows = rows;
        Cols = cols;

    }
    public void Update()
    {
        CurrentFrame++;
        if (CurrentFrame == TotalFrames)
            CurrentFrame = 0;
    }
    public void Draw(SpriteBatch spriteBatch, int x, int y)
    {
        int width = Texture.Width / Cols;
        int height = Texture.Height / Rows;
        int row = CurrentFrame;
        int column = 2;

        Rectangle SourceRec = new Rectangle(width * column, height * row, width, height);
        Rectangle DestinationRec = new Rectangle(x, y, width, height);

        spriteBatch.Begin();
        spriteBatch.Draw(Texture, DestinationRec, SourceRec, Color.White);
        spriteBatch.End();
    }
}
internal class FacingDownLinkState : ISprite
{
    Texture2D Texture;
    int Rows, Cols;
    int CurrentFrame = 0;
    int TotalFrames = 2;
    public FacingDownLinkState(Texture2D texture, int rows, int cols)
    {
        Texture = texture;
        Rows = rows;
        Cols = cols;

    }
    public void Update()
    {
        CurrentFrame++;
        if (CurrentFrame == TotalFrames)
            CurrentFrame = 0;
    }
    public void Draw(SpriteBatch spriteBatch, int x, int y)
    {
        int width = Texture.Width / Cols;
        int height = Texture.Height / Rows;
        int row = CurrentFrame;
        int column = 0;

        Rectangle SourceRec = new Rectangle(width * column, height * row, width, height);
        Rectangle DestinationRec = new Rectangle(x, y, width, height);

        spriteBatch.Begin();
        spriteBatch.Draw(Texture, DestinationRec, SourceRec, Color.White);
        spriteBatch.End();
    }
}

internal class AttackLeftLinkState : ISprite
{
    Texture2D Texture;
    int Rows, Cols;
    int CurrentFrame = 0;
    int TotalFrames = 2;
    public AttackLeftLinkState(Texture2D texture, int rows, int cols)
    {
        Texture = texture;
        Rows = rows;
        Cols = cols;

    }
    public void Update()
    {
        CurrentFrame++;
        if (CurrentFrame == TotalFrames)
            CurrentFrame = 0;
    }
    public void Draw(SpriteBatch spriteBatch, int x, int y)
    {
        int width = Texture.Width / Cols;
        int height = Texture.Height / Rows;
        int row = 2 + CurrentFrame;
        int column = 1;

        Rectangle SourceRec = new Rectangle(width * column, height * row, width, height);
        Rectangle DestinationRec = new Rectangle(x, y, width, height);

        spriteBatch.Begin();
        spriteBatch.Draw(Texture, DestinationRec, SourceRec, Color.White);
        spriteBatch.End();
    }
}
internal class AttackRightLinkState : ISprite
{
    Texture2D Texture;
    int Rows, Cols;
    int CurrentFrame = 0;
    int TotalFrames = 2;
    public AttackRightLinkState(Texture2D texture, int rows, int cols)
    {
        Texture = texture;
        Rows = rows;
        Cols = cols;

    }
    public void Update()
    {
        CurrentFrame++;
        if (CurrentFrame == TotalFrames)
            CurrentFrame = 0;
    }
    public void Draw(SpriteBatch spriteBatch, int x, int y)
    {
        int width = Texture.Width / Cols;
        int height = Texture.Height / Rows;
        int row = 2 + CurrentFrame;
        int column = 3;

        Rectangle SourceRec = new Rectangle(width * column, height * row, width, height);
        Rectangle DestinationRec = new Rectangle(x, y, width, height);

        spriteBatch.Begin();
        spriteBatch.Draw(Texture, DestinationRec, SourceRec, Color.White);
        spriteBatch.End();
    }
}
internal class AttackUpLinkState : ISprite
{
    Texture2D Texture;
    int Rows, Cols;
    int CurrentFrame = 0;
    int TotalFrames = 2;
    public AttackUpLinkState(Texture2D texture, int rows, int cols)
    {
        Texture = texture;
        Rows = rows;
        Cols = cols;

    }
    public void Update()
    {
        CurrentFrame++;
        if (CurrentFrame == TotalFrames)
            CurrentFrame = 0;
    }
    public void Draw(SpriteBatch spriteBatch, int x, int y)
    {
        int width = Texture.Width / Cols;
        int height = Texture.Height / Rows;
        int row = 2 + CurrentFrame;
        int column = 2;

        Rectangle SourceRec = new Rectangle(width * column, height * row, width, height);
        Rectangle DestinationRec = new Rectangle(x, y, width, height);

        spriteBatch.Begin();
        spriteBatch.Draw(Texture, DestinationRec, SourceRec, Color.White);
        spriteBatch.End();
    }
}
internal class AttackDownLinkState : ISprite
{
    Texture2D Texture;
    int Rows, Cols;
    int CurrentFrame = 0;
    int TotalFrames = 2;
    public AttackDownLinkState(Texture2D texture, int rows, int cols)
    {
        Texture = texture;
        Rows = rows;
        Cols = cols;

    }
    public void Update()
    {
        CurrentFrame++;
        if (CurrentFrame == TotalFrames)
            CurrentFrame = 0;
    }
    public void Draw(SpriteBatch spriteBatch, int x, int y)
    {
        int width = Texture.Width / Cols;
        int height = Texture.Height / Rows;
        int row = 2 + CurrentFrame;
        int column = 0;

        Rectangle SourceRec = new Rectangle(width * column, height * row, width, height);
        Rectangle DestinationRec = new Rectangle(x, y, width, height);

        spriteBatch.Begin();
        spriteBatch.Draw(Texture, DestinationRec, SourceRec, Color.White);
        spriteBatch.End();
    }
}