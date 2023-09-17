using System;

/*Used for all state machines as a baseline*/
public interface IGeneralStateMachine
{
	/*States must update based on the current sprite's update method*/
	public void Update();
}
