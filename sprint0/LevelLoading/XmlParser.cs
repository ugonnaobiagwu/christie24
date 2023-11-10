using sprint0.AnimatedSpriteFactory;
using sprint0.BoundariesDoorsAndRooms;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.Xna.Framework;

namespace sprint0.LevelLoading
{
    public static class XmlParser
    {
        public delegate void ParseDelegate(XmlNode node, int roomId, ContentManager content);
        static Dictionary<String,ParseDelegate> ParseInstructions = new Dictionary<String,ParseDelegate>();
        static ParseDelegate BlockParser = new ParseDelegate(ParseBlock);
        static ParseDelegate DoorParser = new ParseDelegate(ParseDoor);
        static ParseDelegate BoundaryParser = new ParseDelegate(ParseBoundary);
       //COMMENTED OUT WHILE Game1 is a parameter static ParseDelegate LinkParser = new ParseDelegate(ParseLink);
        public static void ParseFile(XmlDocument doc, ContentManager content, Sprint0 game)
        {
            PopulateParseInstructions();
            XmlNodeList roomList = doc.DocumentElement.SelectNodes("Room");
            foreach (XmlNode room in roomList)
            {
                ParseRoom(room, content, game);
            }
        }
        private static void PopulateParseInstructions()
        {
            ParseInstructions.Add("Block", BlockParser);
            ParseInstructions.Add("Door", DoorParser);
            ParseInstructions.Add("Boundary", BoundaryParser);
            //COMMENTED OUT WHILE Game1 is a parameter ParseInstructions.Add("Link", LinkParser);
        }
        private static void ParseRoom(XmlNode subtree, ContentManager content, Sprint0 game)
        {
            
            
            int roomId = Int32.Parse(subtree.Attributes["id"].Value);
            
            int x = ParseXCoordinate(subtree);
            int y = ParseYCoordinate(subtree);
            SpriteFactory roomFactory = AnimationParser.ParseAnimationSet(subtree.SelectSingleNode("AnimationSet"), content) ;
            LevelLoader.CreateRoom(x, y, roomId, roomFactory);
            XmlNode RoomContentNodes = subtree.SelectSingleNode("Content");
            ParseRoomContents(RoomContentNodes, roomId, content, game);
        }
        /*NOTE:
         *Because Link is instantiated in Game1.cs and is needed by the keyboard, we hve to pass the Game1 object through to instantiate him
         *There is almost certainly a better way to do this as to decouple
         */
        private static void ParseRoomContents(XmlNode roomContentsNode, int roomId, ContentManager content,Sprint0 game)
        {
            foreach(XmlNode objectNode in roomContentsNode)
            {
                if (objectNode.Name != "Link")
                {
                    ParseDelegate parser = ParseInstructions[objectNode.Name];
                    parser(objectNode, roomId, content);
                }
                else
                {
                    ParseLink(objectNode, roomId, content, game);
                }
            }
        }
        private static void ParseDoor(XmlNode doorNode, int roomId, ContentManager content)
        {
            int x = ParseXCoordinate(doorNode);
            int y = ParseYCoordinate(doorNode);
            int ToRoomId = (int)float.Parse(doorNode.SelectSingleNode("ToRoomId").InnerText);
            Globals.Direction sideOfRoom = (Globals.Direction)float.Parse(doorNode.SelectSingleNode("SideOfRoom").InnerText);
            SpriteFactory doorFactory = AnimationParser.ParseAnimationSet(doorNode.SelectSingleNode("AnimationSet"), content);
            LevelLoader.CreateDoor(x, y, roomId, ToRoomId, sideOfRoom, doorFactory);
        }
        private static void ParseBlock(XmlNode subtree, int roomId, ContentManager content)
        {
            int x = ParseXCoordinate(subtree);
            int y = ParseYCoordinate(subtree);
            string blockType = subtree.SelectSingleNode("BlockType").InnerText;
            SpriteFactory blockFactory = AnimationParser.ParseAnimationSet(subtree.SelectSingleNode("AnimationSet"), content);
            LevelLoader.CreateBlock(x, y, roomId,blockType, blockFactory);
        }
        //NOTE: Boundaries cannot be tested without collision since they are not drawable objects, however these should be close
        private static void ParseBoundary(XmlNode boundaryNode, int roomId, ContentManager content)
        {
            int x = ParseXCoordinate(boundaryNode);
            int y = ParseYCoordinate(boundaryNode);
            int width = (int)float.Parse(boundaryNode.SelectSingleNode("Width").InnerText);
            int height = (int)float.Parse(boundaryNode.SelectSingleNode("Height").InnerText);
            Rectangle boundaryBox = new Rectangle(x, y, width, height);
            LevelLoader.CreateBoundary(boundaryBox, roomId);
        }
        private static void ParseLink(XmlNode linkNode, int roomId, ContentManager content, Sprint0 game)
        {
            Console.WriteLine("I got here");
            /*Gets the x and y location*/
            int x = ParseXCoordinate(linkNode);
            int y = ParseYCoordinate(linkNode);
            int width = 50;
            int height = 50;
            /*Parses Animation*/
            SpriteFactory LinkFactory = AnimationParser.ParseAnimationSet(linkNode.SelectSingleNode("AnimationSet"), content);
            /*Makes object*/
            LevelLoader.CreateLink(x, y, roomId, LinkFactory, game);
        }
        private static int ParseXCoordinate(XmlNode subtree)
        {
            return (int)float.Parse(subtree.SelectSingleNode("x").InnerText);
        }
        private static int ParseYCoordinate(XmlNode subtree)
        {
            return (int)float.Parse(subtree.SelectSingleNode("y").InnerText);
        }
   
    }
}
