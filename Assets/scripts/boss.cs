using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour
{
  [SerializeField]  float jumpForse = 6.5f;
    [SerializeField] float SetTime=2f;
    private float time;
    Vector2 jumpV=new Vector2(-0.5f,1);
    private Rigidbody2D body;
    private int count;
    private int counter;
    public Vector3 endPos = Vector3.zero;
    public Vector3 startPos;
    bool TakeLook;
    Action[] attacks = new Action[4];
    private BoxCollider2D box;
    [SerializeField] saw saw;
    [SerializeField] rocket rocket1;
    Animator anim;
    [SerializeField] energy energy;
    bool shooted;
    Collider2D hit;

  
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        time = SetTime;
        count = 4;
        counter = count;
        box = GetComponent<BoxCollider2D>();
        body = GetComponent<Rigidbody2D>();
        startPos = transform.position;
        attacks[0] = DoNothing;
         attacks[1] = SpawnSaw;
        attacks[2] =ShootLaser;
        attacks[3] = SpawnRocket;
     
    }
   void FixedUpdate()
    {
        time -= Time.fixedDeltaTime;
        Vector3 max = box.bounds.max;
        Vector3 min = box.bounds.min;
        Vector2 corner1 = new Vector2(max.x, min.y - .1f);
        Vector2 corner2 = new Vector2(min.x, min.y - .2f);
        hit = Physics2D.OverlapArea(corner1, corner2);
        bool grounded = false;
        if (grounded && time < 0 && counter != 0)
        {
          
            body.AddForce(jumpV * jumpForse, ForceMode2D.Impulse);
            time = SetTime;
            counter--;
            shooted = false;
        }
    
        if (hit != null)
        {
            anim.SetBool("isJumping", false);
            grounded = true;
         
            if (!shooted && time <= SetTime / 2 && time >= 0)
            {
                 attacks[UnityEngine.Random.Range(0, 4)].Invoke();
              
            }
        }
        else anim.SetBool("isJumping", true);
        if (grounded && time < 0 && counter != 0)
        {

            body.AddForce(jumpV * jumpForse, ForceMode2D.Impulse);
            time = SetTime;
            counter--;
            shooted = false;
        }

        if (counter == 0 && time > 0)
        {
            body.velocity = new Vector2(transform.position.x+0.1f * Time.fixedDeltaTime,
                transform.position.y);
            if (transform.position.x >= endPos.x + 0.7f - box.size.x / 2)
                counter = count;
        }

        if (counter == 1 && grounded && body.transform.GetChild(0).transform.position.y<=
            box.bounds.max.y-0.5f)
        {
            transform.GetComponent<enemy>().canHit = false;
            body.transform.GetChild(0).transform.position =
                new Vector3(transform.position.x, body.transform.GetChild(0).transform.position.y + 2*Time.fixedDeltaTime);
           
        }else if(counter!=1 && body.transform.GetChild(0).transform.position.y >=
            box.bounds.max.y-1.9f)
        {
            body.transform.GetChild(0).transform.position = new Vector3(transform.position.x,
                body.transform.GetChild(0).transform.position.y +(-2) * Time.fixedDeltaTime);
            transform.GetComponent<enemy>().canHit = true;
        }
    }
   
    // Update is called once per frame
    void Update()
    {
    
    }
    void SpawnSaw()
    {
        Instantiate(saw, body.transform.GetChild(1).transform.position, transform.rotation);
        shooted = true;
        
    }
    void SpawnRocket()
    { 
        Instantiate(rocket1, body.transform.GetChild(2).transform.position, transform.rotation);
        shooted = true;
    }
    void ShootLaser()
    {
       
        Instantiate(energy, body.transform.GetChild(3).transform.position,transform.rotation);
        shooted = true;
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(startPos, endPos);
    }
    void DoNothing()
    {

    }
}
