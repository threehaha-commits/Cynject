using UnityEngine;

public static class CInjectHelper
{
    private static Object[] _objectsOnScene;
    
    public static void GetGameObjectsFromScene(bool includeInactive = false)
    {
        _objectsOnScene = Object.FindObjectsOfType<Object>(includeInactive);
    }

    public static Object[] ObjectsFromScene()
    {
        return _objectsOnScene;
    }
}