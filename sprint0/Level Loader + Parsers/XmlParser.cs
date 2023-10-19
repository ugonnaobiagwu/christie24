using Microsoft.Xna.Framework;
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
        public delegate void ParseDelegate(XmlNode node, int RoomID);
        static Dictionary<String, ParseDelegate> ParseInstructions = new Dictionary<string, ParseDelegate>();
        static ParseDelegate LinkParser = new ParseDelegate(ParseLink);
        static ParseDelegate EnemyParser = new ParseDelegate(ParseEnemy);
        static ParseDelegate BlockParser = new ParseDelegate(ParseBlock);
        static ParseDelegate BoundaryParser = new ParseDelegate(ParseBoundary);
        static ParseDelegate DoorParser = new ParseDelegate(ParseDoor);

        /*This is the method called in main.
         An XML Document must be made there and parsed into an XmlNodeList with */
        public static void ParseFile(XmlDocument doc)
        {
            PopulateParseInstructions();
            /*Gets a list of each room and iterates through each*/
            XmlNodeList NodeList = doc.DocumentElement.SelectNodes("Room");
            foreach (XmlNode node in doc)
            {
                ParseRoom(node);
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
        private static void ParseRoom(XmlNode subtree)
        {
           
            /*Starts by getting the attribute, tests that it isn't null, and stores it to a variable if it isn't*/
            var RoomIDAttribute = subtree.Attributes["id"];
            string RoomIDStr = RoomIDAttribute.Value;
            int RoomID = Int32.Parse(RoomIDStr);

            /*NOTE: This may cause issues depending on how selectnodes() interprets ""*/
            XmlNodeList RoomNodes = subtree.SelectNodes("");
            
            foreach(XmlNode node in RoomNodes)
            {
                ParseDelegate parser = ParseInstructions[node.Name];
                parser(node, RoomID);
            } 

        }

        private static void ParseLink(XmlNode subtree, int roomId)
        {
            /*Gets the x and y location*/
            XmlNode XNode = subtree.SelectSingleNode("x");
            XmlNode YNode = subtree.SelectSingleNode("y");
            int x = (int)float.Parse(XNode.InnerText);
            int y = (int)float.Parse(YNode.InnerText);
            /*Makes object*/
            LevelLoader.CreateLink(x, y, roomId);

        }
        private static void ParseBlock(XmlNode subtree, int roomId)
        {
            /*Gets the x and y location*/
            XmlNode XNode = subtree.SelectSingleNode("x");
            XmlNode YNode = subtree.SelectSingleNode("y");
            int x = (int)float.Parse(XNode.InnerText);
            int y = (int)float.Parse(YNode.InnerText);
            /*Gets Block Type*/
            string BlockType = subtree.SelectSingleNode("BlockType").InnerText;
            /*Makes object*/
            LevelLoader.CreateBlock(x, y, roomId, BlockType);

        }
        private static void ParseEnemy(XmlNode subtree, int roomId)
        {
            /*Gets the x and y location*/
            XmlNode XNode = subtree.SelectSingleNode("x");
            XmlNode YNode = subtree.SelectSingleNode("y");
            int x = (int)float.Parse(XNode.InnerText);
            int y = (int)float.Parse(YNode.InnerText);
            /*Gets Enemy Type*/
            string EnemyType = subtree.SelectSingleNode("EnemyType").InnerText;
            /*Makes object*/
            LevelLoader.CreateBlock(x, y, roomId, EnemyType);
        }
        private static void ParseBoundary(XmlNode subtree, int roomId)
        {
            /*Gets the x and y location*/
            XmlNode XNode = subtree.SelectSingleNode("x");
            XmlNode YNode = subtree.SelectSingleNode("y");
            int x = (int)float.Parse(XNode.InnerText);
            int y = (int)float.Parse(YNode.InnerText);
            /*Gets width and height of rectangle*/
            XmlNode WidthNode = subtree.SelectSingleNode("BoundaryWidth");
            int Width =(int) float.Parse(WidthNode.InnerText);
            XmlNode HeightNode = subtree.SelectSingleNode("BoundaryHeight");
            int Height= (int) float.Parse(HeightNode.InnerText);
            /*Makes object*/
            LevelLoader.CreateBoundary(x, y, roomId, Width, Height);
        }
        private static void ParseDoor(XmlNode subtree, int roomId)
        {
            /*Gets the x and y location*/
            XmlNode XNode = subtree.SelectSingleNode("x");
            XmlNode YNode = subtree.SelectSingleNode("y");
            int x = (int)float.Parse(XNode.InnerText);
            int y = (int)float.Parse(YNode.InnerText);
            /*Gets width and height of rectangle*/
            XmlNode WidthNode = subtree.SelectSingleNode("DoorWidth");
            int Width = (int)float.Parse(WidthNode.InnerText);
            XmlNode HeightNode = subtree.SelectSingleNode("DoorHeight");
            int Height = (int)float.Parse(HeightNode.InnerText);
            XmlNode ToWhereNode = subtree.SelectSingleNode("ToWhichRoom");
            int ToWhere = (int)float.Parse(ToWhereNode.InnerText);
            LevelLoader.CreateDoor(x, y, roomId, Width, Height, ToWhere);
        }
    }
}