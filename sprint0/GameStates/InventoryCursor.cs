using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static sprint0.HUDs.Inventory;
namespace sprint0.GameStates
{
	public class InventoryCursor
	{
		public Texture2D CursorTexture;
		public Vector2 CursorPosition;
		private const int MovementOffset = 75;
		public ItemTypes[] SelectedItem;
		public int CurrentSelected = 0;
		public InventoryCursor(Texture2D cursorTexture, int initialX, int initialY)
		{
			CursorTexture = cursorTexture;
			CursorPosition = new Vector2(initialX, initialY);
			SelectedItem = new ItemTypes[4] {ItemTypes.BOOMERANG,ItemTypes.BOMB,ItemTypes.BOW,ItemTypes.BLAZE};
		}

		public void moveLeft() {
			if (CurrentSelected > 0) {
                CursorPosition.X -= MovementOffset;
				CurrentSelected -= 1;
            } 
			
		}
		public void moveRight() {
			if (CurrentSelected < 3) {
                CursorPosition.X += MovementOffset;
				CurrentSelected += 1;
            }
			
		}
		public void moveUp() { CursorPosition.Y -= MovementOffset; }
		public void moveDown() { CursorPosition.Y += MovementOffset; }
		public ItemTypes ReturnSelectedItem()
		{
			return SelectedItem[CurrentSelected];
		}
		public int GetMovementOffset() { return MovementOffset; }
	}
}

