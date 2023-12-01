using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace sprint0.Collision
{
    public static class CollisionIterator
    {
        /*
		 * Iterates through every GameObject in dynamicObjects against all
		 * other gameObjects in a the current room and sets them up for 
		 * collision detection.
		 * 
		 * DESIGN DETAILS FOR FUTUTE ME WHO HAS YET TO IMPLEMENT:
		 * -----
		 * This method will use QuadTrees in order to see if it should test 
		 * for collision for a given quadrant of the screen.
		 * 
		 * This is done by creating new lists for every quadrant. 
		 * These lists consistn of a list of dynamics and all the objects in
		 * a given quadrant. As well as a quadrantCounter.
		 * 
		 * For every object if it falls into a quadrant,
		 * 
		 * If four or more objects fall into the same quadrant (i.e. the size of collidablesInQuadrant), break it down
		 * by cutting the bounds in half and recursively calling the method.
		 * 
		 * If there are less than four objects in the same quadrant, loop through
		 * and test them for collision.
		 * 
		 */

        //private const int INITIATE_LOOP_THRESHOLD = 4;
        private static CollisionHandler handler = new CollisionHandler();

        //public static void Search(IList<IGameObject> collidables, int screenWidth, int screenHeight)
        //{
        //    BranchOrIterate(collidables, 0, screenWidth, 0, screenHeight);
        //}

        //private static void BranchOrIterate(IList<IGameObject> collidablesInQuadrant,
        //    int xQuadrantMinBound, int xQuadrantMaxBound, int yQuadrantMinBound,
        //    int yQuadrantMaxBound)
        //{
        //    if (collidablesInQuadrant.Count < INITIATE_LOOP_THRESHOLD)
        //    {
        //        CollisionIterator.Iterate(collidablesInQuadrant);

        //    }
        //    else
        //    {
        //        CollisionIterator.Branch(collidablesInQuadrant, xQuadrantMinBound, xQuadrantMaxBound, yQuadrantMinBound, yQuadrantMaxBound);
        //    }
        //}

        /*
		 * Private method used to loop for collision once a quadrant is under 
		 * the threshold for being broken down
		 * 
		 * DESIGN DETAILS FOR FUTUTE ME WHO HAS YET TO IMPLEMENT:
		 * -----
		 * 
		 * Linear loop through each dynamic object in the quadrant, and use the 
		 * CollisionDetection utility class to test for collision.
		 * 
		 * Game Object Interface should have a method that returns whether 
		 * or not an object is dynamic. If so, loop through.
		 */
        public static void Iterate(IList<IGameObject> collidablesInQuadrant)
        {
            foreach (IGameObject obj1 in collidablesInQuadrant)
            {
                if (obj1.isDynamic())
                {
                    //System.Diagnostics.Debug.WriteLine("OBJ1 WIDTH AND HEIGHT  " + obj1.width() + " " + obj1.height());
                    foreach (IGameObject obj2 in collidablesInQuadrant)
                    {
                        if (obj2 != obj1 && !obj2.GetType().Equals(obj1.GetType()))
                        {
                            //Console.WriteLine("DEBUG: COLLISION DETECTOR TESTS COLLISION BETWEEN  " + obj1.GetType().ToString() + " AND " + obj2.GetType().ToString());
                            //System.Diagnostics.Debug.WriteLine("OBJ2 WIDTH AND HEIGHT  " + obj2.width() + " " + obj2.height());
                            CollisionDetector.CollisionType thisCollisionType = CollisionDetector.CollisionCheck(obj1, obj2);
                            if (thisCollisionType != CollisionDetector.CollisionType.NONE)
                            {
                                //Console.WriteLine("DEBUG: COLLISION TYPE FOUND:  " + thisCollisionType.ToString());
                                bool foundCollision = handler.HandleCollision(obj1, obj2, thisCollisionType);
                                if (!foundCollision)
                                {
                                    foundCollision = handler.HandleCollision(obj2, obj1, thisCollisionType); // BA Check.
                                    if (!foundCollision)
                                    {
                                        //Console.WriteLine("DEBUG: COLLISION HANDLER COULD NOT FIND HANDLER FOR COMBINATION OF OBJECT:" + obj1.GetType().ToString() + " AND " + obj2.GetType().ToString());
                                    }
                                }
                                else
                                {
                                    //Console.WriteLine("DEBUG: COLLISION HAS BEEN HANDLED BETWEEN:" + obj1.GetType().ToString() + " AND " + obj2.GetType().ToString());
                                }
                            }
                        }
                    }
                }

            }
        }

        /*
		 * Private method used to branch out the QuadTree.
		 * 
		 * DESIGN DETAILS FOR FUTUTE ME WHO HAS YET TO IMPLEMENT:
		 * -----
		 * 
		 * Linear loop through each dynamic object in the quadrant, and use the 
		 * CollisionDetection utility class to test for collision.
		 * 
		 * Game Object Interface should have a method that returns whether 
		 * or not an object is dynamic. If so, loop through.
		 */
        //private static void Branch(IList<IGameObject> collidablesInQuadrant,
        //    int xQuadrantMinBound, int xQuadrantMaxBound,
        //    int yQuadrantMinBound, int yQuadrantMaxBound)
        //{
        //    int xQuadrantHalfBound = ((xQuadrantMaxBound - xQuadrantMinBound) / 2) + xQuadrantMinBound;
        //    int yQuadrantHalfBound = ((yQuadrantMaxBound - yQuadrantMinBound) / 2) + yQuadrantMinBound;
        //    IList<IGameObject> q1 = new List<IGameObject>();
        //    IList<IGameObject> q2 = new List<IGameObject>();
        //    IList<IGameObject> q3 = new List<IGameObject>();
        //    IList<IGameObject> q4 = new List<IGameObject>();
        //    foreach (IGameObject obj in collidablesInQuadrant)
        //    {
        //        if (obj.xPosition() <= xQuadrantHalfBound && obj.yPosition() <= yQuadrantHalfBound)
        //        {
        //            q1.Add(obj);
        //            CollisionIterator.BranchOrIterate(q1, xQuadrantMinBound, xQuadrantHalfBound, yQuadrantMinBound, yQuadrantHalfBound);
        //        }
        //        else if (obj.xPosition() > xQuadrantHalfBound && obj.yPosition() <= yQuadrantHalfBound)
        //        {
        //            q2.Add(obj);
        //            CollisionIterator.BranchOrIterate(q2, xQuadrantHalfBound, xQuadrantMaxBound, yQuadrantMinBound, yQuadrantHalfBound);
        //        }
        //        else if (obj.xPosition() <= xQuadrantHalfBound && obj.yPosition() > yQuadrantHalfBound)
        //        {
        //            q3.Add(obj);
        //            CollisionIterator.BranchOrIterate(q3, xQuadrantMinBound, xQuadrantHalfBound, yQuadrantHalfBound, yQuadrantMaxBound);
        //        }
        //        else if (obj.xPosition() > xQuadrantHalfBound && obj.yPosition() > yQuadrantHalfBound)
        //        {
        //            q4.Add(obj);
        //            CollisionIterator.BranchOrIterate(q4, xQuadrantHalfBound, xQuadrantMaxBound, yQuadrantHalfBound, yQuadrantMaxBound);
        //        }
        //    }
        //}

    }
}

