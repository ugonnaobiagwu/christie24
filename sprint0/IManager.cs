using System;
using System.Collections.Generic;
using sprint0;

public interface IManager<T> where T : IGameObject
{
    void AddObject(int room, T obj);
    void RemoveObject(int room, T obj);
    List<IGameObject> getList(string listName);
    List<int> getRoomIDs();
    List<IGameObject> getRoomList(int roomID);
    Dictionary<int, List<IGameObject>> getDictionary();
}
