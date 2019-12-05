using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 0.2f;
    public float jumpForce = 200f;
    private Vector3 originalGravity;
    private Vector3 fallingGravity;
    private bool isGrounded = true;
    private bool rip = false;


    // Start is called before the first frame update
    void Start()
    {
        originalGravity = Physics.gravity;
        fallingGravity = Physics.gravity * 3.5f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (!rip)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.forward * speed);
            }

            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.back * speed);
            }

            if (Input.GetKey(KeyCode.D))
            {
                if (transform.position.x < 19.7f)
                {
                    transform.Translate(Vector3.right * speed);
                }
            }

            if (Input.GetKey(KeyCode.A))
            {
                if (transform.position.x > -0.3f)
                {
                    transform.Translate(Vector3.left * speed);
                }
            }
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isGrounded = false;
            }
            if (GetComponent<Rigidbody>().velocity.y < 0)
            {
                Physics.gravity = fallingGravity;
            }
            else
            {
                Physics.gravity = originalGravity;
            }
        }
    }

    public void kill()
    {
        rip = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }
}
