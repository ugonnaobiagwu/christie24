using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace sprint0.GameStates
{
	public class InventoryCursor
	{
		public Texture2D CursorTexture;
		public Vector2 CursorPosition;
		private const int MovementOffset = 15;
		public InventoryCursor(Texture2D cursorTexture, int initialX, int initialY)
		{
			CursorTexture = cursorTexture;
			CursorPosition = new Vector2(initialX, initialY);
		}

		public void moveLeft() {CursorPosition.X-=MovementOffset;}
		public void moveRight() { CursorPosition.X += MovementOffset; }
		public void moveUp() { CursorPosition.Y -= MovementOffset; }
		public void moveDown() { CursorPosition.Y += MovementOffset;
			Console.WriteLine(CursorPosition.X);
            Console.WriteLine(CursorPosition.Y);
        }
	}
}

