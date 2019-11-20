using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Player Controller
    [SerializeField]
    private float speed;
    [SerializeField]
    private float jumpPower;
    #endregion
    private float horizontal;
    private bool canMove;

    private Rigidbody2D rigidbody2;
    private SpriteRenderer spriteRenderer;
    private Collision2D ground;
    private Touch theTouch;
    private Vector2 start, end;
    private Animator anim;

    void Start()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        ground = null;
        canMove = false;
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        //Jump();
        //float horizontal = Input.GetAxisRaw("Horizontal");
        Movement();
    }

    public void Directional(float direct)
    {
        canMove = true;
        horizontal = direct;
        anim.SetBool("canMove", canMove);
    }

    public void StopMovement()
    {
        canMove = false;
        horizontal = 0;
        rigidbody2.velocity = new Vector2(transform.right.x * horizontal * speed, rigidbody2.velocity.y);
        anim.SetBool("canMove", canMove);
    }

    public void Movement()
    {
        if (!canMove) return;
        if (horizontal > 0)
        {
            spriteRenderer.flipX = false;
        }else if(horizontal < 0)
        {
            spriteRenderer.flipX = true;
        }
        rigidbody2.velocity = new Vector2(transform.right.x * horizontal * speed, rigidbody2.velocity.y);
    }

    public void Jump()
    {
        if (ground == null)
            return;
        anim.SetTrigger("isJump");
        rigidbody2.velocity = Vector2.up * jumpPower;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            ground = collision;
        }
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            ground = null;
        }
    }
}
