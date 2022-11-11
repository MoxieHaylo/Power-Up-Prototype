using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public PlayerController pC;
    float buttonSquishSpeed = 1f;

    private void OnCollisionEnter(Collision collision)
    {
        if (pC.isBig==true && collision.gameObject.CompareTag("Player"))
        {
            print("squish");
            transform.position = transform.position + new Vector3(0f, -2f, 0f)*buttonSquishSpeed*Time.deltaTime;
        }
    }
}
