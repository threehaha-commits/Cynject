using System.Reflection;
using Object = UnityEngine.Object;

public static class Bind
{
    /// <summary>
    /// Assign value to all objects from scene
    /// </summary>
    /// <param name="value"></param>
    public static void Value(object value)
    {
        foreach (var objectOnScene in CInjectHelper.ObjectsFromScene())
        {
            var fields = GetFieldsType(objectOnScene);
            AssignValue(fields, value, objectOnScene);
        }
    }

    /// <summary>
    /// Assign value to target object in scene
    /// </summary>
    /// <param name="value"></param>
    /// <param name="to"></param>
    public static void SetValueTo(object value, object to)
    {
        var fields = GetFieldsType(to as Object);
        AssignValue(fields, value, to);
    }

    private static void AssignValue(FieldInfo[] infos, object value, object objectFromScene)
    {
        foreach (var info in infos)
        {
            if (FieldDoesntContainTargetAttribute(info)) 
                continue;
            if (!CurrentFieldContainTargetType(info, value)) 
                continue;
            info.SetValue(objectFromScene, value);
            Container.Add(value);
        }
    }

    private static FieldInfo[] GetFieldsType(Object objectOnScene)
    {
        return objectOnScene.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
    }
    
    private static bool CurrentFieldContainTargetType(FieldInfo info, object value)
    {
        return info.FieldType == value.GetType();
    }

    private static bool FieldDoesntContainTargetAttribute(FieldInfo info)
    {
        var fieldHaveAtt = info.GetCustomAttribute<InjectAttribute>();
        return fieldHaveAtt == null;
    }
}