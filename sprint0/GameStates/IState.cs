using System;
using System.Collections.Generic;

namespace sprint0.GameStates
{
	public interface IState
	{
		//Very early interface, subject to change in every way
		void Update();

		//Methods implemented in StateManager and inherited by state classes
		void LinkActivate();
		void LinkDeactivate();
		IList<IGameObject> RoomActivate();
		IList<IGameObject> RoomDeactivate();
		IList<IGameObject> EnemyActivate();
		IList<IGameObject> EnemyDeactivate();
        //Gets current state and returns a string
        string GetState();
		//Updates each corresponding object's updateable method dependent on state ie link cant be updated in the DeathState
		void LinkUpdate();
		void RoomUpdate();
		void EnemyUpdate();
		//Bool if game is resettable (ie in death state)
		bool GameResettable();
	}
}

