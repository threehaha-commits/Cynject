using System.Collections.Generic;
using UnityEngine;

public static class Fabric
{
    public static Object Create(object entity)
    {
        var list = Container.Get();
        var newEntity = Object.Instantiate(entity as Object);
        AssignValuesToEntity(list, newEntity);
        return newEntity;
    }

    public static Object Create(object entity, Transform parent)
    {
        var list = Container.Get();
        var newEntity = Object.Instantiate(entity as Object, parent);
        AssignValuesToEntity(list, newEntity);
        return newEntity;
    }
    
    public static Object Create(object entity, Vector3 position, Quaternion rotation)
    {
        var list = Container.Get();
        var newEntity = Object.Instantiate(entity as Object, position, rotation);
        AssignValuesToEntity(list, newEntity);
        return newEntity;
    }
    
    public static Object Create(object entity, Vector3 position, Quaternion rotation, Transform parent)
    {
        var list = Container.Get();
        var newEntity = Object.Instantiate(entity as Object, position, rotation, parent);
        AssignValuesToEntity(list, newEntity);
        return newEntity;
    }
    
    private static void AssignValuesToEntity(List<MonoBehaviour> list, Object newEntity)
    {
        foreach (var component in list)
            Bind.SetValueTo(component, newEntity);
    }
}