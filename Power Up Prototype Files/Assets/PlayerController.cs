using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Basic Movement")]
    float walkSpeed = 10f;
    float jumpSpeed = 2f; //add variance for up vs down at some point
    public bool isMoving;
    private Vector3 prevPos;
    private Vector3 jump;

    public bool isGrounded = false;

    [Header("Power Ups")]
    public bool isBig = false;
    private Vector3 scaleChangeB, positionChangeB;
    public bool isSmall = false;
    private Vector3 scaleChangeS, positionChangeS;
    public bool isFlying = false;
    float flightSpeed = 0.1f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0f, 2f, 0f);
    }

    private void OnCollisionStay(Collision col)
    {
        if (col.gameObject.CompareTag("Platform"))
        {
            isGrounded = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Big"))
        {
            if(isBig==false)
            {
                scaleChangeB = new Vector3(3f, 3f, 3f);
                this.gameObject.transform.localScale += scaleChangeB;
                print("Biggy");
            }
            
            isBig = true;
            isSmall = false;
            isFlying = false;
            
            walkSpeed = 3f;
            jumpSpeed = 1f;
        }
        if(
            other.gameObject.CompareTag("Small"))
        {
            if(isBig==true)
            {
                scaleChangeS = new Vector3(-3f, -3f, -3f);
                this.gameObject.transform.localScale += scaleChangeS;
                isBig = false;
            }
            if(isSmall==true)
            {
                scaleChangeS = new Vector3(0f, 0f, 0f);
                this.gameObject.transform.localScale += scaleChangeS;
            }
            else
            {
                scaleChangeS = new Vector3(-0.5f, -0.5f, -0.5f);
                this.gameObject.transform.localScale += scaleChangeS;
                isBig = false;
            }
            isBig = false;
            isFlying = false;
            isSmall = true;
            
            //scaleChangeS = new Vector3(-0.5f, -0.5f, -0.5f);
            //this.gameObject.transform.localScale += scaleChangeS;
            walkSpeed = 15f;
            jumpSpeed = 2f;
        }
        if(other.gameObject.CompareTag("Fly"))
        {
            isFlying = true;
            if (isBig == true)
            {
                scaleChangeS = new Vector3(-3f, -3f, -3f);
                this.gameObject.transform.localScale += scaleChangeS;
                isBig = false;
            }
            if (isSmall == true)
            {
                scaleChangeS = new Vector3(0.5f, 0.5f, 0.5f);
                this.gameObject.transform.localScale += scaleChangeS;
            }
        }
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(jump * jumpSpeed, ForceMode.Impulse);
            isGrounded = false;
        }

        float xDirection = Input.GetAxis("Horizontal");
        Vector3 moveDirection = new Vector3(xDirection, 0f, 0f);
        transform.position += moveDirection * walkSpeed * Time.deltaTime;

        if (transform.hasChanged)
        {
            isMoving = true;
            transform.hasChanged = false;
        }
        else
        {
            isMoving = false;
        }

        if(Input.GetKey(KeyCode.Space)&&isFlying)
        {
            rb.AddForce(jump * flightSpeed, ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {

    }
}
