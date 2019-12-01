using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    Rigidbody2D rigidbody;
    BoxCollider2D box;
  public  bool grounded;
   
    bool facingRight = true;
    [SerializeField] float jumpForce = 30f;
    [SerializeField] float speed = 300f;
    public float JumpForce { get { return jumpForce; } }
    bool canDoubleJump;
   public float deltaX;
    float horizontal;
    Collider2D groundDetection;
  
    [SerializeField] float fallMultiplier=2.5f;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
    }


    void FixedUpdate()
    {
        deltaX = horizontal * speed * Time.fixedDeltaTime;

        anim.SetFloat("speed", Mathf.Abs(deltaX));
        rigidbody.velocity = new Vector2(deltaX, rigidbody.velocity.y);

        Vector3 max = box.bounds.max;
        Vector3 min = box.bounds.min;
        Vector2 corner1 = new Vector2(max.x-0.5f, min.y - 0.1f);
        Vector2 corner2 = new Vector2(min.x+0.5f, min.y - 0.2f);
        groundDetection = Physics2D.OverlapArea(corner1, corner2);
      // Debug.DrawLine(corner1, corner2, Color.red);
    }
    
    void Update()
    {
       horizontal = Input.GetAxisRaw("Horizontal");

      
        if (groundDetection != null)
        {
            grounded = true;
            canDoubleJump = true;
            anim.SetBool("Jumped", false);
        }
        else { grounded = false; anim.SetBool("Jumped", true); };


        platform pl = null;
        if (groundDetection != null)
        {
            pl = groundDetection.GetComponent<platform>();
        }
        if (pl != null)
        {
            transform.parent = pl.transform;
        }
        else
        {
            transform.parent = null;
        }


        if (Input.GetButtonDown("Jump"))
        {
            if (grounded)
            {
                rigidbody.velocity = Vector2.up * jumpForce;
                grounded = false;
            }
            else if (canDoubleJump)
            {
                canDoubleJump = false;
                rigidbody.velocity = Vector2.up * jumpForce;
            }
        }
        if(rigidbody.velocity.y<0)
        {
            anim.SetBool("JumpDown", true);
            rigidbody.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else anim.SetBool("JumpDown", false);

       

        if (deltaX < 0 && facingRight)
            Flip();
        else if (deltaX > 0 && !facingRight)
            Flip();
    }
    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }
}