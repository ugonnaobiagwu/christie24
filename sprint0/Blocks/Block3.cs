using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace sprint0.Blocks
{
    internal class Block3 : IBlock
    {

        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }




        public Block3()
        {

        }
        public Block3(Texture2D texture, int rows, int columns)
        {
            this.Texture = texture;
            Rows = rows;
            Columns = columns;

        }

        public void Draw(SpriteBatch spriteBatch, int x, int y)
        {

            int width = this.Texture.Width / Columns;
            int height = this.Texture.Height / Rows;
            int blockRow = 0;
            int blockColumn = 2;

            Rectangle sourceLocation = new Rectangle(width * blockRow, height * blockColumn, width, height);

            //resize block image
            double scale = 0.2; //40% of the orignal size image
            int scaledWidth = (int)(width * scale);
            int scaledHeight = (int)(height * scale);


            Rectangle destinationRectangle = new Rectangle(x, y, scaledWidth, scaledHeight);


            spriteBatch.Draw(this.Texture, destinationRectangle, sourceLocation, Color.White);

        }

        public void Update()
        {

        }

        public void Explode()
        {
            //explode logic

        }
        public void NextBlock() { }

        public void PreviousBlock() { }

    }
}