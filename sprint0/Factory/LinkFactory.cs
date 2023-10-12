using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace sprint0.Factory
{
    public class LinkFactory : SpriteFactory
    {

        private Texture2D SpriteSheet { get; set; }
        private Vector2 SpritePosition { get; set; }
        private string SpriteName { get; set; }
        private string SpriteDirection { get; set; }
        private int SpriteFrames { get; set; }
        //Texture dictionary will have each animation frame indexed with ascending ints
        //Maybe make direction index consistant in dictionary, could implement all directions of draw in SpriteFactory instead of separatly
        //Tentative: up:0-9, right:10-19, down: 20-29, left: 30-39. It goes clockwise...
        //Actually not going to do that now, going to remake dictionary/assign relevant dictionary for whatever is being done,
        //ie attack method will assign a dictionary with attacking frames to the texture dictionary
        private IDictionary<int, Rectangle> TextureDictionary { get; set; }


        public LinkFactory()
        {
            //Need to make texture dictionary in the constructor

        }
        // public IDictionary<int, Rectangle> MakeDictionary(Texture2D newSpriteSheet, int spriteSheetRows, int spriteSheetColumns, int[] currentRow, int[] currentColumn, int frameCount)
        //updates dictionary to attacking sprites in current direction
        public override void attack()
        {
            int[] rowIndex = new int[2];
            int[] columnIndex = new int[2];
            switch (SpriteDirection)
            {
                case "up":
                    //set texture dictionary to hold attacking up textures
                    rowIndex = new int[]{3,4};
                    columnIndex = new int[]{2,2};
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

        //Updates dictionary with walking sprites in current direction
        void walk()
        {
            int[] rowIndex = new int[2];
            int[] columnIndex = new int[2];
            switch (SpriteDirection)
            {
                case "up":
                    //set texture dictionary to hold walking up textures
                    rowIndex = new int[] { 0, 1 };
                    columnIndex = new int[] { 2, 2 };
                    TextureDictionary = MakeDictionary(SpriteSheet, 5, 4, rowIndex, columnIndex, 2);
                    break;
                case "right":
                    //set texture dictionary to hold walking right textures
                    rowIndex = new int[] { 0, 1 };
                    columnIndex = new int[] { 3, 3 };
                    TextureDictionary = MakeDictionary(SpriteSheet, 5, 4, rowIndex, columnIndex, 2);
                    break;
                case "down":
                    //set texture dictionary to hold walking down textures
                    rowIndex = new int[] { 0, 1 };
                    columnIndex = new int[] { 0, 0 };
                    TextureDictionary = MakeDictionary(SpriteSheet, 5, 4, rowIndex, columnIndex, 2);
                    break;
                case "left":
                    //set texture dictionary to hold walking right textures
                    rowIndex = new int[] { 0, 1 };
                    columnIndex = new int[] { 1, 1 };
                    TextureDictionary = MakeDictionary(SpriteSheet, 5, 4, rowIndex, columnIndex, 2);
                    break;
                default:
                    //default just keeps current texture dictionary
                    break;
            }
        }
            //Updates texture dictionary to using item sprites in current direction
            void useItem()
            {
            int[] rowIndex = new int[2];
            int[] columnIndex = new int[2];
            switch (SpriteDirection)
                {
                    case "up":
                    //set texture dictionary to hold item up textures
                    rowIndex = new int[] { 2, 4 };
                    columnIndex = new int[] { 2, 2 };
                    TextureDictionary = MakeDictionary(SpriteSheet, 5, 4, rowIndex, columnIndex, 2);
                    break;
                    case "right":
                    //set texture dictionary to hold item right textures
                    rowIndex = new int[] { 2, 4 };
                    columnIndex = new int[] { 3,3};
                    TextureDictionary = MakeDictionary(SpriteSheet, 5, 4, rowIndex, columnIndex, 2);
                    break;
                    case "down":
                    //set texture dictionary to hold item down textures
                    rowIndex = new int[] { 2, 4 };
                    columnIndex = new int[] {0,0 };
                    TextureDictionary = MakeDictionary(SpriteSheet, 5, 4, rowIndex, columnIndex, 2);
                    break;
                    case "left":
                    //set texture dictionary to hold item right textures
                    rowIndex = new int[] { 2, 4 };
                    columnIndex = new int[] {1,1};
                    TextureDictionary = MakeDictionary(SpriteSheet, 5, 4, rowIndex, columnIndex, 2);
                    break;
                    default:
                        //default just keeps current texture dictionary
                        break;
                }

            }

            //Methods to change sprite details, going to have to call update if sprite changes tangibly
            public override void changeDirection(string newDirection)
            {
                SpriteDirection = newDirection;
            //May be able to change the direction change to be in sprite factory, have a Sprite type instance var, do stuff etc
            }

            void changePosition(Vector2 newPosition)
            {
                SpritePosition = newPosition;
            }

            //Methods to get sprite details
            String getDirection()
            {
                return SpriteDirection;
            }
            String getName()
            {
                return SpriteName;
            }
            Vector2 getPosition()
            {
                return SpritePosition;
            }
        
    }
}
