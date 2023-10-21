using Microsoft.Xna.Framework.Graphics;
using sprint0.AnimatedSpriteFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace sprint0.Level_Loader___Parsers
{
    internal static class AnimationParser
    {
        public static SpriteFactory ParseAnimations(XmlNode AnimationNode, Microsoft.Xna.Framework.Content.ContentManager Content)
        {

            
            /*Gets the texture for the factory*/
            XmlNode AnimationSetNode = AnimationNode.SelectSingleNode("AnimationSet");
            XmlNode Texture2DNode = AnimationSetNode.SelectSingleNode("Texture2D");
            Texture2D TextureSheet = Content.Load<Texture2D>(Texture2DNode.InnerText);
            /*Gets the row and column count*/
            int RowCount = (int)float.Parse(AnimationSetNode.SelectSingleNode("RowCount").InnerText);
            int ColumnCount = (int)float.Parse(AnimationSetNode.SelectSingleNode("ColumnCount").InnerText);
            /*Creates sprite factory*/
            SpriteFactory SpriteFactory = new SpriteFactory(TextureSheet, RowCount, ColumnCount);
            /*Loads sprite factory with animations*/
            XmlNodeList Animations = AnimationSetNode.SelectNodes("Animation");
            foreach(XmlNode node in Animations)
            {
                ParseAnimation(node, SpriteFactory);
            }
            return SpriteFactory;
        }
        private static void ParseAnimation(XmlNode AnimationNode, SpriteFactory spriteFactory)
        {
            string AnimationName = AnimationNode.SelectSingleNode("AnimationName").InnerText;
            int FrameCount = (int)float.Parse(AnimationNode.SelectSingleNode("FrameCount").InnerText);
            int[] RowArray = ParseIndex(AnimationNode.SelectNodes("Row"), FrameCount);
            int[] ColumnArray = ParseIndex(AnimationNode.SelectNodes("Column"), FrameCount);
            spriteFactory.createAnimation(AnimationName, RowArray, ColumnArray, FrameCount);
        }
        private static int[] ParseIndex(XmlNodeList AnimationNode, int frameCount)
        {
            int[] Indexes = new int[frameCount];
            int ArrayIndex = 0;
            foreach(XmlNode node in AnimationNode)
            {
                Indexes[ArrayIndex] = (int) float.Parse(node.InnerText);
            }
            return Indexes;
        }
        
    }
    //
}
