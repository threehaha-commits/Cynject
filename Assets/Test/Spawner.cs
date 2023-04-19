using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public ClassB B;
    
    private IEnumerator Start()
    {
        while (true)
        {
            Fabric.Create(B);
            yield return new WaitForSeconds(1f);
        }
    }
}