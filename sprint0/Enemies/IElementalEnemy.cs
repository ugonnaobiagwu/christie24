using System;
namespace sprint0.Enemies
{
	public interface IElementalEnemy
	{
		public Globals.EnemyElementType EnemyElement();
		public void TakeCriticalDamage();
		public void TakeMinimalDamage();
	}
}

