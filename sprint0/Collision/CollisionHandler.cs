using System;
using System.Collections.Generic;
using System.Data;
using sprint0.Link;
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
                if (row["ObjectA"].Equals(objAType) && row["ObjectB"].Equals(objBType)) {
                    rowWithDelegates = row;
                    handleExists = true;
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
            collisionTable.Columns.Add("CollisionType");
            collisionTable.Columns.Add("HandleA");
            collisionTable.Columns.Add("HandleB");
			LinkDelegate MoveLinkDelegate = MoveLink;
			LinkDelegate MoveLinkAndTakeDamageDelegate = MoveLinkAndTakeDamage;
            DungeonPyramidBlockDelegate MoveDungeonPyramidBlockDelegate = MoveDungeonPyramidBlock;
            GroundBigHeartDelegate GroundBigHeartPickUpDelegate = GroundBigHeartPickUp;
            GroundBlazeDelegate GroundBlazeSteppedOnDelegate = GroundBlazeSteppedOn;
            GroundBoomerangDelegate GroundBoomerangPickUpDelegate = GroundBoomerangPickUp;
            GroundCompassDelegate GroundCompassPickUpDelegate = GroundCompassPickUp;
            GroundKeyDelegate GroundKeyPickUpDelegate = GroundKeyPickUp;
            GroundPageDelegate GroundPagePickUpDelegate = GroundPagePickUp;
            GroundTriforceDelegate GroundTriforcePickUpDelegate = GroundTriforcePickUp;
            OktorokDelegate MoveOktorokDelegate = MoveOktorok;
            OktorokDelegate MoveOktorokAndTakeDamageDelegate = MoveOktorokAndTakeDamage;
            SkeletonDelegate MoveSkeletonDelegate = MoveSkeleton;
            SkeletonDelegate MoveSkeletonAndTakeDamageDelegate = MoveSkeletonAndTakeDamage;
            BokoblinDelegate MoveBokoblinDelegate = MoveBokoblin;
            BokoblinDelegate MoveBokoblinAndTakeDamageDelegate = MoveBokoblinAndTakeDamage;
            BowDelegate BowImpactDelegate = BowImpact;
            BetterBowDelegate BetterBowImpactDelegate = BetterBowImpact;
            BoomerangDelegate BoomerangImpactDelegate = BoomerangImpact; 
            BetterBoomerangDelegate BetterBoomerangImpactDelegate = BetterBoomerangImpact;
            BlazeDelegate BlazeImpactDelegate = BlazeImpact;
            BombDelegate BombImpactDelegate = BombImpact;

            // BOUNDARIES
            collisionTable.Rows.Add(new Object[] { "Link", "Boundary", MoveLinkDelegate, null });
            collisionTable.Rows.Add(new Object[] { "Skeleton", "Boundary", MoveSkeletonDelegate, null });
            collisionTable.Rows.Add(new Object[] { "Bokoblin", "Boundary", MoveBokoblinDelegate, null });
            collisionTable.Rows.Add(new Object[] { "Oktorok", "Boundary", MoveOktorokDelegate, null });
            collisionTable.Rows.Add(new Object[] { "Bow", "Boundary", BowImpactDelegate, null });
            collisionTable.Rows.Add(new Object[] { "BetterBow", "Boundary", BetterBowImpactDelegate, null });
            collisionTable.Rows.Add(new Object[] { "Boomerang", "Boundary", BoomerangImpactDelegate, null });
            collisionTable.Rows.Add(new Object[] { "BetterBoomerang", "Boundary", BetterBoomerangImpactDelegate, null });
            collisionTable.Rows.Add(new Object[] { "Blaze", "Boundary", BlazeImpactDelegate, null });
            collisionTable.Rows.Add(new Object[] { "Bomb", "Boundary", null, null });

            // BLOCKS
            collisionTable.Rows.Add(new Object[] { "Link", "DungeonDragonBlock", MoveLinkDelegate, null });
            collisionTable.Rows.Add(new Object[] { "Skeleton", "DungeonDragonBlock", MoveSkeletonDelegate, null });
            collisionTable.Rows.Add(new Object[] { "Bokoblin", "DungeonDragonBlock", MoveBokoblinDelegate, null });
            collisionTable.Rows.Add(new Object[] { "Oktorok", "DungeonDragonBlock", MoveOktorokDelegate, null });

            collisionTable.Rows.Add(new Object[] { "Link", "DungeonFishBlock", MoveLinkDelegate, null });
            collisionTable.Rows.Add(new Object[] { "Skeleton", "DungeonFishBlock", MoveSkeletonDelegate, null });
            collisionTable.Rows.Add(new Object[] { "Bokoblin", "DungeonFishBlock", MoveBokoblinDelegate, null });
            collisionTable.Rows.Add(new Object[] { "Oktorok", "DungeonFishBlock", MoveOktorokDelegate, null });

            collisionTable.Rows.Add(new Object[] { "Link", "DungeonPyramidBlock", null, MoveDungeonPyramidBlockDelegate });
            collisionTable.Rows.Add(new Object[] { "Skeleton", "DungeonPyramidBlock", MoveSkeletonDelegate, null });
            collisionTable.Rows.Add(new Object[] { "Bokoblin", "DungeonPyramidBlock", MoveBokoblinDelegate, null });
            collisionTable.Rows.Add(new Object[] { "Oktorok", "DungeonPyramidBlock", MoveOktorokDelegate, null });

            collisionTable.Rows.Add(new Object[] { "Link", "WaterBlock", MoveLinkDelegate, null });
            collisionTable.Rows.Add(new Object[] { "Skeleton", "WaterBlock", MoveSkeletonDelegate, null });
            collisionTable.Rows.Add(new Object[] { "Bokoblin", "WaterBlock", MoveBokoblinDelegate, null });
            collisionTable.Rows.Add(new Object[] { "Oktorok", "WaterBlock", MoveOktorokDelegate, null });

            collisionTable.Rows.Add(new Object[] { "Link", "RedPyramidBlock", null, MoveDungeonPyramidBlockDelegate });
            collisionTable.Rows.Add(new Object[] { "Skeleton", "RedPyramidBlock", MoveSkeletonDelegate, null });
            collisionTable.Rows.Add(new Object[] { "Bokoblin", "RedPyramidBlock", MoveBokoblinDelegate, null });
            collisionTable.Rows.Add(new Object[] { "Oktorok", "RedPyramidBlock", MoveOktorokDelegate, null });

            collisionTable.Rows.Add(new Object[] { "Link", "GrassBlock", null, null });
            collisionTable.Rows.Add(new Object[] { "Skeleton", "GrassBlock", null, null });
            collisionTable.Rows.Add(new Object[] { "Bokoblin", "GrassBlock", null, null });
            collisionTable.Rows.Add(new Object[] { "Oktorok", "GrassBlock", null, null });

            collisionTable.Rows.Add(new Object[] { "Link", "BlackBlock", null, null });
            collisionTable.Rows.Add(new Object[] { "Skeleton", "BlackBlock", null, null });
            collisionTable.Rows.Add(new Object[] { "Bokoblin", "BlackBlock", null, null });
            collisionTable.Rows.Add(new Object[] { "Oktorok", "BlackBlock", null, null });

            collisionTable.Rows.Add(new Object[] { "Link", "DungeonBlueBlock", null, null });
            collisionTable.Rows.Add(new Object[] { "Skeleton", "DungeonBlueBlock", null, null });
            collisionTable.Rows.Add(new Object[] { "Bokoblin", "DungeonBlueBlock", null, null });
            collisionTable.Rows.Add(new Object[] { "Oktorok", "DungeonBlueBlock", null, null });

            collisionTable.Rows.Add(new Object[] { "Link", "BlueFishBlock", MoveLinkDelegate, null });
            collisionTable.Rows.Add(new Object[] { "Skeleton", "BlueFishBlock", MoveSkeletonDelegate, null });
            collisionTable.Rows.Add(new Object[] { "Bokoblin", "BlueFishBlock", MoveBokoblinDelegate, null });
            collisionTable.Rows.Add(new Object[] { "Oktorok", "BlueFishBlock", MoveOktorokDelegate, null });

            collisionTable.Rows.Add(new Object[] { "Link", "BlueDragonBlock", MoveLinkDelegate, null });
            collisionTable.Rows.Add(new Object[] { "Skeleton", "BlueDragonBlock", MoveSkeletonDelegate, null });
            collisionTable.Rows.Add(new Object[] { "Bokoblin", "BlueDragonBlock", MoveBokoblinDelegate, null });
            collisionTable.Rows.Add(new Object[] { "Oktorok", "BlueDragonBlock", MoveOktorokDelegate, null });

            // LINK ITEMS + GROUND ITEMS
            //Grounds
            collisionTable.Rows.Add(new Object[] { "Link", "GroundBigHeart", null, GroundBigHeartPickUpDelegate });
            collisionTable.Rows.Add(new Object[] { "Link", "GroundBlaze", null, GroundBlazeSteppedOnDelegate });
            collisionTable.Rows.Add(new Object[] { "Link", "GroundBoomerang", null, GroundBoomerangPickUpDelegate });
            collisionTable.Rows.Add(new Object[] { "Link", "GroundCompass", null, GroundCompassPickUpDelegate });
            collisionTable.Rows.Add(new Object[] { "Link", "GroundKey", null, GroundKeyPickUpDelegate });
            collisionTable.Rows.Add(new Object[] { "Link", "GroundPage", null, GroundPagePickUpDelegate });
            collisionTable.Rows.Add(new Object[] { "Link", "GroundTriforce", null, GroundTriforcePickUpDelegate });

            //LinkItems
            collisionTable.Rows.Add(new Object[] { "Bow", "Link", null, null });
            collisionTable.Rows.Add(new Object[] { "Bow", "Bokoblin", BowImpactDelegate, MoveBokoblinAndTakeDamageDelegate });
            collisionTable.Rows.Add(new Object[] { "Bow", "Oktorok", BowImpactDelegate, MoveOktorokAndTakeDamageDelegate });
            collisionTable.Rows.Add(new Object[] { "Bow", "Skeleton", BowImpactDelegate, MoveSkeletonAndTakeDamageDelegate });

            collisionTable.Rows.Add(new Object[] { "BetterBow", "Link", null, null });
            collisionTable.Rows.Add(new Object[] { "BetterBow", "Bokoblin", BetterBowImpactDelegate, MoveBokoblinAndTakeDamageDelegate });
            collisionTable.Rows.Add(new Object[] { "BetterBow", "Oktorok", BetterBowImpactDelegate, MoveOktorokAndTakeDamageDelegate });
            collisionTable.Rows.Add(new Object[] { "BetterBow", "Skeleton", BetterBowImpactDelegate, MoveSkeletonAndTakeDamageDelegate });

            collisionTable.Rows.Add(new Object[] { "Boomerang", "Link", null, null });
            collisionTable.Rows.Add(new Object[] { "Boomerang", "Bokoblin", BoomerangImpactDelegate, MoveBokoblinAndTakeDamageDelegate });
            collisionTable.Rows.Add(new Object[] { "Boomerang", "Oktorok", BoomerangImpactDelegate, MoveOktorokAndTakeDamageDelegate });
            collisionTable.Rows.Add(new Object[] { "Boomerang", "Skeleton", BoomerangImpactDelegate, MoveSkeletonAndTakeDamageDelegate });

            collisionTable.Rows.Add(new Object[] { "BetterBoomerang", "Link", null, null });
            collisionTable.Rows.Add(new Object[] { "BetterBoomerang", "Bokoblin", BetterBoomerangImpactDelegate, MoveBokoblinAndTakeDamageDelegate });
            collisionTable.Rows.Add(new Object[] { "BetterBoomerang", "Oktorok", BetterBoomerangImpactDelegate, MoveOktorokAndTakeDamageDelegate });
            collisionTable.Rows.Add(new Object[] { "BetterBoomerang", "Skeleton", BetterBoomerangImpactDelegate, MoveSkeletonAndTakeDamageDelegate });

            collisionTable.Rows.Add(new Object[] { "Blaze", "Link", null, null });
            collisionTable.Rows.Add(new Object[] { "Blaze", "Bokoblin", BlazeImpactDelegate, MoveBokoblinAndTakeDamageDelegate });
            collisionTable.Rows.Add(new Object[] { "Blaze", "Oktorok", BlazeImpactDelegate, MoveOktorokAndTakeDamageDelegate });
            collisionTable.Rows.Add(new Object[] { "Blaze", "Skeleton", BlazeImpactDelegate, MoveSkeletonAndTakeDamageDelegate });

            collisionTable.Rows.Add(new Object[] { "Bomb", "Bokoblin", BombImpactDelegate, MoveBokoblinAndTakeDamageDelegate });
            collisionTable.Rows.Add(new Object[] { "Bomb", "Oktorok", BombImpactDelegate, MoveOktorokAndTakeDamageDelegate });
            collisionTable.Rows.Add(new Object[] { "Bomb", "Skeleton", BombImpactDelegate, MoveSkeletonAndTakeDamageDelegate });
            collisionTable.Rows.Add(new Object[] { "Bomb", "Link", null, null });

            collisionTable.Rows.Add(new Object[] { "Sword", "Bokoblin", null, MoveBokoblinAndTakeDamageDelegate });
            collisionTable.Rows.Add(new Object[] { "Sword", "Oktorok", null, MoveOktorokAndTakeDamageDelegate });
            collisionTable.Rows.Add(new Object[] { "Sword", "Skeleton", null, MoveSkeletonAndTakeDamageDelegate });
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
        private delegate void DungeonPyramidBlockDelegate(CollisionDetector.CollisionType collisionType, DungeonPyramidBlock block);
        private void MoveDungeonPyramidBlock(CollisionDetector.CollisionType collisionType, DungeonPyramidBlock block)
        {
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
        private delegate void LinkDelegate(CollisionDetector.CollisionType collisionType, Link.Link link);
        private void MoveLink (CollisionDetector.CollisionType collisionType, Link.Link link) {
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

        private void MoveLinkAndTakeDamage(CollisionDetector.CollisionType collisionType, Link.Link link)
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
            Ocarina.PlaySoundEffect(Ocarina.SoundEffects.LINK_TAKE_DAMAGE);
        }

        /*
         * LINK ITEMS
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
            // Collision with bomb in dormant state causes explosion to occur.
            //COUPLING! EW!
            if (bomb.bombTicks < bomb.maxBombTicks)
            {
                bomb.bombTicks = bomb.maxBombTicks;
            }
        }

        /*
         * GROUND ITEMS
         * Inventory system changes are included in these methods.
         */

        private delegate void GroundBigHeartDelegate(CollisionDetector.CollisionType collisionType, GroundBigHeart groundBigHeart);
        private void GroundBigHeartPickUp(CollisionDetector.CollisionType collisionType, GroundBigHeart groundBigHeart)
        {
            groundBigHeart.PickUp();
            Ocarina.PlaySoundEffect(Ocarina.SoundEffects.GET_GROUND_HEART_KEY);
            // code that impacts inventory system goes here.
        }

        private delegate void GroundBoomerangDelegate(CollisionDetector.CollisionType collisionType, GroundBoomerang groundBoomerang);
        private void GroundBoomerangPickUp(CollisionDetector.CollisionType collisionType, GroundBoomerang groundBoomerang)
        {
            groundBoomerang.PickUp();
            Ocarina.PlaySoundEffect(Ocarina.SoundEffects.LINK_ITEM_GET);
            // code that impacts inventory system goes here.
        }
        private delegate void GroundCompassDelegate(CollisionDetector.CollisionType collisionType, GroundCompass groundCompass);
        private void GroundCompassPickUp(CollisionDetector.CollisionType collisionType, GroundCompass groundCompass)
        {
            groundCompass.PickUp();
            Ocarina.PlaySoundEffect(Ocarina.SoundEffects.LINK_ITEM_GET);
            // code that impacts inventory system goes here.
        }

        private delegate void GroundKeyDelegate(CollisionDetector.CollisionType collisionType, GroundKey groundKeyDelegate);
        private void GroundKeyPickUp(CollisionDetector.CollisionType collisionType, GroundKey groundKey)
        {
            groundKey.PickUp();
            Ocarina.PlaySoundEffect(Ocarina.SoundEffects.GET_GROUND_HEART_KEY);
            // code that impacts inventory system goes here.
        }

        private delegate void GroundPageDelegate(CollisionDetector.CollisionType collisionType, GroundPage groundPage);
        private void GroundPagePickUp(CollisionDetector.CollisionType collisionType, GroundPage groundPage)
        {
            groundPage.PickUp();
            Ocarina.PlaySoundEffect(Ocarina.SoundEffects.LINK_ITEM_GET);
            // code that impacts inventory system goes here.
        }

        private delegate void GroundTriforceDelegate(CollisionDetector.CollisionType collisionType, GroundTriforce groundTriforce);
        private void GroundTriforcePickUp(CollisionDetector.CollisionType collisionType, GroundTriforce groundTriforce)
        {
            groundTriforce.PickUp();
            WindWaker.PauseSong(WindWaker.Songs.DUNGEON); //Should pause this song if playing.
            WindWaker.PlaySong(WindWaker.Songs.TRIFORCE_OBTAIN);
            // code that impacts inventory system goes here.
        }

        private delegate void GroundBlazeDelegate(CollisionDetector.CollisionType collisionType, GroundBlaze groundBlaze);
        private void GroundBlazeSteppedOn(CollisionDetector.CollisionType collisionType, GroundBlaze groundBlaze)
        {
            groundBlaze.PickUp();
            Ocarina.PlaySoundEffect(Ocarina.SoundEffects.LINK_ITEM_GET);
            // code that impacts inventory system goes here.
        }

        // ENEMIES
        /*
         * Like Link, Enemies have methods to move pos
         * Unlike Link, Enemies have knockback built into their take damage calls. Neat. Direction is built in too, but they should knock back in the direction they were hit.
         */
        private delegate void OktorokDelegate(CollisionDetector.CollisionType collisionType, Oktorok enemy);
        private void MoveOktorok(CollisionDetector.CollisionType collisionType, Oktorok enemy)
        {
            switch (collisionType)
            {
                case CollisionDetector.CollisionType.TOP:
                    enemy.EnemyUp();
                    break;
                case CollisionDetector.CollisionType.BOTTOM:
                    enemy.EnemyDown();
                    break;
                case CollisionDetector.CollisionType.LEFT:
                    enemy.EnemyLeft();
                    break;
                case CollisionDetector.CollisionType.RIGHT:
                    enemy.EnemyRight();
                    break;
            }
        }

        private void MoveOktorokAndTakeDamage(CollisionDetector.CollisionType collisionType, Oktorok enemy)
        {
            enemy.TakeDamage();
            Ocarina.PlaySoundEffect(Ocarina.SoundEffects.ENEMY_HIT);
        }

        private delegate void SkeletonDelegate(CollisionDetector.CollisionType collisionType, Skeleton enemy);
        private void MoveSkeleton(CollisionDetector.CollisionType collisionType, Skeleton enemy)
        {
            switch (collisionType)
            {
                case CollisionDetector.CollisionType.TOP:
                    enemy.EnemyUp();
                    break;
                case CollisionDetector.CollisionType.BOTTOM:
                    enemy.EnemyDown();
                    break;
                case CollisionDetector.CollisionType.LEFT:
                    enemy.EnemyLeft();
                    break;
                case CollisionDetector.CollisionType.RIGHT:
                    enemy.EnemyRight();
                    break;
            }
        }

        private void MoveSkeletonAndTakeDamage(CollisionDetector.CollisionType collisionType, Skeleton enemy)
        {

            enemy.takeDamage();
            Ocarina.PlaySoundEffect(Ocarina.SoundEffects.ENEMY_HIT);
        }

        private delegate void BokoblinDelegate (CollisionDetector.CollisionType collisionType, Bokoblin enemy);
        private void MoveBokoblin(CollisionDetector.CollisionType collisionType, Bokoblin enemy)
        {
            switch (collisionType)
            {
                case CollisionDetector.CollisionType.TOP:
                    enemy.EnemyUp();
                    break;
                case CollisionDetector.CollisionType.BOTTOM:
                    enemy.EnemyDown();
                    break;
                case CollisionDetector.CollisionType.LEFT:
                    enemy.EnemyLeft();
                    break;
                case CollisionDetector.CollisionType.RIGHT:
                    enemy.EnemyRight();
                    break;
            }
        }

        private void MoveBokoblinAndTakeDamage(CollisionDetector.CollisionType collisionType, Bokoblin enemy)
        {

            enemy.TakeDamage();
            Ocarina.PlaySoundEffect(Ocarina.SoundEffects.ENEMY_HIT);
        }

    }
}

