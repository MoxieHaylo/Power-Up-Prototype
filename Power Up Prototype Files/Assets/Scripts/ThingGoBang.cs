using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThingGoBang : MonoBehaviour
{
    int iterationCount = 20;

    private void Awake()
    {
        StartCoroutine("GoBangNow");
    }

    IEnumerator GoBangNow()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.5f);

            for(int i = 0; i < iterationCount; i++)
            {
                GameObject cubeBits = GameObject.CreatePrimitive(PrimitiveType.Cube);
                Rigidbody cubeRb = cubeBits.AddComponent<Rigidbody>();
                var cubeRenderer = cubeBits.GetComponent<Renderer>();
                cubeRenderer.material.SetColor("_Color", Color.red);
                cubeRb.mass = 5;
                cubeBits.transform.position = transform.position + new Vector3(0f, 0f, 0f);
                cubeBits.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
                cubeBits.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 100, 0));
                cubeBits.AddComponent<Shrapnel>();
                cubeBits.gameObject.tag = "Shrapnel";
                print("'bout to go bang");
            }

            yield return new WaitForSeconds(0.5f);
            Destroy(this.gameObject);
            yield break;
        }
    }
}
