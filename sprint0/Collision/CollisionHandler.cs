using System;
using System.Collections.Generic;
using System.Data;

namespace sprint0.Collision
{
	public class CollisionHandler
	{
		// Data structures needed to put this show on the road QUICKLY.
		private DataTable collisionTable = new DataTable();
		// Not an exhaustive list of our concrete types.
		private IList<String> TypeList = new List<String>
		{
			"Link", "Bow", "BetterBow", "Boomerang", "BetterBoomerang",
			"Blaze", "Bomb", "DungenBlueBlock", "DungenDrangonBlock",
			"DungenFishBlock","DungenPyramidBlock", "ExplodableBlock",
			"GroundBigHeart", "GroundBlaze", "GroundBomb", "GroundBoomerang",
			"GroundBow", "GroundClock", "GroundCompass", "GroundCompass", "GroundFairy",
			"GroundHeart", "GroundKey", "GroundPage", "GroundRupee", "GroundShimmeringRupee",
			"GroundTriforce"
		};
		private IList<CollisionDetector.CollisionType> CollisionTypeList = new List<CollisionDetector.CollisionType>
		{
			CollisionDetector.CollisionType.TOP, CollisionDetector.CollisionType.BOTTOM, CollisionDetector.CollisionType.LEFT, CollisionDetector.CollisionType.RIGHT
        };


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
		 * Step One. Instantiate and Populate the Data Table.
		 * Step Two. Use the types of Object a and Object b and the collision
		 * to grab the delegate you need.
		 * Step Three. Populate the delegates with the right code and objects.
		 */
        public void HandleCollision(IGameObject a, IGameObject b, CollisionDetector.CollisionType collisionType)
		{
		

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
		 */
		private void PopulateDataTable()
        {
			collisionTable.Clear();
			collisionTable.Columns.Add("ObjectA");
            collisionTable.Columns.Add("ObjectB");
            collisionTable.Columns.Add("CollisionType");
            collisionTable.Columns.Add("HandleA");
            collisionTable.Columns.Add("HandleB");
        }

    }
}

