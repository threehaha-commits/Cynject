using System.Collections;
using Threehaha;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public ClassB B;
    
    private IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            Create.New(B);
        }
    }
}