using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace sprint0.Factory
{
	public class EnemyFactory : SpriteFactory
	{
        private Texture2D SpriteSheet { get; set; }
        private Vector2 SpritePosition { get; set; }
        private string SpriteName { get; set; }
        private string SpriteDirection { get; set; }
        private int SpriteFrames { get; set; }
        private Boolean SpriteCollidable { get; set; }
        private IDictionary<int, Rectangle> TextureDictionary { get; set; }
        public EnemyFactory()
		{
		}

        //updates dictionary to attacking sprites in current direction
        //Copied from Link factory for now, not editing coordinates for now - will wait for level loader details
        public override void attack()
        {
            int[] rowIndex = new int[2];
            int[] columnIndex = new int[2];
            switch (SpriteDirection)
            {
                case "up":
                    //set texture dictionary to hold attacking up textures
                    rowIndex = new int[] { 3, 4 };
                    columnIndex = new int[] { 2, 2 };
                    TextureDictionary = MakeDictionary(SpriteSheet, 5, 4, rowIndex, columnIndex, 2);
                    break;
                case "right":
                    //set texture dictionary to hold attacking right textures
                    rowIndex = new int[] { 3, 4 };
                    columnIndex = new int[] { 3, 3 };
                    TextureDictionary = MakeDictionary(SpriteSheet, 5, 4, rowIndex, columnIndex, 2);
                    break;
                case "down":
                    //set texture dictionary to hold attacking down textures
                    rowIndex = new int[] { 3, 4 };
                    columnIndex = new int[] { 0, 0 };
                    TextureDictionary = MakeDictionary(SpriteSheet, 5, 4, rowIndex, columnIndex, 2);
                    break;
                case "left":
                    //set texture dictionary to hold attacking right textures
                    rowIndex = new int[] { 3, 4 };
                    columnIndex = new int[] { 1, 1 };
                    TextureDictionary = MakeDictionary(SpriteSheet, 5, 4, rowIndex, columnIndex, 2);
                    break;
                default:
                    //default just keeps current texture dictionary
                    break;
            }
        }
    }
}

