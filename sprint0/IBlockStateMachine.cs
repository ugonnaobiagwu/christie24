using System;

public interface IBlockStateMachine
{
	//Certain blocks will be explodable, not every block object needs to implement this fully
	public void Exploded();

}
