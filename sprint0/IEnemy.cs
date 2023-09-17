using System;


public interface IEnemy 
{
	/*All enemies must attack, this can either be by firing a projectile, contact damage, or any other type we decide to add*/
	public void Attack();

	/*Decreases the health saved in a local variable based on the enemy and fling them away from Link as it does in the game*/
	public void TakeDamage();
}
