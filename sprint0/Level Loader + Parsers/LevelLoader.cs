using Microsoft.Xna.Framework;
using sprint0.Link;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace sprint0.Level_Loading___Parsers
{
    internal static class LevelLoader
    {

        public static void CreateLink(string constrInfo, Vector2 loc, int roomId)
        {
            /*Creates a parameter's list needed for GetConstructor()*/
            Object[] parameters = new Type[1];
            parameters[0] = loc;
            parameters[1] = roomId;
            /*Gets the constructor type*/
            Type constr = Type.GetType(constrInfo);
            /*Gets the constructor info
             *NOTE: BindingFlags.Public indicates it's looking for a public method*/
            ConstructorInfo constructorObj = constr.GetConstructor(BindingFlags.Public, new Type[] {typeof(Vector2), typeof(int) });
            /*Creates the Link object*/
            /*.Invoke returns an Object object, is there a way to may it an IGameObject?*/
            var newLinkObj = constructorObj.Invoke(parameters);
        }
        public static void CreateBlock()
        {

        }
        public static void CreateEnemy()
        {

        }
    }
}