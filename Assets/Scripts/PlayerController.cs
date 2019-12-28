using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 0.2f;
    public float jumpForce = 200f;
    private Vector3 originalGravity;
    private Vector3 fallingGravity;
    [SerializeField]
    private GameObject faceCamera;
    private bool isGrounded = true;
    private bool rip = false;
    private Animator animator;
    private bool isWalking;


    // Start is called before the first frame update
    void Start()
    {
        originalGravity = Physics.gravity;
        fallingGravity = Physics.gravity * 3.5f;
        GameManager.Instance.setFaceCamera(faceCamera);
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!rip)
        {
            handleWalking();
            handleRotataion();
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
    }

    private void handleWalking()
    {
        isWalking = false;
        if (Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.S)||Input.GetKey(KeyCode.A))
        {
            Vector3 directrin=transform.forward * speed * Time.deltaTime;
            transform.parent.Translate(directrin);
            isWalking = true;
        }
        if (isWalking)
        {
            if (!animator.GetBool("IsWalking"))
            {
                animator.SetBool("IsWalking", true);
            }
        }
        else
        {
            if (animator.GetBool("IsWalking"))
            {
                animator.SetBool("IsWalking", false);
            }
        }
    }

    private void handleRotataion()
    {

        if (Input.GetKey(KeyCode.W)&&Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 45, 0));
        }
        else if (Input.GetKey(KeyCode.D)&&Input.GetKey(KeyCode.S))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 135, 0));
        }
        else if (Input.GetKey(KeyCode.S)&&Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 225, 0));
        }
        else if (Input.GetKey(KeyCode.W)&&Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 315, 0));
        }
        else if (Input.GetKey(KeyCode.W))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 270, 0));
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
