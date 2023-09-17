using System;

public interface IProjectileStateMachine
{
	/* Takes the projectile to the InFlight State*/
	public void InFlight();

	/* Takes the projectile to the Hit State, uses the specific projectile's CauseDamage()*/
	public void Hit();

}
