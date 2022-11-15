using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public PressurePlate pPlate;

    public Vector3 positionToMoveTo;

    // Start is called before the first frame update
    void Start()
    {
        pPlate.isPressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (pPlate.isPressed==true)
        {
            print("The other class said I'm gonna move now");
            
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            print("test");
            StartCoroutine(LerpPosition(positionToMoveTo, 5));
        }
    }

    IEnumerator LerpPosition(Vector3 targetPosition, float duration)
    {
        float time = 0f;
        Vector3 startPosition = transform.position;
        while(time<duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
    }
}
