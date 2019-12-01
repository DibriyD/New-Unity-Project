using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocket : MonoBehaviour
{
    [SerializeField] enemy enemy;
    Rigidbody2D body;
    Vector3 target;
    public Transform player;

    float hipot;
    float sin;
    Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();  
        body = GetComponent<Rigidbody2D>();
       
       
            player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector3(player.position.x, player.position.y);
        target = new Vector3(player.position.x, player.position.y);
        hipot = Mathf.Sqrt(Mathf.Pow((transform.position.x - target.x), 2) +
            Mathf.Pow((transform.position.y - target.y), 2));
        sin = (transform.position.y - target.y) / hipot;
        sin *= 90;


    }

    float speed;
  
    // Update is called once per frame
    void FixedUpdate()
    {
        speed += 0.3f * Time.fixedDeltaTime;
        transform.position = Vector2.MoveTowards(transform.position, target, speed);
       
            transform.rotation = Quaternion.Euler(0, 0, sin);
        body.velocity *= speed;
        if (transform.position == target)
        {
            body.GetComponent<CircleCollider2D>().radius = 2.4f;
        }
    }
 void Bang()
    {
        Destroy(gameObject);
    }
    void Update()
    {
      
    }
    void OnCollisionEnter2D(Collision2D col)
    {  
        enemy.EnemyCollision(col);
        StartCoroutine(Wait());
    }
  
    IEnumerator Wait()
    {
        anim.SetBool("Explode", true);
        yield return new WaitForSecondsRealtime(2f);
        Destroy(gameObject);
    }
}
