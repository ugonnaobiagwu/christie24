using System;
using Microsoft.Xna.Framework;

namespace sprint0.Collision
{
    /*
		 * NOTE FOR FUTURE ME, OR ANYONE ELSE HERE. (HI!): 
		 * Consider changing the protection level of this class?
		 * 
		 * The only thing that will/should touch this utility class, 
		 * and the handler utility, would be the 
		 * overall iterator, and I'm considering making that a utility 
		 * class as you don't really need an "instance" of a collision object,
		 * since all your doing is reporting.
		 * 
		 */

    public static class CollisionDetector
	{
		public enum CollisionType { TOP, BOTTOM, LEFT, RIGHT, NONE };
        // Do we need this enum in every Collision Class?

        /*
		 * Returns the type of collision that occured on Rectangle b from 
		 * Rectangle a, if any.
		 * 
		 * DESIGN DETAILS FOR FUTUTE ME WHO HAS YET TO IMPLEMENT:
		 * -----
		 * Using the area / location of both gameObjects, build a rectangle
		 * that can be used to call the respective intersection methids needed.
		 */
        public static CollisionType CollisionCheck(IGameObject a, IGameObject b)
		{
			return 0;
		}

        /*
		 * Private method used to return exactly where a collision occured.
		 * 
		 * DESIGN DETAILS FOR FUTUTE ME WHO HAS YET TO IMPLEMENT:
		 * -----
		 * Given that the location member of the generated rectangle gives 
		 * the Top-left corner of the rectangle.
		 * 
		 * This can be used to calculate where in Rectangle b, that 
		 * Rectangle a collided with Rectangle b.
		 */
        private static CollisionType CollisionLocation(Rectangle a, Rectangle b, Rectangle c) {
			return 0;
		}

        /*
		 * Private method used to determine if two rectangles, representing 
		 * game objects, intersect.
		 * 
		 * DESIGN DETAILS FOR FUTUTE ME WHO HAS YET TO IMPLEMENT:
		 * -----
		 * Given that the location member of the generated rectangle 
		 * gives the Top-left corner of the rectangle.
		 * This can be used to calculate where in Rectangle b, 
		 * that Rectangle a collided with Rectangle b.
		 */
        private static bool CollisionIntersection(Rectangle a, Rectangle b)
		{
			return false;
		}

        /*
		 * Private method used to construct a rectangle based on an object's
		 * data.
		 */
        private static Rectangle ConstructObjectRectangle(int objXPos, int objYPos, int objWidth, int objHeight)
        {
            return Rectangle.Empty;
        }

    }
}

