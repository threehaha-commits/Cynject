using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class BindInterface<T>
{
    public static List<T> Get(bool includeInactive = false)
    {
        return Object.FindObjectsOfType<MonoBehaviour>(includeInactive).OfType<T>().ToList();
    }
}