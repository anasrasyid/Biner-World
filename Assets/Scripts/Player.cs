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
    private float aSpeed;
    private bool accelarate;

    private Rigidbody2D rigidbody2;
    private SpriteRenderer spriteRenderer;
    private Collision2D ground;
    private Touch theTouch;
    private Vector2 start, end;
    private Animator anim;

    public GameManager gameManager;

    void Start()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        ground = null;
        accelarate = false;
        aSpeed = speed;
        anim = gameObject.GetComponent<Animator>();
        gameManager = GameObject.Find("GamaManager").GetComponent<GameManager>();
        gameManager.addingEssential();
    }

    void Update()
    {
        //Jump();
        //float horizontal = Input.GetAxisRaw("Horizontal");
        Movement();
    }

    private void FixedUpdate()
    {
        if (accelarate && speed < 10)
        {
            speed += Time.deltaTime;
        }
    }

    public void Directional(float direct)
    {
        horizontal = direct;
        anim.SetBool("canMove", true);
        accelarate = true;
    }

    public void StopMovement()
    {
        horizontal = 0;
        //rigidbody2.velocity = new Vector2(0, rigidbody2.velocity.y);
        anim.SetBool("canMove", false);
        accelarate = false;
        speed = aSpeed;
    }

    public void Movement()
    {
        if (horizontal > 0)
        {
            spriteRenderer.flipX = false;
        }else if(horizontal < 0)
        {
            spriteRenderer.flipX = true;
        }
        //transform.Translate(new Vector2(transform.right.x * horizontal * speed * Time.deltaTime, 0));
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
        if(collision.gameObject.CompareTag("Ground") && ground == null)
        {
            ground = collision;
            anim.SetBool("isGround", true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            ground = null;
            anim.SetBool("isGround", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Traps"))
        {
            gameManager.DelHealth();
        }
        if (collision.gameObject.CompareTag("Box"))
        {
            BoxBin x = collision.gameObject.GetComponent<BoxBin>();
            int k = 1;
            if (x.value == 0)
            {
                k = -1;
            }
            gameManager.Check(k * x.values + gameManager.key);
        }
        else if (collision.gameObject.CompareTag("BoxInt"))
        {
            BoxInt x = collision.gameObject.GetComponent<BoxInt>();
            if (x.operat == '+')
            {
                gameManager.Check(x.value + gameManager.key);
            }else if (x.operat == '-')
            {
                gameManager.Check(-x.value + gameManager.key);
            }else if (x.operat == '*')
            {
                gameManager.Check(x.value * gameManager.key);
            }
            else if (x.operat == ':')
            {
                gameManager.Check(x.value / gameManager.key);
            }
            
        }
    }
}