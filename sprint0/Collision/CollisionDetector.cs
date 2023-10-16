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
		 * This is contigent that objects don't move so fast that they end up
		 * slipping the system's checks.
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
		 * that can be used to call the respective intersection methods needed.
		 */
        public static CollisionType CollisionCheck(IGameObject a, IGameObject b)
		{
			Rectangle aRect = CollisionDetector.ConstructObjectRectangle
				(a.xPosition(), a.yPosition(), a.width(), a.height());
            Rectangle bRect = CollisionDetector.ConstructObjectRectangle
				(b.xPosition(), b.yPosition(), b.width(), b.height());
			Rectangle cRect = CollisionIntersection(aRect, bRect); // collision rect
			return CollisionDetector.CollisionLocation(aRect, bRect, cRect);
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
		 * 
		 * If the width is greater than the height, then we have a Top-Bottom collision,
		 * otherwise we have a Left Right.
		 */

        /* 
		* If Collision Rectangle is a Square... We ****ed up somewhere in 
		* making sure collision was detected early enough.
		*/
        private static CollisionType CollisionLocation(Rectangle a,
			Rectangle b, Rectangle c) {
			if (c.IsEmpty) return CollisionType.NONE;
			CollisionType collisionType = CollisionType.LEFT; // default?
			if (c.Width > c.Height) {
                collisionType = TopOrBottomCollision(b, c);
			} else {
				collisionType = LeftOrRightCollision(b, c);
            }
            return collisionType;
		}

        /*
		 * Private method used to determine if two rectangles, representing 
		 * game objects, intersect, and returns the intersection rectangle if so.
		 * 
		 * DESIGN DETAILS FOR FUTUTE ME WHO HAS YET TO IMPLEMENT:
		 * -----
		 * Reports whether or not two rectangles intersect
		 */
        private static Rectangle CollisionIntersection(Rectangle a, Rectangle b)
		{
			return Rectangle.Intersect(a, b);
		}

        /*
		 * Private method used to construct a rectangle based on an object's
		 * data.
		 */
        private static Rectangle ConstructObjectRectangle
			(int objXPos, int objYPos, int objWidth, int objHeight)
        {
			return new Rectangle
				(new Point(objXPos, objYPos), new Point(objWidth * objHeight));
        }

        /*
		 * Private method used determine which vertical collision occured.
		 * 
		 * DESIGN DETAILS FOR FUTURE ME WHO HAS YET TO IMPLEMENT
		 * -----
		 * If the bottom of c is greater than the vertical midway 
		 * point of b, then it is a top collision, 
		 * otherwise, it is a bottom collsion.
		 */
        private static CollisionType TopOrBottomCollision
			(Rectangle b, Rectangle c)
        {
			if (c.Bottom > ((b.Height / 2) + b.Top))
			{
				return CollisionDetector.CollisionType.TOP;
			} else
			{
                return CollisionDetector.CollisionType.BOTTOM;
            }
        }

        /*
		 * Private method used determine which horizontal collision occured.
		 * 
		 * DESIGN DETAILS FOR FUTURE ME WHO HAS YET TO IMPLEMENT
		 * -----
		 * And with that said, if the left of c 
		 * is less than the horizontal midway point of b, 
		 * then a left collision occured, otherwise a right one did.
		 */
        private static CollisionType LeftOrRightCollision(Rectangle b, Rectangle c)
        {
            if (c.Left < ((b.Width / 2) + b.Left))
            {
                return CollisionDetector.CollisionType.LEFT;
            }
            else
            {
                return CollisionDetector.CollisionType.RIGHT;
            }
        }

    }
}

