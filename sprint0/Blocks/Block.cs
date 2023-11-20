/*using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.AnimatedSpriteFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace sprint0.Blocks
{
    public class Block : IBlock
    {

        private List<IBlock> blockStates;
        private int currentIndex; // default is 0

        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int Xvalue { get; set; }
        private int Yvalue { get; set; }
        public int RoomId { get; set; }


        IBlock currentBlock;
        SpriteFactory blockSpriteFactory;


        //Methods Start here

        public Block(int x, int y, int roomId, SpriteFactory spriteFactory) {
        Xvalue = x;
        Yvalue = y;
        RoomId = roomId;
        blockSpriteFactory = spriteFactory;

            //default Block
            currentBlock = blockStates[currentIndex];
        }
        public Block(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;

            blockStates = new List<IBlock>
        {
            new DungeonBlueBlock(texture, rows, columns),
            new DungeonPyramidBlock(texture, rows, columns),
            new DungeonFishBlock(texture, rows, columns),
            new DungenDragonBlock(texture, rows, columns),
            new BlackBlock(texture, rows, columns),
            new StairBlock(texture, rows, columns),

        };
            currentBlock = blockStates[currentIndex]; // default block

        }

        //IBlock Methods

        public void Explode() {*//* nothing here *//*}

        *//*public void NextBlock()
        {


            currentIndex++;

            //loop back to the beginning once end of the List
            if (currentIndex >= blockStates.Count)
            {
                currentIndex = 0;
            }
            currentBlock = blockStates[currentIndex];
        }


        public void PreviousBlock()
        {

            currentIndex--;
            if (currentIndex < 0)
            {
                currentIndex = blockStates.Count - 1;
            }
            currentBlock = blockStates[currentIndex];
        }*//*

        //ISprite Methods
        public void Draw(SpriteBatch spriteBatch)
        {
            
            currentBlock.Draw(spriteBatch);

        }

        public void Update()
        {
            currentBlock.Update();
        }

        //Methods to return for IGameObject for Block
        //hard code for now (make new class for these?)
        public int xPosition() { return Xvalue; } // returns X pos of object
        public int yPosition() { return Yvalue; } // returns Y pos of object
        public int width() {  } // (i.e.) "how big are you?"
        public int height() {  } // (i.e.) "how big are you?"
        public bool isDynamic() { return false; } // does this object move? 
        public String type() { return "Block"; }







    }
}*/