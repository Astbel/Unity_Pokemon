using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    private CapsuleCollider2D coil;
    private Animator myAnim;

    private BoxCollider2D myfeet;
    //Variable
    public float speed, jumpforce, DoubleJumpForce;

    private bool isGround, CanDoubleJump;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        myfeet = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // movement();
        //  Attack();
        jump();
        Flip();
        CheckGround();
        SwitchAnimation();
    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void FixedUpdate()
    {
        movement();
       
    }

    //method
    /*
    Moving method describe: return a value of speed and it intanse change back to abs int value and for bool it only have 0 or 1 and it will trigger the anim
    */
    void movement()
    {
        float moveDirect = Input.GetAxis("Horizontal");

        Vector2 playerVel = new Vector2(moveDirect * speed * Time.fixedDeltaTime, rb.velocity.y);

        rb.velocity = playerVel;

        bool playerHasXAxisSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;

        myAnim.SetBool("Run", playerHasXAxisSpeed);


    }
    /*player face deriction*/
    void Flip()
    {
        bool playerHasXAxisSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        if (playerHasXAxisSpeed)
        {
            if (rb.velocity.x > 0.1f)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            else if (rb.velocity.x < -0.1f)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }

    /*Jumping method check is player at ground*/
    void jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (isGround)
            {
                myAnim.SetBool("Jump", true);
                Vector2 jumpVal = new Vector2(0.0f, jumpforce);
                rb.velocity = Vector2.up * jumpVal;
                CanDoubleJump = true;
            }
            else
            {
                if (CanDoubleJump)
                {
                    Vector2 DoubleJumpVal = new Vector2(0.0f, DoubleJumpForce);
                    rb.velocity = Vector2.up * DoubleJumpVal;
                    CanDoubleJump = false;
                }
            }
        }

    }
    /*check ground is touch*/
    void CheckGround()
    {
        isGround = myfeet.IsTouchingLayers(LayerMask.GetMask("Ground"));
    }

    /*Switch Anim*/
    void SwitchAnimation()
    {
        myAnim.SetBool("Idel", false);
        if (myAnim.GetBool("Jump"))
        {
            if (rb.velocity.y < 0.0f)
            {
                myAnim.SetBool("Jump", false);
                myAnim.SetBool("Fall", true);
            }
        }
        else if (isGround)
        {
            myAnim.SetBool("Fall", false);
            myAnim.SetBool("Idel", true);
        }
    }

    /*Attack  method*/
    void Attack()
    {
        if (Input.GetButtonDown("Attack"))
        {
            myAnim.SetTrigger("Attack");
        }
    }

}
