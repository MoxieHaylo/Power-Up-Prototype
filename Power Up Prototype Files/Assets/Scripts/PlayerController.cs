using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Basic Movement")]
    float walkSpeed = 10f;
    float jumpSpeed = 2f; 
    public bool isAbleToMove = true;
    private Vector3 jump;

    public bool isGrounded = false;

    [Header("Power Ups")]
    public bool isBig = false;
    private Vector3 scaleChangeB, positionChangeB;
    public bool isSmall = false;
    private Vector3 scaleChangeS, positionChangeS;
    public bool isFlying = false;
    float flightSpeed = 0.1f;
    public bool isExplosive = false;

    private Rigidbody rb;
    public Rigidbody projectile;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0f, 2f, 0f);
        isAbleToMove = true;
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
            isAbleToMove = true;
            if (isBig==false)
            {
                scaleChangeB = new Vector3(3f, 3f, 3f);
                this.gameObject.transform.localScale += scaleChangeB;
                print("Biggy");
            }
            
            isBig = true;
            isSmall = false;
            isFlying = false;
            isExplosive = false;

            walkSpeed = 3f;
            jumpSpeed = 1f;
        }
        if(
            other.gameObject.CompareTag("Small"))
        {
            isAbleToMove = true;
            if (isBig==true)
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
            isExplosive = false;
            isSmall = true;
            
            walkSpeed = 15f;
            jumpSpeed = 2f;
        }
        if(other.gameObject.CompareTag("Fly"))
        {
            isFlying = true;
            transform.position = transform.position + new Vector3(0f, 1f, 0f);
            isAbleToMove = false;
            isExplosive = false;
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
                isSmall = false;
            }
            if (isFlying == true && isGrounded == true)
            {
                print("stuck");
                isAbleToMove = false;
            }

            if (isFlying == true && isGrounded == false)
            {
                print("moving");
                isAbleToMove = true;
            }
        }
        if(other.gameObject.CompareTag("Explode"))
        {
            isExplosive = true;
            print("bang");

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
                isSmall = false;
            }

            walkSpeed = 10f;
            jumpSpeed = 2f;

            isFlying = false;
            isSmall = false;
            isBig = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            print("I'm dead now bye");
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && isGrounded==true)
        {
            rb.AddForce(jump * jumpSpeed, ForceMode.Impulse);
            isGrounded = false;
        }
        if (isAbleToMove == true)
        {
            float xDirection = Input.GetAxis("Horizontal");
            Vector3 moveDirection = new Vector3(xDirection, 0f, 0f);
            transform.position += moveDirection * walkSpeed * Time.deltaTime;
        }
        if (isAbleToMove == false)//this is scuffed, think of a better way
        {
            float xDirection = Input.GetAxis("Horizontal");
            Vector3 moveDirection = new Vector3(xDirection, 0f, 0f);
            transform.position += moveDirection * 0 * Time.deltaTime;
        }
        if (isFlying == true&&isGrounded==false)
        {
            float xDirection = Input.GetAxis("Horizontal");
            Vector3 moveDirection = new Vector3(xDirection, 0f, 0f);
            transform.position += moveDirection * walkSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Space)&&isFlying)
        {
            rb.AddForce(jump * flightSpeed, ForceMode.Impulse);
        }

        if(Input.GetKeyDown(KeyCode.Q)&&isExplosive==true)
        {
            print("le bang");
            Rigidbody clone;
            clone = Instantiate(projectile, transform.position, transform.rotation);
            //clone.velocity = transform.TransformDirection(Vector3.left * 20);
            clone.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0,100,0));
        }
    }

    private void FixedUpdate()
    {

    }
}
