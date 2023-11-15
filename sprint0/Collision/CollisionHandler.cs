using System;
using System.Collections.Generic;
using System.Data;
using sprint0.LinkObj;
using sprint0.Items;
using sprint0.Items.groundItems;
using sprint0.Blocks;
using sprint0.Enemies;
using sprint0.Sound.Ocarina;

namespace sprint0.Collision
{
    public class CollisionHandler
    {
        /*
         * DEVELOPMENT NOTES:
         * 
         * 1. Stair Blocks lead nowhere currently.
         * 2. Enemies handle their own knockback so the direction they face is slightky office.
         * 3. Still need inventory system edits.
         * 4. Still need enemy projectiles.
         * 5. Still need  doors.
         * 
         * Things to note:
         * 1. Link does not collide with any of his items in action.
         * 2. Enemies don't collide with movable blocks or ground Items.
         * 3. Bomb Boundary Collision
         */



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
		 * handling of the two objects detected in a collision. Returns true if a handler
		 * exists for that combination.
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
        public bool HandleCollision(IGameObject a, IGameObject b, CollisionDetector.CollisionType collisionType)
        {
            bool handleExists = false;
            String objAType = a.GetType().ToString();
            String objBType = b.GetType().ToString();
            DataRow rowWithDelegates = null;
            foreach (DataRow row in collisionTable.Rows)
            {
                if (row["ObjectA"].Equals(objAType) && row["ObjectB"].Equals(objBType))
                {
                    System.Diagnostics.Debug.WriteLine("OBJECT A: " + row["ObjectA"].ToString() + " AND OBJECT B:  " + row["ObjectB"].ToString());

                    rowWithDelegates = row;
                    System.Diagnostics.Debug.WriteLine(rowWithDelegates.ToString());

                    handleExists = true;
                    break;
                }
            }
            if (rowWithDelegates != null)
            {

                // use the actual value in the field
                if (rowWithDelegates.Field<GameObjectDelegate>("HandleA") != null)
                {
                    GameObjectDelegate aDelegate = (GameObjectDelegate)rowWithDelegates["HandleA"];
                    aDelegate.Invoke(collisionType, a);
                }
                if (rowWithDelegates.Field<GameObjectDelegate>("HandleB") != null)
                {
                    GameObjectDelegate bDelegate = (GameObjectDelegate)rowWithDelegates["HandleB"];
                    bDelegate.Invoke(collisionType, b);
                }
            }

            return handleExists;
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
            collisionTable.Columns.Add("HandleA", typeof(GameObjectDelegate));
            collisionTable.Columns.Add("HandleB", typeof(GameObjectDelegate));
            GameObjectDelegate MoveLinkDelegate = new GameObjectDelegate(MoveLink);
            GameObjectDelegate MoveLinkAndTakeDamageDelegate = new GameObjectDelegate(MoveLinkAndTakeDamage);
            GameObjectDelegate MoveDungeonPyramidBlockDelegate = new GameObjectDelegate(MoveDungeonPyramidBlock);
            GameObjectDelegate GroundBigHeartPickUpDelegate = new GameObjectDelegate(GroundBigHeartPickUp);
            GameObjectDelegate GroundBlazeSteppedOnDelegate = new GameObjectDelegate(GroundBlazeSteppedOn);
            GameObjectDelegate GroundBoomerangPickUpDelegate = new GameObjectDelegate(GroundBoomerangPickUp);
            GameObjectDelegate GroundCompassPickUpDelegate = new GameObjectDelegate(GroundCompassPickUp);
            GameObjectDelegate GroundKeyPickUpDelegate = new GameObjectDelegate(GroundKeyPickUp);
            GameObjectDelegate GroundPagePickUpDelegate = new GameObjectDelegate(GroundPagePickUp);
            GameObjectDelegate GroundTriforcePickUpDelegate = new GameObjectDelegate(GroundTriforcePickUp);
            GameObjectDelegate MoveOktorokDelegate = new GameObjectDelegate(MoveOktorok);
            GameObjectDelegate MoveOktorokAndTakeDamageDelegate = new GameObjectDelegate(MoveOktorokAndTakeDamage);
            GameObjectDelegate MoveSkeletonDelegate = new GameObjectDelegate(MoveSkeleton);
            GameObjectDelegate MoveSkeletonAndTakeDamageDelegate = new GameObjectDelegate(MoveSkeletonAndTakeDamage);
            GameObjectDelegate MoveBokoblinDelegate = new GameObjectDelegate(MoveBokoblin);
            GameObjectDelegate MoveBokoblinAndTakeDamageDelegate = new GameObjectDelegate(MoveBokoblinAndTakeDamage);
            GameObjectDelegate MoveDragonDelegate = new GameObjectDelegate(MoveDragon);
            GameObjectDelegate MoveDragonAndTakeDamageDelegate = new GameObjectDelegate(MoveDragonAndTakeDamage);
            GameObjectDelegate BowImpactDelegate = new GameObjectDelegate(BowImpact);
            GameObjectDelegate BetterBowImpactDelegate = new GameObjectDelegate(BetterBowImpact);
            GameObjectDelegate BoomerangImpactDelegate = new GameObjectDelegate(BoomerangImpact);
            GameObjectDelegate BetterBoomerangImpactDelegate = new GameObjectDelegate(BetterBoomerangImpact);
            GameObjectDelegate BlazeImpactDelegate = new GameObjectDelegate(BlazeImpact);
            GameObjectDelegate BombImpactDelegate = new GameObjectDelegate(BombImpact);
            GameObjectDelegate GroundItemPickUpDelegate = new GameObjectDelegate(GenericGroundItemPickUp);


            // BOUNDARIES
            collisionTable.Rows.Add(new Object[] { "sprint0.LinkObj.Link", "sprint0.BoundariesDoorsAndRooms.Boundary", MoveLinkDelegate, null });
            collisionTable.Rows.Add(new Object[] { "sprint0.LinkObj.Link", "sprint0.BoundariesDoorsAndRooms.Door", MoveLinkDelegate, null });
            collisionTable.Rows.Add(new Object[] { "sprint0.Enemies.Skeleton", "sprint0.BoundariesDoorsAndRooms.Boundary", MoveSkeletonDelegate, null });
            collisionTable.Rows.Add(new Object[] { "sprint0.Enemies.Bokoblin", "sprint0.BoundariesDoorsAndRooms.Boundary", MoveBokoblinDelegate, null });
            collisionTable.Rows.Add(new Object[] { "sprint0.Enemies.Oktorok", "sprint0.BoundariesDoorsAndRooms.Boundary", MoveOktorokDelegate, null });
            collisionTable.Rows.Add(new Object[] { "sprint0.Enemies.Dragon", "sprint0.BoundariesDoorsAndRooms.Boundary", MoveDragonDelegate, null });
            collisionTable.Rows.Add(new Object[] { "sprint0.Enemies.Skeleton", "sprint0.BoundariesDoorsAndRooms.Door", MoveSkeletonDelegate, null });
            collisionTable.Rows.Add(new Object[] { "sprint0.Enemies.Bokoblin", "sprint0.BoundariesDoorsAndRooms.Door", MoveBokoblinDelegate, null });
            collisionTable.Rows.Add(new Object[] { "sprint0.Enemies.Oktorok", "sprint0.BoundariesDoorsAndRooms.Door", MoveOktorokDelegate, null });
            collisionTable.Rows.Add(new Object[] { "sprint0.Enemies.Dragon", "sprint0.BoundariesDoorsAndRooms.Door", MoveDragonDelegate, null });
            collisionTable.Rows.Add(new Object[] { "sprint0.Items.Bow", "sprint0.BoundariesDoorsAndRooms.Boundary", BowImpactDelegate, null });
            collisionTable.Rows.Add(new Object[] { "sprint0.Items.BetterBow", "sprint0.BoundariesDoorsAndRooms.Boundary", BetterBowImpactDelegate, null });
            collisionTable.Rows.Add(new Object[] { "sprint0.Items.Boomerang", "sprint0.BoundariesDoorsAndRooms.Boundary", BoomerangImpactDelegate, null });
            collisionTable.Rows.Add(new Object[] { "sprint0.Items.BetterBoomerang", "sprint0.BoundariesDoorsAndRooms.Boundary", BetterBoomerangImpactDelegate, null });
            collisionTable.Rows.Add(new Object[] { "sprint0.Items.Blaze", "sprint0.BoundariesDoorsAndRooms.Boundary", BlazeImpactDelegate, null });
            collisionTable.Rows.Add(new Object[] { "sprint0.Items.Bomb", "sprint0.BoundariesDoorsAndRooms.Boundary", null, null });

            // BLOCKS
            collisionTable.Rows.Add(new Object[] { "sprint0.LinkObj.Link", "sprint0.Blocks.DungeonDragonBlock", MoveLinkDelegate, null });
            collisionTable.Rows.Add(new Object[] { "sprint0.Enemies.Skeleton", "sprint0.Blocks.DungeonDragonBlock", MoveSkeletonDelegate, null });
            collisionTable.Rows.Add(new Object[] { "sprint0.Enemies.Bokoblin", "sprint0.Blocks.DungeonDragonBlock", MoveBokoblinDelegate, null });
            collisionTable.Rows.Add(new Object[] { "sprint0.Enemies.Oktorok", "sprint0.Blocks.DungeonDragonBlock", MoveOktorokDelegate, null });
            collisionTable.Rows.Add(new Object[] { "sprint0.Enemies.Dragon", "sprint0.Blocks.DungeonDragonBlock", MoveDragonDelegate, null });

            collisionTable.Rows.Add(new Object[] { "sprint0.LinkObj.Link", "sprint0.Blocks.DungeonFishBlock", MoveLinkDelegate, null });
            collisionTable.Rows.Add(new Object[] { "sprint0.Enemies.Skeleton", "sprint0.Blocks.DungeonFishBlock", MoveSkeletonDelegate, null });
            collisionTable.Rows.Add(new Object[] { "sprint0.Enemies.Bokoblin", "sprint0.Blocks.DungeonFishBlock", MoveBokoblinDelegate, null });
            collisionTable.Rows.Add(new Object[] { "sprint0.Enemies.Oktorok", "sprint0.Blocks.DungeonFishBlock", MoveOktorokDelegate, null });
            collisionTable.Rows.Add(new Object[] { "sprint0.Enemies.Dragon", "sprint0.Blocks.DungeonFishBlock", MoveDragonDelegate, null });

            collisionTable.Rows.Add(new Object[] { "sprint0.LinkObj.Link", "sprint0.Blocks.DungeonPyramidBlock", MoveLinkDelegate, MoveDungeonPyramidBlockDelegate });
            collisionTable.Rows.Add(new Object[] { "sprint0.Enemies.Skeleton", "sprint0.Blocks.DungeonPyramidBlock", MoveSkeletonDelegate, null });
            collisionTable.Rows.Add(new Object[] { "sprint0.Enemies.Bokoblin", "sprint0.Blocks.DungeonPyramidBlock", MoveBokoblinDelegate, null });
            collisionTable.Rows.Add(new Object[] { "sprint0.Enemies.Oktorok", "sprint0.Blocks.DungeonPyramidBlock", MoveOktorokDelegate, null });
            collisionTable.Rows.Add(new Object[] { "sprint0.Enemies.Dragon", "sprint0.Blocks.DungeonPyramidBlock", MoveDragonDelegate, null });


            collisionTable.Rows.Add(new Object[] { "sprint0.LinkObj.Link", "sprint0.Blocks.WaterBlock", MoveLinkDelegate, null });
            collisionTable.Rows.Add(new Object[] { "sprint0.Enemies.Skeleton", "sprint0.Blocks.WaterBlock", MoveSkeletonDelegate, null });
            collisionTable.Rows.Add(new Object[] { "sprint0.Enemies.Bokoblin", "sprint0.Blocks.WaterBlock", MoveBokoblinDelegate, null });
            collisionTable.Rows.Add(new Object[] { "sprint0.Enemies.Oktorok", "sprint0.Blocks.WaterBlock", MoveOktorokDelegate, null });
            collisionTable.Rows.Add(new Object[] { "sprint0.Enemies.Dragon", "sprint0.Blocks.WaterBlock", MoveDragonDelegate, null });


            collisionTable.Rows.Add(new Object[] { "sprint0.LinkObj.Link", "sprint0.Blocks.RedPyramidBlock", null, MoveDungeonPyramidBlockDelegate });
            collisionTable.Rows.Add(new Object[] { "sprint0.Enemies.Skeleton", "sprint0.Blocks.RedPyramidBlock", MoveSkeletonDelegate, null });
            collisionTable.Rows.Add(new Object[] { "sprint0.Enemies.Bokoblin", "sprint0.Blocks.RedPyramidBlock", MoveBokoblinDelegate, null });
            collisionTable.Rows.Add(new Object[] { "sprint0.Enemies.Oktorok", "sprint0.Blocks.RedPyramidBlock", MoveOktorokDelegate, null });
            collisionTable.Rows.Add(new Object[] { "sprint0.Enemies.Dragon", "sprint0.Blocks.RedPyramidBlock", MoveDragonDelegate, null });


            collisionTable.Rows.Add(new Object[] { "sprint0.LinkObj.Link", "sprint0.Blocks.GrassBlock", null, null });
            collisionTable.Rows.Add(new Object[] { "sprint0.Enemies.Skeleton", "sprint0.Blocks.GrassBlock", null, null });
            collisionTable.Rows.Add(new Object[] { "sprint0.Enemies.Bokoblin", "sprint0.Blocks.GrassBlock", null, null });
            collisionTable.Rows.Add(new Object[] { "sprint0.Enemies.Oktorok", "sprint0.Blocks.GrassBlock", null, null });
            collisionTable.Rows.Add(new Object[] { "sprint0.Enemies.Dragon", "sprint0.Blocks.GrassBlock", MoveDragonDelegate, null });


            collisionTable.Rows.Add(new Object[] { "sprint0.LinkObj.Link", "sprint0.Blocks.BlackBlock", null, null });
            collisionTable.Rows.Add(new Object[] { "sprint0.Enemies.Skeleton", "sprint0.Blocks.BlackBlock", null, null });
            collisionTable.Rows.Add(new Object[] { "sprint0.Enemies.Bokoblin", "sprint0.Blocks.BlackBlock", null, null });
            collisionTable.Rows.Add(new Object[] { "sprint0.Enemies.Oktorok", "sprint0.Blocks.BlackBlock", null, null });
            collisionTable.Rows.Add(new Object[] { "sprint0.Enemies.Dragon", "sprint0.Blocks.BlackBlock", MoveDragonDelegate, null });


            collisionTable.Rows.Add(new Object[] { "sprint0.LinkObj.Link", "sprint0.Blocks.DungeonDragonBlock", MoveLinkDelegate, null });
            collisionTable.Rows.Add(new Object[] { "sprint0.Enemies.Skeleton", "sprint0.Blocks.DungeonDragonBlock", MoveSkeletonDelegate, null });
            collisionTable.Rows.Add(new Object[] { "sprint0.Enemies.Bokoblin", "sprint0.Blocks.DungeonDragonBlock", MoveBokoblinDelegate, null });
            collisionTable.Rows.Add(new Object[] { "sprint0.Enemies.Oktorok", "sprint0.Blocks.DungeonDragonBlock", MoveOktorokDelegate, null });
            collisionTable.Rows.Add(new Object[] { "sprint0.Enemies.Dragon", "sprint0.Blocks.DungeonDragonBlock", MoveDragonDelegate, null });


            collisionTable.Rows.Add(new Object[] { "sprint0.LinkObj.Link", "sprint0.Blocks.BlueFishBlock", MoveLinkDelegate, null });
            collisionTable.Rows.Add(new Object[] { "sprint0.Enemies.Skeleton", "sprint0.Blocks.BlueFishBlock", MoveSkeletonDelegate, null });
            collisionTable.Rows.Add(new Object[] { "sprint0.Enemies.Bokoblin", "sprint0.Blocks.BlueFishBlock", MoveBokoblinDelegate, null });
            collisionTable.Rows.Add(new Object[] { "sprint0.Enemies.Oktorok", "sprint0.Blocks.BlueFishBlock", MoveOktorokDelegate, null });
            collisionTable.Rows.Add(new Object[] { "sprint0.Enemies.Dragon", "sprint0.Blocks.BlueFishBlock", MoveDragonDelegate, null });


            collisionTable.Rows.Add(new Object[] { "sprint0.LinkObj.Link", "sprint0.Blocks.BlueDragonBlock", MoveLinkDelegate, null });
            collisionTable.Rows.Add(new Object[] { "sprint0.Enemies.Skeleton", "sprint0.Blocks.BlueDragonBlock", MoveSkeletonDelegate, null });
            collisionTable.Rows.Add(new Object[] { "sprint0.Enemies.Bokoblin", "sprint0.Blocks.BlueDragonBlock", MoveBokoblinDelegate, null });
            collisionTable.Rows.Add(new Object[] { "sprint0.Enemies.Oktorok", "sprint0.Blocks.BlueDragonBlock", MoveOktorokDelegate, null });
            collisionTable.Rows.Add(new Object[] { "sprint0.Enemies.Dragon", "sprint0.Blocks.BlueDragonBlock", MoveDragonDelegate, null });

            // LINK ITEMS + GROUND ITEMS
            //Grounds
            collisionTable.Rows.Add(new Object[] { "sprint0.LinkObj.Link", "sprint0.Items.groundItems.GroundBigHeart", null, GroundBigHeartPickUpDelegate });
            collisionTable.Rows.Add(new Object[] { "sprint0.LinkObj.Link", "sprint0.Items.groundItems.GroundBlaze", null, GroundBlazeSteppedOnDelegate });
            collisionTable.Rows.Add(new Object[] { "sprint0.LinkObj.Link", "sprint0.Items.groundItems.GroundBoomerang", null, GroundBoomerangPickUpDelegate });
            collisionTable.Rows.Add(new Object[] { "sprint0.LinkObj.Link", "sprint0.Items.groundItems.GroundCompass", null, GroundCompassPickUpDelegate });
            collisionTable.Rows.Add(new Object[] { "sprint0.LinkObj.Link", "sprint0.Items.groundItems.GroundKey", null, GroundKeyPickUpDelegate });
            collisionTable.Rows.Add(new Object[] { "sprint0.LinkObj.Link", "sprint0.Items.groundItems.GroundPage", null, GroundPagePickUpDelegate });
            collisionTable.Rows.Add(new Object[] { "sprint0.LinkObj.Link", "sprint0.Items.groundItems.GroundTriforce", null, GroundTriforcePickUpDelegate });

            //LinkItems
            collisionTable.Rows.Add(new Object[] { "sprint0.Items.Bow", "sprint0.LinkObj.Link", null, null });
            collisionTable.Rows.Add(new Object[] { "sprint0.Items.Bow", "sprint0.Enemies.Bokoblin", BowImpactDelegate, MoveBokoblinAndTakeDamageDelegate });
            collisionTable.Rows.Add(new Object[] { "sprint0.Items.Bow", "sprint0.Enemies.Oktorok", BowImpactDelegate, MoveOktorokAndTakeDamageDelegate });
            collisionTable.Rows.Add(new Object[] { "sprint0.Items.Bow", "sprint0.Enemies.Skeleton", BowImpactDelegate, MoveSkeletonAndTakeDamageDelegate });
            collisionTable.Rows.Add(new Object[] { "sprint0.Items.Bow", "sprint0.Enemies.Dragon", BowImpactDelegate, MoveDragonAndTakeDamageDelegate });

            collisionTable.Rows.Add(new Object[] { "sprint0.Items.BetterBow", "sprint0.LinkObj.Link", null, null });
            collisionTable.Rows.Add(new Object[] { "sprint0.Items.BetterBow", "sprint0.Enemies.Bokoblin", BetterBowImpactDelegate, MoveBokoblinAndTakeDamageDelegate });
            collisionTable.Rows.Add(new Object[] { "sprint0.Items.BetterBow", "sprint0.Enemies.Oktorok", BetterBowImpactDelegate, MoveOktorokAndTakeDamageDelegate });
            collisionTable.Rows.Add(new Object[] { "sprint0.Items.BetterBow", "sprint0.Enemies.Skeleton", BetterBowImpactDelegate, MoveSkeletonAndTakeDamageDelegate });
            collisionTable.Rows.Add(new Object[] { "sprint0.Items.BetterBow", "sprint0.Enemies.Dragon", BetterBowImpactDelegate, MoveDragonAndTakeDamageDelegate });

            collisionTable.Rows.Add(new Object[] { "sprint0.Items.Boomerang", "sprint0.LinkObj.Link", null, null });
            collisionTable.Rows.Add(new Object[] { "sprint0.Items.Boomerang", "sprint0.Enemies.Bokoblin", BoomerangImpactDelegate, MoveBokoblinAndTakeDamageDelegate });
            collisionTable.Rows.Add(new Object[] { "sprint0.Items.Boomerang", "sprint0.Enemies.Oktorok", BoomerangImpactDelegate, MoveOktorokAndTakeDamageDelegate });
            collisionTable.Rows.Add(new Object[] { "sprint0.Items.Boomerang", "sprint0.Enemies.Skeleton", BoomerangImpactDelegate, MoveSkeletonAndTakeDamageDelegate });
            collisionTable.Rows.Add(new Object[] { "sprint0.Items.Boomerang", "sprint0.Enemies.Dragon", BoomerangImpactDelegate, MoveDragonAndTakeDamageDelegate });

            collisionTable.Rows.Add(new Object[] { "sprint0.Items.BetterBoomerang", "sprint0.LinkObj.Link", null, null });
            collisionTable.Rows.Add(new Object[] { "sprint0.Items.BetterBoomerang", "sprint0.Enemies.Bokoblin", BetterBoomerangImpactDelegate, MoveBokoblinAndTakeDamageDelegate });
            collisionTable.Rows.Add(new Object[] { "sprint0.Items.BetterBoomerang", "sprint0.Enemies.Oktorok", BetterBoomerangImpactDelegate, MoveOktorokAndTakeDamageDelegate });
            collisionTable.Rows.Add(new Object[] { "sprint0.Items.BetterBoomerang", "sprint0.Enemies.Skeleton", BetterBoomerangImpactDelegate, MoveSkeletonAndTakeDamageDelegate });
            collisionTable.Rows.Add(new Object[] { "sprint0.Items.BetterBoomerang", "sprint0.Enemies.Dragon", BetterBoomerangImpactDelegate, MoveDragonAndTakeDamageDelegate });

            collisionTable.Rows.Add(new Object[] { "sprint0.Items.Blaze", "sprint0.LinkObj.Link", null, null });
            collisionTable.Rows.Add(new Object[] { "sprint0.Items.Blaze", "sprint0.Enemies.Bokoblin", BlazeImpactDelegate, MoveBokoblinAndTakeDamageDelegate });
            collisionTable.Rows.Add(new Object[] { "sprint0.Items.Blaze", "sprint0.Enemies.Oktorok", BlazeImpactDelegate, MoveOktorokAndTakeDamageDelegate });
            collisionTable.Rows.Add(new Object[] { "sprint0.Items.Blaze", "sprint0.Enemies.Skeleton", BlazeImpactDelegate, MoveSkeletonAndTakeDamageDelegate });
            collisionTable.Rows.Add(new Object[] { "sprint0.Items.Blaze", "sprint0.Enemies.Dragon", BlazeImpactDelegate, MoveDragonAndTakeDamageDelegate });

            collisionTable.Rows.Add(new Object[] { "sprint0.Items.Bomb", "sprint0.Enemies.Bokoblin", BombImpactDelegate, MoveBokoblinAndTakeDamageDelegate });
            collisionTable.Rows.Add(new Object[] { "sprint0.Items.Bomb", "sprint0.Enemies.Oktorok", BombImpactDelegate, MoveOktorokAndTakeDamageDelegate });
            collisionTable.Rows.Add(new Object[] { "sprint0.Items.Bomb", "sprint0.Enemies.Skeleton", BombImpactDelegate, MoveSkeletonAndTakeDamageDelegate });
            collisionTable.Rows.Add(new Object[] { "sprint0.Items.Bomb", "sprint0.Enemies.Dragon", BombImpactDelegate, MoveDragonAndTakeDamageDelegate });
            collisionTable.Rows.Add(new Object[] { "sprint0.Items.Bomb", "sprint0.LinkObj.Link", null, null });

            collisionTable.Rows.Add(new Object[] { "sprint0.LinkSword", "sprint0.Enemies.Bokoblin", null, MoveBokoblinAndTakeDamageDelegate });
            collisionTable.Rows.Add(new Object[] { "sprint0.LinkSword", "sprint0.Enemies.Oktorok", null, MoveOktorokAndTakeDamageDelegate });
            collisionTable.Rows.Add(new Object[] { "sprint0.LinkSword", "sprint0.Enemies.Skeleton", null, MoveSkeletonAndTakeDamageDelegate });
            collisionTable.Rows.Add(new Object[] { "sprint0.LinkSword", "sprint0.Enemies.Dragon", null, MoveSkeletonAndTakeDamageDelegate });

            // COMBAT ON LINK COLLISIONS
            collisionTable.Rows.Add(new Object[] { "sprint0.LinkObj.Link", "sprint0.Enemies.Oktorok", MoveLinkAndTakeDamageDelegate, null });
            collisionTable.Rows.Add(new Object[] { "sprint0.LinkObj.Link", "sprint0.Enemies.Bokoblin", MoveLinkAndTakeDamageDelegate, null });
            collisionTable.Rows.Add(new Object[] { "sprint0.LinkObj.Link", "sprint0.Enemies.Skeleton", MoveLinkAndTakeDamageDelegate, null });
            collisionTable.Rows.Add(new Object[] { "sprint0.LinkObj.Link", "sprint0.Enemies.Dragon", MoveLinkAndTakeDamageDelegate, null });

            collisionTable.Rows.Add(new Object[] { "sprint0.LinkObj.Link", "sprint0.Items.BokoblinBoomerang", MoveLinkAndTakeDamageDelegate, null });
            collisionTable.Rows.Add(new Object[] { "sprint0.LinkObj.Link", "sprint0.Items.DragonBlaze", MoveLinkAndTakeDamageDelegate, null });
            collisionTable.Rows.Add(new Object[] { "sprint0.LinkObj.Link", "sprint0.Items.OktorokBlaze", MoveLinkAndTakeDamageDelegate, null });

            // LINK AND THE GROUND ITEMS.
            // play the item use Link animation here.
            collisionTable.Rows.Add(new Object[] { "sprint0.LinkObj.Link", "sprint0.Items.groundItems.GroundHeart", null, GroundItemPickUpDelegate });
            collisionTable.Rows.Add(new Object[] { "sprint0.LinkObj.Link", "sprint0.Items.groundItems.GroundCompass", null, GroundItemPickUpDelegate });
            collisionTable.Rows.Add(new Object[] { "sprint0.LinkObj.Link", "sprint0.Items.groundItems.GroundBigHeart", null, GroundItemPickUpDelegate });
            collisionTable.Rows.Add(new Object[] { "sprint0.LinkObj.Link", "sprint0.Items.groundItems.GroundKey", null, GroundItemPickUpDelegate });
            collisionTable.Rows.Add(new Object[] { "sprint0.LinkObj.Link", "sprint0.Items.groundItems.GroundPage", null, GroundItemPickUpDelegate });
            collisionTable.Rows.Add(new Object[] { "sprint0.LinkObj.Link", "sprint0.Items.groundItems.GroundRupee", null, GroundItemPickUpDelegate });
            collisionTable.Rows.Add(new Object[] { "sprint0.LinkObj.Link", "sprint0.Items.groundItems.GroundTriforce", null, GroundItemPickUpDelegate });
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
        //BLOCKS
        private void MoveDungeonPyramidBlock(CollisionDetector.CollisionType collisionType, IGameObject obj)
        {
            DungeonPyramidBlock block = (DungeonPyramidBlock)obj;
            switch (collisionType)
            {
                case CollisionDetector.CollisionType.TOP:
                    block.YValue++;
                    break;
                case CollisionDetector.CollisionType.BOTTOM:
                    block.YValue--;
                    break;
                case CollisionDetector.CollisionType.LEFT:
                    block.XValue++;
                    break;
                case CollisionDetector.CollisionType.RIGHT:
                    block.XValue--;
                    break;
            }
        }

        //LINK
        private void MoveLink(CollisionDetector.CollisionType collisionType, IGameObject obj)
        {
            // I need a better way to change Link's stuff without making such a mess.
            LinkObj.Link link = (LinkObj.Link)obj;
            switch (collisionType)
            {
                case CollisionDetector.CollisionType.TOP:
                    link.YVal -= 1;
                    break;
                case CollisionDetector.CollisionType.BOTTOM:
                    link.YVal += 1;
                    break;
                case CollisionDetector.CollisionType.LEFT:
                    link.XVal -= 1;
                    break;
                case CollisionDetector.CollisionType.RIGHT:
                    link.XVal += 1;
                    break;
            }
        }

        private void MoveLinkAndTakeDamage(CollisionDetector.CollisionType collisionType, IGameObject obj)
        {
            LinkObj.Link link = (LinkObj.Link)obj;
            switch (collisionType)
            {
                case CollisionDetector.CollisionType.TOP:
                    link.YVal -= 25;
                    break;
                case CollisionDetector.CollisionType.BOTTOM:
                    link.YVal += 25;
                    break;
                case CollisionDetector.CollisionType.LEFT:
                    link.XVal -= 25;
                    break;
                case CollisionDetector.CollisionType.RIGHT:
                    link.XVal += 25;
                    break;
            }
            Ocarina.PlaySoundEffect(Ocarina.SoundEffects.LINK_TAKE_DAMAGE);
            link.LinkTakeDamage();
        }

        /*
         * LINK ITEMS
         * this is expecting the item... do not throw the entire item system obj
         */

        //Bows
        private void BowImpact(CollisionDetector.CollisionType collisionType, IGameObject obj)
        {
            Bow bow = (Bow)obj;
            bow.thisStateMachine.CeaseUse();
        }
        private void BetterBowImpact(CollisionDetector.CollisionType collisionType, IGameObject obj)
        {
            BetterBow betterBow = (BetterBow)obj;
            betterBow.thisStateMachine.CeaseUse();
        }

        //Boomerangs
        private void BoomerangImpact(CollisionDetector.CollisionType collisionType, IGameObject obj)
        {
            Boomerang boomerang = (Boomerang)obj;
            boomerang.thisStateMachine.CeaseUse();
        }
        private void BetterBoomerangImpact(CollisionDetector.CollisionType collisionType, IGameObject obj)
        {
            BetterBoomerang betterBoomerang = (BetterBoomerang)obj;
            betterBoomerang.thisStateMachine.CeaseUse();
        }

        //Blaze
        private void BlazeImpact(CollisionDetector.CollisionType collisionType, IGameObject obj)
        {
            Blaze blaze = (Blaze)obj;
            blaze.thisStateMachine.CeaseUse();
        }

        //Bomb
        private void BombImpact(CollisionDetector.CollisionType collisionType, IGameObject obj)
        {
            // Collision with bomb in dormant state causes explosion to occur.
            //COUPLING! EW!
            Bomb bomb = (Bomb)obj;
            if (bomb.bombTicks < bomb.maxBombTicks)
            {
                bomb.bombTicks = bomb.maxBombTicks;
            }
        }

        /*
         * GROUND ITEMS
         * Inventory system changes are included in these methods.
         */

        private void GroundBigHeartPickUp(CollisionDetector.CollisionType collisionType, IGameObject obj)
        {
            GroundBigHeart groundBigHeart = (GroundBigHeart)obj;
            Ocarina.PlaySoundEffect(Ocarina.SoundEffects.GET_GROUND_HEART_KEY);
            groundBigHeart.PickUp();
            // code that impacts inventory system goes here.
        }

        private void GroundBoomerangPickUp(CollisionDetector.CollisionType collisionType, IGameObject obj)
        {
            GroundBoomerang groundBoomerang = (GroundBoomerang)obj;
            Ocarina.PlaySoundEffect(Ocarina.SoundEffects.LINK_ITEM_GET);
            groundBoomerang.PickUp();
            // code that impacts inventory system goes here.
        }
        private void GroundCompassPickUp(CollisionDetector.CollisionType collisionType, IGameObject obj)
        {
            GroundCompass groundCompass = (GroundCompass)obj;
            groundCompass.PickUp();
            Ocarina.PlaySoundEffect(Ocarina.SoundEffects.LINK_ITEM_GET);

            // code that impacts inventory system goes here.
        }

        private void GroundKeyPickUp(CollisionDetector.CollisionType collisionType, IGameObject obj)
        {
            GroundKey groundKey = (GroundKey)obj;
            groundKey.PickUp();
            Ocarina.PlaySoundEffect(Ocarina.SoundEffects.GET_GROUND_HEART_KEY);

            // code that impacts inventory system goes here.
        }

        private void GroundPagePickUp(CollisionDetector.CollisionType collisionType, IGameObject obj)
        {
            GroundPage groundPage = (GroundPage)obj;
            groundPage.PickUp();
            Ocarina.PlaySoundEffect(Ocarina.SoundEffects.LINK_ITEM_GET);

            // code that impacts inventory system goes here.
        }

        private void GroundTriforcePickUp(CollisionDetector.CollisionType collisionType, IGameObject obj)
        {
            GroundTriforce groundTriforce = (GroundTriforce)obj;
            groundTriforce.PickUp();
            Ocarina.PlaySoundEffect(Ocarina.SoundEffects.FANFARE);
            // code that impacts inventory system goes here.
        }

        private void GroundBlazeSteppedOn(CollisionDetector.CollisionType collisionType, IGameObject obj)
        {
            GroundBlaze groundBlaze = (GroundBlaze)obj;
            groundBlaze.PickUp();
            // code that impacts inventory system goes here.
        }

        // ENEMIES
        /*
         * Like Link, Enemies have methods to move pos
         * Unlike Link, Enemies have knockback built into their take damage calls. Neat. Direction is built in too, but they should knock back in the direction they were hit.
         */
        private void MoveOktorok(CollisionDetector.CollisionType collisionType, IGameObject obj)
        {
            Oktorok enemy = (Oktorok)obj;
            switch (collisionType)
            {
                case CollisionDetector.CollisionType.TOP:
                    enemy.ChangeEnemyY(-35);
                    break;
                case CollisionDetector.CollisionType.BOTTOM:
                    enemy.ChangeEnemyY(35);
                    break;
                case CollisionDetector.CollisionType.LEFT:
                    enemy.ChangeEnemyX(-35);
                    break;
                case CollisionDetector.CollisionType.RIGHT:
                    enemy.ChangeEnemyX(35);
                    break;
            }
        }

        private void MoveOktorokAndTakeDamage(CollisionDetector.CollisionType collisionType, IGameObject obj)
        {
            Oktorok enemy = (Oktorok)obj;
            switch (collisionType)
            {
                case CollisionDetector.CollisionType.TOP:
                    enemy.ChangeEnemyY(-35);
                    break;
                case CollisionDetector.CollisionType.BOTTOM:
                    enemy.ChangeEnemyY(35);
                    break;
                case CollisionDetector.CollisionType.LEFT:
                    enemy.ChangeEnemyX(-35);
                    break;
                case CollisionDetector.CollisionType.RIGHT:
                    enemy.ChangeEnemyX(35);
                    break;
            }
            Ocarina.PlaySoundEffect(Ocarina.SoundEffects.ENEMY_HIT);
            enemy.TakeDamage();
        }

        private void MoveSkeleton(CollisionDetector.CollisionType collisionType, IGameObject obj)
        {
            Skeleton enemy = (Skeleton)obj;
            switch (collisionType)
            {
                case CollisionDetector.CollisionType.TOP:
                    enemy.ChangeEnemyY(-35);
                    break;
                case CollisionDetector.CollisionType.BOTTOM:
                    enemy.ChangeEnemyY(35);
                    break;
                case CollisionDetector.CollisionType.LEFT:
                    enemy.ChangeEnemyX(-35);
                    break;
                case CollisionDetector.CollisionType.RIGHT:
                    enemy.ChangeEnemyX(35);
                    break;
            }
        }

        private void MoveSkeletonAndTakeDamage(CollisionDetector.CollisionType collisionType, IGameObject obj)
        {
            Skeleton enemy = (Skeleton)obj;
            switch (collisionType)
            {
                case CollisionDetector.CollisionType.TOP:
                    enemy.ChangeEnemyY(-35);
                    break;
                case CollisionDetector.CollisionType.BOTTOM:
                    enemy.ChangeEnemyY(35);
                    break;
                case CollisionDetector.CollisionType.LEFT:
                    enemy.ChangeEnemyX(-35);
                    break;
                case CollisionDetector.CollisionType.RIGHT:
                    enemy.ChangeEnemyX(35);
                    break;
            }
            enemy.takeDamage();
            Ocarina.PlaySoundEffect(Ocarina.SoundEffects.ENEMY_HIT);
        }

        private void MoveBokoblin(CollisionDetector.CollisionType collisionType, IGameObject obj)
        {
            Bokoblin enemy = (Bokoblin)obj;
            switch (collisionType)
            {
                case CollisionDetector.CollisionType.TOP:
                    enemy.ChangeEnemyY(-50);
                    break;
                case CollisionDetector.CollisionType.BOTTOM:
                    enemy.ChangeEnemyY(50);
                    break;
                case CollisionDetector.CollisionType.LEFT:
                    enemy.ChangeEnemyX(-50);
                    break;
                case CollisionDetector.CollisionType.RIGHT:
                    enemy.ChangeEnemyX(50);
                    break;
            }
        }

        private void MoveBokoblinAndTakeDamage(CollisionDetector.CollisionType collisionType, IGameObject obj)
        {
            Bokoblin enemy = (Bokoblin)obj;
            switch (collisionType)
            {
                case CollisionDetector.CollisionType.TOP:
                    enemy.ChangeEnemyY(-50);
                    break;
                case CollisionDetector.CollisionType.BOTTOM:
                    enemy.ChangeEnemyY(50);
                    break;
                case CollisionDetector.CollisionType.LEFT:
                    enemy.ChangeEnemyX(-50);
                    break;
                case CollisionDetector.CollisionType.RIGHT:
                    enemy.ChangeEnemyX(50);
                    break;
            }
            enemy.TakeDamage();
            Ocarina.PlaySoundEffect(Ocarina.SoundEffects.ENEMY_HIT);

        }

        private void MoveDragon(CollisionDetector.CollisionType collisionType, IGameObject obj)
        {
            Dragon enemy = (Dragon)obj;
            switch (collisionType)
            {
                case CollisionDetector.CollisionType.TOP:
                    enemy.ChangeEnemyY(-50);
                    break;
                case CollisionDetector.CollisionType.BOTTOM:
                    enemy.ChangeEnemyY(50);
                    break;
                case CollisionDetector.CollisionType.LEFT:
                    enemy.ChangeEnemyX(-50);
                    break;
                case CollisionDetector.CollisionType.RIGHT:
                    enemy.ChangeEnemyX(50);
                    break;
            }
        }

        private void MoveDragonAndTakeDamage(CollisionDetector.CollisionType collisionType, IGameObject obj)
        {
            Dragon enemy = (Dragon)obj;
            switch (collisionType)
            {
                case CollisionDetector.CollisionType.TOP:
                    enemy.ChangeEnemyY(-50);
                    break;
                case CollisionDetector.CollisionType.BOTTOM:
                    enemy.ChangeEnemyY(50);
                    break;
                case CollisionDetector.CollisionType.LEFT:
                    enemy.ChangeEnemyX(-50);
                    break;
                case CollisionDetector.CollisionType.RIGHT:
                    enemy.ChangeEnemyX(50);
                    break;
            }
            enemy.takeDamage();
            Ocarina.PlaySoundEffect(Ocarina.SoundEffects.BOSS_TAKE_DAMAGE);
        }

        // Ground Items handle their own "pick up call"
        private void GenericGroundItemPickUp(CollisionDetector.CollisionType collisionType, IGameObject obj)
        {
            IGroundItem item = (IGroundItem)obj;
            item.PickUp();
            String itemType = item.GetType().ToString();
            if (itemType.Equals("GroundRupee"))
            {
                Ocarina.PlaySoundEffect(Ocarina.SoundEffects.GET_GROUND_RUPEE);

            }
            else if (itemType.Equals("GroundKey") || itemType.Equals("GroundHeart"))
            {
                Ocarina.PlaySoundEffect(Ocarina.SoundEffects.GET_GROUND_HEART_KEY);
            }
            else
            {
                Ocarina.PlaySoundEffect(Ocarina.SoundEffects.LINK_ITEM_GET);
            }

        }
    }
}