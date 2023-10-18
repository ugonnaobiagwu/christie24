using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace sprint0.Level_Loading___Parsers
{
    internal static class XmlParser
    {
        /*This is the method called in main.
         An XML Document must be made there and parsed into an XmlNodeList with */
        public static void ParseFile(XmlDocument doc)
        {
            /*Gets a list of each room and iterates through each*/
            XmlNodeList NodeList = doc.DocumentElement.SelectNodes("Room");
            foreach (XmlNode node in doc)
            {
                ParseRoom(node);
            }

        }
        /*Parses every item in the room*/
        private static void ParseRoom(XmlNode doc)
        {
           
            /*Starts by getting the attribute, tests that it isn't null, and stores it to a variable if it isn't*/
            var RoomIDAttribute = doc.Attributes["id"];
            string RoomIDStr = RoomIDAttribute.Value;
            int RoomID = Int32.Parse(RoomIDStr);
            

            /*Creates the new Xml Node Lists and calls each's parser recursively*/
            XmlNodeList EnemyNodeList = doc.SelectNodes("Enemy");
            /*NOTE: Must check before each foreach in case there are none of the specified objects in the room.*/
            if (EnemyNodeList.Count != 0)
            {
                foreach (XmlNode node in EnemyNodeList)
                {
                    ParseEnemy(node);
                }
            }
            XmlNodeList LinkNodeList = doc.SelectNodes("Link");
            if (LinkNodeList.Count != 0)
            {
                foreach (XmlNode node in LinkNodeList)
                {
                    ParseLink(node, oomID);
                }
            }

            XmlNodeList BlockNodeList = doc.SelectNodes("Block");
            if (BlockNodeList.Count != 0)
            {
                foreach (XmlElement node in BlockNodeList)
                {
                    ParseBlock(node);
                }
            }
            XmlNodeList BoundaryNodeList = doc.SelectNodes("Boundary");
            if (BoundaryNodeList.Count != 0)
            {
                foreach (XmlElement node in BoundaryNodeList)
                {
                    ParseBoundary(node);
                }
            }
            XmlNodeList DoorNodeList = doc.SelectNodes("Door");
            if (DoorNodeList.Count != 0)
            {
                foreach (XmlAttribute node in DoorNodeList)
                {
                    ParseDoor(node);
                }
            }

        }

        private static void ParseLink(XmlNode doc, int roomId)
        {
            /*Creates the parameter for Link's constructor*/
            XmlNode XNode = doc.SelectSingleNode("x");
            XmlNode YNode = doc.SelectSingleNode("y");
            /*NOTE: Vector2 is fighting me so this needs to be split into x and y*/
            Vector2 Location = new Vector2(float.Parse(XNode.InnerText), float.Parse(YNode.InnerText));\
            /*Gets Constructor Info for typeof() instantiation*/
            XmlNode ConstrNode = doc.SelectSingleNode("ConstructorInfo");
            string ConstrInfo = ConstrNode.InnerText;
            LevelLoader.CreateLink(ConstrInfo,Location, roomId);

        }
    }
}