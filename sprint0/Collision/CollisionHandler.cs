using System;
using System.Collections.Generic;
using System.Data;
using sprint0.Link;
using sprint0.Items;


namespace sprint0.Collision
{
	public class CollisionHandler
	{
		// Data structures needed to put this show on the road QUICKLY.
		private DataTable collisionTable = new DataTable();

        /*
		 * Constructor. May do more now that you can make an instance of this
		 * class. That poor, poor architecture document must be feeling so sad
		 * rn.
		 */
        public CollisionHandler()
		{
			PopulateDataTable();
		}

        /*
		 * Public method called from outside the handler class to begin 
		 * handling of the two objects detected in a collision.
		 * 
		 * DESIGN DETAILS FOR FUTUTE ME WHO HAS YET TO IMPLEMENT:
		 * -----
		 * 
		 * Given two objects and their collision type. Search the table for the
		 * right combination using the actual types of both objects [as Strings]
		 * then, go ahead and grab the delegates and call them using the
		 * collision data (these params) as the params for the methods in the 
		 * table.
		 * 
		 * (be sure to check if a delegate entry is null, this signifies that
		 * an object does not have any collision reaction in that combo)
		 * 
		 * Get type of an IGameObject returns the concrete class. So it's
		 * really important our GameObjects implement the IGameObject interface
		 */
        public void HandleCollision(IGameObject a, IGameObject b, CollisionDetector.CollisionType collisionType)
		{
            String objAType = a.GetType().ToString();
            String objBType = b.GetType().ToString();
            DataRow rowWithDelegates = null;
            foreach (DataRow row in collisionTable.Rows)
            {
                //AB check.
                if (row["ObjectA"].Equals(objAType) && row["ObjectB"].Equals(objBType)) {
                    rowWithDelegates = row;
                    break;
                }

                //BA check
                else if (row["ObjectA"].Equals(objBType) && row["ObjectB"].Equals(objAType))
                {
                    rowWithDelegates = row;
                    break;
                }
            }
            if (rowWithDelegates != null)
            {
                if (rowWithDelegates["HandleA"] != null)
                {
                    GameObjectDelegate aDelegate = (GameObjectDelegate)rowWithDelegates["HandleA"];
                    aDelegate(collisionType, a);
                }
                if (rowWithDelegates["HandleB"] != null)
                {
                    GameObjectDelegate bDelegate = (GameObjectDelegate)rowWithDelegates["HandleB"];
                    bDelegate(collisionType, b);
                }
            }
        }

		/*
		 * Private method used to populate the data table with all the right 
		 * objects delegates in the proper rows and cols.
		 * 
		 * I would consider making the entire class an instance class since
		 * doing this every single time would probably get costly. Maybe the 
		 * Iterator can be the one that owns the instance of this class?
		 * 
		 * DESIGN DETAILS FOR FUTUTE ME WHO HAS YET TO IMPLEMENT:
		 * -----
		 * Using the delegate "types" made below, instantiate new delegates
		 * and populate the table with the right rows and combinations of
		 * proper collidables, bearing in mind that ObjA Collides with ObjB
		 *
		 * Each method will deal with each collision direction if needed, so the 
		 * collision direction entry is ommitted in the table since it's not
		 * consistently needed. (i.e. MoveLink, as an example of how we'll do this)
		 */
		private void PopulateDataTable()
        {
			collisionTable.Clear();
			collisionTable.Columns.Add("ObjectA");
            collisionTable.Columns.Add("ObjectB");
            collisionTable.Columns.Add("CollisionType");
            collisionTable.Columns.Add("HandleA");
            collisionTable.Columns.Add("HandleB");
			LinkDelegate MoveLinkDelegate = MoveLink;
			LinkDelegate MoveLinkAndTakeDamageDelegate = MoveLinkAndTakeDamage;
			BlazeDelegate BlazeImpactDelegate = BlazeImpact;
			collisionTable.Rows.Add(new Object[] { "ILink", "DungenDrangonBlock", MoveLinkDelegate, null });
            collisionTable.Rows.Add(new Object[] { "ILink", "DungenFishBlock", MoveLinkDelegate, null });
            collisionTable.Rows.Add(new Object[] { "ILink", "DungenPyramidBlock", MoveLinkDelegate, null });
			collisionTable.Rows.Add(new Object[] { "ILink", "ExplodableBlock", MoveLinkDelegate, null });
            collisionTable.Rows.Add(new Object[] { "ILink", "Blaze", MoveLinkAndTakeDamageDelegate, BlazeImpactDelegate });
        }

        /*
		 * DELEGATES & METHODS
		 * ----
		 * 
		 * collisionType is under the assumptipn that object A collided with B.
		 * Object A is always a dynamic object.
		 * 
		 * Use the delegate objects created for each section as a blue print for the 
		 * methods you'll make to meet their signatures. Then, during table 
		 * population, instantiate the delegates using the delegate objects
		 * as their type, and assign the proper method to it. 
		 * 
		 * The idea is that one Delegate can act as the placeholder blueprint
		 * for any delegate that deals with that object so long as the 
		 * signatures match.
		 * 
		 */
        private delegate void GameObjectDelegate(CollisionDetector.CollisionType collisionType, IGameObject obj);

		//LINK
		private delegate void LinkDelegate(CollisionDetector.CollisionType collisionType, ILink link);
        private void MoveLink (CollisionDetector.CollisionType collisionType, ILink link) {
            // I need a better way to change Link's stuff without making such a mess.
            switch (collisionType)
			{
				case CollisionDetector.CollisionType.TOP:
					link.LinkUp();
                    break;
                case CollisionDetector.CollisionType.BOTTOM:
                    link.LinkDown();
					break;
                case CollisionDetector.CollisionType.LEFT:
                    link.LinkLeft();
                    break;
                case CollisionDetector.CollisionType.RIGHT:
                    link.LinkRight();
                    break;
            }
		}

        private void MoveLinkAndTakeDamage(CollisionDetector.CollisionType collisionType, ILink link)
        {
            switch (collisionType)
            {
                case CollisionDetector.CollisionType.TOP:
                    link.LinkUp();
                    link.LinkUp();
                    link.LinkUp();
                    link.LinkUp();
                    link.LinkUp();
                    break;
                case CollisionDetector.CollisionType.BOTTOM:
                    link.LinkDown();
                    link.LinkDown();
                    link.LinkDown();
                    link.LinkDown();
                    link.LinkDown();
                    break;
                case CollisionDetector.CollisionType.LEFT:
                    link.LinkLeft();
                    link.LinkLeft();
                    link.LinkLeft();
                    link.LinkLeft();
                    link.LinkLeft();
                    break;
                case CollisionDetector.CollisionType.RIGHT:
                    link.LinkRight();
                    link.LinkRight();
                    link.LinkRight();
                    link.LinkRight();
                    link.LinkRight();
                    break;
            }
			link.LinkTakeDamage();
        }

        /*
         * ITEMS
         * this is expecting the item... do not throw the entire item system obj
         */

        //Bows
        private delegate void BowDelegate(CollisionDetector.CollisionType collisionType, Bow bow);
		private void BowImpact(CollisionDetector.CollisionType collisionType, Bow bow)
		{
			bow.thisStateMachine.CeaseUse();
		}
        private delegate void BetterBowDelegate(CollisionDetector.CollisionType collisionType, BetterBow betterBow);
        private void BetterBowImpact(CollisionDetector.CollisionType collisionType, BetterBow betterBow)
        {
            betterBow.thisStateMachine.CeaseUse();
        }

        //Boomerangs
        private delegate void BoomerangDelegate(CollisionDetector.CollisionType collisionType, Boomerang boomerang);
        private void BoomerangImpact(CollisionDetector.CollisionType collisionType, Boomerang boomerang)
        {
            boomerang.thisStateMachine.CeaseUse();
        }
        private delegate void BetterBoomerangDelegate(CollisionDetector.CollisionType collisionType, BetterBoomerang betterBoomerang);
        private void BetterBoomerangImpact(CollisionDetector.CollisionType collisionType, BetterBoomerang betterBoomerang)
        {
            betterBoomerang.thisStateMachine.CeaseUse();
        }

        //Blaze
        private delegate void BlazeDelegate(CollisionDetector.CollisionType collisionType, Blaze blaze);
        private void BlazeImpact(CollisionDetector.CollisionType collisionType, Blaze blaze)
        {
            blaze.thisStateMachine.CeaseUse();
        }

		//Bomb
		private delegate void BombDelegate(CollisionDetector.CollisionType collisionType, Bomb bomb);
		private void BombImpact(CollisionDetector.CollisionType collisionType, Bomb bomb)
		{
            // NOTE: Bomb doesn't have splash damage implemented yet for when it's finally exploded.
            // DESIGN DECISION: should Bomb explode if an enemy collides with it?
        }
    }
}

