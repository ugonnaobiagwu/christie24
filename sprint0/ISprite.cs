using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Numerics;

public interface ISprite
{
	public void Draw(SpriteBatch spriteBatch, int x, int y);
	public void Update();
	public int GetWidth();
	public int GetHeight();
	public int GetTotalFrames();
	public int GetCurrentFrame();
	public void Draw(SpriteBatch spriteBatch, int x, int y, float rotation);



}

	
