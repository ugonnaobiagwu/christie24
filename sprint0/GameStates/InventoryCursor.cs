using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static sprint0.HUDs.Inventory;
using static sprint0.Globals;

namespace sprint0.GameStates
{
	public class InventoryCursor
	{
		public Texture2D CursorTexture;
		public Vector2 CursorPosition;
		private const int MovementXOffset = 75;
        private const int MovementYOffset = 60;
        public ItemTypes[] SelectedItem;
		public ItemTypes[] SelectedItem2;
		public int CurrentSelected = 0;
		public int currentRow = 0;
		public InventoryCursor(Texture2D cursorTexture, int initialX, int initialY)
		{
			CursorTexture = cursorTexture;
			CursorPosition = new Vector2(initialX, initialY);
			//If the inventory ever gets bigger make a better system for item selection
			SelectedItem = new ItemTypes[4] {ItemTypes.BOOMERANG,ItemTypes.BOMB,ItemTypes.BOW,ItemTypes.BLAZE};
			SelectedItem2 = new ItemTypes[4] { ItemTypes.GREENTUNIC,ItemTypes.REDTUNIC, ItemTypes.BLUETUNIC, ItemTypes.SWORD}; //Green at the end as placeholder
		}

		public void moveLeft() {
			if (CurrentSelected > 0) {
                CursorPosition.X -= MovementXOffset;
				CurrentSelected -= 1;
            } 
			
		}
		public void moveRight() {
			if (CurrentSelected < 3) {
                CursorPosition.X += MovementXOffset;
				CurrentSelected += 1;
            }
			
		}
		public void moveUp() {
			if (currentRow <1)
			{
				currentRow++;
				CursorPosition.Y -= MovementYOffset;
			}
		}
		public void moveDown() {
			if (currentRow > 0)
			{
				currentRow--;
				CursorPosition.Y += MovementYOffset;
			}
		}
		public ItemTypes ReturnSelectedItem()
		{

			return SelectedItem[CurrentSelected]; 
			
		}
		public ItemTypes ReturnSelectedTunic()
		{
			return SelectedItem2[CurrentSelected];
		}
		public int GetMovementOffset() { return MovementXOffset; }
	}
}

