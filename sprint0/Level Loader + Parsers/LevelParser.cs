using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using sprint0.AnimatedSpriteFactory;
using sprint0.Level_Loader___Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace sprint0.Level_Loading___Parsers
{
    internal static class XmlParser
    {
        public delegate void ParseDelegate(XmlNode node, int RoomID, ContentManager Content);
        static Dictionary<String, ParseDelegate> ParseInstructions = new Dictionary<string, ParseDelegate>();
        static ParseDelegate LinkParser = new ParseDelegate(ParseLink);
        static ParseDelegate EnemyParser = new ParseDelegate(ParseEnemy);
        static ParseDelegate BlockParser = new ParseDelegate(ParseBlock);
        static ParseDelegate BoundaryParser = new ParseDelegate(ParseBoundary);
        static ParseDelegate DoorParser = new ParseDelegate(ParseDoor);

        /*This is the method called in main.
         An XML Document must be made there and parsed into an XmlNodeList with */
        public static void ParseFile(XmlDocument doc, ContentManager Content)
        {
            PopulateParseInstructions();
            /*Gets a list of each room and iterates through each*/
            XmlNodeList NodeList = doc.DocumentElement.SelectNodes("Room");
            foreach (XmlNode node in NodeList)
            {
                ParseRoom(node,Content);
            }

        }
        public static void PopulateParseInstructions()
        {
            ParseInstructions.Add("Link", LinkParser);
            ParseInstructions.Add("Enemy", EnemyParser);
            ParseInstructions.Add("Block", BlockParser);
            ParseInstructions.Add("Boundary", BoundaryParser);
            ParseInstructions.Add("Door", DoorParser);

        }
        /*Parses every item in the room*/
        private static void ParseRoom(XmlNode subtree, ContentManager Content)
        {
           

            /*Starts by getting the attribute, tests that it isn't null, and stores it to a variable if it isn't*/
            var RoomIDAttribute = subtree.Attributes["id"];
            string RoomIDStr = RoomIDAttribute.Value;
            int RoomID = Int32.Parse(RoomIDStr);
            /*NOTE: NEED TO ADD A <RoomTexture> parser, currently not sure where rooms will be saved and drawn.*/
            /*NOTE: This may cause issues depending on how selectnodes() interprets ""*/
            XmlNodeList RoomNodes = subtree.SelectNodes("");
            
            foreach(XmlNode node in RoomNodes)
            {
                ParseDelegate parser = ParseInstructions[node.Name];
                parser(node, RoomID, Content);
            } 

        }

        private static void ParseLink(XmlNode subtree, int roomId, ContentManager Content)
        {
            /*Gets the x and y location*/
            int x = ParseXCoordinate(subtree);
            int y = ParseYCoordinate(subtree);
            /*Parses Animation*/
            SpriteFactory LinkFactory = AnimationParser.ParseAnimations(subtree, Content);
            /*Makes object*/
            LevelLoader.CreateLink(x, y, roomId,LinkFactory);

        }
        private static void ParseBlock(XmlNode subtree, int roomId, ContentManager Content)
        {
            /*Gets the x and y location*/
            int x = ParseXCoordinate(subtree);
            int y = ParseYCoordinate(subtree);
            /*Gets Block Type*/
            string BlockType = subtree.SelectSingleNode("BlockType").InnerText;
            /*Parses animation*/
            SpriteFactory BlockFactory = AnimationParser.ParseAnimations(subtree, Content);
            /*Makes object*/
          /*  LevelLoader.CreateBlock(x, y, roomId, BlockType, BlockFactory);*/

        }
        private static void ParseEnemy(XmlNode subtree, int roomId, ContentManager Content)
        {
            /*Gets the x and y location*/
            int x = ParseXCoordinate(subtree);
            int y = ParseYCoordinate(subtree);
            /*Gets Enemy Type*/
            string EnemyType = subtree.SelectSingleNode("EnemyType").InnerText;
            /*Parses Animation*/
            SpriteFactory EnemyFactory = AnimationParser.ParseAnimations(subtree, Content);
            /*Makes object*/
           /* LevelLoader.CreateEnemy(x, y, roomId, EnemyType, EnemyFactory);*/
        }
        private static void ParseBoundary(XmlNode subtree, int roomId, ContentManager Content)
        {
            /*Gets the x and y location*/
            int x = ParseXCoordinate(subtree);
            int y = ParseYCoordinate(subtree);
            /*Gets width and height of rectangle*/
            int Width = ParseWidth(subtree);
            int Height= ParseWidth(subtree);
            /*Parses Animation*/
            SpriteFactory BoundaryFactory = AnimationParser.ParseAnimations(subtree, Content);
            /*Makes object*/
            LevelLoader.CreateBoundary(x, y, roomId, Width, Height, BoundaryFactory);
        }
        private static void ParseDoor(XmlNode subtree, int roomId, ContentManager Content)
        {
            /*Gets the x and y location*/
            int x = ParseXCoordinate(subtree);
            int y = ParseYCoordinate(subtree);
            /*Gets width and height of rectangle*/
            int Width = ParseWidth(subtree);
            int Height = ParseHeight(subtree);
            /*Gets the room the door leads to*/
            int ToWhere = ParseToWhere(subtree);
            /*Parses Animation*/
            SpriteFactory DoorFactory = AnimationParser.ParseAnimations(subtree, Content);
            LevelLoader.CreateDoor(x, y, roomId, Width, Height, ToWhere, DoorFactory);
        }
        private static int ParseXCoordinate(XmlNode subtree)
        {
            XmlNode XNode = subtree.SelectSingleNode("x");
            return (int)float.Parse(XNode.InnerText);
        }
        private static int ParseYCoordinate(XmlNode subtree)
        {
            XmlNode YNode = subtree.SelectSingleNode("y");
            return (int)float.Parse(YNode.InnerText);
        }
        private static int ParseWidth(XmlNode subtree)
        {
            XmlNode WidthNode = subtree.SelectSingleNode("Width");
            return (int)float.Parse(WidthNode.InnerText);
        }
        private static int ParseHeight(XmlNode subtree)
        {
            XmlNode HeightNode = subtree.SelectSingleNode("Height");
            return (int)float.Parse(HeightNode.InnerText);
        }
        private static int ParseToWhere(XmlNode subtree)
        {
            XmlNode ToWhereNode = subtree.SelectSingleNode("ToWhichRoom");
            return (int)float.Parse(ToWhereNode.InnerText);
        }
    }
    //
}