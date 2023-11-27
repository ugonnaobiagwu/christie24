using System;
using System.Collections.Generic;
using sprint0;

public interface IManager<T> where T : IGameObject
{
    // need to fix this
    // probably dont even need this

    void addObject(T obj);
    void removeObject(T obj);
    void deleteObjects();
    List<T> getList(string listName);
    List<int> getRoomIDs();
    Dictionary<int, List<IGameObject>> getDictionary();
}