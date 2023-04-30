using UnityEngine;

public static class CInjectHelper
{
    private static Object[] _objectsOnScene;
    
    private static void FindGameObjectsIsScene(bool includeInactive = false)
    {
        _objectsOnScene = Object.FindObjectsOfType<Object>(includeInactive);
    }

    public static Object[] GetObjectsFromScene(bool includeInactive = false, bool update = false)
    {
        if(_objectsOnScene == null)
            FindGameObjectsIsScene(includeInactive);
        if(update)
            FindGameObjectsIsScene(includeInactive);
        return _objectsOnScene;
    }
}