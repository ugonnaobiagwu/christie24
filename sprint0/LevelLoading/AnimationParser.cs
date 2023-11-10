using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using sprint0.AnimatedSpriteFactory;

namespace sprint0.LevelLoading
{
    public static class AnimationParser
    {
        public static SpriteFactory ParseAnimationSet(XmlNode AnimationSetNode, ContentManager content)
        {
            Texture2D textureSheet = content.Load<Texture2D>(AnimationSetNode.SelectSingleNode("Texture2D").InnerText);
            int rowCount = (int)float.Parse(AnimationSetNode.SelectSingleNode("RowCount").InnerText);
            int columnCount = (int)float.Parse(AnimationSetNode.SelectSingleNode("ColumnCount").InnerText);
            SpriteFactory spriteFactory = new SpriteFactory(textureSheet,rowCount,columnCount);
            XmlNodeList animationNodeList = AnimationSetNode.SelectNodes("Animation");
            foreach(XmlNode animationNode in animationNodeList)
            {
                ParseAnimation(animationNode, spriteFactory);
            }
            return spriteFactory;
        }
        private static void ParseAnimation(XmlNode animationNode, SpriteFactory spritefactory)
        {
            string animationName = animationNode.SelectSingleNode("AnimationName").InnerText;
            int frameCount = (int)float.Parse(animationNode.SelectSingleNode("FrameCount").InnerText);
            int[] RowArray = ParseIndex(animationNode.SelectSingleNode("Rows").SelectNodes("Row"), frameCount);
            int[] ColumnArray = ParseIndex(animationNode.SelectSingleNode("Columns").SelectNodes("Column"), frameCount);
            float widthScale = float.Parse(animationNode.SelectSingleNode("WidthScale").InnerText);
            float heightScale = float.Parse(animationNode.SelectSingleNode("HeightScale").InnerText);
            int secondsPerFrame = (int)float.Parse(animationNode.SelectSingleNode("SecondsPerFrame").InnerText);
            spritefactory.createAnimation(animationName, RowArray,ColumnArray,frameCount, secondsPerFrame, widthScale, heightScale);
        }
        private static int[] ParseIndex(XmlNodeList indexNodes, int frameCount)
        {
            int[] indexes = new int[frameCount];
            int arrayIndex = 0;
            foreach(XmlNode indexNode in indexNodes)
            {
                indexes[arrayIndex] = int.Parse(indexNode.InnerText);
                arrayIndex++;
            }
            return indexes;
        }
      
    }
}
