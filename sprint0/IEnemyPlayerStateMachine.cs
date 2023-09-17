using System;

/*Specifically handles both enemy and player staes, as they share most attributes, with Link's major difference being
 * the ability to be controlled.
 * 
 * Items are handled as their own entitiy in their own state machine
 */
public interface IEnemyPlayerStateMachine
{
    /*Since there are four directions, the specified direction change cannot be used as a sinlge boolean, since there are four states. Specifying
	 what direction to face is needed.*/
    public void ChangeDirection(String direction);

    /*Updates sprite to an attacking sprite, this would need to be reverse at the end of the animation as it isn't a perminant state
	
	 Projectiles would have to revert Link and the enemy's state prior to it finishing in order to be able to move while the projectile fires
	 Completes with the projectile being exploded/ removed from the game. This is a guess and may need tweaking with actual implementation
	 */
    public void Attack();

    /*Updates sprite to a damaged sprite, can use the mario star example as a guideline for invincibility frames, needs to be reversed at the end while keeping the health decrease*/
    public void TakeDamage();

    /*This takes the object to the death state, for enemies disappearing and Link should cause his death animation
     
      May be unnecessary if we use the TakeDamage state to automatically handle this. 
     */
    public void Die();

}
