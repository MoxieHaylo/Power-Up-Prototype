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
            GameObject cubeBits = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Rigidbody cubeRb = cubeBits.AddComponent<Rigidbody>();
            //MeshRenderer cubeMAT = cubeBits.AddComponent<MeshRenderer>();
            //cubeMAT.material.color = Color.red;
            cubeRb.mass = 5;
            //cube.transform.localPosition = new Vector3(0f, 1f, 0f);
            //cube.transform.parent = transform;
            //transform = new Vector3(0f, 1f, 0f);
            cubeBits.transform.position = transform.position + new Vector3(0f, 1f, 0f);
            cubeBits.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
            cubeBits.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 100, 0));
            print("'bout to go bang");
            yield return new WaitForSeconds(2f);
            Destroy(this.gameObject);
            yield break;
        }
    }
}
