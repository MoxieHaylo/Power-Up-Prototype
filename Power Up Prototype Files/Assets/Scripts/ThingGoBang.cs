using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThingGoBang : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine("GoBangNow");
    }

    IEnumerator GoBangNow()
    {
        while(true)
        {
            print("'bout to go bang");
            yield return new WaitForSeconds(2f);
            Destroy(this.gameObject);
            yield break;
        }
    }
}
