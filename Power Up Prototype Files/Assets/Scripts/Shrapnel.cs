using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrapnel : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine("CleanUp");
    }

    IEnumerator CleanUp()
    {
        while(true)
        {
            print("I exploded");
            yield return new WaitForSeconds(4f);
            print("And now I clean");
            Destroy(this.gameObject);
            yield break;
        }
    }
}
