using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate0 : MonoBehaviour
{
    public PlayerController pC;
    float buttonSquishSpeed = 1f;
    public bool isPressed;

    void Start()
    {
        isPressed = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (pC.isBig==true && collision.gameObject.CompareTag("Player"))
        {
            isPressed = true;
            print("squish");
            transform.position = transform.position + new Vector3(0f, -10f, 0f)*buttonSquishSpeed*Time.deltaTime;

            if(isPressed)
            {
                print("I pressed a button!");
            }
        }
    }

    void Update()
    {
    
    }
}
