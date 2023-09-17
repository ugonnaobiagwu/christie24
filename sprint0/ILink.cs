using System;

public interface ILink
{
	/*Depending on the item link currently has, it will use it, cycling items will be in the itemState*/
	public void UseItem();

	/*Link always has the ability to use his sword regardless of the current item*/
	public void SwingSword();

	/*Link will take damage when coming in contact with a projectile or enemy*/
	public void TakeDamage();

}
