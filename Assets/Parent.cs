using UnityEngine;

public class Parent : MonoBehaviour, IPreInitialize, IInitialize, IPostInitialize
{
    public virtual void PreInitialize() { }
    
    public virtual void Initialize() { }
    
    public virtual void PostInitialize() { }
}