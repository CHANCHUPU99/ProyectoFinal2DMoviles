using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    #region Public
    public static PlayerController2 instance;
    public LayerMask whatIsGround;
    
    #endregion

    #region Private
    Rigidbody2D rb2d;
    bool isFacingRight, isGrounded;
    #endregion

    #region Serialize Fields
    [SerializeField] float xSpeed, jumpForce, footRadious;
    [SerializeField] Transform footPosition;
    #endregion

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        isFacingRight = true;
        isGrounded = false;
    }

    void FixedUpdate()
    {

        isGrounded = Physics2D.OverlapCircle(footPosition.position, footRadious, whatIsGround) &&
            rb2d.velocity.y < 0.1;
        horizontalMovement();
        verticalMovement();
    }

     void horizontalMovement()
    {
        float xMove;
        xMove = Input.GetAxisRaw("Horizontal");
        rb2d.velocity = new Vector2(xMove * xSpeed, rb2d.velocity.y);
        if ((xMove < 0 && isFacingRight) || (xMove > 0 && !isFacingRight))
        {
            flip();
        }
        if (isGrounded)
        {
            if (xMove != 0)
            {
                PlayerManager1.instance.changePlayerState(PlayerState.Running);
            }
            else if (xMove == 0)
            {
                PlayerManager1.instance.changePlayerState(PlayerState.Idle);
            }

        }
    }

     void verticalMovement()
    {
        if (isGrounded)
        {
            return;
        }
        if (!isGrounded && rb2d.velocity.y >= 0.1)
        {
            PlayerManager1.instance.changePlayerState(PlayerState.Jump);
        }
        else if (!isGrounded && rb2d.velocity.y < -0.1)
        {
            PlayerManager1.instance.changePlayerState(PlayerState.JumpFall);
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            jump();
        }
    }
    void jump()
    {
        if (!isGrounded)
        {
            return;
        }
        rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);

    }

    void flip()
    {
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(footPosition.position, footRadious);
    }
}
