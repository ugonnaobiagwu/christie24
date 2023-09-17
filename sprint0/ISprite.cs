using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Numerics;

public interface ISprite
{
	/*All Sprites need to draw*/
	public void Draw(SpriteBatch spriteBatch, int x, int y);

	/*All Sprites need to update*/
	public void Update();

    /*Depending on the stateMachine's status, it will call a different ChangeDirection with polymorphism, all Sprites change direction in at least movement*/
    public void ChangeDirection(String directiontToFace);
}

	
