using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableObjects : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Shrapnel"))
        {
            print("hit");
            StartCoroutine("BreakTheWall");
        }
    }

    IEnumerator BreakTheWall()
    {
        while (true)
        {
            print("wall go bye bye");
            yield return new WaitForSeconds(0.25f);
            Destroy(this.gameObject);
            yield break;
        }
    }
}
