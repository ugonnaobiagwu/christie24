using System;

public interface IBombStateMachine
{
	//Takes bomb to planted state
	public void Planted();

	//Takes bomb to Exploded State
	public void Exploded();
}
