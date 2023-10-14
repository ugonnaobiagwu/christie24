using System;
using Microsoft.Xna.Framework;

namespace sprint0.Collision
{
	public static class CollisionDetector
	{
		public enum CollisionType { TOP, BOTTOM, LEFT, RIGHT, NONE }; // Do we need this enum in every Collision Class since this is a utility class?

		/*
		 * Returns the type of collision that occured on Rectangle b from Rectangle a, if any.
		 */
		public static CollisionType CollisionCheck(/* GameObject a, GameObject b*/)
		{
			return 0;
		}

        /*
		 * Private method used to return exactly where a collision occured.
		 * 
		 * DESIGN DETAILS FOR FUTUTE ME WHO HAS YET TO IMPLEMENT:
		 * -----
		 * Given that the location member of the generated rectangle gives the Top-left corner of the rectangle.
		 * This can be used to calculate where in Rectangle b, that Rectangle a collided with Rectangle b.
		 */
        private static CollisionType CollisionLocation(Rectangle a, Rectangle b, Rectangle c) {
			return 0;
		}

        /*
		 * Private method used to determine if two rectangles, representing game objects, intersect.
		 * 
		 * DESIGN DETAILS FOR FUTUTE ME WHO HAS YET TO IMPLEMENT:
		 * -----
		 * Given that the location member of the generated rectangle gives the Top-left corner of the rectangle.
		 * This can be used to calculate where in Rectangle b, that Rectangle a collided with Rectangle b.
		 */
        private static bool CollisionIntersection(Rectangle a, Rectangle b)
		{
			return false;
		}

    }
}

