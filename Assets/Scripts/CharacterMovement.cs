using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    public Vector3 gravity;
    public Vector3 playerVelocity;
    public bool groundedPlayer;
    private float jumpHeight = 1f;
    private float gravityValue = -9.81f;
    private CharacterController controller;
    private Animator animator;
    private float walkSpeed = 5;
    private float runSpeed = 8; 
    private bool doubleJump = false;
    private float doubleJumpMultipliyer = 0.5f;
    public ParticleSystem part = null;
    public float timer = 5f; // Object will be active for 5 seconds

 
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    public void Update()
    {
       ProcessMovement();
       UpdateAnimator();
       
    }
    void DisableRootMotion()
    {
        animator.applyRootMotion = false;  
    }
    void UpdateAnimator()
    {
        // Do Roll
        if (Input.GetButtonDown("Fire2"))
        {
            animator.applyRootMotion = true; 
            animator.SetTrigger("DoRoll");
        }
        
        // Movement
        if (Mathf.Abs(Input.GetAxis("Horizontal"))>0.0f || Mathf.Abs(Input.GetAxis("Vertical"))>0.0f)
        {
            if (Input.GetButton("Fire3"))// Left shift
            {
                animator.SetFloat("CharacterSpeed",1.0f);
            }
            else
            {
                animator.SetFloat("CharacterSpeed",0.5f);
            }
        }
        else 
        {
            animator.SetFloat("CharacterSpeed",0.0f);

        }
        
        // Is Grounded
        animator.SetBool("IsGrounded",groundedPlayer);
        
    }

    void ProcessMovement()
    { 
        // Moving the character foward according to the speed
        float speed = GetMovementSpeed();

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        // Turning the character
        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        // This loop will check if the player is grounded or if he has the double jump ability
        if (groundedPlayer)
        {
            if (Input.GetButtonDown("Jump") )
            {
                gravity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
                //Debug.Log(doubleJump);

            }
            else 
            {
                // Dont apply gravity if grounded and not jumping
                gravity.y = -1.0f;
            }
        }
        else 
        {
            if (Input.GetButtonDown("Jump") && doubleJump)
                {
                    animator.SetTrigger("isDouble");
                    gravity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue * doubleJumpMultipliyer);
                    doubleJump = false;
                    part.Play();
                    
                }

            // Since there is no physics applied on character controller we have this applies to reapply gravity
            gravity.y += gravityValue * Time.deltaTime;
        }  
        playerVelocity = gravity * Time.deltaTime + move * Time.deltaTime * speed;
        controller.Move(playerVelocity);

        // controller.isGrounded tells you if a character is grounded ( IE Touches the ground)
        groundedPlayer = controller.isGrounded;
    }

    float GetMovementSpeed()
    {
        if (Input.GetButton("Fire3"))// Left shift
        {
            return runSpeed;
        }
        else
        {
            return walkSpeed;
        }
    }

     private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Point")
        {
            GameManager.Instance.AddScore(50);
            Destroy(other.gameObject);
        }

         if (other.tag == "DoubleJump")
        {
            doubleJump = true;
            other.gameObject.GetComponent<DoubleJump>().PickupDoubleJump();
        }
    }
}
