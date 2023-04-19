using System.Collections.Generic;
using UnityEngine;

public static class Container
{
    private static List<MonoBehaviour> _list = new();

    /// <summary>
    /// Must be call in start game
    /// </summary>
    public static void Clear()
    {
        _list.Clear();
    }
    
    /// <summary>
    /// Added component to array list. It is need for keep components for future assign
    /// </summary>
    /// <param name="mono"></param>
    public static void Add(object mono)
    {
        if (NotContainsThe(mono as MonoBehaviour))
            _list.Add(mono as MonoBehaviour);
    }

    public static List<MonoBehaviour> Get()
    {
        return _list;
    }
    
    private static bool NotContainsThe(MonoBehaviour mono)
    {
        return !_list.Contains(mono);
    }
}