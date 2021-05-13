using UnityEngine;

public class DuckMovement : MonoBehaviour
{
    //public float jump = 10.0f;
    private Rigidbody2D rb;
    public float sprintSpeed;
    public float speed;
    public float forceOfJump;
    private float moveInput;

    private bool isGrounded;
    public Transform PositionOfFeet;
    public float Radius;
    public LayerMask ground;

    private float jumpCounter;
    public float jumpTime;
    private bool isJumping;

    //public float HowLongJump = 10.0f;
    //public float jumpTimeReversed = 0.0f;


    public Animator duckAnimator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        duckAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
        }
    }

    void Update()
    {
        // Sprint
        if
        (   Input.GetKey(KeyCode.LeftShift)  && Input.GetKey(KeyCode.A)
        ||  Input.GetKey(KeyCode.RightShift) && Input.GetKey(KeyCode.A)
        ||  Input.GetKey(KeyCode.LeftShift)  && Input.GetKey(KeyCode.LeftArrow)
        ||  Input.GetKey(KeyCode.RightShift) && Input.GetKey(KeyCode.LeftArrow)
        )
        {
            transform.position += Vector3.left * speed * sprintSpeed * Time.deltaTime;
        }
        if
        (   Input.GetKey(KeyCode.LeftShift)  && Input.GetKey(KeyCode.D)
        ||  Input.GetKey(KeyCode.RightShift) && Input.GetKey(KeyCode.D)
        ||  Input.GetKey(KeyCode.LeftShift)  && Input.GetKey(KeyCode.RightArrow)
        ||  Input.GetKey(KeyCode.RightShift) && Input.GetKey(KeyCode.RightArrow)
        )
        {
            transform.position += Vector3.right * speed * sprintSpeed * Time.deltaTime;
        }

        // Jump
        isGrounded = Physics2D.OverlapCircle(PositionOfFeet.position, Radius, ground);

        if
        (   isGrounded == true && Input.GetKeyDown(KeyCode.Space)
        ||  isGrounded == true && Input.GetKeyDown(KeyCode.W)
        ||  isGrounded == true && Input.GetKeyDown(KeyCode.UpArrow)
        )
        {
            isJumping = true;
            jumpCounter = jumpTime;
            rb.velocity = Vector2.up * forceOfJump;
        }

        if
        (   Input.GetKey(KeyCode.Space)   && isJumping == true
        ||  Input.GetKey(KeyCode.W)       && isJumping == true
        ||  Input.GetKey(KeyCode.UpArrow) && isJumping == true
        )
        {
            if (jumpCounter > 0)
            {
                rb.velocity = Vector2.up * forceOfJump;
                jumpCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
        {
            isJumping = false;
        }

        // Jump Animation
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            duckAnimator.SetTrigger("jump");
        }

        // Walking Animation
        if (Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.D)) || (Input.GetKey(KeyCode.LeftArrow)) || (Input.GetKey(KeyCode.RightArrow)))
        {
            duckAnimator.SetBool("walk", true);
        }
        else
        {
            duckAnimator.SetBool("walk", false);
        }
    }
}
