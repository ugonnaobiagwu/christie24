using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using sprint0.AnimatedSpriteFactory;
using sprint0.BoundariesDoorsAndRooms;
using sprint0.LevelLoading;
using sprint0;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
namespace sprint0.LevelLoading
{
    public static class XmlParser
    {
        public delegate void ContentParseDelegate(XmlNode node, int roomId, ContentManager content);
        static Dictionary<String, ContentParseDelegate> ContentParseInstructions = new Dictionary<String, ContentParseDelegate>();
        static ContentParseDelegate BlockParser = new ContentParseDelegate(ParseBlock);
        static ContentParseDelegate DoorParser = new ContentParseDelegate(ParseDoor);
        static ContentParseDelegate BoundaryParser = new ContentParseDelegate(ParseBoundary);
        static ContentParseDelegate EnemyParser = new ContentParseDelegate(ParseEnemy);
        static ContentParseDelegate FloorParser = new ContentParseDelegate(ParseFloor);
        static ContentParseDelegate GroundItemParser = new ContentParseDelegate(ParseGroundItem);
        static ContentParseDelegate NPCParser = new ContentParseDelegate(ParseNPC);
        //BAD CODE: this should be able to be condensed somehow, its the same thing but it leads to different sets of switch cases
        public delegate void ItemsTwoFactoryDelegate(XmlNode itemNode, int roomId, ContentManager content);
        public delegate void ItemsOneFactoryDelegate(XmlNode itemNode, int roomId, ContentManager content);
        //COMMENTED OUT WHILE Game1 is a parameter static ParseDelegate LinkParser = new ParseDelegate(ParseLink);
        public static void ParseFile(XmlDocument doc, ContentManager content)
        {
            if (ContentParseInstructions.Count == 0)
            {
                PopulateParseInstructions();
            }
            ParseLink(doc.DocumentElement.SelectSingleNode("Link"), content);
            ParseItems(doc.DocumentElement.SelectSingleNode("Items"), content);
            XmlNodeList roomList = doc.DocumentElement.SelectNodes("Room");
            foreach (XmlNode room in roomList)
            {
                ParseRoom(room, content);
            }
        }
        private static void PopulateParseInstructions()
        {
            ContentParseInstructions.Add("Block", BlockParser);
            ContentParseInstructions.Add("Door", DoorParser);
            ContentParseInstructions.Add("Boundary", BoundaryParser);
            ContentParseInstructions.Add("Enemy", EnemyParser);
            ContentParseInstructions.Add("Floor", FloorParser);
            ContentParseInstructions.Add("GroundItem", GroundItemParser);
            ContentParseInstructions.Add("NPC", NPCParser);
            //COMMENTED OUT WHILE Game1 is a parameter ParseInstructions.Add("Link", LinkParser);
            //ItemsOneFactoryInstructions.Add("Blaze", BlazeParser);
        }
        private static void ParseRoom(XmlNode subtree, ContentManager content)
        {
            int roomId = Int32.Parse(subtree.Attributes["id"].Value);
            int x = ParseXCoordinate(subtree);
            int y = ParseYCoordinate(subtree);
            SpriteFactory roomFactory = AnimationParser.ParseAnimationSet(subtree.SelectSingleNode("AnimationSet"), content);
            LevelLoader.CreateRoom(x, y, roomId, roomFactory);
            XmlNode RoomContentNodes = subtree.SelectSingleNode("Content");
            ParseRoomContents(RoomContentNodes, roomId, content);
        }
        private static void ParseRoomContents(XmlNode roomContentsNode, int roomId, ContentManager content)
        {
            foreach (XmlNode objectNode in roomContentsNode)
            {
                ContentParseDelegate parser = ContentParseInstructions[objectNode.Name];
                parser(objectNode, roomId, content);

            }
        }
        private static void ParseDoor(XmlNode doorNode, int roomId, ContentManager content)
        {
            int x = ParseXCoordinate(doorNode);
            int y = ParseYCoordinate(doorNode);
            int ToRoomId = (int)float.Parse(doorNode.SelectSingleNode("ToRoomId").InnerText);
            IDoor.DoorState state = (IDoor.DoorState)float.Parse(doorNode.SelectSingleNode("DoorState").InnerText);
            Globals.Direction sideOfRoom = (Globals.Direction)float.Parse(doorNode.SelectSingleNode("SideOfRoom").InnerText);
            SpriteFactory doorFactory = AnimationParser.ParseAnimationSet(doorNode.SelectSingleNode("AnimationSet"), content);
            LevelLoader.CreateDoor(x, y, roomId, ToRoomId, sideOfRoom, doorFactory, state);
        }
        private static void ParseBlock(XmlNode subtree, int roomId, ContentManager content)
        {
            int x = ParseXCoordinate(subtree);
            int y = ParseYCoordinate(subtree);
            string blockType = subtree.SelectSingleNode("BlockType").InnerText;
            //Initiallized at -1 because numbering starts at 0 and unless it is a StairBlock, it shouldn't go to a room.
            int toRoomId = -1;
            /*BAD CODE: the way we have the blocks, I have to use a magic string to initialize the StairBlock.
             This could be fixed by separating the blocks into types and have it parse a specific one like ParseRoomContent()*/
            if (blockType == "StairBlock")
            {
                toRoomId = (int)float.Parse(subtree.SelectSingleNode("ToRoomId").InnerText);
            }
            SpriteFactory blockFactory = AnimationParser.ParseAnimationSet(subtree.SelectSingleNode("AnimationSet"), content);
            LevelLoader.CreateBlock(x, y, roomId, blockType, blockFactory, toRoomId);
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
        private static void ParseLink(XmlNode linkNode, ContentManager content)
        {
            /*Gets the x and y location*/
            int x = ParseXCoordinate(linkNode);
            int y = ParseYCoordinate(linkNode);
            /*Parses Animation*/
            SpriteFactory LinkFactory = AnimationParser.ParseAnimationSet(linkNode.SelectSingleNode("AnimationSet"), content);
            /*Makes object*/
            LevelLoader.CreateLink(x, y, LinkFactory);
        }
        private static void ParseEnemy(XmlNode enemyNode, int roomId, ContentManager content)
        {
            int x = ParseXCoordinate(enemyNode);
            int y = ParseYCoordinate(enemyNode);
            string enemyType = enemyNode.SelectSingleNode("EnemyNode").InnerText;
            XmlNodeList AnimationSetNodes = enemyNode.SelectNodes("AnimationSet");
            SpriteFactory[] factoryArray = new SpriteFactory[AnimationSetNodes.Count];
            for (int i = 0; i < AnimationSetNodes.Count; i++)
            {
                factoryArray[i] = AnimationParser.ParseAnimationSet(AnimationSetNodes[i], content);
            }
            LevelLoader.CreateEnemy(x, y, roomId, enemyType, factoryArray);
        }
        private static void ParseFloor(XmlNode floorNode, int roomId, ContentManager content)
        {
            int x = ParseXCoordinate(floorNode);
            int y = ParseYCoordinate(floorNode);
            SpriteFactory floorFactory = AnimationParser.ParseAnimationSet(floorNode.SelectSingleNode("AnimationSet"), content);
            LevelLoader.CreateFloor(x, y, roomId, floorFactory);
        }
        private static void ParseItems(XmlNode itemsNode, ContentManager content)
        {
            foreach (XmlNode itemNode in itemsNode)
            {
                ParseItem(itemNode, content);
            }
        }
        private static void ParseItem(XmlNode itemNode, ContentManager content)
        {
            //NOTE: This is probably how both methods should be handled.
            XmlNodeList animationSets = itemNode.SelectNodes("AnimationSet");
            SpriteFactory[] factoryArray = new SpriteFactory[animationSets.Count];
            for (int i = 0; i < animationSets.Count; i++)
            {
                factoryArray[i] = AnimationParser.ParseAnimationSet(animationSets[i], content);
            }
            LevelLoader.LoadItem(factoryArray, itemNode.Name);
        }
        private static void ParseGroundItem(XmlNode groundItemNode, int roomId, ContentManager content)
        {
            int x = ParseXCoordinate(groundItemNode);
            int y = ParseYCoordinate(groundItemNode);
            string groundItemType = groundItemNode.SelectSingleNode("GroundItemType").InnerText;
            SpriteFactory groundItemFactory = AnimationParser.ParseAnimationSet(groundItemNode.SelectSingleNode("AnimationSet"), content);
            LevelLoader.CreateGroundItem(x, y, roomId, groundItemType, groundItemFactory);
        }
        private static void ParseNPC(XmlNode nPCNode, int roomId, ContentManager content)
        {
            int x = ParseXCoordinate(nPCNode);
            int y = ParseYCoordinate(nPCNode);
            SpriteFactory nPCFactory = AnimationParser.ParseAnimationSet(nPCNode.SelectSingleNode("AnimationSet"), content);
            LevelLoader.CreateNPC(x, y, roomId, nPCFactory);
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
