using Threehaha;
using UnityEngine;


public class CynjectInitialize : MonoBehaviour
{
    private void Awake()
    {
        Container.Clear();
        CInjectHelper.GetObjectsFromScene(true);
        
        CallPreInitialize();

        CallInitialize();

        CallPostInitialize();
    }

    private void CallPostInitialize()
    {
        var postInitialize = BindInterface<IPostInitialize>.Get();
        foreach (var init in postInitialize)
            init.PostInitialize();
    }

    private void CallInitialize()
    {
        var initialize = BindInterface<IInitialize>.Get();
        foreach (var init in initialize)
            init.Initialize();
    }

    private void CallPreInitialize()
    {
        var preInitialize = BindInterface<IPreInitialize>.Get();
        foreach (var init in preInitialize)
            init.PreInitialize();
    }
}