using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saw : MonoBehaviour
{
    [SerializeField] enemy enemy;
    CircleCollider2D circle;
    [SerializeField] float speed=10;
    float move = 0;
    Vector3 start;
    Rigidbody2D rb;
   public float rotation = 1000;
    
    // Start is called before the first frame update
    void Start()
    {
        circle = GetComponent<CircleCollider2D>();
        start = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }
        // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        move-= speed * Time.fixedDeltaTime;
        rb.rotation+= rotation * Time.fixedDeltaTime;
        circle.transform.position= new Vector3(move+start.x,transform.position.y);
        StartCoroutine(Dest());
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        enemy.EnemyCollision(col);
    }
    IEnumerator Dest()
    {
        yield return new WaitForSecondsRealtime(3);
        Destroy(gameObject);
    }
}
